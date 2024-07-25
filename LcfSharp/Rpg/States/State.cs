using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Troops;
using LcfSharp.IO.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.States
{
    public enum StateChunk : int
    {
        Name = 0x01,
        Type = 0x02,
        Color = 0x03,
        Priority = 0x04,
        Restriction = 0x05,
        ARate = 0x0B,
        BRate = 0x0C,
        CRate = 0x0D,
        DRate = 0x0E,
        ERate = 0x0F,
        HoldTurn = 0x15,
        AutoReleaseProb = 0x16,
        ReleaseByDamage = 0x17,
        AffectType = 0x1E,
        AffectAttack = 0x1F,
        AffectDefense = 0x20,
        AffectSpirit = 0x21,
        AffectAgility = 0x22,
        ReduceHitRatio = 0x23,
        AvoidAttacks = 0x24,
        ReflectMagic = 0x25,
        Cursed = 0x26,
        BattlerAnimationId = 0x27,
        RestrictSkill = 0x29,
        RestrictSkillLevel = 0x2A,
        RestrictMagic = 0x2B,
        RestrictMagicLevel = 0x2C,
        HpChangeType = 0x2D,
        SpChangeType = 0x2E,
        MessageActor = 0x33,
        MessageEnemy = 0x34,
        MessageAlready = 0x35,
        MessageAffected = 0x36,
        MessageRecovery = 0x37,
        HpChangeMax = 0x3D,
        HpChangeVal = 0x3E,
        HpChangeMapSteps = 0x3F,
        HpChangeMapVal = 0x40,
        SpChangeMax = 0x41,
        SpChangeVal = 0x42,
        SpChangeMapSteps = 0x43,
        SpChangeMapVal = 0x44
    }

    public enum StatePersistence
    {
        Ends = 0,
        Persists = 1
    }

    public enum StateRestriction
    {
        Normal = 0,
        DoNothing = 1,
        AttackEnemy = 2,
        AttackAlly = 3
    }

    public enum StateAffectType
    {
        Half = 0,
        Double = 1,
        Nothing = 2
    }


    public enum StateChangeType
    {
        Lose = 0,
        Gain = 1,
        Nothing = 2
    }

    [LcfChunk<StateChunk>]
    public class State
    {
        public const int DeathID = 1;

        public static readonly Dictionary<StatePersistence, string> PersistenceTags = new Dictionary<StatePersistence, string>
        {
            { StatePersistence.Ends, "ends" },
            { StatePersistence.Persists, "persists" }
        };

        public static readonly Dictionary<StateRestriction, string> RestrictionTags = new Dictionary<StateRestriction, string>
        {
            { StateRestriction.Normal, "normal" },
            { StateRestriction.DoNothing, "do_nothing" },
            { StateRestriction.AttackEnemy, "attack_enemy" },
            { StateRestriction.AttackAlly, "attack_ally" }
        };

        public static readonly Dictionary<StateAffectType, string> AffectTypeTags = new Dictionary<StateAffectType, string>
        {
            { StateAffectType.Half, "half" },
            { StateAffectType.Double, "double" },
            { StateAffectType.Nothing, "nothing" }
        };

        public static readonly Dictionary<StateChangeType, string> ChangeTypeTags = new Dictionary<StateChangeType, string>
        {
            { StateChangeType.Lose, "lose" },
            { StateChangeType.Gain, "gain" },
            { StateChangeType.Nothing, "nothing" }
        };

        [LcfID]
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

        [LcfAlwaysPersistAttribute]
        public StatePersistence Type
        {
            get;
            set;
        }

        public int Color
        {
            get;
            set;
        } = 6;

        public int Priority
        {
            get;
            set;
        } = 50;

        [LcfAlwaysPersistAttribute]
        public StateRestriction Restriction
        {
            get;
            set;
        }

        public int ARate
        {
            get;
            set;
        } = 100;

        public int BRate
        {
            get;
            set;
        } = 80;

        public int CRate
        {
            get;
            set;
        } = 60;

        public int DRate
        {
            get;
            set;
        } = 30;

        public int ERate
        {
            get;
            set;
        }

        public int HoldTurn
        {
            get;
            set;
        }

        public int AutoReleaseProb
        {
            get;
            set;
        }

        public int ReleaseByDamage
        {
            get;
            set;
        }

        public int AffectType
        {
            get;
            set;
        }

        public bool AffectAttack
        {
            get;
            set;
        }

        public bool AffectDefense
        {
            get;
            set;
        }

        public bool AffectSpirit
        {
            get;
            set;
        }

        public bool AffectAgility
        {
            get;
            set;
        }

        public int ReduceHitRatio
        {
            get;
            set;
        } = 100;

        public bool AvoidAttacks
        {
            get;
            set;
        }

        public bool ReflectMagic
        {
            get;
            set;
        }

        public bool Cursed
        {
            get;
            set;
        }

        public int BattlerAnimationID
        {
            get;
            set;
        } = 100;

        public bool RestrictSkill
        {
            get;
            set;
        }

        public int RestrictSkillLevel
        {
            get;
            set;
        }

        public bool RestrictMagic
        {
            get;
            set;
        }

        public int RestrictMagicLevel
        {
            get;
            set;
        }

        public int HpChangeType
        {
            get;
            set;
        }

        public int SpChangeType
        {
            get;
            set;
        }

        public DbString MessageActor
        {
            get;
            set;
        }

        public DbString MessageEnemy
        {
            get;
            set;
        }

        public DbString MessageAlready
        {
            get;
            set;
        }

        public DbString MessageAffected
        {
            get;
            set;
        }

        public DbString MessageRecovery
        {
            get;
            set;
        }

        public int HpChangeMax
        {
            get;
            set;
        }

        public int HpChangeVal
        {
            get;
            set;
        }

        public int HpChangeMapSteps
        {
            get;
            set;
        }

        public int HpChangeMapVal
        {
            get;
            set;
        }

        public int SpChangeMax
        {
            get;
            set;
        }

        public int SpChangeVal
        {
            get;
            set;
        }

        public int SpChangeMapSteps
        {
            get;
            set;
        }

        public int SpChangeMapVal
        {
            get;
            set;
        }
    }
}