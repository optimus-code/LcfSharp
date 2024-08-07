﻿/// <copyright>
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

namespace LcfSharp.Rpg.Animations
{
    /// <summary>
    /// Class representing cell data for an animation.
    /// </summary>
    [LcfChunk<AnimationCellDataChunk>]
    public class AnimationCellData
    {
        /// <summary>
        /// The unique identifier for the animation cell data.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the cell data is valid.
        /// </summary>
        public int Valid
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the cell.
        /// </summary>
        public int CellID
        {
            get;
            set;
        }

        /// <summary>
        /// The X-coordinate of the cell.
        /// </summary>
        public int X
        {
            get;
            set;
        }

        /// <summary>
        /// The Y-coordinate of the cell.
        /// </summary>
        public int Y
        {
            get;
            set;
        }

        /// <summary>
        /// The zoom level of the cell.
        /// </summary>
        public int Zoom
        {
            get;
            set;
        }

        /// <summary>
        /// The red tone value of the cell.
        /// </summary>
        public int ToneRed
        {
            get;
            set;
        }

        /// <summary>
        /// The green tone value of the cell.
        /// </summary>
        public int ToneGreen
        {
            get;
            set;
        }

        /// <summary>
        /// The blue tone value of the cell.
        /// </summary>
        public int ToneBlue
        {
            get;
            set;
        }

        /// <summary>
        /// The gray tone value of the cell.
        /// </summary>
        public int ToneGray
        {
            get;
            set;
        }

        /// <summary>
        /// The transparency level of the cell.
        /// </summary>
        public int Transparency
        {
            get;
            set;
        }
    }
}