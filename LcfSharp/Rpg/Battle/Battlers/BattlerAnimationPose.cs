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

using LcfSharp.Chunks.Database.Battle;
using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg.Battle.Battlers
{
    /// <summary>
    /// Class representing a pose in a battler animation.
    /// </summary>
    [LcfChunk<BattlerAnimationPoseChunk>]
    public class BattlerAnimationPose
    {
        /// <summary>
        /// The unique identifier for the battler animation pose.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The name of the battler animation pose.
        /// </summary>
        [LcfAlwaysPersist]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the battler graphic.
        /// </summary>
        [LcfAlwaysPersist]
        public string BattlerName
        {
            get;
            set;
        }

        /// <summary>
        /// The index of the battler graphic.
        /// </summary>
        public int BattlerIndex
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The animation type of the battler animation pose.
        /// </summary>
        public BattlerAnimationPoseAnimType AnimationType
        {
            get;
            set;
        } = BattlerAnimationPoseAnimType.Character;

        /// <summary>
        /// The ID of the battle animation associated with the pose.
        /// </summary>
        public int BattleAnimationID
        {
            get;
            set;
        } = 1;
    }
}