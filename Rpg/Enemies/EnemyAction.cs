namespace LcfSharp.Rpg.Enemies
{
    using System.Collections.Generic;

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

        public int ID
        {
            get;
            set;
        }

        public int KindValue
        {
            get;
            set;
        }

        public int BasicValue
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

        public int ConditionTypeValue
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
