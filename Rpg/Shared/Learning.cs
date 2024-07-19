using LcfSharp.IO;
using LcfSharp.Rpg.Actors;
using System;

namespace LcfSharp.Rpg.Shared
{
    public enum LearningChunk : byte
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

        public int SkillID
        {
            get;
            set;
        } = 1;

        public Learning(LcfReader reader)
        {
            TypeHelpers.ReadChunks<LearningChunk>(reader, (chunkID) =>
            {
                switch ((LearningChunk)chunkID)
                {
                    case LearningChunk.Level:
                        Level = reader.ReadInt();
                        return true;

                    case LearningChunk.SkillID:
                        SkillID = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}
