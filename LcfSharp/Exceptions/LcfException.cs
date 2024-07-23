using System;

namespace LcfSharp.Exceptions
{
    public class LcfException : Exception
    {
        public LcfException() 
        {
        }

        public LcfException(string error)
            : base(error)
        {
        }
    }
}
