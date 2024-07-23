using LcfSharp.IO;
using LcfSharp.Rpg.Audio;
using LcfSharp.Rpg.Shared;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Animations
{
    public enum AnimationTimingChunk : int
    {
        /** Integer */
        Frame = 0x01,
        /** rpg::Sound */
        Se = 0x02,
        /** Integer */
        FlashScope = 0x03,
        /** Integer */
        FlashRed = 0x04,
        /** Integer */
        FlashGreen = 0x05,
        /** Integer */
        FlashBlue = 0x06,
        /** Integer */
        FlashPower = 0x07,
        /** Integer - This field RPG2003 only but commonly found in some 2k LDB's. We disable the is2k3 field on purpose because if its defaulted in 2k it won't be written anyway. */
        ScreenShake = 0x08
    }

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

        public AnimationTiming(LcfReader reader)
        {
            TypeHelpers.ReadChunks<AnimationTimingChunk>(reader, (chunk) =>
            {
                switch ((AnimationTimingChunk)chunk.ID)
                {
                    case AnimationTimingChunk.Frame:
                        Frame = reader.ReadInt();
                        return true;

                    case AnimationTimingChunk.Se:
                        Se = new Sound(reader);
                        return true;

                    case AnimationTimingChunk.FlashScope:
                        FlashScopeValue = reader.ReadInt();
                        return true;

                    case AnimationTimingChunk.FlashRed:
                        FlashRed = reader.ReadInt();
                        return true;

                    case AnimationTimingChunk.FlashGreen:
                        FlashGreen = reader.ReadInt();
                        return true;

                    case AnimationTimingChunk.FlashBlue:
                        FlashBlue = reader.ReadInt();
                        return true;

                    case AnimationTimingChunk.FlashPower:
                        FlashPower = reader.ReadInt();
                        return true;

                    case AnimationTimingChunk.ScreenShake:
                        if (!Database.IsRM2K3)
                            return false;
                        ScreenShakeValue = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}
