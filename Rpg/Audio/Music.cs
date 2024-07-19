using LcfSharp.IO;
using LcfSharp.Types;
using System;

namespace LcfSharp.Rpg.Audio
{
    public enum MusicChunk : byte
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

        public Music(LcfReader reader)
        {
            TypeHelpers.ReadChunks<MusicChunk>(reader, (chunkID) =>
            {
                switch ((MusicChunk)chunkID)
                {
                    case MusicChunk.Name:
                        Name = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case MusicChunk.FadeIn:
                        FadeIn = reader.ReadInt();
                        return true;

                    case MusicChunk.Volume:
                        Volume = reader.ReadInt();
                        return true;

                    case MusicChunk.Tempo:
                        Tempo = reader.ReadInt();
                        return true;

                    case MusicChunk.Balance:
                        Balance = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}
