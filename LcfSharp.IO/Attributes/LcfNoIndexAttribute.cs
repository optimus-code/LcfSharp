using System;

namespace LcfSharp.IO.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class LcfNoIndexAttribute : Attribute
    {
    }
}