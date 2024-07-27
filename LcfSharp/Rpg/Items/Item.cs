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

namespace LcfSharp.Rpg.Items
{
    public enum ItemType : int
    {
        Normal = 0,
        Weapon = 1,
        Shield = 2,
        Armor = 3,
        Helmet = 4,
        Accessory = 5,
        Medicine = 6,
        Book = 7,
        Material = 8,
        Special = 9,
        Switch = 10
    }

    public enum ItemTrajectory : int
    {
        Straight = 0,
        Return = 1
    }

    public enum ItemTarget : int
    {
        Single = 0,
        Center = 1,
        Simultaneous = 2,
        Sequential = 3
    }

    [LcfChunk<ItemChunk>]
    public class Item
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

        public string Description
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public ItemType Type
        {
            get;
            set;
        }

        public int Price
        {
            get;
            set;
        }

        public int Uses
        {
            get;
            set;
        }

        public int AtkPoints1
        {
            get;
            set;
        }

        public int DefPoints1
        {
            get;
            set;
        }

        public int SpiPoints1
        {
            get;
            set;
        }

        public int AgiPoints1
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public bool TwoHanded
        {
            get;
            set;
        }

        public int SPCost
        {
            get;
            set;
        }

        public int Hit
        {
            get;
            set;
        }

        public int CriticalHit
        {
            get;
            set;
        }

        public int AnimationID
        {
            get;
            set;
        }

        public bool Preemptive
        {
            get;
            set;
        }

        public bool DualAttack
        {
            get;
            set;
        }

        public bool AttackAll
        {
            get;
            set;
        }

        public bool IgnoreEvasion
        {
            get;
            set;
        }

        public bool PreventCritical
        {
            get;
            set;
        }

        public bool RaiseEvasion
        {
            get;
            set;
        }

        public bool HalfSPCost
        {
            get;
            set;
        }

        public bool NoTerrainDamage
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public bool Cursed
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public bool EntireParty
        {
            get;
            set;
        }

        public int RecoverHPRate
        {
            get;
            set;
        }

        public int RecoverHP
        {
            get;
            set;
        }

        public int RecoverSPRate
        {
            get;
            set;
        }

        public int RecoverSP
        {
            get;
            set;
        }

        public bool OccasionField1
        {
            get;
            set;
        }

        public bool KOOnly
        {
            get;
            set;
        }

        public int MaxHPPoints
        {
            get;
            set;
        }

        public int MaxSPPoints
        {
            get;
            set;
        }

        public int AtkPoints2
        {
            get;
            set;
        }

        public int DefPoints2
        {
            get;
            set;
        }

        public int SpiPoints2
        {
            get;
            set;
        }

        public int AgiPoints2
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public int UsingMessage
        {
            get;
            set;
        }

        public int SkillID
        {
            get;
            set;
        }

        public int SwitchID
        {
            get;
            set;
        }

        public bool OccasionField2
        {
            get;
            set;
        }

        public bool OccasionBattle
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        [LcfSize(( int ) ItemChunk.ActorSetSize)]
        public List<bool> ActorSet
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        [LcfSize(( int ) ItemChunk.StateSetSize)]
        public List<bool> StateSet
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        [LcfSize(( int ) ItemChunk.AttributeSetSize)]
        public List<bool> AttributeSet
        {
            get;
            set;
        }

        public int StateChance
        {
            get;
            set;
        }

        public bool ReverseStateEffect
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int WeaponAnimation
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public List<BattlerAnimationItemSkill> AnimationData
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public bool UseSkill
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        [LcfSize(( int ) ItemChunk.ClassSetSize)]
        public List<bool> ClassSet
        {
            get;
            set;
        }

        public ItemTrajectory RangedTrajectory
        {
            get;
            set;
        }

        public ItemTarget RangedTarget
        {
            get;
            set;
        }
    }
}