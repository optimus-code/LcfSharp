using System;

namespace LcfSharp.IO.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class LcfChunkAttribute(Type chunkEnumType) : Attribute
    {
        public Type ChunkEnumType
        {
            get;
            protected set;
        } = chunkEnumType;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class LcfChunkAttribute<TEnum> : LcfChunkAttribute
    {
        public LcfChunkAttribute() 
            : base(typeof(TEnum))
        {
        }
    }
}