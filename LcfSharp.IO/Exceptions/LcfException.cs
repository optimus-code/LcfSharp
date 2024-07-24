using System;

namespace LcfSharp.IO.Exceptions
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
