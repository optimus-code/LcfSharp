using System.IO;
using System.Reflection;
using System;
using System.Linq;
using LcfSharp.IO.Attributes;
using System.Collections.Generic;
using LcfSharp.IO.Exceptions;
using LcfSharp.IO.Extensions;
using System.Runtime.InteropServices;
using LcfSharp.IO.Types;
using System.Text.RegularExpressions;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfChunkConverter : LcfConverter
    {
        public sealed override Type Type
        {
            get;
            protected set;
        }

        public override bool CanConvert(Type typeToConvert) => typeToConvert == Type;

        private static Dictionary<Type, LcfType> _typeCache = [];
        private static Dictionary<Type, List<LcfProperty>> _propertyCache = [];
        private static Dictionary<string, int> _lengthEvaluations = [];
        class LcfType
        {
            public List<LcfProperty> Properties
            {
                get;
                private set;
            }

            public Type ChunkEnumType
            {
                get;
                private set;
            }

            public LcfProperty IDProperty
            {
                get;
                set;
            }

            public Dictionary<int, LcfProperty> Chunks
            {
                get;
                private set;
            } = [];

            public LcfType(Type type)
            {
                Properties = LcfProperty.Get(type);

                var chunkAttribute = type.GetCustomAttribute<LcfChunkAttribute>();

                if (chunkAttribute == null)
                    throw new LcfException($"Missing LcfChunk attribute on '{type.FullName}.");

                ChunkEnumType = chunkAttribute.ChunkEnumType;
                IDProperty = GetIDProperty();
                MapChunks();
            }

            private void MapChunks()
            {
                foreach (var property in Properties)
                {
                    if (Enum.TryParse(ChunkEnumType, property.Property.Name, out var enumValue))
                    {
                        Chunks[(int)enumValue] = property;
                    }
                }
            }

            private LcfProperty GetIDProperty()
            {
                foreach (var property in Properties)
                {
                    if (property.ID != null)
                    {
                        return property;
                    }
                }
                return null;
            }

            public static LcfType Get(Type type)
            {
                if (!_typeCache.TryGetValue(type, out var lcfType))
                {
                    lcfType = new LcfType(type);
                    _typeCache[type] = lcfType;
                }
                return lcfType;
            }

            public LcfProperty GetPropertyByChunkID(int chunkID)
            {
                Chunks.TryGetValue(chunkID, out var property);
                return property;
            }
        }

        class LcfProperty
        {
            public PropertyInfo Property { get; set; }
            public LcfIDAttribute ID { get; set; }
            public LcfAlwaysPersistAttribute AlwaysPersist { get; set; }
            public LcfSizeAttribute Size { get; set; }
            public LcfVersionAttribute Version { get; set; }

            public bool IsAllowed 
            {
                get;
                private set;
            }

            public bool IsGenericListType
            {
                get;
                private set;
            }

            public Type GenericListInnerType
            {
                get;
                private set;
            }

            public bool IsGenericListBasicType
            {
                get;
                private set;
            }

            public LcfProperty(PropertyInfo property)
            {
                Property = property;
                ID = property.GetCustomAttribute<LcfIDAttribute>();
                AlwaysPersist = property.GetCustomAttribute<LcfAlwaysPersistAttribute>();
                Size = property.GetCustomAttribute<LcfSizeAttribute>();
                Version = property.GetCustomAttribute<LcfVersionAttribute>();
                IsAllowed = CheckIsAllowed();
                IsGenericListType = property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>);

                if (IsGenericListType)
                {
                    GenericListInnerType = property.PropertyType.GetGenericArguments()[0];
                    IsGenericListBasicType = !GenericListInnerType.IsClass && GenericListInnerType.IsPrimitive;
                }
            }

            private bool CheckIsAllowed()
            {
                return (Property != null && Version?.Version == LcfConverterFactory.EngineVersion)
                    || (Version == null && LcfConverterFactory.EngineVersion == LcfEngineVersion.RM2K);
            }

            public static List<LcfProperty> Get(Type type)
            {
                if (!_propertyCache.TryGetValue(type, out var properties))
                {
                    properties = new List<LcfProperty>();
                    foreach (var p in LcfConverterFactory.GetProperties(type))
                    {
                        if (p.GetCustomAttribute<LcfIgnoreAttribute>() == null)
                        {
                            properties.Add(new LcfProperty(p));
                        }
                    }
                    _propertyCache[type] = properties;
                }
                return properties;
            }
        }

        public LcfChunkConverter(Type chunkType)
        {
            Type = chunkType;
        }

        private void ProcessProperty(BinaryReader reader, object obj, PropertyInfo property, int? length)
        {
            var converter = LcfConverterFactory.GetConverter(property.PropertyType);
            if (converter is not null)
            {
                var value = converter.Read(reader, length);
                property.SetValue(obj, value);
            }
            else
            {
                throw new InvalidDataException($"No converter found for type {property.PropertyType}");
            }
        }

        public override object Read(BinaryReader reader, int? length)
        {
            var obj = Activator.CreateInstance(Type);
            var lcfType = LcfType.Get(Type);
            var parsedProperties = new HashSet<string>();

            // If it has an ID property read in that first!
            if (lcfType.IDProperty != null)
            {
                lcfType.IDProperty.Property.SetValue(obj, reader.ReadVarInt());
                parsedProperties.Add(lcfType.IDProperty.Property.Name);
            }

            var properties = lcfType.Properties;
            var chunkEnumType = lcfType.ChunkEnumType;

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var chunkID = reader.ReadVarInt();

                if (chunkID == 0)
                    break;

                var chunkLength = reader.ReadVarInt();

                if (Enum.IsDefined(chunkEnumType, chunkID))
                {
                    LcfProperty match = lcfType.GetPropertyByChunkID(chunkID);

                    if (match != null && match.IsAllowed)
                    {
                        if (parsedProperties.Contains(match.Property.Name))
                            throw new LcfException($"{match.Property.Name} has already been parsed, there's a read error somewhere.");

                        var propertyLength = chunkLength;

                        if (match.IsGenericListType)
                        {
                            if (match.IsGenericListBasicType)
                                propertyLength = chunkLength / Marshal.SizeOf(match.GenericListInnerType);
                        }

                        if (match.Size != null && _lengthEvaluations.ContainsKey(match.Property.Name))
                        {
                            propertyLength = _lengthEvaluations[match.Property.Name];
                            _lengthEvaluations.Remove(match.Property.Name);
                        }
                        ProcessProperty(reader, obj, match.Property, propertyLength);
                        parsedProperties.Add(match.Property.Name);
                    }
                    // If there's a property with a size value dependent on this
                    else if (properties.Count(p => p.Size?.ChunkID == chunkID && p.IsAllowed) > 0)
                    {
                        var propertyTarget = properties.FirstOrDefault(p => p.Size?.ChunkID == chunkID);
                        _lengthEvaluations.Add(propertyTarget.Property.Name, reader.ReadVarInt());
                    }
                    else
                    {
                        Console.WriteLine($"Missing property match for chunk: '0x{chunkID:X}' in '{Type.FullName}'.");

                        reader.BaseStream.Seek(chunkLength, SeekOrigin.Current);
                    }
                }
                else
                {
                    reader.BaseStream.Seek(chunkLength, SeekOrigin.Current);
                }
            }

            var unusedProperties = properties.Where(p => p.IsAllowed
                && !parsedProperties.Contains(p.Property.Name) 
                && p.AlwaysPersist != null
                && p.Property.PropertyType != typeof(DbString))
                    .ToList();

            if (unusedProperties.Any())
            {
                Console.WriteLine($"Unparsed properites in type '{Type.FullName}': {unusedProperties.Count}");
            }

            _lengthEvaluations.Clear();

            return obj;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            throw new NotImplementedException();
        }
    }
}