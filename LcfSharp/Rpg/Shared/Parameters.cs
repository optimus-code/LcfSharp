using System.Collections.Generic;
using System.Linq;
using System;
using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg.Shared
{
    [LcfListCollection]
    public class Parameters
    {
        public List<short> MaxHP { get; set; } = new List<short>();
        public List<short> MaxSP { get; set; } = new List<short>();
        public List<short> Attack { get; set; } = new List<short>();
        public List<short> Defense { get; set; } = new List<short>();
        public List<short> Spirit { get; set; } = new List<short>();
        public List<short> Agility { get; set; } = new List<short>();

        public void Setup(int finalLevel)
        {
            int level = Math.Max(finalLevel, 0);
            ResizeList(MaxHP, level, 1);
            ResizeList(MaxSP, level, 0);
            ResizeList(Attack, level, 1);
            ResizeList(Defense, level, 1);
            ResizeList(Spirit, level, 1);
            ResizeList(Agility, level, 1);
        }

        private void ResizeList(List<short> list, int size, short defaultValue)
        {
            if (list.Count < size)
            {
                int addCount = size - list.Count;
                list.AddRange(Enumerable.Repeat(defaultValue, addCount));
            }
        }

        public static bool operator ==(Parameters left, Parameters right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.MaxHP.SequenceEqual(right.MaxHP) &&
                   left.MaxSP.SequenceEqual(right.MaxSP) &&
                   left.Attack.SequenceEqual(right.Attack) &&
                   left.Defense.SequenceEqual(right.Defense) &&
                   left.Spirit.SequenceEqual(right.Spirit) &&
                   left.Agility.SequenceEqual(right.Agility);
        }

        public static bool operator !=(Parameters left, Parameters right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is Parameters other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                MaxHP, MaxSP, Attack, Defense, Spirit, Agility);
        }

        public override string ToString()
        {
            return $"MaxHP: {string.Join(", ", MaxHP)}, " +
                   $"MaxSP: {string.Join(", ", MaxSP)}, " +
                   $"Attack: {string.Join(", ", Attack)}, " +
                   $"Defense: {string.Join(", ", Defense)}, " +
                   $"Spirit: {string.Join(", ", Spirit)}, " +
                   $"Agility: {string.Join(", ", Agility)}";
        }
    }
}
