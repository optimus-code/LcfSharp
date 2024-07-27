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
using LcfSharp.Rpg.Battle.Battlers;

namespace LcfSharp.Rpg.Shared
{
    public enum BattlerAnimationItemSkillSpeed : int
    {
        Fast = 0,
        Medium = 1,
        Slow = 2
    }

    public enum BattlerAnimationItemSkillAnimType : int
    {
        Weapon = 0,
        Battle = 1
    }

    public enum BattlerAnimationItemSkillMovement : int
    {
        None = 0,
        Step = 1,
        Jump = 2,
        Move = 3
    }

    public enum BattlerAnimationItemSkillAfterimage : int
    {
        None = 0,
        Add = 1
    }

    [LcfChunk<BattlerAnimationItemSkillChunk>]
    public class BattlerAnimationItemSkill
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        } = 0;

        public int Unknown02
        {
            get;
            set;
        } = 0;

        public BattlerAnimationItemSkillAnimType Type
        {
            get;
            set;
        } = 0;

        public int WeaponAnimationID
        {
            get;
            set;
        } = 0;

        public BattlerAnimationItemSkillMovement Movement
        {
            get;
            set;
        } = 0;

        public BattlerAnimationItemSkillAfterimage AfterImage
        {
            get;
            set;
        } = 0;

        public int Attacks
        {
            get;
            set;
        } = 0;

        public bool Ranged
        {
            get;
            set;
        } = false;

        public int RangedAnimationID
        {
            get;
            set;
        } = 0;

        public int RangedSpeed
        {
            get;
            set;
        } = 0;

        public int BattleAnimationID
        {
            get;
            set;
        } = 1;

        public BattlerAnimationPoses Pose
        {
            get;
            set;
        } = BattlerAnimationPoses.Skill;
    }
}