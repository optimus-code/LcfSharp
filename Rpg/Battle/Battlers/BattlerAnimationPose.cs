using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle.Battlers
{
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
    }

}
