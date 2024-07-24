using System;
using System.IO;

namespace LcfSharp.IO.Converters
{
    public abstract class LcfConverter
    {
        internal LcfConverter() { }
        public abstract Type Type { get; protected set; }
        public abstract bool CanConvert(Type typeToConvert);
        public abstract object Read(BinaryReader reader, int? length);
        public abstract void Write(BinaryWriter writer, object value);
    }

    public abstract class LcfConverter<T> : LcfConverter
    {
        protected internal LcfConverter() { }
        public sealed override Type Type
        {
            get;
            protected set;
        } = typeof(T);

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(T);
        }
    }
}
