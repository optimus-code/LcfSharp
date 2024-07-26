using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Shared;
using LcfSharp.IO.Types;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationChunk : int
    {
        /** String */
        Name = 0x01,
        /** Integer */
        Speed = 0x02,
        /** Array - rpg::BattlerAnimationPose */
        Poses = 0x0A,
        /** Array - rpg::BattlerAnimationWeapon */
        Weapons = 0x0B
    }

    public enum BattlerAnimationSpeed : int
    {
        Slow = 20,
        Medium = 14,
        Fast = 8
    }

    public enum BattlerAnimationPoses : int
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

    [LcfChunk<BattlerAnimationChunk>]
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

        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        } = 0;

        [LcfAlwaysPersistAttribute]
		public string Name
        {
            get;
            set;
        }

        [XmlAttribute]
        public BattlerAnimationSpeed Speed
        {
            get;
            set;
        } = BattlerAnimationSpeed.Slow;

        [LcfAlwaysPersistAttribute]
        [XmlElement("Pose")]
        public List<BattlerAnimationPose> Poses
        {
            get;
            set;
        } = new List<BattlerAnimationPose>();

        [LcfAlwaysPersistAttribute]
        [XmlElement("Weapon")]
        public List<BattlerAnimationWeapon> Weapons
        {
            get;
            set;
        } = new List<BattlerAnimationWeapon>();
    }
}