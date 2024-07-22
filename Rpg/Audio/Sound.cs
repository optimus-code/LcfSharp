﻿using LcfSharp.IO;
using LcfSharp.Types;

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

    public class Sound
    {
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

        public Sound()
        {
        }

        public Sound(LcfReader reader)
        {
            TypeHelpers.ReadChunks<SoundChunk>(reader, (chunk) =>
            {
                switch ((SoundChunk)chunk.ID)
                {
                    case SoundChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;

                    case SoundChunk.Volume:
                        Volume = reader.ReadInt();
                        return true;

                    case SoundChunk.Tempo:
                        Tempo = reader.ReadInt();
                        return true;

                    case SoundChunk.Balance:
                        Balance = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}
