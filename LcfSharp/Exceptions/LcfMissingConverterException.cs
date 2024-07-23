using System;

namespace LcfSharp.Exceptions
{
    public class LcfMissingConverterException : LcfException
    {
        public LcfMissingConverterException(Type type) 
            : base($"Missing LcfConverter for type '{type.FullName}'.")
        {
        }
    }
}
