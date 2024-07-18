using LcfSharp.Types;
using System;

namespace LcfSharp.Rpg.Audio
{
    public class Music
    {
        public DbString Name
        {
            get;
            set;
        } = "(OFF)";

        public int Fadein
        {
            get;
            set;
        } = 0;

        public int Volume
        {
            get;
            set;
        } = 100;

        public int Tempo
        {
            get;
            set;
        } = 100;

        public int Balance
        {
            get;
            set;
        } = 50;

        public override bool Equals(object obj)
        {
            if (obj is Music music)
            {
                return Name == music.Name &&
                       Fadein == music.Fadein &&
                       Volume == music.Volume &&
                       Tempo == music.Tempo &&
                       Balance == music.Balance;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Fadein, Volume, Tempo, Balance);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Fadein: {Fadein}, Volume: {Volume}, Tempo: {Tempo}, Balance: {Balance}";
        }

        public static bool operator ==(Music left, Music right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Music left, Music right)
        {
            return !Equals(left, right);
        }
    }
}
