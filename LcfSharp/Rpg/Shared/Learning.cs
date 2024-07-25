using LcfSharp.IO.Attributes;
using System.Xml.Serialization;

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
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        } = 0;

        [XmlAttribute]
        public int Level
        {
            get;
            set;
        } = 1;

        [XmlAttribute]
        public int SkillID
        {
            get;
            set;
        } = 1;
    }
}