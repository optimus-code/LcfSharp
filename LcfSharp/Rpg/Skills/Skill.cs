using System.Collections.Generic;
using System.Collections;
using LcfSharp.Rpg.Audio;
using LcfSharp.Rpg.Shared;
using LcfSharp.IO.Types;
using LcfSharp.IO;
using LcfSharp.Rpg.Troops;
using LcfSharp.IO.Attributes;
using System.Xml.Serialization;

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
        SkillType = 0x08,
        /** Integer - RPG2003 */
        SPType = 0x09,
        /** Integer - RPG2003 */
        SPPercent = 0x0A,
        /** Integer */
        SPCost = 0x0B,
        /** Integer */
        SkillScope = 0x0C,
        /** Integer */
        SwitchID = 0x0D,
        /** Integer */
        AnimationID = 0x0E,
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
        AffectHP = 0x1F,
        /** Flag */
        AffectSP = 0x20,
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

    [LcfChunk<SkillChunk>]
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

        [LcfID]
        [XmlAttribute]
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

        [LcfAlwaysPersistAttribute]
        [XmlAttribute]
        public Type SkillType
        {
            get;
            set;
        } = Type.Normal;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [XmlAttribute]
        public SpType SPType
        {
            get;
            set;
        } = SpType.Cost;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [XmlAttribute]
        public int SPPercent
        {
            get;
            set;
        } = 0;

        [XmlAttribute]
        public int SPCost
        {
            get;
            set;
        } = 0;

        [LcfAlwaysPersistAttribute]
        [XmlAttribute]
        public Scope SkillScope
        {
            get;
            set;
        } = Scope.Enemy;

        public int SwitchID
        {
            get;
            set;
        } = 1;

        public int AnimationID
        {
            get;
            set;
        } = 1;

        [LcfAlwaysPersistAttribute]
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

        [LcfVersion(LcfEngineVersion.RM2K3)]
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

        public bool AffectHP
        {
            get;
            set;
        } = false;

        public bool AffectSP
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

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)SkillChunk.StateEffectsSize)]
        public List<bool> StateEffects
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)SkillChunk.AttributeEffectsSize)]
        public List<bool> AttributeEffects
        {
            get;
            set;
        }

        public bool AffectAttrDefence
        {
            get;
            set;
        } = false;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int BattlerAnimation
        {
            get;
            set;
        } = -1;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
        public List<BattlerAnimationItemSkill> BattlerAnimationData
        {
            get;
            set;
        } = [];
    }
}