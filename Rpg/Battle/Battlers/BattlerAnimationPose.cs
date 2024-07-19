using LcfSharp.IO;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationPoseChunk : byte
    {
        Name = 0x01,
        BattlerName = 0x02,
        BattlerIndex = 0x03,
        AnimationType = 0x04,
        BattleAnimationId = 0x05
    }

    public enum BattlerAnimationPoseAnimType
    {
        Character = 0,
        Battle = 1
    }

    public class BattlerAnimationPose
    {
        public static readonly Dictionary<BattlerAnimationPoseAnimType, string> AnimTypeTags = new Dictionary<BattlerAnimationPoseAnimType, string>
        {
            { BattlerAnimationPoseAnimType.Character, "character" },
            { BattlerAnimationPoseAnimType.Battle, "battle" }
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

        public DbString BattlerName
        {
            get;
            set;
        }

        public int BattlerIndex
        {
            get;
            set;
        } = 0;

        public int AnimationType
        {
            get;
            set;
        } = 0;

        public int BattleAnimationID
        {
            get;
            set;
        } = 1;

        public BattlerAnimationPose(LcfReader reader)
        {
            TypeHelpers.ReadChunks<BattlerAnimationPoseChunk>(reader, (chunkID) =>
            {
                switch ((BattlerAnimationPoseChunk)chunkID)
                {
                    case BattlerAnimationPoseChunk.Name:
                        Name = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case BattlerAnimationPoseChunk.BattlerName:
                        BattlerName = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case BattlerAnimationPoseChunk.BattlerIndex:
                        BattlerIndex = reader.ReadInt();
                        return true;

                    case BattlerAnimationPoseChunk.AnimationType:
                        AnimationType = reader.ReadInt();
                        return true;

                    case BattlerAnimationPoseChunk.BattleAnimationId:
                        BattleAnimationID = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}
