using LcfSharp.IO;
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
        SkillId = 0x03,
        /** Integer */
        EnemyId = 0x04,
        /** Integer */
        ConditionType = 0x05,
        /** Integer */
        ConditionParam1 = 0x06,
        /** Integer */
        ConditionParam2 = 0x07,
        /** Integer */
        SwitchId = 0x08,
        /** Flag */
        SwitchOn = 0x09,
        /** Integer */
        SwitchOnId = 0x0A,
        /** Flag */
        SwitchOff = 0x0B,
        /** Integer */
        SwitchOffId = 0x0C,
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

        public EnemyActionKind KindValue
        {
            get;
            set;
        }

        public EnemyActionBasic BasicValue
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

        public EnemyActionConditionType ConditionTypeValue
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

        public EnemyAction(LcfReader reader)
        {
            TypeHelpers.ReadChunks<BattleCommandChunk>(reader, (chunk) =>
            {
                switch ((EnemyActionChunk)chunk.ID)
                {
                    case EnemyActionChunk.Kind:
                        KindValue = (EnemyActionKind)reader.ReadInt();
                        return true;

                    case EnemyActionChunk.Basic:
                        BasicValue = (EnemyActionBasic)reader.ReadInt();
                        return true;

                    case EnemyActionChunk.SkillId:
                        SkillID = reader.ReadInt();
                        return true;

                    case EnemyActionChunk.EnemyId:
                        EnemyID = reader.ReadInt();
                        return true;

                    case EnemyActionChunk.ConditionType:
                        ConditionTypeValue = (EnemyActionConditionType)reader.ReadInt();
                        return true;

                    case EnemyActionChunk.ConditionParam1:
                        ConditionParam1 = reader.ReadInt();
                        return true;

                    case EnemyActionChunk.ConditionParam2:
                        ConditionParam2 = reader.ReadInt();
                        return true;

                    case EnemyActionChunk.SwitchId:
                        SwitchID = reader.ReadInt();
                        return true;

                    case EnemyActionChunk.SwitchOn:
                        SwitchOn = reader.ReadBool();
                        return true;

                    case EnemyActionChunk.SwitchOnId:
                        SwitchOnID = reader.ReadInt();
                        return true;

                    case EnemyActionChunk.SwitchOff:
                        SwitchOff = reader.ReadBool();
                        return true;

                    case EnemyActionChunk.SwitchOffId:
                        SwitchOffID = reader.ReadInt();
                        return true;

                    case EnemyActionChunk.Rating:
                        Rating = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}