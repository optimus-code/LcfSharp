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
                set;
            }

            public LcfProperty(PropertyInfo property)
            {
                Property = property;
                ID = property.GetCustomAttribute<LcfIDAttribute>();
                AlwaysPersist = property.GetCustomAttribute<LcfAlwaysPersistAttribute>();
                Size = property.GetCustomAttribute<LcfSizeAttribute>();
                Version = property.GetCustomAttribute<LcfVersionAttribute>();
                IsAllowed = CheckIsAllowed();
            }

            private bool CheckIsAllowed()
            {
                return (Property != null && Version?.Version == LcfConverterFactory.EngineVersion)
                    || (Version == null && LcfConverterFactory.EngineVersion == LcfEngineVersion.RM2K);

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
            var properties = LcfConverterFactory.GetProperties(Type)
                .Where(p => p.GetCustomAttribute<LcfIgnoreAttribute>() == null)
                .Select(p => new LcfProperty(p))
                .ToList();

            var chunkAttribute = Type.GetCustomAttribute<LcfChunkAttribute>();

            if (chunkAttribute == null)
                throw new LcfException($"Missing LcfChunk attribute on '{Type.FullName}.");

            var chunkEnumType = chunkAttribute.ChunkEnumType;
            var lengthEvaluations = new Dictionary<string, int>();

            var idProperty = properties.FirstOrDefault(p => p.ID != null);

            var parsedProperties = new HashSet<string>();

            // If it has an ID property read in that first!
            if (idProperty != null)
            {
                idProperty.Property.SetValue(obj, reader.ReadVarInt());
                parsedProperties.Add(idProperty.Property.Name);
            }

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var chunkID = reader.ReadVarInt();

                if (chunkID == 0)
                    break;

                var chunkLength = reader.ReadVarInt();

                if (Enum.IsDefined(chunkEnumType, chunkID))
                {
                    LcfProperty match = null;
                    foreach ( var property in properties)
                    {
                        if (Enum.TryParse(chunkEnumType, property.Property.Name, out var enumValue) &&
                            (int)enumValue == chunkID)
                        {
                            match = property;
                            break;
                        }
                    }

                    if (match != null && match.IsAllowed)
                    {
                        if (parsedProperties.Contains(match.Property.Name))
                            throw new LcfException($"{match.Property.Name} has already been parsed, there's a read error somewhere.");

                        var propertyLength = chunkLength;

                        if (match.Property.PropertyType.IsGenericType && match.Property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            var innerType = match.Property.PropertyType.GetGenericArguments()[0];
                            var isBasicType = !innerType.IsClass && innerType.IsPrimitive;

                            if (isBasicType)
                                propertyLength = chunkLength / Marshal.SizeOf(innerType);
                        }

                        if (match.Size != null && lengthEvaluations.ContainsKey(match.Property.Name))
                        {
                            propertyLength = lengthEvaluations[match.Property.Name];
                            lengthEvaluations.Remove(match.Property.Name);
                        }
                        ProcessProperty(reader, obj, match.Property, propertyLength);
                        parsedProperties.Add(match.Property.Name);
                    }
                    // If there's a property with a size value dependent on this
                    else if (properties.Count(p => p.Size?.ChunkID == chunkID && p.IsAllowed) > 0)
                    {
                        var propertyTarget = properties.FirstOrDefault(p => p.Size?.ChunkID == chunkID);
                        lengthEvaluations.Add(propertyTarget.Property.Name, reader.ReadVarInt());
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
            return obj;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            throw new NotImplementedException();
        }
    }
}