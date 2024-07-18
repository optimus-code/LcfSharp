using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationSpeed
    {
        Slow = 20,
        Medium = 14,
        Fast = 8
    }

    public enum BattlerAnimationPoses
    {
        Idle = 0,
        AttackRight = 1,
        AttackLeft = 2,
        Skill = 3,
        Dead = 4,
        Damage = 5,
        Dazed = 6,
        Defend = 7,
        WalkLeft = 8,
        WalkRight = 9,
        Victory = 10,
        Item = 11
    }

    public class BattlerAnimation
    {
        public static readonly Dictionary<BattlerAnimationSpeed, string> SpeedTags = new Dictionary<BattlerAnimationSpeed, string>
        {
            { BattlerAnimationSpeed.Slow, "slow" },
            { BattlerAnimationSpeed.Medium, "medium" },
            { BattlerAnimationSpeed.Fast, "fast" }
        };

        public static readonly Dictionary<BattlerAnimationPoses, string> PoseTags = new Dictionary<BattlerAnimationPoses, string>
        {
            { BattlerAnimationPoses.Idle, "Idle" },
            { BattlerAnimationPoses.AttackRight, "AttackRight" },
            { BattlerAnimationPoses.AttackLeft, "AttackLeft" },
            { BattlerAnimationPoses.Skill, "Skill" },
            { BattlerAnimationPoses.Dead, "Dead" },
            { BattlerAnimationPoses.Damage, "Damage" },
            { BattlerAnimationPoses.Dazed, "Dazed" },
            { BattlerAnimationPoses.Defend, "Defend" },
            { BattlerAnimationPoses.WalkLeft, "WalkLeft" },
            { BattlerAnimationPoses.WalkRight, "WalkRight" },
            { BattlerAnimationPoses.Victory, "Victory" },
            { BattlerAnimationPoses.Item, "Item" }
        };

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

        public int Speed
        {
            get;
            set;
        } = 20;

        public List<BattlerAnimationPoses> Poses
        {
            get;
            set;
        } = new List<BattlerAnimationPoses>();

        public List<BattlerAnimationWeapon> Weapons
        {
            get;
            set;
        } = new List<BattlerAnimationWeapon>();
    }
}
