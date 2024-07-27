/// <copyright>
/// 
/// LcfSharp Copyright (c) 2024 optimus-code
/// (A "loose" .NET port of liblcf)
/// Licensed under the MIT License.
/// 
/// Copyright (c) 2014-2023 liblcf authors
/// Licensed under the MIT License.
/// 
/// Permission is hereby granted, free of charge, to any person obtaining
/// a copy of this software and associated documentation files (the
/// "Software"), to deal in the Software without restriction, including
/// without limitation the rights to use, copy, modify, merge, publish,
/// distribute, sublicense, and/or sell copies of the Software, and to
/// permit persons to whom the Software is furnished to do so, subject to
/// the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included
/// in all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
/// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
/// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
/// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
/// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
/// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
/// </copyright>

using LcfSharp.Chunks.Database.Animation;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Audio;

namespace LcfSharp.Rpg.Animations
{
    /// <summary>
    /// Class representing the timing of an animation.
    /// </summary>
    [LcfChunk<AnimationTimingChunk>]
    public class AnimationTiming
    {
        /// <summary>
        /// The unique identifier for the animation timing.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The frame at which the timing occurs.
        /// </summary>
        public int Frame
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect to play at the timing.
        /// </summary>
        [LcfAlwaysPersist]
        public Sound Se
        {
            get;
            set;
        }

        /// <summary>
        /// The scope of the flash effect.
        /// </summary>
        [LcfAlwaysPersist]
        public AnimationFlashScope FlashScope
        {
            get;
            set;
        }

        /// <summary>
        /// The red component of the flash color.
        /// </summary>
        public int FlashRed
        {
            get;
            set;
        }

        /// <summary>
        /// The green component of the flash color.
        /// </summary>
        public int FlashGreen
        {
            get;
            set;
        }

        /// <summary>
        /// The blue component of the flash color.
        /// </summary>
        public int FlashBlue
        {
            get;
            set;
        }

        /// <summary>
        /// The power of the flash effect.
        /// </summary>
        public int FlashPower
        {
            get;
            set;
        }

        /// <summary>
        /// The screen shake effect.
        /// </summary>
        public AnimationScreenShake ScreenShakeValue
        {
            get;
            set;
        }
    }
}