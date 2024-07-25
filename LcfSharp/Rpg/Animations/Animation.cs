using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Animations
{
    public enum AnimationChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        AnimationName = 0x02,
        /** Battle2 animation when true */
        Large = 0x03,
        /** Array - rpg::AnimationTiming */
        Timings = 0x06,
        /** Integer */
        Scope = 0x09,
        /** Integer */
        Position = 0x0A,
        /** Array - rpg::AnimationFrames */
        Frames = 0x0C
    }

    public enum AnimationScope
    {
        Target = 0,
        Screen = 1
    }

    public enum AnimationPosition
    {
        Up = 0,
        Middle = 1,
        Down = 2
    }

    [LcfChunk<AnimationChunk>]
    public class Animation
    {
        public static readonly Dictionary<AnimationScope, string> ScopeTags = new Dictionary<AnimationScope, string>
        {
            { AnimationScope.Target, "target" },
            { AnimationScope.Screen, "screen" }
        };

        public static readonly Dictionary<AnimationPosition, string> PositionTags = new Dictionary<AnimationPosition, string>
        {
            { AnimationPosition.Up, "up" },
            { AnimationPosition.Middle, "middle" },
            { AnimationPosition.Down, "down" }
        };

        [LcfID]
        public int ID
        {
            get;
            set;
        }
[LcfAlwaysPersistAttribute]
		public DbString Name
        {
            get;
            set;
        }
[LcfAlwaysPersistAttribute]
		public DbString AnimationName
        {
            get;
            set;
        }

        public bool Large
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public List<AnimationTiming> Timings
        {
            get;
            set;
        } = [];

        [LcfAlwaysPersistAttribute]
        public AnimationScope Scope
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public AnimationPosition Position
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public List<AnimationFrame> Frames
        {
            get;
            set;
        } = [];
    }
}