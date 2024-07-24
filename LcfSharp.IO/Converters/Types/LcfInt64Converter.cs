using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfInt64Converter : LcfConverter<long>
    {
        public override object Read(BinaryReader reader, int? length)
        {
            return reader.Read7BitEncodedInt64();
        }

        public override void Write(BinaryWriter writer, object value)
        {
            writer.Write7BitEncodedInt64((long)value);
        }
    }
}