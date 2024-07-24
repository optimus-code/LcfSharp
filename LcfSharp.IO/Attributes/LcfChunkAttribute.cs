using System;

namespace LcfSharp.IO.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class LcfChunkAttribute(Type enumType): Attribute
    {
        public virtual Type EnumType
        {
            get;
        } = enumType;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class LcfChunkAttribute<TEnum> : LcfChunkAttribute
        where TEnum : Enum
    {
        public LcfChunkAttribute() : base(typeof(TEnum))
        {
        }
    }
}