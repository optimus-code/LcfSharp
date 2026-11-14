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

using LcfSharp.Chunks.Persistence;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types.Generic;
using LcfSharp.IO.Types;

namespace LcfSharp.Rpg.Persistence
{
    /// <summary>
    /// Represents Actor data in an LSD save file.
    /// </summary>
    [LcfChunk<SaveActorChunk>]
    public class SaveActor : IIndexedItem
    {
        public static readonly string EmptyName = "\x1";

        [LcfID]
        public int ID
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public LcfString Name
        {
            get;
            set;
        } = EmptyName;

        [LcfAlwaysPersist]
        public LcfString Title
        {
            get;
            set;
        } = EmptyName;

        public LcfString SpriteName
        {
            get;
            set;
        }

        public int SpriteID
        {
            get;
            set;
        }

        public int Transparency
        {
            get;
            set;
        }

        public LcfString FaceName
        {
            get;
            set;
        }

        public int FaceID
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        } = -1;

        public int Exp
        {
            get;
            set;
        } = -1;

        public int HPMod
        {
            get;
            set;
        } = -1;

        public int SPMod
        {
            get;
            set;
        } = -1;

        public int AttackMod
        {
            get;
            set;
        }

        public int DefenseMod
        {
            get;
            set;
        }

        public int SpiritMod
        {
            get;
            set;
        }

        public int AgilityMod
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        [LcfSize( ( int ) SaveActorChunk.SkillsSize, AlwaysPersist = true )]
        public LcfPackedList<short> Skills
        {
            get;
            set;
        } = [];

        [LcfAlwaysPersist]
        public LcfPackedList<short> Equipped
        {
            get;
            set;
        } = [0, 0, 0, 0, 0];

        public int CurrentHP
        {
            get;
            set;
        } = -1;

        public int CurrentSP
        {
            get;
            set;
        } = -1;

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public LcfPackedList<LcfFixedInt32> BattleCommands
        {
            get;
            set;
        } = [-1, -1, -1, -1, -1, -1, -1];

        [LcfAlwaysPersist]
        [LcfSize( ( int ) SaveActorChunk.StatusSize )]
        public LcfPackedList<short> Status
        {
            get;
            set;
        } = [];

        public bool ChangedBattleCommands
        {
            get;
            set;
        }

        public int ClassID
        {
            get;
            set;
        } = -1;

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int Row
        {
            get;
            set;
        }

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public bool TwoWeapon
        {
            get;
            set;
        }

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public bool LockEquipment
        {
            get;
            set;
        }

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public bool AutoBattle
        {
            get;
            set;
        }

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public bool SuperGuard
        {
            get;
            set;
        }

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int BattlerAnimation
        {
            get;
            set;
        }
    }
}