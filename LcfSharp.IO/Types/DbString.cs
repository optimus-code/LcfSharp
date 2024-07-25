namespace LcfSharp.IO.Types
{
    public struct DbString
    {
        public string Value 
        { 
            get;
            set;
        }

        public static implicit operator DbString(string value)
        {
            return new DbString
            {
                Value = value
            };
        }
    }
}