using System.Collections.Generic;
using System.Collections;
using LcfSharp.Rpg.Audio;
using LcfSharp.Rpg.Shared;
using LcfSharp.Types;
using LcfSharp.IO;
using LcfSharp.Rpg.Troops;

namespace LcfSharp.Rpg.Skills
{
    public enum SkillChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        Description = 0x02,
        /** String - RPG2000 */
        UsingMessage1 = 0x03,
        /** String - RPG2000 */
        UsingMessage2 = 0x04,
        /** Integer - RPG2000 */
        FailureMessage = 0x07,
        /** Integer */
        Type = 0x08,
        /** Integer - RPG2003 */
        SpType = 0x09,
        /** Integer - RPG2003 */
        SpPercent = 0x0A,
        /** Integer */
        SpCost = 0x0B,
        /** Integer */
        Scope = 0x0C,
        /** Integer */
        SwitchId = 0x0D,
        /** Integer */
        AnimationId = 0x0E,
        /** rpg::Sound */
        SoundEffect = 0x10,
        /** Flag */
        OccasionField = 0x12,
        /** Flag */
        OccasionBattle = 0x13,
        /** Flag - RPG2003 */
        ReverseStateEffect = 0x14,
        /** Integer */
        PhysicalRate = 0x15,
        /** Integer */
        MagicalRate = 0x16,
        /** Integer */
        Variance = 0x17,
        /** Integer */
        Power = 0x18,
        /** Integer */
        Hit = 0x19,
        /** Flag */
        AffectHp = 0x1F,
        /** Flag */
        AffectSp = 0x20,
        /** Flag */
        AffectAttack = 0x21,
        /** Flag */
        AffectDefense = 0x22,
        /** Flag */
        AffectSpirit = 0x23,
        /** Flag */
        AffectAgility = 0x24,
        /** Flag */
        AbsorbDamage = 0x25,
        /** Flag */
        IgnoreDefense = 0x26,
        /** Integer */
        StateEffectsSize = 0x29,
        /** Array - Flag */
        StateEffects = 0x2A,
        /** Integer */
        AttributeEffectsSize = 0x2B,
        /** Array - Flag */
        AttributeEffects = 0x2C,
        /** Flag */
        AffectAttrDefence = 0x2D,
        /** Integer - RPG2003 */
        BattlerAnimation = 0x31,
        /** ? - RPG2003 */
        BattlerAnimationData = 0x32
    }

    public class Skill
    {
        // Sentinel name used to denote that the default skill start message should be used.
        public const string kDefaultMessage = "default_message";

        public enum Type
        {
            Normal = 0,
            Teleport = 1,
            Escape = 2,
            Switch = 3,
            Subskill = 4
        }

        public enum SpType
        {
            Cost = 0,
            Percent = 1
        }

        public enum Scope
        {
            Enemy = 0,
            Enemies = 1,
            Self = 2,
            Ally = 3,
            Party = 4
        }

        public enum HpType
        {
            Cost = 0,
            Percent = 1
        }

        public int ID
        {
            get;
            set;
        } = 0;

        public DbString Name
        {
            get;
            set;
        }

        public DbString Description
        {
            get;
            set;
        }

        public DbString UsingMessage1
        {
            get;
            set;
        }

        public DbString UsingMessage2
        {
            get;
            set;
        }

        public int FailureMessage
        {
            get;
            set;
        } = 0;

        public Type SkillType
        {
            get;
            set;
        } = Type.Normal;

        public SpType SkillSpType
        {
            get;
            set;
        } = SpType.Cost;

        public int SpPercent
        {
            get;
            set;
        } = 0;

        public int SpCost
        {
            get;
            set;
        } = 0;

        public Scope SkillScope
        {
            get;
            set;
        } = Scope.Enemy;

        public int SwitchId
        {
            get;
            set;
        } = 1;

        public int AnimationId
        {
            get;
            set;
        } = 1;

        public Sound SoundEffect
        {
            get;
            set;
        }

        public bool OccasionField
        {
            get;
            set;
        } = true;

        public bool OccasionBattle
        {
            get;
            set;
        } = false;

        public bool ReverseStateEffect
        {
            get;
            set;
        } = false;

        public int PhysicalRate
        {
            get;
            set;
        } = 0;

        public int MagicalRate
        {
            get;
            set;
        } = 3;

        public int Variance
        {
            get;
            set;
        } = 4;

        public int Power
        {
            get;
            set;
        } = 0;

        public int Hit
        {
            get;
            set;
        } = 100;

        public bool AffectHp
        {
            get;
            set;
        } = false;

        public bool AffectSp
        {
            get;
            set;
        } = false;

        public bool AffectAttack
        {
            get;
            set;
        } = false;

        public bool AffectDefense
        {
            get;
            set;
        } = false;

        public bool AffectSpirit
        {
            get;
            set;
        } = false;

        public bool AffectAgility
        {
            get;
            set;
        } = false;

        public bool AbsorbDamage
        {
            get;
            set;
        } = false;

        public bool IgnoreDefense
        {
            get;
            set;
        } = false;

        public DbBitArray StateEffects
        {
            get;
            set;
        }

        public DbBitArray AttributeEffects
        {
            get;
            set;
        }

        public bool AffectAttrDefence
        {
            get;
            set;
        } = false;

        public int BattlerAnimation
        {
            get;
            set;
        } = -1;

        public List<BattlerAnimationItemSkill> BattlerAnimationData
        {
            get;
            set;
        }

        public Skill(LcfReader reader)
        {
            int stateEffectsSize = 0;
            int attributeEffectsSize = 0;

            TypeHelpers.ReadChunks<SkillChunk>(reader, (chunk) =>
            {
                switch ((SkillChunk)chunk.ID)
                {
                    case SkillChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;

                    case SkillChunk.Description:
                        Description = reader.ReadDbString(chunk.Length);
                        return true;

                    case SkillChunk.UsingMessage1:
                        UsingMessage1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case SkillChunk.UsingMessage2:
                        UsingMessage2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case SkillChunk.FailureMessage:
                        FailureMessage = reader.ReadInt();
                        return true;

                    case SkillChunk.Type:
                        SkillType = (Type)reader.ReadInt();
                        return true;

                    case SkillChunk.SpType:
                        if (!Database.IsRM2K3)
                            return false;
                        SkillSpType = (SpType)reader.ReadInt();
                        return true;

                    case SkillChunk.SpPercent:
                        if (!Database.IsRM2K3)
                            return false;
                        SpPercent = reader.ReadInt();
                        return true;

                    case SkillChunk.SpCost:
                        SpCost = reader.ReadInt();
                        return true;

                    case SkillChunk.Scope:
                        SkillScope = (Scope)reader.ReadInt();
                        return true;

                    case SkillChunk.SwitchId:
                        SwitchId = reader.ReadInt();
                        return true;

                    case SkillChunk.AnimationId:
                        AnimationId = reader.ReadInt();
                        return true;

                    case SkillChunk.SoundEffect:
                        SoundEffect = new Sound(reader);
                        return true;

                    case SkillChunk.OccasionField:
                        OccasionField = reader.ReadBool();
                        return true;

                    case SkillChunk.OccasionBattle:
                        OccasionBattle = reader.ReadBool();
                        return true;

                    case SkillChunk.ReverseStateEffect:
                        if (!Database.IsRM2K3)
                            return false;
                        ReverseStateEffect = reader.ReadBool();
                        return true;

                    case SkillChunk.PhysicalRate:
                        PhysicalRate = reader.ReadInt();
                        return true;

                    case SkillChunk.MagicalRate:
                        MagicalRate = reader.ReadInt();
                        return true;

                    case SkillChunk.Variance:
                        Variance = reader.ReadInt();
                        return true;

                    case SkillChunk.Power:
                        Power = reader.ReadInt();
                        return true;

                    case SkillChunk.Hit:
                        Hit = reader.ReadInt();
                        return true;

                    case SkillChunk.AffectHp:
                        AffectHp = reader.ReadBool();
                        return true;

                    case SkillChunk.AffectSp:
                        AffectSp = reader.ReadBool();
                        return true;

                    case SkillChunk.AffectAttack:
                        AffectAttack = reader.ReadBool();
                        return true;

                    case SkillChunk.AffectDefense:
                        AffectDefense = reader.ReadBool();
                        return true;

                    case SkillChunk.AffectSpirit:
                        AffectSpirit = reader.ReadBool();
                        return true;

                    case SkillChunk.AffectAgility:
                        AffectAgility = reader.ReadBool();
                        return true;

                    case SkillChunk.AbsorbDamage:
                        AbsorbDamage = reader.ReadBool();
                        return true;

                    case SkillChunk.IgnoreDefense:
                        IgnoreDefense = reader.ReadBool();
                        return true;

                    case SkillChunk.StateEffectsSize:
                        stateEffectsSize = reader.ReadInt();
                        return true;

                    case SkillChunk.StateEffects:
                        if (stateEffectsSize > 0)
                        {
                            StateEffects = reader.ReadBitArray(stateEffectsSize);
                            return true;
                        }
                        break;

                    case SkillChunk.AttributeEffectsSize:
                        attributeEffectsSize = reader.ReadInt();
                        return true;

                    case SkillChunk.AttributeEffects:
                        if (attributeEffectsSize > 0)
                        {
                            AttributeEffects = reader.ReadBitArray(attributeEffectsSize);
                            return true;
                        }
                        break;

                    case SkillChunk.AffectAttrDefence:
                        AffectAttrDefence = reader.ReadBool();
                        return true;

                    case SkillChunk.BattlerAnimation:
                        if (!Database.IsRM2K3)
                            return false;
                        BattlerAnimation = reader.ReadInt();
                        return true;

                    case SkillChunk.BattlerAnimationData:
                        if (!Database.IsRM2K3)
                            return false;
                        BattlerAnimationData = new List<BattlerAnimationItemSkill>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            BattlerAnimationData.Add(new BattlerAnimationItemSkill(reader));
                        });
                        return true;
                }
                return false;
            });
        }
    }
}