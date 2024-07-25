using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;

namespace LcfSharp.Rpg.Audio
{
    public enum SoundChunk : int
    {
        /** String */
        Name = 0x01,
        /** Integer */
        Volume = 0x03,
        /** Integer */
        Tempo = 0x04,
        /** Integer */
        Balance = 0x05
    }

    [LcfChunk<SoundChunk>]
    public class Sound
    {
        [LcfAlwaysPersistAttribute]
        public DbString Name
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
    }
}