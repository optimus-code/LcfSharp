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
using LcfSharp.Rpg.Battle.Battlers.ItemSkills;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Items
{
    /// <summary>
    /// Class representing an item in the game.
    /// </summary>
    [LcfChunk<ItemChunk>]
    public class Item
    {
        /// <summary>
        /// The unique identifier for the item.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the item.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The description of the item.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// The type of the item.
        /// </summary>
        [LcfAlwaysPersist]
        public ItemType Type
        {
            get;
            set;
        }

        /// <summary>
        /// The price of the item.
        /// </summary>
        public int Price
        {
            get;
            set;
        }

        /// <summary>
        /// The number of uses for the item.
        /// </summary>
        public int Uses
        {
            get;
            set;
        }

        /// <summary>
        /// The attack points added by the item.
        /// </summary>
        public int AtkPoints1
        {
            get;
            set;
        }

        /// <summary>
        /// The defense points added by the item.
        /// </summary>
        public int DefPoints1
        {
            get;
            set;
        }

        /// <summary>
        /// The spirit points added by the item.
        /// </summary>
        public int SpiPoints1
        {
            get;
            set;
        }

        /// <summary>
        /// The agility points added by the item.
        /// </summary>
        public int AgiPoints1
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item is two-handed.
        /// </summary>
        [LcfAlwaysPersist]
        public bool TwoHanded
        {
            get;
            set;
        }

        /// <summary>
        /// The SP cost of the item.
        /// </summary>
        public int SPCost
        {
            get;
            set;
        }

        /// <summary>
        /// The hit rate of the item.
        /// </summary>
        public int Hit
        {
            get;
            set;
        }

        /// <summary>
        /// The critical hit rate of the item.
        /// </summary>
        public int CriticalHit
        {
            get;
            set;
        }

        /// <summary>
        /// The animation ID associated with the item.
        /// </summary>
        public int AnimationID
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item allows preemptive attacks.
        /// </summary>
        public bool Preemptive
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item allows dual attacks.
        /// </summary>
        public bool DualAttack
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item attacks all targets.
        /// </summary>
        public bool AttackAll
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item ignores evasion.
        /// </summary>
        public bool IgnoreEvasion
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item prevents critical hits.
        /// </summary>
        public bool PreventCritical
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item raises evasion.
        /// </summary>
        public bool RaiseEvasion
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item halves SP cost.
        /// </summary>
        public bool HalfSPCost
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item prevents terrain damage.
        /// </summary>
        public bool NoTerrainDamage
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item is cursed (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public bool Cursed
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item affects the entire party.
        /// </summary>
        [LcfAlwaysPersist]
        public bool EntireParty
        {
            get;
            set;
        }

        /// <summary>
        /// The HP recovery rate of the item.
        /// </summary>
        public int RecoverHPRate
        {
            get;
            set;
        }

        /// <summary>
        /// The amount of HP recovered by the item.
        /// </summary>
        public int RecoverHP
        {
            get;
            set;
        }

        /// <summary>
        /// The SP recovery rate of the item.
        /// </summary>
        public int RecoverSPRate
        {
            get;
            set;
        }

        /// <summary>
        /// The amount of SP recovered by the item.
        /// </summary>
        public int RecoverSP
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item can be used on the field.
        /// </summary>
        public bool OccasionField1
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item can only be used on KO'd characters.
        /// </summary>
        public bool KOOnly
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum HP points added by the item.
        /// </summary>
        public int MaxHPPoints
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum SP points added by the item.
        /// </summary>
        public int MaxSPPoints
        {
            get;
            set;
        }

        /// <summary>
        /// The secondary attack points added by the item.
        /// </summary>
        public int AtkPoints2
        {
            get;
            set;
        }

        /// <summary>
        /// The secondary defense points added by the item.
        /// </summary>
        public int DefPoints2
        {
            get;
            set;
        }

        /// <summary>
        /// The secondary spirit points added by the item.
        /// </summary>
        public int SpiPoints2
        {
            get;
            set;
        }

        /// <summary>
        /// The secondary agility points added by the item.
        /// </summary>
        public int AgiPoints2
        {
            get;
            set;
        }

        /// <summary>
        /// The message displayed when the item is used.
        /// </summary>
        [LcfAlwaysPersist]
        public int UsingMessage
        {
            get;
            set;
        }

        /// <summary>
        /// The skill ID associated with the item.
        /// </summary>
        public int SkillID
        {
            get;
            set;
        }

        /// <summary>
        /// The switch ID associated with the item.
        /// </summary>
        public int SwitchID
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item can be used on the field.
        /// </summary>
        public bool OccasionField2
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item can be used in battle.
        /// </summary>
        public bool OccasionBattle
        {
            get;
            set;
        }

        /// <summary>
        /// The actor set affected by the item.
        /// </summary>
        [LcfAlwaysPersist]
        [LcfSize( ( int ) ItemChunk.ActorSetSize )]
        public List<bool> ActorSet
        {
            get;
            set;
        }

        /// <summary>
        /// The state set affected by the item.
        /// </summary>
        [LcfAlwaysPersist]
        [LcfSize( ( int ) ItemChunk.StateSetSize )]
        public List<bool> StateSet
        {
            get;
            set;
        }

        /// <summary>
        /// The attribute set affected by the item.
        /// </summary>
        [LcfAlwaysPersist]
        [LcfSize( ( int ) ItemChunk.AttributeSetSize )]
        public List<bool> AttributeSet
        {
            get;
            set;
        }

        /// <summary>
        /// The chance of causing a state change.
        /// </summary>
        public int StateChance
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the state effect is reversed.
        /// </summary>
        public bool ReverseStateEffect
        {
            get;
            set;
        }

        /// <summary>
        /// The weapon animation associated with the item (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int WeaponAnimation
        {
            get;
            set;
        }

        /// <summary>
        /// The animation data for the item (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public List<BattlerAnimationItemSkill> AnimationData
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the item uses a skill (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public bool UseSkill
        {
            get;
            set;
        }

        /// <summary>
        /// The class set affected by the item (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        [LcfSize( ( int ) ItemChunk.ClassSetSize )]
        public List<bool> ClassSet
        {
            get;
            set;
        }

        /// <summary>
        /// The trajectory of a ranged item.
        /// </summary>
        public ItemTrajectory RangedTrajectory
        {
            get;
            set;
        }

        /// <summary>
        /// The target type of a ranged item.
        /// </summary>
        public ItemTarget RangedTarget
        {
            get;
            set;
        }
    }
}