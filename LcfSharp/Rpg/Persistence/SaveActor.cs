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

using System.Collections.Generic;

namespace LcfSharp.Rpg.Persistence
{
    public enum SaveActorRowType
    {
        Front = 0,
        Back = 1
    }

    public class SaveActor
    {
        public static readonly Dictionary<SaveActorRowType, string> RowTypeTags = new Dictionary<SaveActorRowType, string>
        {
            { SaveActorRowType.Front, "front" },
            { SaveActorRowType.Back, "back" }
        };

        // Sentinel name used to denote that the default LDB name should be used.
        public static readonly string EmptyName = "\x1";

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        } = EmptyName;

        public string Title
        {
            get;
            set;
        } = EmptyName;

        public string SpriteName
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

        public string FaceName
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

        public List<short> Skills
        {
            get;
            set;
        } = [];

        public List<short> Equipped
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

        public List<int> BattleCommands
        {
            get;
            set;
        } = [-1, -1, -1, -1, -1, -1, -1];

        public List<short> Status
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

        public int Row
        {
            get;
            set;
        }

        public bool TwoWeapon
        {
            get;
            set;
        }

        public bool LockEquipment
        {
            get;
            set;
        }

        public bool AutoBattle
        {
            get;
            set;
        }

        public bool SuperGuard
        {
            get;
            set;
        }

        public int BattlerAnimation
        {
            get;
            set;
        }
    }

}
