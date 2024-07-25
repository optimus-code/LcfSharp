using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg.Shared
{
    public enum LearningChunk : int
    {
        /** Integer */
        Level = 0x01,
        /** Integer */
        SkillID = 0x02
    }

    [LcfChunk<LearningChunk>]
    public class Learning
    {
        [LcfID]
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
    }
}