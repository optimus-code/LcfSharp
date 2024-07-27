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
using System.Collections.Generic;

namespace LcfSharp.Rpg.Animations
{
    /// <summary>
    /// Class representing an animation.
    /// </summary>
    [LcfChunk<AnimationChunk>]
    public class Animation
    {
        /// <summary>
        /// The unique identifier for the animation.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the animation.
        /// </summary>
        [LcfAlwaysPersist]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the animation file.
        /// </summary>
        [LcfAlwaysPersist]
        public string AnimationName
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the animation is large.
        /// </summary>
        public bool Large
        {
            get;
            set;
        }

        /// <summary>
        /// The list of timings for the animation.
        /// </summary>
        [LcfAlwaysPersist]
        public List<AnimationTiming> Timings
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The scope of the animation.
        /// </summary>
        [LcfAlwaysPersist]
        public AnimationScope Scope
        {
            get;
            set;
        }

        /// <summary>
        /// The position of the animation.
        /// </summary>
        [LcfAlwaysPersist]
        public AnimationPosition Position
        {
            get;
            set;
        }

        /// <summary>
        /// The list of frames for the animation.
        /// </summary>
        [LcfAlwaysPersist]
        public List<AnimationFrame> Frames
        {
            get;
            set;
        } = [];
    }
}