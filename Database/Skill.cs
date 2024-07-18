using System.Collections.Generic;
using System.Collections;
using LcfSharp.Skills;
using LcfSharp.Audio;

namespace LcfSharp.Database
{
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

        public string Name
        {
            get; 
            set;
        }

        public string Description
        {
            get; 
            set;
        }

        public string UsingMessage1
        {
            get;
            set;
        }

        public string UsingMessage2
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
            set; } = false;

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

        public BitArray StateEffects
        {
            get; 
            set;
        }

        public BitArray AttributeEffects
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
    }

    public class EasyRPGSkill : Skill
    {
        public string Battle2k3Message
        { 
            get; 
            set; 
        } = kDefaultMessage;

        public bool IgnoreReflect
        { 
            get; 
            set; 
        } = false;

        public int StateHit
        { 
            get;
            set; 
        } = -1;

        public int AttributeHit
        { 
            get; 
            set; 
        } = -1;

        public bool IgnoreRestrictSkill
        { 
            get; 
            set; 
        } = false;

        public bool IgnoreRestrictMagic
        {
            get; 
            set; 
        } = false;

        public bool EnableStatAbsorbing
        { 
            get;
            set; 
        } = false;

        public bool AffectedByEvadeAllPhysicalAttacks
        { 
            get;
            set; 
        } = false;

        public int CriticalHitChance
        { 
            get;
            set; 
        } = 0;

        public bool AffectedByRowModifiers
        { 
            get; 
            set; 
        } = false;

        public HpType HpType2
        { 
            get; 
            set; 
        } = HpType.Cost;

        public int HpPercent
        { 
            get; 
            set; 
        } = 0;

        public int HpCost
        {
            get;
            set; 
        } = 0;
    }
}
