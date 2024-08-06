namespace LcfSharp.IO.Types
{
    public struct Rectangle
    {
        public uint Left
        {
            get;
            set;
        }

        public uint Top
        {
            get;
            set;
        }

        public uint Right
        {
            get;
            set;
        }

        public uint Bottom
        {
            get;
            set;
        }

        public Rectangle(uint left, uint top, uint right, uint bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}
