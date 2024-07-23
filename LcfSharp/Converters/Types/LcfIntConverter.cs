using System;
using System.IO;

namespace LcfSharp.Converters.Types
{
    public class LcfIntConverter : LcfConverter<int>
    {
        public override int Read(BinaryReader reader, Type typeToConvert)
        {
            return ReadCompressedInt(reader);
        }

        public override void Write(BinaryWriter writer, int value)
        {
            WriteCompressedInt(writer, value);
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