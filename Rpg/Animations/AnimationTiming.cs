using LcfSharp.Rpg.Audio;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Animations
{
    public class AnimationTiming
    {
        public enum AnimationFlashScope
        {
            Nothing = 0,
            Target = 1,
            Screen = 2
        }

        public static readonly Dictionary<AnimationFlashScope, string> FlashScopeTags = new Dictionary<AnimationFlashScope, string>
        {
            { AnimationFlashScope.Nothing, "nothing" },
            { AnimationFlashScope.Target, "target" },
            { AnimationFlashScope.Screen, "screen" }
        };

        public enum AnimationScreenShake
        {
            Nothing = 0,
            Target = 1,
            Screen = 2
        }

        public static readonly Dictionary<AnimationScreenShake, string> ScreenShakeTags = new Dictionary<AnimationScreenShake, string>
        {
            { AnimationScreenShake.Nothing, "nothing" },
            { AnimationScreenShake.Target, "target" },
            { AnimationScreenShake.Screen, "screen" }
        };

        public int ID
        {
            get;
            set;
        }

        public int Frame
        {
            get;
            set;
        }

        public Sound Se
        {
            get;
            set;
        }

        public int FlashScopeValue
        {
            get;
            set;
        }

        public int FlashRed
        {
            get;
            set;
        }

        public int FlashGreen
        {
            get;
            set;
        }

        public int FlashBlue
        {
            get;
            set;
        }

        public int FlashPower
        {
            get;
            set;
        }

        public int ScreenShakeValue
        {
            get;
            set;
        }
    }
}
