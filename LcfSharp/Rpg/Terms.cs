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
        public LcfString Encounter
        {
            get;
            set;
        }

        /// <summary>
        /// The text for special combat situations.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString SpecialCombat
        {
            get;
            set;
        }

        /// <summary>
        /// The text for a successful escape.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString EscapeSuccess
        {
            get;
            set;
        }

        /// <summary>
        /// The text for a failed escape.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString EscapeFailure
        {
            get;
            set;
        }

        /// <summary>
        /// The text for a victory.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Victory
        {
            get;
            set;
        }

        /// <summary>
        /// The text for a defeat.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Defeat
        {
            get;
            set;
        }

        /// <summary>
        /// The text for experience received.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ExpReceived
        {
            get;
            set;
        }

        /// <summary>
        /// The first part of the text for gold received.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString GoldReceivedA
        {
            get;
            set;
        }

        /// <summary>
        /// The second part of the text for gold received.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString GoldReceivedB
        {
            get;
            set;
        }

        /// <summary>
        /// The text for items received.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ItemReceived
        {
            get;
            set;
        }

        /// <summary>
        /// The text for attacking.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Attacking
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy critical hits.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString EnemyCritical
        {
            get;
            set;
        }

        /// <summary>
        /// The text for actor critical hits.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ActorCritical
        {
            get;
            set;
        }

        /// <summary>
        /// The text for defending.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Defending
        {
            get;
            set;
        }

        /// <summary>
        /// The text for observing.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Observing
        {
            get;
            set;
        }

        /// <summary>
        /// The text for focusing.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Focus
        {
            get;
            set;
        }

        /// <summary>
        /// The text for autodestruction.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Autodestruction
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy escape.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString EnemyEscape
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy transformation.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString EnemyTransform
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy damaged.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString EnemyDamaged
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy undamaged.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString EnemyUndamaged
        {
            get;
            set;
        }

        /// <summary>
        /// The text for actor damaged.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ActorDamaged
        {
            get;
            set;
        }

        /// <summary>
        /// The text for actor undamaged.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ActorUndamaged
        {
            get;
            set;
        }

        /// <summary>
        /// The first text for skill failure.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString SkillFailureA
        {
            get;
            set;
        }

        /// <summary>
        /// The second text for skill failure.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString SkillFailureB
        {
            get;
            set;
        }

        /// <summary>
        /// The third text for skill failure.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString SkillFailureC
        {
            get;
            set;
        }

        /// <summary>
        /// The text for dodging.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Dodge
        {
            get;
            set;
        }

        /// <summary>
        /// The text for using an item.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString UseItem
        {
            get;
            set;
        }

        /// <summary>
        /// The text for HP recovery.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString HpRecovery
        {
            get;
            set;
        }

        /// <summary>
        /// The text for parameter increase.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ParameterIncrease
        {
            get;
            set;
        }

        /// <summary>
        /// The text for parameter decrease.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ParameterDecrease
        {
            get;
            set;
        }

        /// <summary>
        /// The text for enemy HP absorbed.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString EnemyHpAbsorbed
        {
            get;
            set;
        }

        /// <summary>
        /// The text for actor HP absorbed.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ActorHpAbsorbed
        {
            get;
            set;
        }

        /// <summary>
        /// The text for resistance increase.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ResistanceIncrease
        {
            get;
            set;
        }

        /// <summary>
        /// The text for resistance decrease.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ResistanceDecrease
        {
            get;
            set;
        }

        /// <summary>
        /// The text for leveling up.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString LevelUp
        {
            get;
            set;
        }

        /// <summary>
        /// The text for learning a new skill.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString SkillLearned
        {
            get;
            set;
        }

        /// <summary>
        /// The text for battle start. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public LcfString BattleStart
        {
            get;
            set;
        }

        /// <summary>
        /// The text for missing an attack. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public LcfString Miss
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopGreeting1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop re-greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopRegreeting1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop buy text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopBuy1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop sell text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSell1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop leave text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopLeave1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop buy select text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopBuySelect1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop buy number text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopBuyNumber1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop purchased text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopPurchased1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop sell select text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSellSelect1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop sell number text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSellNumber1
        {
            get;
            set;
        }

        /// <summary>
        /// The first shop sold text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSold1
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopGreeting2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop re-greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopRegreeting2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop buy text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopBuy2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop sell text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSell2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop leave text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopLeave2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop buy select text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopBuySelect2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop buy number text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopBuyNumber2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop purchased text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopPurchased2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop sell select text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSellSelect2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop sell number text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSellNumber2
        {
            get;
            set;
        }

        /// <summary>
        /// The second shop sold text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSold2
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopGreeting3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop re-greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopRegreeting3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop buy text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopBuy3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop sell text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSell3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop leave text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopLeave3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop buy select text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopBuySelect3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop buy number text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopBuyNumber3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop purchased text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopPurchased3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop sell select text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSellSelect3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop sell number text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSellNumber3
        {
            get;
            set;
        }

        /// <summary>
        /// The third shop sold text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ShopSold3
        {
            get;
            set;
        }

        /// <summary>
        /// The first inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString InnAGreeting1
        {
            get;
            set;
        }

        /// <summary>
        /// The second inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString InnAGreeting2
        {
            get;
            set;
        }

        /// <summary>
        /// The third inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString InnAGreeting3
        {
            get;
            set;
        }

        /// <summary>
        /// The inn acceptance text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString InnAAccept
        {
            get;
            set;
        }

        /// <summary>
        /// The inn cancellation text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString InnACancel
        {
            get;
            set;
        }

        /// <summary>
        /// The first second inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString InnBGreeting1
        {
            get;
            set;
        }

        /// <summary>
        /// The second second inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString InnBGreeting2
        {
            get;
            set;
        }

        /// <summary>
        /// The third second inn greeting text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString InnBGreeting3
        {
            get;
            set;
        }

        /// <summary>
        /// The second inn acceptance text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString InnBAccept
        {
            get;
            set;
        }

        /// <summary>
        /// The second inn cancellation text.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString InnBCancel
        {
            get;
            set;
        }

        /// <summary>
        /// The text for possessed items.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString PossessedItems
        {
            get;
            set;
        }

        /// <summary>
        /// The text for equipped items.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString EquippedItems
        {
            get;
            set;
        }

        /// <summary>
        /// The text for gold.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Gold
        {
            get;
            set;
        }

        /// <summary>
        /// The text for battle fight command.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString BattleFight
        {
            get;
            set;
        }

        /// <summary>
        /// The text for battle auto command.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString BattleAuto
        {
            get;
            set;
        }

        /// <summary>
        /// The text for battle escape command.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString BattleEscape
        {
            get;
            set;
        }

        /// <summary>
        /// The text for attack command.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString CommandAttack
        {
            get;
            set;
        }

        /// <summary>
        /// The text for defend command.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString CommandDefend
        {
            get;
            set;
        }

        /// <summary>
        /// The text for item command.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString CommandItem
        {
            get;
            set;
        }

        /// <summary>
        /// The text for skill command.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString CommandSkill
        {
            get;
            set;
        }

        /// <summary>
        /// The text for menu equipment.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString MenuEquipment
        {
            get;
            set;
        }

        /// <summary>
        /// The text for menu save.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString MenuSave
        {
            get;
            set;
        }

        /// <summary>
        /// The text for menu quit.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString MenuQuit
        {
            get;
            set;
        }

        /// <summary>
        /// The text for starting a new game.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString NewGame
        {
            get;
            set;
        }

        /// <summary>
        /// The text for loading a game.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString LoadGame
        {
            get;
            set;
        }

        /// <summary>
        /// The text for exiting the game.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ExitGame
        {
            get;
            set;
        }

        /// <summary>
        /// The text for status. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public LcfString Status
        {
            get;
            set;
        }

        /// <summary>
        /// The text for row. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public LcfString Row
        {
            get;
            set;
        }

        /// <summary>
        /// The text for order. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public LcfString Order
        {
            get;
            set;
        }

        /// <summary>
        /// The text for wait on. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public LcfString WaitOn
        {
            get;
            set;
        }

        /// <summary>
        /// The text for wait off. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public LcfString WaitOff
        {
            get;
            set;
        }

        /// <summary>
        /// The text for level.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Level
        {
            get;
            set;
        }

        /// <summary>
        /// The text for health points.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString HealthPoints
        {
            get;
            set;
        }

        /// <summary>
        /// The text for spirit points.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString SpiritPoints
        {
            get;
            set;
        }

        /// <summary>
        /// The text for normal status.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString NormalStatus
        {
            get;
            set;
        }

        /// <summary>
        /// The abbreviated text for experience.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ExpShort
        {
            get;
            set;
        }

        /// <summary>
        /// The abbreviated text for level.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString LvlShort
        {
            get;
            set;
        }

        /// <summary>
        /// The abbreviated text for health points.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString HpShort
        {
            get;
            set;
        }

        /// <summary>
        /// The abbreviated text for spirit points.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString SpShort
        {
            get;
            set;
        }

        /// <summary>
        /// The text for SP cost.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString SpCost
        {
            get;
            set;
        }

        /// <summary>
        /// The text for attack.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Attack
        {
            get;
            set;
        }

        /// <summary>
        /// The text for defense.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Defense
        {
            get;
            set;
        }

        /// <summary>
        /// The text for spirit.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Spirit
        {
            get;
            set;
        }

        /// <summary>
        /// The text for agility.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Agility
        {
            get;
            set;
        }

        /// <summary>
        /// The text for weapon.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Weapon
        {
            get;
            set;
        }

        /// <summary>
        /// The text for shield.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Shield
        {
            get;
            set;
        }

        /// <summary>
        /// The text for armor.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Armor
        {
            get;
            set;
        }

        /// <summary>
        /// The text for helmet.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Helmet
        {
            get;
            set;
        }

        /// <summary>
        /// The text for accessory.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Accessory
        {
            get;
            set;
        }

        /// <summary>
        /// The message for saving the game.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString SaveGameMessage
        {
            get;
            set;
        }

        /// <summary>
        /// The message for loading the game.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString LoadGameMessage
        {
            get;
            set;
        }

        /// <summary>
        /// The text for file.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString File
        {
            get;
            set;
        }

        /// <summary>
        /// The message for exiting the game.
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString ExitGameMessage
        {
            get;
            set;
        }

        /// <summary>
        /// The text for "Yes".
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString Yes
        {
            get;
            set;
        }

        /// <summary>
        /// The text for "No".
        /// </summary>
        [LcfAlwaysPersist]
        public LcfString No
        {
            get;
            set;
        }
    }
}