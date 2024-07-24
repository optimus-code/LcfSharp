using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfBooleanConverter : LcfConverter<bool>
    {
        public override object Read(BinaryReader reader, int? length)
        {
            return reader.Read7BitEncodedInt() > 0;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            var booleanValue = (bool)value;
            writer.Write7BitEncodedInt(booleanValue ? 1 : 0);
        }
    }
}