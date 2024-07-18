using System;

namespace LcfSharp.Actors
{
    public class Learning
    {
        public int ID
        {
            get;
            set;
        } = 0;

        public int Level
        {
            get;
            set;
        } = 1;

        public int SkillID
        {
            get;
            set;
        } = 1;

        public static bool operator ==(Learning left, Learning right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.Level == right.Level && left.SkillID == right.SkillID;
        }

        public static bool operator !=(Learning left, Learning right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is Learning other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Level, SkillID);
        }

        public override string ToString()
        {
            return $"ID: {ID}, Level: {Level}, SkillID: {SkillID}";
        }
    }
}
