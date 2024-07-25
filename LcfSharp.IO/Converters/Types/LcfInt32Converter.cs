using LcfSharp.IO.Extensions;
using System;
using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfInt32Converter : LcfConverter<int>
    {
        public override object Read(BinaryReader reader, int? length)
        {
            return reader.ReadVarInt();
        }

        public override void Write(BinaryWriter writer, object value)
        {
            throw new NotImplementedException();
        }
    }
}