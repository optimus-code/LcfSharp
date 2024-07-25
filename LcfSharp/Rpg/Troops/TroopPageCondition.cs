using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Troops
{
    public enum TroopPageConditionChunk : int
    {
        Flags = 0x01,
        SwitchAID = 0x02,
        SwitchBID = 0x03,
        VariableID = 0x04,
        VariableValue = 0x05,
        TurnA = 0x06,
        TurnB = 0x07,
        FatigueMin = 0x08,
        FatigueMax = 0x09,
        EnemyID = 0x0A,
        EnemyHPMin = 0x0B,
        EnemyHPMax = 0x0C,
        ActorID = 0x0D,
        ActorHPMin = 0x0E,
        ActorHPMax = 0x0F,
        TurnEnemyID = 0x10,
        TurnEnemyA = 0x11,
        TurnEnemyB = 0x12,
        TurnActorID = 0x13,
        TurnActorA = 0x14,
        TurnActorB = 0x15,
        CommandActorID = 0x16,
        CommandID = 0x17
    }

    [LcfChunk<TroopPageConditionChunk>]
    public class TroopPageCondition
    {
        [LcfAlwaysPersist]
        public TroopPageConditionFlags Flags 
        {
            get; 
            set; 
        } = new TroopPageConditionFlags();

        [XmlAttribute]
        public int SwitchAID
        {
            get;
            set;
        } = 1;

        [XmlAttribute]
        public int SwitchBID
        {
            get;
            set;
        } = 1;

        [XmlAttribute]
        public int VariableID
        {
            get;
            set;
        } = 1;

        [XmlAttribute]
        public int VariableValue
        {
            get;
            set;
        }

        [XmlAttribute]
        public int TurnA
        {
            get;
            set;
        }

        [XmlAttribute]
        public int TurnB
        {
            get;
            set;
        }

        [XmlAttribute]
        public int FatigueMin
        {
            get;
            set;
        }

        [XmlAttribute]
        public int FatigueMax
        {
            get;
            set;
        } = 100;

        [XmlAttribute]
        public int EnemyID
        {
            get;
            set;
        }

        [XmlAttribute]
        public int EnemyHPMin
        {
            get;
            set;
        }

        [XmlAttribute]
        public int EnemyHPMax
        {
            get;
            set;
        } = 100;

        [XmlAttribute]
        public int ActorID
        {
            get;
            set;
        } = 1;

        [XmlAttribute]
        public int ActorHPMin
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ActorHPMax
        {
            get;
            set;
        } = 100;

        [XmlAttribute]
        public int TurnEnemyID
        {
            get;
            set;
        }

        [XmlAttribute]
        public int TurnEnemyA
        {
            get;
            set;
        }

        [XmlAttribute]
        public int TurnEnemyB
        {
            get;
            set;
        }

        [XmlAttribute]
        public int TurnActorID
        {
            get;
            set;
        } = 1;

        [XmlAttribute]
        public int TurnActorA
        {
            get;
            set;
        }

        [XmlAttribute]
        public int TurnActorB
        {
            get;
            set;
        }

        [XmlAttribute]
        public int CommandActorID
        {
            get;
            set;
        } = 1;

        [XmlAttribute]
        public int CommandID
        {
            get;
            set;
        } = 1;
    }
}