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

using LcfSharp.Chunks.Database.Troops;
using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg.Troops
{
    /// <summary>
    /// Class representing the conditions for a troop page.
    /// </summary>
    [LcfChunk<TroopPageConditionChunk>]
    public class TroopPageCondition
    {
        /// <summary>
        /// The flags for the troop page condition.
        /// </summary>
        [LcfAlwaysPersist]
        public TroopPageConditionFlags Flags
        {
            get;
            set;
        } = new TroopPageConditionFlags( );

        /// <summary>
        /// The ID of the first switch for the condition. Default is 1.
        /// </summary>
        public int SwitchAID
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The ID of the second switch for the condition. Default is 1.
        /// </summary>
        public int SwitchBID
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The ID of the variable for the condition. Default is 1.
        /// </summary>
        public int VariableID
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The value of the variable for the condition.
        /// </summary>
        public int VariableValue
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum turn value for the condition.
        /// </summary>
        public int TurnA
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum turn value for the condition.
        /// </summary>
        public int TurnB
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum fatigue value for the condition.
        /// </summary>
        public int FatigueMin
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum fatigue value for the condition. Default is 100.
        /// </summary>
        public int FatigueMax
        {
            get;
            set;
        } = 100;

        /// <summary>
        /// The ID of the enemy for the condition.
        /// </summary>
        public int EnemyID
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum HP value for the enemy.
        /// </summary>
        public int EnemyHPMin
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum HP value for the enemy. Default is 100.
        /// </summary>
        public int EnemyHPMax
        {
            get;
            set;
        } = 100;

        /// <summary>
        /// The ID of the actor for the condition. Default is 1.
        /// </summary>
        public int ActorID
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The minimum HP value for the actor.
        /// </summary>
        public int ActorHPMin
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum HP value for the actor. Default is 100.
        /// </summary>
        public int ActorHPMax
        {
            get;
            set;
        } = 100;

        /// <summary>
        /// The ID of the enemy turn for the condition.
        /// </summary>
        public int TurnEnemyID
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum enemy turn value for the condition.
        /// </summary>
        public int TurnEnemyA
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum enemy turn value for the condition.
        /// </summary>
        public int TurnEnemyB
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the actor turn for the condition. Default is 1.
        /// </summary>
        public int TurnActorID
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The minimum actor turn value for the condition.
        /// </summary>
        public int TurnActorA
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum actor turn value for the condition.
        /// </summary>
        public int TurnActorB
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the actor command for the condition. Default is 1.
        /// </summary>
        public int CommandActorID
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The ID of the command for the condition. Default is 1.
        /// </summary>
        public int CommandID
        {
            get;
            set;
        } = 1;
    }
}