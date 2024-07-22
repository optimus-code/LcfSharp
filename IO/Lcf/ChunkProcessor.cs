namespace LcfSharp.IO.Lcf
{
    using LcfSharp.IO.Lcf.Attributes;
    using LcfSharp.Rpg.Shared;
    using LcfSharp.Types;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.PortableExecutable;

    public class ChunkProcessor
    {

        private static readonly ReadOnlyDictionary<Type, Func<LcfReader, Chunk, object>> TYPE_READERS =
            new ReadOnlyDictionary<Type, Func<LcfReader, Chunk, object>>(
                new Dictionary<Type, Func<LcfReader, Chunk, object>>
                {
                { typeof(byte), (r,c) => r.ReadByte() },
                { typeof(bool), (r,c) => r.ReadBool() },
                { typeof(short), (r,c) => r.ReadShort() },
                { typeof(int), (r,c) => r.ReadInt() },
                { typeof(string), (r,c) => r.ReadString(c.Length) },
                { typeof(DbString), (r,c) => r.ReadDbString(c.Length) },

                // List Types                
                { typeof(List<byte>), (r,c) => r.ReadByteList(c.Length) },
                { typeof(List<bool>), (r,c) => r.ReadBoolList(c.Length) },
                { typeof(List<short>), (r,c) => r.ReadShortList(c.Length) },
                { typeof(List<int>), (r,c) => r.ReadIntList(c.Length) },

                // Complex Types                
                { typeof(Parameters), (r,c) => new Parameters(r, c.Length / 2) },
                }
            );

        public static ReadOnlyDictionary<Type, List<LcfFieldInfo>> TYPE_FIELDS;
        public static ReadOnlyDictionary<Type, Type> TYPE_ENUMS;

        static ChunkProcessor()
        {
            var typeFieldMap = new Dictionary<Type, List<LcfFieldInfo>>();
            var typeEnumMap = new Dictionary<Type, Type>();

            // Get all types in the current assembly
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types)
            {
                var propertiesWithAttributes = type.GetProperties()
                    .Select(prop => new
                    {
                        Property = prop,
                        Attribute = (LcfFieldAttributeBase)prop.GetCustomAttributes(true)?.FirstOrDefault(a => a is LcfFieldAttributeBase)
                    })
                    .Where(x => x.Attribute != null)
                    .ToList();

                if (propertiesWithAttributes.Count > 0)
                {
                    typeFieldMap[type] = propertiesWithAttributes
                        .Select(x => new LcfFieldInfo(x.Property, x.Attribute))
                        .ToList();

                    var enumType = propertiesWithAttributes
                        .Select(p => p.Attribute.ChunkEnumType)
                        .First();

                    if (!typeEnumMap.ContainsKey(type))
                        typeEnumMap.Add(type, enumType);
                }
            }

            TYPE_FIELDS = new ReadOnlyDictionary<Type, List<LcfFieldInfo>>(typeFieldMap);
            TYPE_ENUMS = new ReadOnlyDictionary<Type, Type>(typeEnumMap);
        }

        public static void ReadRootLcf<TEnum>(object instance, LcfReader reader)
        {

        }

        private static void ReadListLcf(Type itemType, LcfReader reader)
        {
            var count = reader.ReadInt();

            for (var i = 0; i < count; i++)
            {
                var id = reader.ReadInt();
                var instance = Activator.CreateInstance(itemType);
                ReadLcf(instance, reader);
            }
        }

        public static void ReadLcf(object instance, LcfReader reader)
        {
            var instanceType = instance.GetType();

            if (!TYPE_ENUMS.ContainsKey(enumType))
                throw new Exception("Type has no LcfField Attributes!");

            var enumType = TYPE_ENUMS[instanceType];
            var sizeDependentChunksValues = new Dictionary<int, int>();

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var chunk = new Chunk { ID = reader.ReadInt() };

                if (chunk.ID == 0)
                    break;

                chunk.Length = reader.ReadInt();

                if (Enum.IsDefined(enumType, chunk.ID))
                {
                    long startPosition = reader.BaseStream.Position;

                    var matchingField = TYPE_FIELDS[instanceType]
                        .FirstOrDefault(f => f.Attribute?.ChunkID == chunk.ID ||
                        f.Attribute?.SizeChunkID.HasValue == true &&
                        f.Attribute.SizeChunkID == chunk.ID);

                    if (matchingField != null)
                    {
                        var hasSizeChunk = matchingField.Attribute.SizeChunkID.HasValue;

                        // If it's actually a size chunk ensure the value gets stored for later
                        if (hasSizeChunk
                            && matchingField.Attribute.SizeChunkID.Value == chunk.ID)
                        {
                            sizeDependentChunksValues.Add(matchingField.Attribute.ChunkID, reader.ReadInt());
                        }
                        else
                        {
                            var propertyType = matchingField.Property.PropertyType;

                            // If we have a size chunk it's usually a list or a DbBitArray
                            if (hasSizeChunk)
                            {
                                // If we have a size for the chunk
                                if (sizeDependentChunksValues.ContainsKey(chunk.ID))
                                {
                                    var propertySize = sizeDependentChunksValues[chunk.ID];

                                    if (propertyType == typeof(DbBitArray))
                                    {
                                        matchingField.Property.SetValue(instance,
                                            reader.ReadBitArray(propertySize));
                                    }
                                    // Need to handle complex types
                                    else
                                    {

                                    }
                                }
                                // Else we need to warn
                                else
                                {

                                }
                            }
                            else
                            {
                                if (propertyType.IsAssignableTo(typeof(DbFlags)))
                                {
                                    matchingField.Property.SetValue(instance,
                                        DbFlags.Read(reader, propertyType));
                                }
                                else if (TYPE_READERS.ContainsKey(propertyType))
                                {
                                    var typeReader = TYPE_READERS[propertyType];

                                    if (typeReader != null)
                                    {
                                        matchingField.Property.SetValue(instance,
                                            typeReader.Invoke(reader, chunk));
                                    }
                                }
                                else if (propertyType.IsArray)
                                {

                                }
                                else if (propertyType.IsGenericType &&
                                    propertyType.GetGenericTypeDefinition() == typeof(List<>))
                                {

                                }
                            }
                        }
                    }

                    long bytesRead = reader.BaseStream.Position - startPosition;
                    if (bytesRead != chunkLength)
                    {
                        Console.WriteLine($"Warning: Corrupted Chunk 0x{chunkId:X} (expected size: {chunkLength}, read: {bytesRead})");
                        reader.BaseStream.Seek(startPosition + chunkLength, SeekOrigin.Begin);
                    }
                }
                else
                {
                    reader.BaseStream.Seek(chunkLength, SeekOrigin.Current);
                }
            }
        }

        private static void ReadBoolean(LcfReader reader, object instance, PropertyInfo property)
        {
            property.SetValue(instance, reader.ReadBool());
        }

        private static void ReadInt16(LcfReader reader, object instance, PropertyInfo property)
        {
            property.SetValue(instance, reader.ReadShort());
        }

        private static void ReadInt32(LcfReader reader, object instance, PropertyInfo property)
        {
            property.SetValue(instance, reader.ReadInt32());
        }

        private static void ReadVarInt(LcfReader reader, object instance, PropertyInfo property)
        {
            property.SetValue(instance, reader.ReadInt());
        }
    }
}
