using System;

namespace LcfSharp.IO.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LcfFieldAttribute(int chunkID) : Attribute
    {
        public int ChunkID
        {
            get;
        } = chunkID;
    }
}