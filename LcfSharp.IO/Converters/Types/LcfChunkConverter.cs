using System.IO;
using System.Reflection;
using System;
using System.Linq;
using LcfSharp.IO.Attributes;
using System.Collections.Generic;
using LcfSharp.IO.Exceptions;

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

            var idProperty = properties.Values.FirstOrDefault(p => p.PropertyType.GetCustomAttribute<LcfIDAttribute>() != null);

            // If it has an ID property read in that first!
            if (idProperty != null)
                idProperty.SetValue(obj, reader.Read7BitEncodedInt());

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var chunkID = reader.Read7BitEncodedInt();

                if (chunkID == 0)
                    break;

                var chunkLength = reader.Read7BitEncodedInt();

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

                    if (match != null)
                    {
                        var propertyLength = chunkLength;
                        var sizeAttribute = match.PropertyType.GetCustomAttribute<LcfSizeAttribute>();
                        if (sizeAttribute != null && lengthEvaluations.ContainsKey(match.Name))
                        {
                            propertyLength = lengthEvaluations[match.Name];
                            lengthEvaluations.Remove(match.Name);
                        }
                        ProcessProperty(reader, obj, match, propertyLength);
                    }
                    else
                        throw new LcfException($"Missing property match for chunk: '{chunkID}' in '{Type.FullName}'.");
                }
                // If there's a property with a size value dependent on this
                else if (properties.Count(p => p.Value.PropertyType.GetCustomAttribute<LcfSizeAttribute>()?.ChunkID == chunkID) > 0)
                {
                    var propertyTarget = properties.FirstOrDefault(p => p.Value.PropertyType.GetCustomAttribute<LcfSizeAttribute>()?.ChunkID == chunkID);
                    lengthEvaluations.Add(propertyTarget.Key, reader.Read7BitEncodedInt());
                }
                else
                {
                    // Skip unrecognized chunk until the next 0 byte separator
                    reader.BaseStream.Seek(chunkLength, SeekOrigin.Current);
                }
            }

            return obj;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            writer.Write((byte)value);
        }
    }
}