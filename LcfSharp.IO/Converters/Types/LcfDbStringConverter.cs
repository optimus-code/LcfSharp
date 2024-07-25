using LcfSharp.IO.Extensions;
using LcfSharp.IO.Types;
using System;
using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfDbStringConverter : LcfConverter<DbString>
    {
        public override object Read(BinaryReader reader, int? length)
        {
            if (length.HasValue && length.Value == 0)
                return new DbString();

            var count = length.HasValue ? length.Value : reader.ReadVarInt();
            return reader.ReadDbString(count);
        }

        public override void Write(BinaryWriter writer, object value)
        {
            throw new NotImplementedException();
        }
    }
}