using System;

namespace LcfSharp.IO.Exceptions
{
    public class LcfMissingConverterException : LcfException
    {
        public LcfMissingConverterException(Type type) 
            : base($"Missing LcfConverter for type '{type.FullName}'.")
        {
        }
    }
}