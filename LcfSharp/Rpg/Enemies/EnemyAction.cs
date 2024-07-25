using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Battle;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Enemies
{
    public enum EnemyActionChunk : int
    {
        /** Integer */
        Kind = 0x01,
        /** Integer */
        Basic = 0x02,
        /** Integer */
        SkillID = 0x03,
        /** Integer */
        EnemyID = 0x04,
        /** Integer */
        ConditionType = 0x05,
        /** Integer */
        ConditionParam1 = 0x06,
        /** Integer */
        ConditionParam2 = 0x07,
        /** Integer */
        SwitchID = 0x08,
        /** Flag */
        SwitchOn = 0x09,
        /** Integer */
        SwitchOnID = 0x0A,
        /** Flag */
        SwitchOff = 0x0B,
        /** Integer */
        SwitchOffID = 0x0C,
        /** Integer */
        Rating = 0x0D
    }

    public enum EnemyActionKind
    {
        Basic = 0,
        Skill = 1,
        Transformation = 2
    }

    public enum EnemyActionBasic
    {
        Attack = 0,
        DualAttack = 1,
        Defense = 2,
        Observe = 3,
        Charge = 4,
        Autodestruction = 5,
        Escape = 6,
        Nothing = 7
    }

    public enum EnemyActionConditionType
    {
        Always = 0,
        Switch = 1,
        Turn = 2,
        Actors = 3,
        HP = 4,
        SP = 5,
        PartyLvl = 6,
        PartyFatigue = 7
    }

    [LcfChunk<EnemyActionChunk>]
    public class EnemyAction
    {
        public static readonly Dictionary<EnemyActionBasic, string> BasicTags = new Dictionary<EnemyActionBasic, string>
        {
            { EnemyActionBasic.Attack, "attack" },
            { EnemyActionBasic.DualAttack, "dual_attack" },
            { EnemyActionBasic.Defense, "defense" },
            { EnemyActionBasic.Observe, "observe" },
            { EnemyActionBasic.Charge, "charge" },
            { EnemyActionBasic.Autodestruction, "autodestruction" },
            { EnemyActionBasic.Escape, "escape" },
            { EnemyActionBasic.Nothing, "nothing" }
        };

        public static readonly Dictionary<EnemyActionKind, string> KindTags = new Dictionary<EnemyActionKind, string>
        {
            { EnemyActionKind.Basic, "basic" },
            { EnemyActionKind.Skill, "skill" },
            { EnemyActionKind.Transformation, "transformation" }
        };

        public static readonly Dictionary<EnemyActionConditionType, string> ConditionTypeTags = new Dictionary<EnemyActionConditionType, string>
        {
            { EnemyActionConditionType.Always, "always" },
            { EnemyActionConditionType.Switch, "switch" },
            { EnemyActionConditionType.Turn, "turn" },
            { EnemyActionConditionType.Actors, "actors" },
            { EnemyActionConditionType.HP, "hp" },
            { EnemyActionConditionType.SP, "sp" },
            { EnemyActionConditionType.PartyLvl, "party_lvl" },
            { EnemyActionConditionType.PartyFatigue, "party_fatigue" }
        };

        [LcfID]
        public int ID
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public EnemyActionKind Kind
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public EnemyActionBasic Basic
        {
            get;
            set;
        }

        public int SkillID
        {
            get;
            set;
        }

        public int EnemyID
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public EnemyActionConditionType ConditionType
        {
            get;
            set;
        }

        public int ConditionParam1
        {
            get;
            set;
        }

        public int ConditionParam2
        {
            get;
            set;
        }

        public int SwitchID
        {
            get;
            set;
        }

        public bool SwitchOn
        {
            get;
            set;
        }

        public int SwitchOnID
        {
            get;
            set;
        }

        public bool SwitchOff
        {
            get;
            set;
        }

        public int SwitchOffID
        {
            get;
            set;
        }

        public int Rating
        {
            get;
            set;
        }
    }
}