using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfInt16Converter : LcfConverter<short>
    {
        public override object Read(BinaryReader reader, int? length)
        {
            return reader.ReadInt16();
        }

        public override void Write(BinaryWriter writer, object value)
        {
            writer.Write((short)value);
        }
    }
}