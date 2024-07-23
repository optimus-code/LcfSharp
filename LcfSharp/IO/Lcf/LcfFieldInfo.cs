using LcfSharp.IO.Lcf.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LcfSharp.IO.Lcf
{
    public class LcfFieldInfo
    {
        public PropertyInfo Property { get; }
        public LcfFieldAttributeBase Attribute { get; }

        public LcfFieldInfo(PropertyInfo property, LcfFieldAttributeBase attribute)
        {
            Property = property;
            Attribute = attribute;
        }
    }
}
