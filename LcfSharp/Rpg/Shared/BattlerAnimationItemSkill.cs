using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Battle.Battlers;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Shared
{
    public enum BattlerAnimationItemSkillChunk : int
    {
        Unknown02 = 0x02,
        Type = 0x03,
        WeaponAnimationId = 0x04,
        Movement = 0x05,
        AfterImage = 0x06,
        Attacks = 0x07,
        Ranged = 0x08,
        RangedAnimationId = 0x09,
        RangedSpeed = 0x0C,
        BattleAnimationId = 0x0D,
        Pose = 0x0E
    }

    public enum BattlerAnimationItemSkillSpeed : int
    {
        Fast = 0,
        Medium = 1,
        Slow = 2
    }

    public enum BattlerAnimationItemSkillAnimType : int
    {
        Weapon = 0,
        Battle = 1
    }

    public enum BattlerAnimationItemSkillMovement : int
    {
        None = 0,
        Step = 1,
        Jump = 2,
        Move = 3
    }

    public enum BattlerAnimationItemSkillAfterimage : int
    {
        None = 0,
        Add = 1
    }

    [LcfChunk<BattlerAnimationItemSkillChunk>]
    public class BattlerAnimationItemSkill
    {
        public static readonly Dictionary<BattlerAnimationItemSkillSpeed, string> SpeedTags = new Dictionary<BattlerAnimationItemSkillSpeed, string>
        {
            { BattlerAnimationItemSkillSpeed.Fast, "fast" },
            { BattlerAnimationItemSkillSpeed.Medium, "medium" },
            { BattlerAnimationItemSkillSpeed.Slow, "slow" }
        };

        public static readonly Dictionary<BattlerAnimationItemSkillAnimType, string> AnimTypeTags = new Dictionary<BattlerAnimationItemSkillAnimType, string>
        {
            { BattlerAnimationItemSkillAnimType.Weapon, "weapon" },
            { BattlerAnimationItemSkillAnimType.Battle, "battle" }
        };

        public static readonly Dictionary<BattlerAnimationItemSkillMovement, string> MovementTags = new Dictionary<BattlerAnimationItemSkillMovement, string>
        {
            { BattlerAnimationItemSkillMovement.None, "none" },
            { BattlerAnimationItemSkillMovement.Step, "step" },
            { BattlerAnimationItemSkillMovement.Jump, "jump" },
            { BattlerAnimationItemSkillMovement.Move, "move" }
        };

        public static readonly Dictionary<BattlerAnimationItemSkillAfterimage, string> AfterimageTags = new Dictionary<BattlerAnimationItemSkillAfterimage, string>
        {
            { BattlerAnimationItemSkillAfterimage.None, "none" },
            { BattlerAnimationItemSkillAfterimage.Add, "add" }
        };

        [LcfID]
        public int ID
        {
            get;
            set;
        } = 0;

        public int Unknown02
        {
            get;
            set;
        } = 0;

        public BattlerAnimationItemSkillAnimType Type
        {
            get;
            set;
        } = 0;

        public int WeaponAnimationID
        {
            get;
            set;
        } = 0;

        public BattlerAnimationItemSkillMovement Movement
        {
            get;
            set;
        } = 0;

        public BattlerAnimationItemSkillAfterimage AfterImage
        {
            get;
            set;
        } = 0;

        public int Attacks
        {
            get;
            set;
        } = 0;

        public bool Ranged
        {
            get;
            set;
        } = false;

        public int RangedAnimationID
        {
            get;
            set;
        } = 0;

        public int RangedSpeed
        {
            get;
            set;
        } = 0;

        public int BattleAnimationID
        {
            get;
            set;
        } = 1;

        public BattlerAnimationPoses Pose
        {
            get;
            set;
        } = BattlerAnimationPoses.Skill;
    }
}