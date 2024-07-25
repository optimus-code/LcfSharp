using System;

namespace LcfSharp.IO.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LcfVersionAttribute(LcfEngineVersion version = LcfEngineVersion.RM2K) : Attribute
    {
        public LcfEngineVersion Version
        {
            get;
        } = version;
    }
}
