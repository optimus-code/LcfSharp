using System.IO;
using System.Reflection;
using System;
using System.Linq;
using LcfSharp.IO.Attributes;
using System.Collections.Generic;
using LcfSharp.IO.Exceptions;
using LcfSharp.IO.Extensions;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

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

        private bool IsAllowed(PropertyInfo property)
        {
            var versionAttribute = property.GetCustomAttribute<LcfVersionAttribute>();

            return (property != null && versionAttribute?.Version == LcfConverterFactory.EngineVersion)
                || (versionAttribute == null && LcfConverterFactory.EngineVersion == LcfEngineVersion.RM2K);

        }

        public override object Read(BinaryReader reader, int? length)
        {
            var obj = Activator.CreateInstance(Type);
            var properties = Type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute<LcfIgnoreAttribute>() == null)
                .ToDictionary(p => p.Name, p => p);

            var chunkAttribute = Type.GetCustomAttribute<LcfChunkAttribute>();

            if (chunkAttribute == null)
                throw new LcfException($"Missing LcfChunk attribute on '{Type.FullName}.");

            var chunkEnumType = chunkAttribute.ChunkEnumType;
            var lengthEvaluations = new Dictionary<string, int>();

            var idProperty = properties.Values.FirstOrDefault(p => p.GetCustomAttribute<LcfIDAttribute>() != null);

            var parsedProperties = new HashSet<string>();

            // If it has an ID property read in that first!
            if (idProperty != null)
            {
                idProperty.SetValue(obj, reader.ReadVarInt());
                parsedProperties.Add(idProperty.Name);
            }

            if (Type.Name == "Chipset")
            {

            }
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var chunkID = reader.ReadVarInt();

                if (chunkID == 0)
                    break;

                var chunkLength = reader.ReadVarInt();

                if (Type.Name == "Chipset")
                {

                }
                if (Enum.IsDefined(chunkEnumType, chunkID))
                {
                    PropertyInfo match = null;
                    foreach ( var property in properties.Values)
                    {
                        if (Enum.TryParse(chunkEnumType, property.Name, out var enumValue) &&
                            (int)enumValue == chunkID)
                        {
                            match = property;
                            break;
                        }
                    }
                     
                    if (match != null && IsAllowed(match))
                    {
                        if (parsedProperties.Contains(match.Name))
                            throw new LcfException($"{match.Name} has already been parsed, there's a read error somewhere.");

                        var propertyLength = chunkLength;

                        if (match.PropertyType.IsGenericType && match.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            var innerType = match.PropertyType.GetGenericArguments()[0];
                            var isBasicType = !innerType.IsClass && innerType.IsPrimitive;

                            if (isBasicType)
                                propertyLength = chunkLength / Marshal.SizeOf(innerType);
                        }
                        var sizeAttribute = match.GetCustomAttribute<LcfSizeAttribute>();
                        if (sizeAttribute != null && lengthEvaluations.ContainsKey(match.Name))
                        {
                            propertyLength = lengthEvaluations[match.Name];
                            lengthEvaluations.Remove(match.Name);
                        }
                        ProcessProperty(reader, obj, match, propertyLength);
                        parsedProperties.Add(match.Name);
                    }
                    // If there's a property with a size value dependent on this
                    else if (properties.Count(p => p.Value.GetCustomAttribute<LcfSizeAttribute>()?.ChunkID == chunkID && IsAllowed(p.Value)) > 0)
                    {
                        var propertyTarget = properties.FirstOrDefault(p => p.Value.GetCustomAttribute<LcfSizeAttribute>()?.ChunkID == chunkID);
                        lengthEvaluations.Add(propertyTarget.Key, reader.ReadVarInt());
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

            var unusedProperties = properties.Values.Where(p => !parsedProperties.Contains(p.Name) && p.GetCustomAttribute<LcfAlwaysPersistAttribute>() != null)
                .ToList();

            if (unusedProperties.Any())
            {
                Console.WriteLine($"Unparsed properites: {unusedProperties.Count}");
            }
            if (Type.Name == "Chipset")
            {

            }
            return obj;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            throw new NotImplementedException();
        }
    }
}