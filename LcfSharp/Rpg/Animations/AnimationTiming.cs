using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Audio;
using LcfSharp.Rpg.Shared;
using System.Collections.Generic;
using System.Xml.Serialization;

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

    [LcfChunk<AnimationTimingChunk>]
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

        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Frame
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public Sound Se
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [XmlAttribute]
        public int FlashScope
        {
            get;
            set;
        }

        [XmlAttribute]
        public int FlashRed
        {
            get;
            set;
        }

        [XmlAttribute]
        public int FlashGreen
        {
            get;
            set;
        }

        [XmlAttribute]
        public int FlashBlue
        {
            get;
            set;
        }

        [XmlAttribute]
        public int FlashPower
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ScreenShakeValue
        {
            get;
            set;
        }
    }
}