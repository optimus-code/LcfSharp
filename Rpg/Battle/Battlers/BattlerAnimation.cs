﻿using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationChunk : byte
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

        public BattlerAnimationSpeed Speed
        {
            get;
            set;
        } = BattlerAnimationSpeed.Slow;

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


        public BattlerAnimation(LcfReader reader)
        {
            TypeHelpers.ReadChunks<BattlerAnimationChunk>(reader, (chunkID) =>
            {
                switch ((BattlerAnimationChunk)chunkID)
                {
                    case BattlerAnimationChunk.Name:
                        Name = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case BattlerAnimationChunk.Speed:
                        Speed = (BattlerAnimationSpeed)reader.ReadInt();
                        return true;

                    case BattlerAnimationChunk.Poses:
                        // Read the list of BattlerAnimationPoses objects
                        int poseCount = reader.ReadInt();
                        for (int i = 0; i < poseCount; i++)
                        {
                            Poses.Add((BattlerAnimationPoses)reader.ReadInt());
                        }
                        return true;

                    case BattlerAnimationChunk.Weapons:
                        // Read the list of BattlerAnimationWeapon objects
                        int weaponCount = reader.ReadInt();
                        for (int i = 0; i < weaponCount; i++)
                        {
                            Weapons.Add(new BattlerAnimationWeapon(reader));
                        }
                        return true;
                }
                return false;
            });
        }
    }
}