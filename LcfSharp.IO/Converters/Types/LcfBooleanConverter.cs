using LcfSharp.IO.Extensions;
using System;
using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfBooleanConverter : LcfConverter<bool>
    {
        public override object Read(BinaryReader reader, int? length)
        {
            return reader.ReadVarInt() > 0;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            throw new NotImplementedException();
        }
    }
}