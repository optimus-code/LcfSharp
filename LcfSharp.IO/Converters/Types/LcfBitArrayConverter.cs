using System.Collections;
using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfBitArrayConverter : LcfConverter<BitArray>
    {
        public override object Read(BinaryReader reader, int? length)
        {
            var buffer = new BitArray(length.Value);

            for (var i = 0; i < length.Value; i++)
            {
                var val = reader.ReadByte();
                buffer[i] = val != 0;
            }
            return buffer;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            var buffer = (BitArray)value;

            for (var i = 0; i < buffer.Length; i++)
            {
                writer.Write((byte)(buffer[i] ? 1 : 0));
            }
        }
    }
}