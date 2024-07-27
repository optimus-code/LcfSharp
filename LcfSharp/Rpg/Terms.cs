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

namespace LcfSharp.Rpg
{
    /// <summary>
    /// Class representing various terms used in the game.
    /// </summary>
    [LcfChunk<TermsChunk>]
    public class Terms
    {
        /// <summary>
        /// The text for encountering enemies.
        /// </summary>
        [LcfAlwaysPersist]
        public string Encounter
        {
            get;
            set;
        }

        /// <summary>
        /// The text for special combat situations.
        /// </summary>
        [LcfAlwaysPersist]
        public string SpecialCombat
        {
            get;
            set;
        }

        /// <summary>
        /// The text for a successful escape.
        /// </summary>
        [LcfAlwaysPersist]
        public string EscapeSuccess
        {
            get;
            set;
        }

        /// <summary>
        /// The text for a failed escape.
        /// </summary>
        [LcfAlwaysPersist]
        public string EscapeFailure
        {
            get;
            set;
        }

        /// <summary>
        /// The text for a victory.
        /// </summary>
        [LcfAlwaysPersist]
        public string Victory
        {
            get;
            set;
        }

        /// <summary>
        /// The text for a defeat.
        /// </summary>
        [LcfAlwaysPersist]
        public string Defeat
        {
            get;
            set;
        }

        /// <summary>
        /// The text for experience received.
        /// </summary>
        [LcfAlwaysPersist]
        public string ExpReceived
        {
            get;
            set;
        }

        /// <summary>
        /// The first part of the text for gold received.
        /// </summary>
        [LcfAlwaysPersist]
        public string GoldReceivedA
        {
            get;
            set;
        }

        /// <summary>
        /// The second part of the text for gold received.
        /// </summary>
        [LcfAlwaysPersist]
        public string GoldReceivedB
        {
            get;
            set;
        }

        /// <summary>
        /// The text for items received.
        /// </summary>
        [LcfAlwaysPersist]
        public string ItemReceived
        {
            get;
            set;
        }

        /// <summary>
        /// The text for attacking.
        /// </summary>
        [LcfAlwaysPersist]
        public string Attacking
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy critical hits.
        /// </summary>
        [LcfAlwaysPersist]
        public string EnemyCritical
        {
            get;
            set;
        }

        /// <summary>
        /// The text for actor critical hits.
        /// </summary>
        [LcfAlwaysPersist]
        public string ActorCritical
        {
            get;
            set;
        }

        /// <summary>
        /// The text for defending.
        /// </summary>
        [LcfAlwaysPersist]
        public string Defending
        {
            get;
            set;
        }

        /// <summary>
        /// The text for observing.
        /// </summary>
        [LcfAlwaysPersist]
        public string Observing
        {
            get;
            set;
        }

        /// <summary>
        /// The text for focusing.
        /// </summary>
        [LcfAlwaysPersist]
        public string Focus
        {
            get;
            set;
        }

        /// <summary>
        /// The text for autodestruction.
        /// </summary>
        [LcfAlwaysPersist]
        public string Autodestruction
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy escape.
        /// </summary>
        [LcfAlwaysPersist]
        public string EnemyEscape
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy transformation.
        /// </summary>
        [LcfAlwaysPersist]
        public string EnemyTransform
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy damaged.
        /// </summary>
        [LcfAlwaysPersist]
        public string EnemyDamaged
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy undamaged.
        /// </summary>
        [LcfAlwaysPersist]
        public string EnemyUndamaged
        {
            get;
            set;
        }

        /// <summary>
        /// The text for actor damaged.
        /// </summary>
        [LcfAlwaysPersist]
        public string ActorDamaged
        {
            get;
            set;
        }

        /// <summary>
        /// The text for actor undamaged.
        /// </summary>
        [LcfAlwaysPersist]
        public string ActorUndamaged
        {
            get;
            set;
        }

        /// <summary>
        /// The first text for skill failure.
        /// </summary>
        [LcfAlwaysPersist]
        public string SkillFailureA
        {
            get;
            set;
        }

        /// <summary>
        /// The second text for skill failure.
        /// </summary>
        [LcfAlwaysPersist]
        public string SkillFailureB
        {
            get;
            set;
        }

        /// <summary>
        /// The third text for skill failure.
        /// </summary>
        [LcfAlwaysPersist]
        public string SkillFailureC
        {
            get;
            set;
        }

        /// <summary>
        /// The text for dodging.
        /// </summary>
        [LcfAlwaysPersist]
        public string Dodge
        {
            get;
            set;
        }

        /// <summary>
        /// The text for using an item.
        /// </summary>
        [LcfAlwaysPersist]
        public string UseItem
        {
            get;
            set;
        }

        /// <summary>
        /// The text for HP recovery.
        /// </summary>
        [LcfAlwaysPersist]
        public string HpRecovery
        {
            get;
            set;
        }

        /// <summary>
        /// The text for parameter increase.
        /// </summary>
        [LcfAlwaysPersist]
        public string ParameterIncrease
        {
            get;
            set;
        }

        /// <summary>
        /// The text for parameter decrease.
        /// </summary>
        [LcfAlwaysPersist]
        public string ParameterDecrease
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy HP absorbed.
        /// </summary>
        [LcfAlwaysPersist]
        public string EnemyHpAbsorbed
        {
            get;
            set;
        }

        /// <summary>
        /// The text for actor HP absorbed.
        /// </summary>
        [LcfAlwaysPersist]
        public string ActorHpAbsorbed
        {
            get;
            set;
        }

        /// <summary>
        /// The text for resistance increase.
        /// </summary>
        [LcfAlwaysPersist]
        public string ResistanceIncrease
        {
            get;
            set;
        }

        /// <summary>
        /// The text for resistance decrease.
        /// </summary>
        [LcfAlwaysPersist]
        public string ResistanceDecrease
        {
            get;
            set;
        }

        /// <summary>
        /// The text for leveling up.
        /// </summary>
        [LcfAlwaysPersist]
        public string LevelUp
        {
            get;
            set;
        }

        /// <summary>
        /// The text for learning a new skill.
        /// </summary>
        [LcfAlwaysPersist]
        public string SkillLearned
        {
            get;
            set;
        }

        /// <summary>
        /// The text for battle start. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public string BattleStart
        {
            get;
            set;
        }

        /// <summary>
        /// The text for missing an attack. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public string Miss
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopGreeting1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop re-greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopRegreeting1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop buy text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopBuy1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop sell text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSell1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop leave text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopLeave1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop buy select text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopBuySelect1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop buy number text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopBuyNumber1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop purchased text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopPurchased1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop sell select text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSellSelect1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop sell number text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSellNumber1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop sold text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSold1
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopGreeting2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop re-greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopRegreeting2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop buy text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopBuy2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop sell text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSell2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop leave text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopLeave2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop buy select text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopBuySelect2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop buy number text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopBuyNumber2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop purchased text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopPurchased2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop sell select text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSellSelect2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop sell number text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSellNumber2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop sold text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSold2
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopGreeting3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop re-greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopRegreeting3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop buy text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopBuy3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop sell text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSell3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop leave text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopLeave3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop buy select text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopBuySelect3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop buy number text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopBuyNumber3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop purchased text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopPurchased3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop sell select text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSellSelect3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop sell number text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSellNumber3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop sold text.
        /// </summary>
        [LcfAlwaysPersist]
        public string ShopSold3
        {
            get;
            set;
        }

        /// <summary>
        /// The first inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string InnAGreeting1
        {
            get;
            set;
        }

        /// <summary>
        /// The second inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string InnAGreeting2
        {
            get;
            set;
        }

        /// <summary>
        /// The third inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string InnAGreeting3
        {
            get;
            set;
        }

        /// <summary>
        /// The inn acceptance text.
        /// </summary>
        [LcfAlwaysPersist]
        public string InnAAccept
        {
            get;
            set;
        }

        /// <summary>
        /// The inn cancellation text.
        /// </summary>
        [LcfAlwaysPersist]
        public string InnACancel
        {
            get;
            set;
        }

        /// <summary>
        /// The first second inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string InnBGreeting1
        {
            get;
            set;
        }

        /// <summary>
        /// The second second inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string InnBGreeting2
        {
            get;
            set;
        }

        /// <summary>
        /// The third second inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public string InnBGreeting3
        {
            get;
            set;
        }

        /// <summary>
        /// The second inn acceptance text.
        /// </summary>
        [LcfAlwaysPersist]
        public string InnBAccept
        {
            get;
            set;
        }

        /// <summary>
        /// The second inn cancellation text.
        /// </summary>
        [LcfAlwaysPersist]
        public string InnBCancel
        {
            get;
            set;
        }

        /// <summary>
        /// The text for possessed items.
        /// </summary>
        [LcfAlwaysPersist]
        public string PossessedItems
        {
            get;
            set;
        }

        /// <summary>
        /// The text for equipped items.
        /// </summary>
        [LcfAlwaysPersist]
        public string EquippedItems
        {
            get;
            set;
        }

        /// <summary>
        /// The text for gold.
        /// </summary>
        [LcfAlwaysPersist]
        public string Gold
        {
            get;
            set;
        }

        /// <summary>
        /// The text for battle fight command.
        /// </summary>
        [LcfAlwaysPersist]
        public string BattleFight
        {
            get;
            set;
        }

        /// <summary>
        /// The text for battle auto command.
        /// </summary>
        [LcfAlwaysPersist]
        public string BattleAuto
        {
            get;
            set;
        }

        /// <summary>
        /// The text for battle escape command.
        /// </summary>
        [LcfAlwaysPersist]
        public string BattleEscape
        {
            get;
            set;
        }

        /// <summary>
        /// The text for attack command.
        /// </summary>
        [LcfAlwaysPersist]
        public string CommandAttack
        {
            get;
            set;
        }

        /// <summary>
        /// The text for defend command.
        /// </summary>
        [LcfAlwaysPersist]
        public string CommandDefend
        {
            get;
            set;
        }

        /// <summary>
        /// The text for item command.
        /// </summary>
        [LcfAlwaysPersist]
        public string CommandItem
        {
            get;
            set;
        }

        /// <summary>
        /// The text for skill command.
        /// </summary>
        [LcfAlwaysPersist]
        public string CommandSkill
        {
            get;
            set;
        }

        /// <summary>
        /// The text for menu equipment.
        /// </summary>
        [LcfAlwaysPersist]
        public string MenuEquipment
        {
            get;
            set;
        }

        /// <summary>
        /// The text for menu save.
        /// </summary>
        [LcfAlwaysPersist]
        public string MenuSave
        {
            get;
            set;
        }

        /// <summary>
        /// The text for menu quit.
        /// </summary>
        [LcfAlwaysPersist]
        public string MenuQuit
        {
            get;
            set;
        }

        /// <summary>
        /// The text for starting a new game.
        /// </summary>
        [LcfAlwaysPersist]
        public string NewGame
        {
            get;
            set;
        }

        /// <summary>
        /// The text for loading a game.
        /// </summary>
        [LcfAlwaysPersist]
        public string LoadGame
        {
            get;
            set;
        }

        /// <summary>
        /// The text for exiting the game.
        /// </summary>
        [LcfAlwaysPersist]
        public string ExitGame
        {
            get;
            set;
        }

        /// <summary>
        /// The text for status. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// The text for row. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public string Row
        {
            get;
            set;
        }

        /// <summary>
        /// The text for order. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public string Order
        {
            get;
            set;
        }

        /// <summary>
        /// The text for wait on. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public string WaitOn
        {
            get;
            set;
        }

        /// <summary>
        /// The text for wait off. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public string WaitOff
        {
            get;
            set;
        }

        /// <summary>
        /// The text for level.
        /// </summary>
        [LcfAlwaysPersist]
        public string Level
        {
            get;
            set;
        }

        /// <summary>
        /// The text for health points.
        /// </summary>
        [LcfAlwaysPersist]
        public string HealthPoints
        {
            get;
            set;
        }

        /// <summary>
        /// The text for spirit points.
        /// </summary>
        [LcfAlwaysPersist]
        public string SpiritPoints
        {
            get;
            set;
        }

        /// <summary>
        /// The text for normal status.
        /// </summary>
        [LcfAlwaysPersist]
        public string NormalStatus
        {
            get;
            set;
        }

        /// <summary>
        /// The abbreviated text for experience.
        /// </summary>
        [LcfAlwaysPersist]
        public string ExpShort
        {
            get;
            set;
        }

        /// <summary>
        /// The abbreviated text for level.
        /// </summary>
        [LcfAlwaysPersist]
        public string LvlShort
        {
            get;
            set;
        }

        /// <summary>
        /// The abbreviated text for health points.
        /// </summary>
        [LcfAlwaysPersist]
        public string HpShort
        {
            get;
            set;
        }

        /// <summary>
        /// The abbreviated text for spirit points.
        /// </summary>
        [LcfAlwaysPersist]
        public string SpShort
        {
            get;
            set;
        }

        /// <summary>
        /// The text for SP cost.
        /// </summary>
        [LcfAlwaysPersist]
        public string SpCost
        {
            get;
            set;
        }

        /// <summary>
        /// The text for attack.
        /// </summary>
        [LcfAlwaysPersist]
        public string Attack
        {
            get;
            set;
        }

        /// <summary>
        /// The text for defense.
        /// </summary>
        [LcfAlwaysPersist]
        public string Defense
        {
            get;
            set;
        }

        /// <summary>
        /// The text for spirit.
        /// </summary>
        [LcfAlwaysPersist]
        public string Spirit
        {
            get;
            set;
        }

        /// <summary>
        /// The text for agility.
        /// </summary>
        [LcfAlwaysPersist]
        public string Agility
        {
            get;
            set;
        }

        /// <summary>
        /// The text for weapon.
        /// </summary>
        [LcfAlwaysPersist]
        public string Weapon
        {
            get;
            set;
        }

        /// <summary>
        /// The text for shield.
        /// </summary>
        [LcfAlwaysPersist]
        public string Shield
        {
            get;
            set;
        }

        /// <summary>
        /// The text for armor.
        /// </summary>
        [LcfAlwaysPersist]
        public string Armor
        {
            get;
            set;
        }

        /// <summary>
        /// The text for helmet.
        /// </summary>
        [LcfAlwaysPersist]
        public string Helmet
        {
            get;
            set;
        }

        /// <summary>
        /// The text for accessory.
        /// </summary>
        [LcfAlwaysPersist]
        public string Accessory
        {
            get;
            set;
        }

        /// <summary>
        /// The message for saving the game.
        /// </summary>
        [LcfAlwaysPersist]
        public string SaveGameMessage
        {
            get;
            set;
        }

        /// <summary>
        /// The message for loading the game.
        /// </summary>
        [LcfAlwaysPersist]
        public string LoadGameMessage
        {
            get;
            set;
        }

        /// <summary>
        /// The text for file.
        /// </summary>
        [LcfAlwaysPersist]
        public string File
        {
            get;
            set;
        }

        /// <summary>
        /// The message for exiting the game.
        /// </summary>
        [LcfAlwaysPersist]
        public string ExitGameMessage
        {
            get;
            set;
        }

        /// <summary>
        /// The text for "Yes".
        /// </summary>
        [LcfAlwaysPersist]
        public string Yes
        {
            get;
            set;
        }

        /// <summary>
        /// The text for "No".
        /// </summary>
        [LcfAlwaysPersist]
        public string No
        {
            get;
            set;
        }
    }
}