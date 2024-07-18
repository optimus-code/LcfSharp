using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Animations
{
    public class Animation
    {
        public enum AnimationScope
        {
            Target = 0,
            Screen = 1
        }

        public static readonly Dictionary<AnimationScope, string> ScopeTags = new Dictionary<AnimationScope, string>
        {
            { AnimationScope.Target, "target" },
            { AnimationScope.Screen, "screen" }
        };

        public enum AnimationPosition
        {
            Up = 0,
            Middle = 1,
            Down = 2
        }

        public static readonly Dictionary<AnimationPosition, string> PositionTags = new Dictionary<AnimationPosition, string>
        {
            { AnimationPosition.Up, "up" },
            { AnimationPosition.Middle, "middle" },
            { AnimationPosition.Down, "down" }
        };

        public int ID
        {
            get;
            set;
        }

        public DbString Name
        {
            get;
            set;
        }

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

        public List<AnimationTiming> Timings
        {
            get;
            set;
        }

        public int Scope
        {
            get;
            set;
        }

        public int Position
        {
            get;
            set;
        }

        public List<AnimationFrame> Frames
        {
            get;
            set;
        }
    }
}
