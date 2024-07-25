using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;

namespace LcfSharp.Rpg.Audio
{
    public enum MusicChunk : int
    {
        /** String */
        Name = 0x01,
        /** Integer */
        FadeIn = 0x02,
        /** Integer */
        Volume = 0x03,
        /** Integer */
        Tempo = 0x04,
        /** Integer */
        Balance = 0x05
    }

    [LcfChunk<MusicChunk>]
    public class Music
    {
        public DbString Name
        {
            get;
            set;
        } = "(OFF)";

        public int FadeIn
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
    }
}