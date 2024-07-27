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
    /// <summary>
    /// Class representing an actor in the game.
    /// </summary>
    [LcfChunk<ActorChunk>]
    public class Actor
    {
        /// <summary>
        /// The unique identifier for the actor. Default is 0.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The name of the actor.
        /// </summary>
        [LcfAlwaysPersist]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The title of the actor.
        /// </summary>
        [LcfAlwaysPersist]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the character graphic.
        /// </summary>
        [LcfAlwaysPersist]
        public string CharacterName
        {
            get;
            set;
        }

        /// <summary>
        /// The index of the character graphic. Default is 0.
        /// </summary>
        public int CharacterIndex
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Indicates whether the actor is transparent. Default is false.
        /// </summary>
        public bool Transparent
        {
            get;
            set;
        } = false;

        /// <summary>
        /// The initial level of the actor. Default is 1.
        /// </summary>
        public int InitialLevel
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The final level of the actor. Default is -1.
        /// </summary>
        public int FinalLevel
        {
            get;
            set;
        } = -1;

        /// <summary>
        /// Indicates whether the actor can perform critical hits. Default is true.
        /// </summary>
        public bool CriticalHit
        {
            get;
            set;
        } = true;

        /// <summary>
        /// The chance of performing a critical hit. Default is 30.
        /// </summary>
        public int CriticalHitChance
        {
            get;
            set;
        } = 30;

        /// <summary>
        /// The name of the face graphic.
        /// </summary>
        [LcfAlwaysPersist]
        public string FaceName
        {
            get;
            set;
        }

        /// <summary>
        /// The index of the face graphic. Default is 0.
        /// </summary>
        public int FaceIndex
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Indicates whether the actor can wield two weapons. Default is false.
        /// </summary>
        public bool TwoWeapon
        {
            get;
            set;
        } = false;

        /// <summary>
        /// Indicates whether the actor's equipment is locked. Default is false.
        /// </summary>
        public bool LockEquipment
        {
            get;
            set;
        } = false;

        /// <summary>
        /// Indicates whether the actor is set to auto-battle. Default is false.
        /// </summary>
        public bool AutoBattle
        {
            get;
            set;
        } = false;

        /// <summary>
        /// Indicates whether the actor has super guard ability. Default is false.
        /// </summary>
        public bool SuperGuard
        {
            get;
            set;
        } = false;

        /// <summary>
        /// The parameters of the actor.
        /// </summary>
        [LcfAlwaysPersist]
        public Parameters Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// The base experience points for the actor. Default is -1.
        /// </summary>
        public int ExpBase
        {
            get;
            set;
        } = -1;

        /// <summary>
        /// The experience inflation rate for the actor. Default is -1.
        /// </summary>
        public int ExpInflation
        {
            get;
            set;
        } = -1;

        /// <summary>
        /// The experience correction value for the actor. Default is 0.
        /// </summary>
        public int ExpCorrection
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The initial equipment of the actor.
        /// </summary>
        [LcfAlwaysPersist]
        public Equipment InitialEquipment
        {
            get;
            set;
        }

        /// <summary>
        /// The animation ID for the unarmed attack. Default is 1.
        /// </summary>
        public int UnarmedAnimation
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The class ID of the actor. Only available in RM2K3. Default is 0.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int ClassID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The X-coordinate of the actor in battle. Only available in RM2K3. Default is 220.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int BattleX
        {
            get;
            set;
        } = 220;

        /// <summary>
        /// The Y-coordinate of the actor in battle. Only available in RM2K3. Default is 120.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int BattleY
        {
            get;
            set;
        } = 120;

        /// <summary>
        /// The battler animation ID for the actor. Only available in RM2K3. Default is 1.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int BattlerAnimation
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The list of skills the actor can learn.
        /// </summary>
        [LcfAlwaysPersist]
        public List<Learning> Skills
        {
            get;
            set;
        } = [];

        /// <summary>
        /// Indicates whether the skill name can be renamed. Default is false.
        /// </summary>
        public bool RenameSkill
        {
            get;
            set;
        } = false;

        /// <summary>
        /// The custom name of the skill.
        /// </summary>
        public string SkillName
        {
            get;
            set;
        }

        /// <summary>
        /// The state ranks of the actor.
        /// </summary>
        [LcfAlwaysPersist]
        [LcfSize( ( int ) ActorChunk.StateRanksSize )]
        public List<byte> StateRanks
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The attribute ranks of the actor.
        /// </summary>
        [LcfAlwaysPersist]
        [LcfSize( ( int ) ActorChunk.AttributeRanksSize )]
        public List<byte> AttributeRanks
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The battle commands for the actor. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public List<int> BattleCommands
        {
            get;
            set;
        } = [];
    }
}