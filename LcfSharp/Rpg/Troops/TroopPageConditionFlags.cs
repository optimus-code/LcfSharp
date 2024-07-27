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

using LcfSharp.IO.Types;

namespace LcfSharp.Rpg.Troops
{
    /// <summary>
    /// Class representing the flags for troop page conditions.
    /// </summary>
    public class TroopPageConditionFlags : IDbFlags
    {
        /// <summary>
        /// Indicates if the condition is based on the first switch.
        /// </summary>
        public bool SwitchA
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if the condition is based on the second switch.
        /// </summary>
        public bool SwitchB
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if the condition is based on a variable.
        /// </summary>
        public bool Variable
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if the condition is based on turns.
        /// </summary>
        public bool Turn
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if the condition is based on fatigue.
        /// </summary>
        public bool Fatigue
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if the condition is based on the enemy's HP.
        /// </summary>
        public bool EnemyHP
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if the condition is based on the actor's HP.
        /// </summary>
        public bool ActorHP
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if the condition is based on the enemy's turn.
        /// </summary>
        public bool TurnEnemy
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if the condition is based on the actor's turn.
        /// </summary>
        public bool TurnActor
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if the condition is based on the actor's command.
        /// </summary>
        public bool CommandActor
        {
            get;
            set;
        }
    }
}