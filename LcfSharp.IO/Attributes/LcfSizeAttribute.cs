using System;

namespace LcfSharp.IO.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LcfSizeAttribute(int chunkID) : Attribute
    {
        public int ChunkID
        {
            get;
        } = chunkID;
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LcfSizeAttribute<TEnum> : LcfSizeAttribute
        where TEnum : Enum
    {
        public LcfSizeAttribute(TEnum chunkID)
            : base(Convert.ToInt32(chunkID))
        {
        }
    }
}