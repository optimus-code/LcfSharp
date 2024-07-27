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
using LcfSharp.IO.Types;
using LcfSharp.Rpg.Shared;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Actors
{
    [LcfChunk<ActorChunk>]
    public class Actor
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

        [LcfAlwaysPersist]
		public string Title
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
		public string CharacterName
        {
            get;
            set;
        }

        public int CharacterIndex
        {
            get;
            set;
        } = 0;

        public bool Transparent
        {
            get;
            set;
        } = false;

        public int InitialLevel
        {
            get;
            set;
        } = 1;

        public int FinalLevel
        {
            get;
            set;
        } = -1;

        public bool CriticalHit
        {
            get;
            set;
        } = true;

        public int CriticalHitChance
        {
            get;
            set;
        } = 30;
        
        [LcfAlwaysPersist]
		public string FaceName
        {
            get;
            set;
        }

        public int FaceIndex
        {
            get;
            set;
        } = 0;

        public bool TwoWeapon
        {
            get;
            set;
        } = false;

        public bool LockEquipment
        {
            get;
            set;
        } = false;

        public bool AutoBattle
        {
            get;
            set;
        } = false;

        public bool SuperGuard
        {
            get;
            set;
        } = false;

        [LcfAlwaysPersist]
        public Parameters Parameters
        {
            get;
            set;
        }

        public int ExpBase
        {
            get;
            set;
        } = -1;

        public int ExpInflation
        {
            get;
            set;
        } = -1;

        public int ExpCorrection
        {
            get;
            set;
        } = 0;

        [LcfAlwaysPersist]
        public Equipment InitialEquipment
        {
            get;
            set;
        }

        public int UnarmedAnimation
        {
            get;
            set;
        } = 1;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int ClassId
        {
            get;
            set;
        } = 0;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int BattleX
        {
            get;
            set;
        } = 220;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int BattleY
        {
            get;
            set;
        } = 120;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int BattlerAnimation
        {
            get;
            set;
        } = 1;


        [LcfAlwaysPersist]
        public List<Learning> Skills
        {
            get; set;
        } = [];

        public bool RenameSkill
        {
            get;
            set;
        } = false;

		public string SkillName
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        [LcfSize(( int ) ActorChunk.StateRanksSize)]
        public List<byte> StateRanks
        {
            get;
            set;
        } = [];

        [LcfAlwaysPersist]
        [LcfSize(( int ) ActorChunk.AttributeRanksSize)]
        public List<byte> AttributeRanks
        {
            get;
            set;
        } = [];

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public List<int> BattleCommands
        {
            get;
            set;
        } = [];
    }
}