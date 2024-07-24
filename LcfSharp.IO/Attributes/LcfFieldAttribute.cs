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
}