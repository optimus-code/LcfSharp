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
using System.Collections.Generic;

namespace LcfSharp.Rpg.Enemies
{
    /// <summary>
    /// Class representing an enemy in the game.
    /// </summary>
    [LcfChunk<EnemyChunk>]
    public class Enemy
    {
        /// <summary>
        /// The unique identifier for the enemy.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the enemy.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the battler graphic.
        /// </summary>
        public string BattlerName
        {
            get;
            set;
        }

        /// <summary>
        /// The hue of the battler graphic.
        /// </summary>
        public int BattlerHue
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum HP of the enemy.
        /// </summary>
        public int MaxHP
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum SP of the enemy.
        /// </summary>
        public int MaxSP
        {
            get;
            set;
        }

        /// <summary>
        /// The attack power of the enemy.
        /// </summary>
        public int Attack
        {
            get;
            set;
        }

        /// <summary>
        /// The defense power of the enemy.
        /// </summary>
        public int Defense
        {
            get;
            set;
        }

        /// <summary>
        /// The spirit power of the enemy.
        /// </summary>
        public int Spirit
        {
            get;
            set;
        }

        /// <summary>
        /// The agility of the enemy.
        /// </summary>
        public int Agility
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the enemy is transparent.
        /// </summary>
        public bool Transparent
        {
            get;
            set;
        }

        /// <summary>
        /// The experience points awarded for defeating the enemy.
        /// </summary>
        public int Exp
        {
            get;
            set;
        }

        /// <summary>
        /// The amount of gold awarded for defeating the enemy.
        /// </summary>
        public int Gold
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the item dropped by the enemy.
        /// </summary>
        public int DropID
        {
            get;
            set;
        }

        /// <summary>
        /// The probability of the item being dropped.
        /// </summary>
        public int DropProb
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the enemy can perform critical hits.
        /// </summary>
        public bool CriticalHit
        {
            get;
            set;
        }

        /// <summary>
        /// The chance of performing a critical hit.
        /// </summary>
        public int CriticalHitChance
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the enemy can miss attacks.
        /// </summary>
        public bool Miss
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the enemy can levitate.
        /// </summary>
        public bool Levitate
        {
            get;
            set;
        }

        /// <summary>
        /// The state ranks of the enemy.
        /// </summary>
        [LcfAlwaysPersist]
        [LcfSize( ( int ) EnemyChunk.StateRanksSize )]
        public List<byte> StateRanks
        {
            get;
            set;
        }

        /// <summary>
        /// The attribute ranks of the enemy.
        /// </summary>
        [LcfAlwaysPersist]
        [LcfSize( ( int ) EnemyChunk.AttributeRanksSize )]
        public List<byte> AttributeRanks
        {
            get;
            set;
        }

        /// <summary>
        /// The list of actions the enemy can perform.
        /// </summary>
        [LcfAlwaysPersist]
        public List<EnemyAction> Actions
        {
            get;
            set;
        }
    }
}