using System;

namespace LcfSharp.IO.Exceptions
{
    public class LcfInvalidHeaderException : LcfException
    {
        public LcfInvalidHeaderException(string expected, string found)
            : base($"Invalid header detected, expected '{expected}' but found '{found}'.")
        {
        }
    }
}