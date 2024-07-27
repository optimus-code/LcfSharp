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
    [LcfChunk<AnimationTimingChunk>]
    public class AnimationTiming
    {
        public enum AnimationFlashScope
        {
            Nothing = 0,
            Target = 1,
            Screen = 2
        }

        public enum AnimationScreenShake
        {
            Nothing = 0,
            Target = 1,
            Screen = 2
        }

        [LcfID]
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

        [LcfAlwaysPersist]
        public Sound Se
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public int FlashScope
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