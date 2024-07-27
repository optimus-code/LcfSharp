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
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationSpeed : int
    {
        Slow = 20,
        Medium = 14,
        Fast = 8
    }

    public enum BattlerAnimationPoses : int
    {
        Idle = 0,
        AttackRight = 1,
        AttackLeft = 2,
        Skill = 3,
        Dead = 4,
        Damage = 5,
        Dazed = 6,
        Defend = 7,
        WalkLeft = 8,
        WalkRight = 9,
        Victory = 10,
        Item = 11
    }

    [LcfChunk<BattlerAnimationChunk>]
    public class BattlerAnimation
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        } = 0;

        [LcfAlwaysPersist]
		public string Name
        {
            get;
            set;
        }

        public BattlerAnimationSpeed Speed
        {
            get;
            set;
        } = BattlerAnimationSpeed.Slow;

        [LcfAlwaysPersist]
        public List<BattlerAnimationPose> Poses
        {
            get;
            set;
        } = [];

        [LcfAlwaysPersist]
        public List<BattlerAnimationWeapon> Weapons
        {
            get;
            set;
        } = [];
    }
}