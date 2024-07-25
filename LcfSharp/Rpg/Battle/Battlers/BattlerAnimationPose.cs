using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationPoseChunk : int
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

    [LcfChunk<BattlerAnimationPoseChunk>]
    public class BattlerAnimationPose
    {
        public static readonly Dictionary<BattlerAnimationPoseAnimType, string> AnimTypeTags = new Dictionary<BattlerAnimationPoseAnimType, string>
        {
            { BattlerAnimationPoseAnimType.Character, "character" },
            { BattlerAnimationPoseAnimType.Battle, "battle" }
        };

        [LcfID]
        public int ID
        {
            get;
            set;
        } = 0;
[LcfAlwaysPersistAttribute]
		public DbString Name
        {
            get;
            set;
        }
[LcfAlwaysPersistAttribute]
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
    }
}