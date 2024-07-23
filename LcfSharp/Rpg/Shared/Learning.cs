using LcfSharp.IO;
using LcfSharp.Rpg.Actors;
using System;

namespace LcfSharp.Rpg.Shared
{
    public enum LearningChunk : int
    {
        /** Integer */
        Level = 0x01,
        /** Integer */
        SkillID = 0x02
    }
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

        public short SkillID
        {
            get;
            set;
        } = 1;

        public Learning(LcfReader reader)
        {
            int expectedChunks = 2;
            int readChunks = 0;
            TypeHelpers.ReadChunks<LearningChunk>(reader, (chunk) =>
            {
                switch ((LearningChunk)chunk.ID)
                {
                    case LearningChunk.Level:
                        Level = reader.ReadInt();
                        readChunks++;
                        return true;

                    case LearningChunk.SkillID:
                        SkillID = reader.ReadShort();
                        readChunks++;
                        return true;
                }
                return false;
            }, ()=>
            {
                return readChunks == expectedChunks;
            });
        }
    }
}
