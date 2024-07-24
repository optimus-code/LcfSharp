using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfByteConverter : LcfConverter<byte>
    {
        public override object Read(BinaryReader reader, int? length)
        {
            return reader.ReadByte();
        }

        public override void Write(BinaryWriter writer, object value)
        {
            writer.Write((byte)value);
        }
    }
}