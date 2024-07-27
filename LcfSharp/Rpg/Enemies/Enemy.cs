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
    [LcfChunk<EnemyChunk>]
    public class Enemy
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string BattlerName
        {
            get;
            set;
        }

        public int BattlerHue
        {
            get;
            set;
        }

        public int MaxHP
        {
            get;
            set;
        }

        public int MaxSP
        {
            get;
            set;
        }

        public int Attack
        {
            get;
            set;
        }

        public int Defense
        {
            get;
            set;
        }

        public int Spirit
        {
            get;
            set;
        }

        public int Agility
        {
            get;
            set;
        }
        
        public bool Transparent
        {
            get;
            set;
        }

        public int Exp
        {
            get;
            set;
        }

        public int Gold
        {
            get;
            set;
        }

        public int DropID
        {
            get;
            set;
        }

        public int DropProb
        {
            get;
            set;
        }

        public bool CriticalHit
        {
            get;
            set;
        }

        public int CriticalHitChance
        {
            get;
            set;
        }

        public bool Miss
        {
            get;
            set;
        }

        public bool Levitate
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        [LcfSize(( int ) EnemyChunk.StateRanksSize)]
        public List<byte> StateRanks
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        [LcfSize(( int ) EnemyChunk.AttributeRanksSize)]
        public List<byte> AttributeRanks
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public List<EnemyAction> Actions
        {
            get;
            set;
        }
    }
}