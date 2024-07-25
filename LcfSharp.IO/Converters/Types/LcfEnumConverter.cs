using LcfSharp.IO.Extensions;
using System;
using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfEnumConverter : LcfConverter
    {
        public sealed override Type Type
        {
            get;
            protected set;
        }

        public override bool CanConvert(Type typeToConvert) => typeToConvert == Type;

        public LcfEnumConverter(Type enumType)
        {
            Type = enumType;
        }

        public override object Read(BinaryReader reader, int? length)
        {
            return Enum.ToObject(Type, reader.ReadVarInt());
        }

        public override void Write(BinaryWriter writer, object value)
        {
            throw new NotImplementedException();
        }
    }
}