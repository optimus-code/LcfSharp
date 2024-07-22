using LcfSharp.IO;
using LcfSharp.Rpg.Troops;
using LcfSharp.Types;
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

        public int Type
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

        public int Restriction
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

        public State(LcfReader reader)
        {
            TypeHelpers.ReadChunks<TroopMemberChunk>(reader, (chunk) =>
            {
                switch ((StateChunk)chunk.ID)
                {
                    case StateChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;

                    case StateChunk.Type:
                        Type = reader.ReadInt();
                        return true;

                    case StateChunk.Color:
                        Color = reader.ReadInt();
                        return true;

                    case StateChunk.Priority:
                        Priority = reader.ReadInt();
                        return true;

                    case StateChunk.Restriction:
                        Restriction = reader.ReadInt();
                        return true;

                    case StateChunk.ARate:
                        ARate = reader.ReadInt();
                        return true;

                    case StateChunk.BRate:
                        BRate = reader.ReadInt();
                        return true;

                    case StateChunk.CRate:
                        CRate = reader.ReadInt();
                        return true;

                    case StateChunk.DRate:
                        DRate = reader.ReadInt();
                        return true;

                    case StateChunk.ERate:
                        ERate = reader.ReadInt();
                        return true;

                    case StateChunk.HoldTurn:
                        HoldTurn = reader.ReadInt();
                        return true;

                    case StateChunk.AutoReleaseProb:
                        AutoReleaseProb = reader.ReadInt();
                        return true;

                    case StateChunk.ReleaseByDamage:
                        ReleaseByDamage = reader.ReadInt();
                        return true;

                    case StateChunk.AffectType:
                        AffectType = reader.ReadInt();
                        return true;

                    case StateChunk.AffectAttack:
                        AffectAttack = reader.ReadBool();
                        return true;

                    case StateChunk.AffectDefense:
                        AffectDefense = reader.ReadBool();
                        return true;

                    case StateChunk.AffectSpirit:
                        AffectSpirit = reader.ReadBool();
                        return true;

                    case StateChunk.AffectAgility:
                        AffectAgility = reader.ReadBool();
                        return true;

                    case StateChunk.ReduceHitRatio:
                        ReduceHitRatio = reader.ReadInt();
                        return true;

                    case StateChunk.AvoidAttacks:
                        AvoidAttacks = reader.ReadBool();
                        return true;

                    case StateChunk.ReflectMagic:
                        ReflectMagic = reader.ReadBool();
                        return true;

                    case StateChunk.Cursed:
                        Cursed = reader.ReadBool();
                        return true;

                    case StateChunk.BattlerAnimationId:
                        BattlerAnimationID = reader.ReadInt();
                        return true;

                    case StateChunk.RestrictSkill:
                        RestrictSkill = reader.ReadBool();
                        return true;

                    case StateChunk.RestrictSkillLevel:
                        RestrictSkillLevel = reader.ReadInt();
                        return true;

                    case StateChunk.RestrictMagic:
                        RestrictMagic = reader.ReadBool();
                        return true;

                    case StateChunk.RestrictMagicLevel:
                        RestrictMagicLevel = reader.ReadInt();
                        return true;

                    case StateChunk.HpChangeType:
                        HpChangeType = reader.ReadInt();
                        return true;

                    case StateChunk.SpChangeType:
                        SpChangeType = reader.ReadInt();
                        return true;

                    case StateChunk.MessageActor:
                        MessageActor = reader.ReadDbString(chunk.Length);
                        return true;

                    case StateChunk.MessageEnemy:
                        MessageEnemy = reader.ReadDbString(chunk.Length);
                        return true;

                    case StateChunk.MessageAlready:
                        MessageAlready = reader.ReadDbString(chunk.Length);
                        return true;

                    case StateChunk.MessageAffected:
                        MessageAffected = reader.ReadDbString(chunk.Length);
                        return true;

                    case StateChunk.MessageRecovery:
                        MessageRecovery = reader.ReadDbString(chunk.Length);
                        return true;

                    case StateChunk.HpChangeMax:
                        HpChangeMax = reader.ReadInt();
                        return true;

                    case StateChunk.HpChangeVal:
                        HpChangeVal = reader.ReadInt();
                        return true;

                    case StateChunk.HpChangeMapSteps:
                        HpChangeMapSteps = reader.ReadInt();
                        return true;

                    case StateChunk.HpChangeMapVal:
                        HpChangeMapVal = reader.ReadInt();
                        return true;

                    case StateChunk.SpChangeMax:
                        SpChangeMax = reader.ReadInt();
                        return true;

                    case StateChunk.SpChangeVal:
                        SpChangeVal = reader.ReadInt();
                        return true;

                    case StateChunk.SpChangeMapSteps:
                        SpChangeMapSteps = reader.ReadInt();
                        return true;

                    case StateChunk.SpChangeMapVal:
                        SpChangeMapVal = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}