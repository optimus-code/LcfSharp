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
using System.Diagnostics;

namespace LcfSharp.IO.Converters
{
    public class LcfChunkConverter : LcfConverter
    {
        public sealed override Type Type
        {
            get;
            protected set;
        }

        public override bool CanConvert(Type typeToConvert) => typeToConvert == Type;

        private Dictionary<string, int> _lengthEvaluations = [];  

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

            if (Type.Name == "Troop")
            {
            }
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var chunkID = reader.ReadVarInt();

                //if (chunkID > 90)
                //    throw new Exception();

                if (chunkID == 0)
                    break;

                var chunkLength = reader.ReadVarInt();

                if (Type.Name == "TroopPage")
                {
                }
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
                    else if (lcfType.SizeChunks.TryGetValue(chunkID, out var targetProperty))
                    {
                        _lengthEvaluations.Add(targetProperty.Property.Name, reader.ReadVarInt());
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

            var unusedProperties = lcfType.Chunks.Values
                .Where(p => !parsedProperties.Contains(p.Property.Name) &&
                    p.AlwaysPersist != null &&
                    p.Property.PropertyType != typeof(string))
                .ToList();

            if (unusedProperties.Any())
                Debug.WriteLine($"Unparsed properites in type '{Type.FullName}': {unusedProperties.Count}");

            _lengthEvaluations.Clear();

            if (Type.Name == "TroopPage")
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