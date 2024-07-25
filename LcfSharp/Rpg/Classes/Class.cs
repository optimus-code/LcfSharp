using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Shared;
using LcfSharp.IO.Types;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Classes
{
    public enum ClassChunk : int
    {
        Name = 0x01,
        TwoWeapon = 0x15,
        LockEquipment = 0x16,
        AutoBattle = 0x17,
        SuperGuard = 0x18,
        Parameters = 0x1F,
        ExpBase = 0x29,
        ExpInflation = 0x2A,
        ExpCorrection = 0x2B,
        BattlerAnimation = 0x3E,
        Skills = 0x3F,
        StateRanksSize = 0x47,
        StateRanks = 0x48,
        AttributeRanksSize = 0x49,
        AttributeRanks = 0x4A,
        BattleCommands = 0x50
    }

    [LcfChunk<ClassChunk>]
    public class Class
    {
        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        }

        public DbString Name
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool TwoWeapon
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool LockEquipment
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool AutoBattle
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool SuperGuard
        {
            get;
            set;
        }

        public Parameters Parameters
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ExpBase
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ExpInflation
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ExpCorrection
        {
            get;
            set;
        }

        [XmlAttribute]
        public int BattlerAnimation
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [XmlElement("Skill")]
        public List<Learning> Skills
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)ClassChunk.StateRanksSize)]
        public List<byte> StateRanks
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)ClassChunk.AttributeRanksSize)]
        public List<byte> AttributeRanks
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public List<int> BattleCommands
        {
            get;
            set;
        }
    }
}