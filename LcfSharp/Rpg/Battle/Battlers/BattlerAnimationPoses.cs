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

namespace LcfSharp.Rpg.Battle.Battlers
{
    /// <summary>
    /// Enum representing the different poses of a battler animation.
    /// </summary>
    public enum BattlerAnimationPoses : int
    {
        /// <summary>
        /// Idle pose.
        /// </summary>
        Idle = 0,

        /// <summary>
        /// Attack to the right pose.
        /// </summary>
        AttackRight = 1,

        /// <summary>
        /// Attack to the left pose.
        /// </summary>
        AttackLeft = 2,

        /// <summary>
        /// Skill pose.
        /// </summary>
        Skill = 3,

        /// <summary>
        /// Dead pose.
        /// </summary>
        Dead = 4,

        /// <summary>
        /// Damage pose.
        /// </summary>
        Damage = 5,

        /// <summary>
        /// Dazed pose.
        /// </summary>
        Dazed = 6,

        /// <summary>
        /// Defend pose.
        /// </summary>
        Defend = 7,

        /// <summary>
        /// Walk to the left pose.
        /// </summary>
        WalkLeft = 8,

        /// <summary>
        /// Walk to the right pose.
        /// </summary>
        WalkRight = 9,

        /// <summary>
        /// Victory pose.
        /// </summary>
        Victory = 10,

        /// <summary>
        /// Item use pose.
        /// </summary>
        Item = 11
    }
}