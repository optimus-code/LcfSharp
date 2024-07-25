using System;

namespace LcfSharp.IO.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LcfAlwaysPersistAttribute : Attribute
    {
    }
}