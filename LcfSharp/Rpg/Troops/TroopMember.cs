using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Troops
{
    public enum TroopMemberChunk : int
    {
        EnemyID = 0x01,
        X = 0x02,
        Y = 0x03,
        Invisible = 0x04
    }

    [LcfChunk<TroopMemberChunk>]
    public class TroopMember
    {
        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        }

        [XmlAttribute]
        public int EnemyID
        {
            get;
            set;
        } = 1;

        [XmlAttribute]
        public int X
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Y
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool Invisible
        {
            get;
            set;
        }
    }
}
