using System.IO;
using System.Reflection;
using System;
using System.Linq;
using LcfSharp.IO.Attributes;
using System.Collections.Generic;

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

        private void ProcessProperty(BinaryReader reader, object obj, PropertyInfo property, int length)
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
                .Where(p => p.GetCustomAttribute<LcfFieldAttribute>() != null)
                .ToDictionary(p => p.GetCustomAttribute<LcfFieldAttribute>().ChunkID, p => p);

            var lengthEvaluations = new Dictionary<int, int>();

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var chunkID = reader.Read7BitEncodedInt();

                if (chunkID == 0)
                    break;

                var chunkLength = reader.Read7BitEncodedInt();

                if (properties.TryGetValue(chunkID, out var property))
                {
                    var propertyLength = chunkLength;
                    var sizeAttribute = property.PropertyType.GetCustomAttribute<LcfSizeAttribute>();
                    if (sizeAttribute != null && lengthEvaluations.ContainsKey(chunkID))
                    {
                        propertyLength = lengthEvaluations[chunkID];
                        lengthEvaluations.Remove(chunkID);
                    }
                    ProcessProperty(reader, obj, property, propertyLength);
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