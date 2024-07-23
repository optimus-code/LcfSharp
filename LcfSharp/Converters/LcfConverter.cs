using System;
using System.IO;

namespace LcfSharp.Converters
{
    public abstract class LcfConverter
    {
        internal LcfConverter() { }
        public abstract Type Type { get; }
        public abstract bool CanConvert(Type typeToConvert);
    }

    public abstract class LcfConverter<T> : LcfConverter
    {
        protected internal LcfConverter() { }
        public sealed override Type Type => typeof(T);
        public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(T);
        public abstract T Read(BinaryReader reader, Type typeToConvert);
        public abstract void Write(BinaryWriter writer, T value);
    }
}
