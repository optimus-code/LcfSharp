using System;
using System.Collections.Generic;
using System.IO;

namespace LcfSharp.Converters.Types
{
    public class LcfListConverter<T> : LcfConverter<List<T>>
    {
        private readonly LcfConverter<T> _elementConverter;

        public LcfListConverter()
        {
            _elementConverter = (LcfConverter<T>)LcfConverterFactory.GetConverter(typeof(T));
        }

        public override List<T> Read(BinaryReader reader, Type typeToConvert)
        {
            int count = ReadCompressedInt(reader);
            var list = new List<T>(count);
            for (int i = 0; i < count; i++)
            {
                list.Add(_elementConverter.Read(reader, typeof(T))!);
            }
            return list;
        }

        public override void Write(BinaryWriter writer, List<T> value)
        {
            WriteCompressedInt(writer, value.Count);
            foreach (var item in value)
            {
                _elementConverter.Write(writer, item);
            }
        }

        private int ReadCompressedInt(BinaryReader reader)
        {
            int value = 0;
            int shift = 0;
            byte b;
            do
            {
                b = reader.ReadByte();
                value |= (b & 0x7F) << shift;
                shift += 7;
            } while ((b & 0x80) != 0);
            return value;
        }

        private void WriteCompressedInt(BinaryWriter writer, int value)
        {
            while (value >= 0x80)
            {
                writer.Write((byte)(value | 0x80));
                value >>= 7;
            }
            writer.Write((byte)value);
        }
    }

}
