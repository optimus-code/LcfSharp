
using System.Collections.Generic;
using System;

namespace LcfSharp.Audio
{
    public class Sound
    {
        public string Name
        { 
            get;
            set; 
        } = "(OFF)";

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

        public override bool Equals( object obj )
        {
            return obj is Sound sound &&
                   Name == sound.Name &&
                   Volume == sound.Volume &&
                   Tempo == sound.Tempo &&
                   Balance == sound.Balance;
        }

        public override int GetHashCode( )
        {
            return HashCode.Combine( Name, Volume, Tempo, Balance );
        }

        public override string ToString( )
        {
            return $"{nameof( Name )}: {Name}, {nameof( Volume )}: {Volume}, {nameof( Tempo )}: {Tempo}, {nameof( Balance )}: {Balance}";
        }

        public static bool operator ==( Sound left, Sound right )
        {
            return EqualityComparer<Sound>.Default.Equals( left, right );
        }

        public static bool operator !=( Sound left, Sound right )
        {
            return !( left == right );
        }
    }
}
