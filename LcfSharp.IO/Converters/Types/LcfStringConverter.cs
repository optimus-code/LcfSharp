using LcfSharp.IO.Extensions;
using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfStringConverter : LcfConverter<string>
    {
        public override object Read(BinaryReader reader, int? length)
        {
            if ( length.HasValue && length.Value == 0 )
                return null;

            var count = length.HasValue ? length.Value : reader.ReadVarInt();
            return reader.ReadString(count);
        }

        public override void Write(BinaryWriter writer, object value)
        {
            var stringValue = (string)value;
            writer.Write7BitEncodedInt(stringValue.Length);
            writer.WriteString(stringValue);
        }
    }
}
