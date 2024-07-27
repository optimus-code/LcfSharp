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

using LcfSharp.Chunks.Database;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Shared;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Classes
{
    /// <summary>
    /// Class representing a character class in the game.
    /// </summary>
    [LcfChunk<ClassChunk>]
    public class Class
    {
        /// <summary>
        /// The unique identifier for the class.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the class.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the class can wield two weapons.
        /// </summary>
        public bool TwoWeapon
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the class's equipment is locked.
        /// </summary>
        public bool LockEquipment
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the class is set to auto-battle.
        /// </summary>
        public bool AutoBattle
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the class has super guard ability.
        /// </summary>
        public bool SuperGuard
        {
            get;
            set;
        }

        /// <summary>
        /// The parameters of the class.
        /// </summary>
        public Parameters Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// The base experience points for the class.
        /// </summary>
        public int ExpBase
        {
            get;
            set;
        }

        /// <summary>
        /// The experience inflation rate for the class.
        /// </summary>
        public int ExpInflation
        {
            get;
            set;
        }

        /// <summary>
        /// The experience correction value for the class.
        /// </summary>
        public int ExpCorrection
        {
            get;
            set;
        }

        /// <summary>
        /// The battler animation ID for the class.
        /// </summary>
        public int BattlerAnimation
        {
            get;
            set;
        }

        /// <summary>
        /// The list of skills the class can learn.
        /// </summary>
        [LcfAlwaysPersist]
        public List<Learning> Skills
        {
            get;
            set;
        }

        /// <summary>
        /// The state ranks of the class.
        /// </summary>
        [LcfAlwaysPersist]
        [LcfSize( ( int ) ClassChunk.StateRanksSize )]
        public List<byte> StateRanks
        {
            get;
            set;
        }

        /// <summary>
        /// The attribute ranks of the class.
        /// </summary>
        [LcfAlwaysPersist]
        [LcfSize( ( int ) ClassChunk.AttributeRanksSize )]
        public List<byte> AttributeRanks
        {
            get;
            set;
        }

        /// <summary>
        /// The battle commands for the class.
        /// </summary>
        [LcfAlwaysPersist]
        public List<int> BattleCommands
        {
            get;
            set;
        }
    }
}