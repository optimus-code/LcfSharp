using System;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Shared
{
    public class Rect
    {
        public uint L
        {
            get;
            set;
        }

        public uint T
        {
            get;
            set;
        }

        public uint R
        {
            get;
            set;
        }

        public uint B
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (obj is Rect other)
            {
                return L == other.L &&
                       T == other.T &&
                       R == other.R &&
                       B == other.B;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(L, T, R, B);
        }

        public override string ToString()
        {
            return $"Rect [L={L}, T={T}, R={R}, B={B}]";
        }

        public static bool operator ==(Rect left, Rect right)
        {
            return EqualityComparer<Rect>.Default.Equals(left, right);
        }

        public static bool operator !=(Rect left, Rect right)
        {
            return !(left == right);
        }
    }
}