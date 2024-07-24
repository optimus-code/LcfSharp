using System;

namespace LcfSharp.IO.Converters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = false)]
    public class LcfConverterAttribute : Attribute
    {
        public LcfConverterAttribute(Type converterType)
        {
            ConverterType = converterType;
        }

        public Type ConverterType { get; }

        public virtual LcfConverter CreateConverter(Type typeToConvert)
        {
            return (LcfConverter)Activator.CreateInstance(ConverterType);
        }
    }
}
