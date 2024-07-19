using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationItemSkillChunk : byte
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

        public int Pose
        {
            get;
            set;
        } = 3;

        public BattlerAnimationItemSkill(LcfReader reader)
        {
            TypeHelpers.ReadChunks<BattlerAnimationItemSkillChunk>(reader, (chunkID) =>
            {
                switch ((BattlerAnimationItemSkillChunk)chunkID)
                {
                    case BattlerAnimationItemSkillChunk.Unknown02:
                        Unknown02 = reader.ReadInt();
                        return true;

                    case BattlerAnimationItemSkillChunk.Type:
                        Type = (BattlerAnimationItemSkillAnimType)reader.ReadInt();
                        return true;

                    case BattlerAnimationItemSkillChunk.WeaponAnimationId:
                        WeaponAnimationID = reader.ReadInt();
                        return true;

                    case BattlerAnimationItemSkillChunk.Movement:
                        Movement = (BattlerAnimationItemSkillMovement)reader.ReadInt();
                        return true;

                    case BattlerAnimationItemSkillChunk.AfterImage:
                        AfterImage = (BattlerAnimationItemSkillAfterimage)reader.ReadInt();
                        return true;

                    case BattlerAnimationItemSkillChunk.Attacks:
                        Attacks = reader.ReadInt();
                        return true;

                    case BattlerAnimationItemSkillChunk.Ranged:
                        Ranged = reader.ReadBool();
                        return true;

                    case BattlerAnimationItemSkillChunk.RangedAnimationId:
                        RangedAnimationID = reader.ReadInt();
                        return true;

                    case BattlerAnimationItemSkillChunk.RangedSpeed:
                        RangedSpeed = reader.ReadInt();
                        return true;

                    case BattlerAnimationItemSkillChunk.BattleAnimationId:
                        BattleAnimationID = reader.ReadInt();
                        return true;

                    case BattlerAnimationItemSkillChunk.Pose:
                        Pose = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}