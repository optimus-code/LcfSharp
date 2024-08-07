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

using LcfSharp.Chunks.Database.Enemies;
using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg.Enemies
{
    /// <summary>
    /// Class representing an enemy action.
    /// </summary>
    [LcfChunk<EnemyActionChunk>]
    public class EnemyAction
    {
        /// <summary>
        /// The unique identifier for the enemy action.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The kind of enemy action.
        /// </summary>
        [LcfAlwaysPersist]
        public EnemyActionKind Kind
        {
            get;
            set;
        }

        /// <summary>
        /// The basic enemy action.
        /// </summary>
        [LcfAlwaysPersist]
        public EnemyActionBasic Basic
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the skill used in the action.
        /// </summary>
        public int SkillID
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the enemy associated with the action.
        /// </summary>
        public int EnemyID
        {
            get;
            set;
        }

        /// <summary>
        /// The condition type for the action.
        /// </summary>
        [LcfAlwaysPersist]
        public EnemyActionConditionType ConditionType
        {
            get;
            set;
        }

        /// <summary>
        /// The first parameter for the condition.
        /// </summary>
        public int ConditionParam1
        {
            get;
            set;
        }

        /// <summary>
        /// The second parameter for the condition.
        /// </summary>
        public int ConditionParam2
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the switch used in the condition.
        /// </summary>
        public int SwitchID
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the switch is turned on.
        /// </summary>
        public bool SwitchOn
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the switch to turn on.
        /// </summary>
        public int SwitchOnID
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the switch is turned off.
        /// </summary>
        public bool SwitchOff
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the switch to turn off.
        /// </summary>
        public int SwitchOffID
        {
            get;
            set;
        }

        /// <summary>
        /// The rating of the action.
        /// </summary>
        public int Rating
        {
            get;
            set;
        }
    }
}