using System;
using System.IO;
using System.Text;

namespace LcfSharp.Converters.Types
{
    public class LcfStringConverter : LcfConverter<string>
    {
        public override string? Read(BinaryReader reader, Type typeToConvert)
        {
            int length = reader.ReadInt32();
            return Encoding.UTF8.GetString(reader.ReadBytes(length));
        }

        public override void Write(BinaryWriter writer, string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            writer.Write(bytes.Length);
            writer.Write(bytes);
        }
    }
}
