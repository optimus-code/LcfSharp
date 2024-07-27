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
using LcfSharp.Rpg.Audio;
using System.Collections.Generic;

namespace LcfSharp.Rpg.GameSystems
{
    /// <summary>
    /// Class representing the game system settings.
    /// </summary>
    [LcfChunk<GameSystemChunk>]
    public class GameSystem
    {
        /// <summary>
        /// The ID of the LDB (database).
        /// </summary>
        public int LdbID
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the boat.
        /// </summary>
        public string BoatName
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the ship.
        /// </summary>
        public string ShipName
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the airship.
        /// </summary>
        public string AirshipName
        {
            get;
            set;
        }

        /// <summary>
        /// The index of the boat graphic.
        /// </summary>
        public int BoatIndex
        {
            get;
            set;
        }

        /// <summary>
        /// The index of the ship graphic.
        /// </summary>
        public int ShipIndex
        {
            get;
            set;
        }

        /// <summary>
        /// The index of the airship graphic.
        /// </summary>
        public int AirshipIndex
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the title screen graphic.
        /// </summary>
        public string TitleName
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the game over screen graphic.
        /// </summary>
        public string GameoverName
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the system graphic.
        /// </summary>
        public string SystemName
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the second system graphic (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public string System2Name
        {
            get;
            set;
        }

        /// <summary>
        /// The list of party member IDs.
        /// </summary>
        public List<short> Party
        {
            get;
            set;
        } = [1];

        /// <summary>
        /// The list of menu commands (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        [LcfSize( ( int ) GameSystemChunk.MenuCommandsSize )]
        public List<short> MenuCommands
        {
            get;
            set;
        } = [1];

        /// <summary>
        /// The music played on the title screen.
        /// </summary>
        public Music TitleMusic
        {
            get;
            set;
        }

        /// <summary>
        /// The music played during battles.
        /// </summary>
        public Music BattleMusic
        {
            get;
            set;
        }

        /// <summary>
        /// The music played at the end of battles.
        /// </summary>
        public Music BattleEndMusic
        {
            get;
            set;
        }

        /// <summary>
        /// The music played at inns.
        /// </summary>
        public Music InnMusic
        {
            get;
            set;
        }

        /// <summary>
        /// The music played when on the boat.
        /// </summary>
        public Music BoatMusic
        {
            get;
            set;
        }

        /// <summary>
        /// The music played when on the ship.
        /// </summary>
        public Music ShipMusic
        {
            get;
            set;
        }

        /// <summary>
        /// The music played when on the airship.
        /// </summary>
        public Music AirshipMusic
        {
            get;
            set;
        }

        /// <summary>
        /// The music played on the game over screen.
        /// </summary>
        public Music GameoverMusic
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when moving the cursor.
        /// </summary>
        public Sound CursorSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when making a decision.
        /// </summary>
        public Sound DecisionSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when canceling an action.
        /// </summary>
        public Sound CancelSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when an invalid action is attempted.
        /// </summary>
        public Sound BuzzerSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played at the start of a battle.
        /// </summary>
        public Sound BattleSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when escaping from a battle.
        /// </summary>
        public Sound EscapeSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when an enemy attacks.
        /// </summary>
        public Sound EnemyAttackSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when an enemy is damaged.
        /// </summary>
        public Sound EnemyDamagedSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when an actor is damaged.
        /// </summary>
        public Sound ActorDamagedSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when an attack is dodged.
        /// </summary>
        public Sound DodgeSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when an enemy dies.
        /// </summary>
        public Sound EnemyDeathSe
        {
            get;
            set;
        }

        /// <summary>
        /// The sound effect played when using an item.
        /// </summary>
        public Sound ItemSe
        {
            get;
            set;
        }

        /// <summary>
        /// The fade-out transition effect for screen transitions.
        /// </summary>
        public GameSystemFadeOut TransitionOut
        {
            get;
            set;
        }

        /// <summary>
        /// The fade-in transition effect for screen transitions.
        /// </summary>
        public GameSystemFadeIn TransitionIn
        {
            get;
            set;
        }

        /// <summary>
        /// The fade-out transition effect for the start of battles.
        /// </summary>
        public GameSystemFadeOut BattleStartFadeOut
        {
            get;
            set;
        }

        /// <summary>
        /// The fade-in transition effect for the start of battles.
        /// </summary>
        public GameSystemFadeIn BattleStartFadeIn
        {
            get;
            set;
        }

        /// <summary>
        /// The fade-out transition effect for the end of battles.
        /// </summary>
        public GameSystemFadeOut BattleEndFadeOut
        {
            get;
            set;
        }

        /// <summary>
        /// The fade-in transition effect for the end of battles.
        /// </summary>
        public GameSystemFadeIn BattleEndFadeIn
        {
            get;
            set;
        }

        /// <summary>
        /// The stretch setting for messages.
        /// </summary>
        public GameSystemStretch MessageStretch
        {
            get;
            set;
        }

        /// <summary>
        /// The font used in the game.
        /// </summary>
        public GameSystemFont FontID
        {
            get;
            set;
        }

        /// <summary>
        /// The selected battle condition.
        /// </summary>
        public GameSystemBattleCondition SelectedCondition
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the selected hero.
        /// </summary>
        public int SelectedHero
        {
            get;
            set;
        }

        /// <summary>
        /// The background used for battle tests.
        /// </summary>
        public string BattleTestBackground
        {
            get;
            set;
        }

        /// <summary>
        /// The list of test battlers used in battle tests.
        /// </summary>
        public List<TestBattler> BattleTestData
        {
            get;
            set;
        }

        /// <summary>
        /// The number of times the game has been saved.
        /// </summary>
        public int SaveCount
        {
            get;
            set;
        }

        /// <summary>
        /// The terrain ID used in battle tests.
        /// </summary>
        public int BattleTestTerrain
        {
            get;
            set;
        }

        /// <summary>
        /// The battle formation used in battle tests.
        /// </summary>
        public GameSystemBattleFormation BattleTestFormation
        {
            get;
            set;
        }

        /// <summary>
        /// The battle condition used in battle tests.
        /// </summary>
        public GameSystemBattleCondition BattleTestCondition
        {
            get;
            set;
        }

        /// <summary>
        /// The equipment setting for the game (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public GameSystemEquipmentSetting EquipmentSetting
        {
            get;
            set;
        }

        /// <summary>
        /// The alternative terrain used in battle tests (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public int BattleTestAltTerrain
        {
            get;
            set;
        } = -1;

        /// <summary>
        /// Indicates whether to show the frame (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public bool ShowFrame
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the frame graphic (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public string FrameName
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether to invert animations (only in RM2K3).
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public bool InvertAnimations
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether to show the title screen (only in RM2K3). Default is true.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public bool ShowTitle
        {
            get;
            set;
        } = true;
    }
}