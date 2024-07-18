using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationItemSkillSpeed
    {
        Fast = 0,
        Medium = 1,
        Slow = 2
    }

    public enum BattlerAnimationItemSkillAnimType
    {
        Weapon = 0,
        Battle = 1
    }

    public enum BattlerAnimationItemSkillMovement
    {
        None = 0,
        Step = 1,
        Jump = 2,
        Move = 3
    }

    public enum BattlerAnimationItemSkillAfterimage
    {
        None = 0,
        Add = 1
    }

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

        public int Type
        {
            get;
            set;
        } = 0;

        public int WeaponAnimationID
        {
            get;
            set;
        } = 0;

        public int Movement
        {
            get;
            set;
        } = 0;

        public int AfterImage
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

        public int Pose
        {
            get;
            set;
        } = 3;
    }

}
