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

using LcfSharp.Chunks.Database.Enemies;
using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg.Enemies
{
    public enum EnemyActionKind
    {
        Basic = 0,
        Skill = 1,
        Transformation = 2
    }

    public enum EnemyActionBasic
    {
        Attack = 0,
        DualAttack = 1,
        Defense = 2,
        Observe = 3,
        Charge = 4,
        Autodestruction = 5,
        Escape = 6,
        Nothing = 7
    }

    public enum EnemyActionConditionType
    {
        Always = 0,
        Switch = 1,
        Turn = 2,
        Actors = 3,
        HP = 4,
        SP = 5,
        PartyLvl = 6,
        PartyFatigue = 7
    }

    [LcfChunk<EnemyActionChunk>]
    public class EnemyAction
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public EnemyActionKind Kind
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public EnemyActionBasic Basic
        {
            get;
            set;
        }

        public int SkillID
        {
            get;
            set;
        }
        
        public int EnemyID
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public EnemyActionConditionType ConditionType
        {
            get;
            set;
        }

        public int ConditionParam1
        {
            get;
            set;
        }

        public int ConditionParam2
        {
            get;
            set;
        }

        public int SwitchID
        {
            get;
            set;
        }

        public bool SwitchOn
        {
            get;
            set;
        }

        public int SwitchOnID
        {
            get;
            set;
        }

        public bool SwitchOff
        {
            get;
            set;
        }

        public int SwitchOffID
        {
            get;
            set;
        }

        public int Rating
        {
            get;
            set;
        }
    }
}