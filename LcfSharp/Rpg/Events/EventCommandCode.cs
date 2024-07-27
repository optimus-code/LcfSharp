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

namespace LcfSharp.Rpg.Events
{
    /// <summary>
    /// Enum representing the various codes for event commands.
    /// </summary>
    public enum EventCommandCode : int
    {
        /// <summary>
        /// No command.
        /// </summary>
        None = 0,

        /// <summary>
        /// End event command.
        /// </summary>
        END = 10,

        /// <summary>
        /// Call a common event.
        /// </summary>
        CallCommonEvent = 1005,

        /// <summary>
        /// Force flee.
        /// </summary>
        ForceFlee = 1006,

        /// <summary>
        /// Enable combo.
        /// </summary>
        EnableCombo = 1007,

        /// <summary>
        /// Change class.
        /// </summary>
        ChangeClass = 1008,

        /// <summary>
        /// Change battle commands.
        /// </summary>
        ChangeBattleCommands = 1009,

        /// <summary>
        /// Open load menu.
        /// </summary>
        OpenLoadMenu = 5001,

        /// <summary>
        /// Exit game.
        /// </summary>
        ExitGame = 5002,

        /// <summary>
        /// Toggle ATB mode.
        /// </summary>
        ToggleAtbMode = 5003,

        /// <summary>
        /// Toggle fullscreen.
        /// </summary>
        ToggleFullscreen = 5004,

        /// <summary>
        /// Open video options.
        /// </summary>
        OpenVideoOptions = 5005,

        /// <summary>
        /// Show message.
        /// </summary>
        ShowMessage = 10110,

        /// <summary>
        /// Message options.
        /// </summary>
        MessageOptions = 10120,

        /// <summary>
        /// Change face graphic.
        /// </summary>
        ChangeFaceGraphic = 10130,

        /// <summary>
        /// Show choice.
        /// </summary>
        ShowChoice = 10140,

        /// <summary>
        /// Input number.
        /// </summary>
        InputNumber = 10150,

        /// <summary>
        /// Control switches.
        /// </summary>
        ControlSwitches = 10210,

        /// <summary>
        /// Control variables.
        /// </summary>
        ControlVars = 10220,

        /// <summary>
        /// Timer operation.
        /// </summary>
        TimerOperation = 10230,

        /// <summary>
        /// Change gold.
        /// </summary>
        ChangeGold = 10310,

        /// <summary>
        /// Change items.
        /// </summary>
        ChangeItems = 10320,

        /// <summary>
        /// Change party members.
        /// </summary>
        ChangePartyMembers = 10330,

        /// <summary>
        /// Change experience points.
        /// </summary>
        ChangeExp = 10410,

        /// <summary>
        /// Change level.
        /// </summary>
        ChangeLevel = 10420,

        /// <summary>
        /// Change parameters.
        /// </summary>
        ChangeParameters = 10430,

        /// <summary>
        /// Change skills.
        /// </summary>
        ChangeSkills = 10440,

        /// <summary>
        /// Change equipment.
        /// </summary>
        ChangeEquipment = 10450,

        /// <summary>
        /// Change HP.
        /// </summary>
        ChangeHP = 10460,

        /// <summary>
        /// Change SP.
        /// </summary>
        ChangeSP = 10470,

        /// <summary>
        /// Change condition.
        /// </summary>
        ChangeCondition = 10480,

        /// <summary>
        /// Full heal.
        /// </summary>
        FullHeal = 10490,

        /// <summary>
        /// Simulated attack.
        /// </summary>
        SimulatedAttack = 10500,

        /// <summary>
        /// Change hero name.
        /// </summary>
        ChangeHeroName = 10610,

        /// <summary>
        /// Change hero title.
        /// </summary>
        ChangeHeroTitle = 10620,

        /// <summary>
        /// Change sprite association.
        /// </summary>
        ChangeSpriteAssociation = 10630,

        /// <summary>
        /// Change actor face.
        /// </summary>
        ChangeActorFace = 10640,

        /// <summary>
        /// Change vehicle graphic.
        /// </summary>
        ChangeVehicleGraphic = 10650,

        /// <summary>
        /// Change system BGM.
        /// </summary>
        ChangeSystemBGM = 10660,

        /// <summary>
        /// Change system SFX.
        /// </summary>
        ChangeSystemSFX = 10670,

        /// <summary>
        /// Change system graphics.
        /// </summary>
        ChangeSystemGraphics = 10680,

        /// <summary>
        /// Change screen transitions.
        /// </summary>
        ChangeScreenTransitions = 10690,

        /// <summary>
        /// Enemy encounter.
        /// </summary>
        EnemyEncounter = 10710,

        /// <summary>
        /// Open shop.
        /// </summary>
        OpenShop = 10720,

        /// <summary>
        /// Show inn.
        /// </summary>
        ShowInn = 10730,

        /// <summary>
        /// Enter hero name.
        /// </summary>
        EnterHeroName = 10740,

        /// <summary>
        /// Teleport.
        /// </summary>
        Teleport = 10810,

        /// <summary>
        /// Memorize location.
        /// </summary>
        MemorizeLocation = 10820,

        /// <summary>
        /// Recall to location.
        /// </summary>
        RecallToLocation = 10830,

        /// <summary>
        /// Enter/Exit vehicle.
        /// </summary>
        EnterExitVehicle = 10840,

        /// <summary>
        /// Set vehicle location.
        /// </summary>
        SetVehicleLocation = 10850,

        /// <summary>
        /// Change event location.
        /// </summary>
        ChangeEventLocation = 10860,

        /// <summary>
        /// Trade event locations.
        /// </summary>
        TradeEventLocations = 10870,

        /// <summary>
        /// Store terrain ID.
        /// </summary>
        StoreTerrainID = 10910,

        /// <summary>
        /// Store event ID.
        /// </summary>
        StoreEventID = 10920,

        /// <summary>
        /// Erase screen.
        /// </summary>
        EraseScreen = 11010,

        /// <summary>
        /// Show screen.
        /// </summary>
        ShowScreen = 11020,

        /// <summary>
        /// Tint screen.
        /// </summary>
        TintScreen = 11030,

        /// <summary>
        /// Flash screen.
        /// </summary>
        FlashScreen = 11040,

        /// <summary>
        /// Shake screen.
        /// </summary>
        ShakeScreen = 11050,

        /// <summary>
        /// Pan screen.
        /// </summary>
        PanScreen = 11060,

        /// <summary>
        /// Weather effects.
        /// </summary>
        WeatherEffects = 11070,

        /// <summary>
        /// Show picture.
        /// </summary>
        ShowPicture = 11110,

        /// <summary>
        /// Move picture.
        /// </summary>
        MovePicture = 11120,

        /// <summary>
        /// Erase picture.
        /// </summary>
        ErasePicture = 11130,

        /// <summary>
        /// Show battle animation.
        /// </summary>
        ShowBattleAnimation = 11210,

        /// <summary>
        /// Set player visibility.
        /// </summary>
        PlayerVisibility = 11310,

        /// <summary>
        /// Flash sprite.
        /// </summary>
        FlashSprite = 11320,

        /// <summary>
        /// Move event.
        /// </summary>
        MoveEvent = 11330,

        /// <summary>
        /// Proceed with movement.
        /// </summary>
        ProceedWithMovement = 11340,

        /// <summary>
        /// Halt all movement.
        /// </summary>
        HaltAllMovement = 11350,

        /// <summary>
        /// Wait.
        /// </summary>
        Wait = 11410,

        /// <summary>
        /// Play BGM.
        /// </summary>
        PlayBGM = 11510,

        /// <summary>
        /// Fade out BGM.
        /// </summary>
        FadeOutBGM = 11520,

        /// <summary>
        /// Memorize BGM.
        /// </summary>
        MemorizeBGM = 11530,

        /// <summary>
        /// Play memorized BGM.
        /// </summary>
        PlayMemorizedBGM = 11540,

        /// <summary>
        /// Play sound effect.
        /// </summary>
        PlaySound = 11550,

        /// <summary>
        /// Play movie.
        /// </summary>
        PlayMovie = 11560,

        /// <summary>
        /// Key input processing.
        /// </summary>
        KeyInputProc = 11610,

        /// <summary>
        /// Change map tileset.
        /// </summary>
        ChangeMapTileset = 11710,

        /// <summary>
        /// Change PBG.
        /// </summary>
        ChangePBG = 11720,

        /// <summary>
        /// Change encounter steps.
        /// </summary>
        ChangeEncounterSteps = 11740,

        /// <summary>
        /// Tile substitution.
        /// </summary>
        TileSubstitution = 11750,

        /// <summary>
        /// Teleport targets.
        /// </summary>
        TeleportTargets = 11810,

        /// <summary>
        /// Change teleport access.
        /// </summary>
        ChangeTeleportAccess = 11820,

        /// <summary>
        /// Escape target.
        /// </summary>
        EscapeTarget = 11830,

        /// <summary>
        /// Change escape access.
        /// </summary>
        ChangeEscapeAccess = 11840,

        /// <summary>
        /// Open save menu.
        /// </summary>
        OpenSaveMenu = 11910,

        /// <summary>
        /// Change save access.
        /// </summary>
        ChangeSaveAccess = 11930,

        /// <summary>
        /// Open main menu.
        /// </summary>
        OpenMainMenu = 11950,

        /// <summary>
        /// Change main menu access.
        /// </summary>
        ChangeMainMenuAccess = 11960,

        /// <summary>
        /// Conditional branch.
        /// </summary>
        ConditionalBranch = 12010,

        /// <summary>
        /// Label.
        /// </summary>
        Label = 12110,

        /// <summary>
        /// Jump to label.
        /// </summary>
        JumpToLabel = 12120,

        /// <summary>
        /// Loop.
        /// </summary>
        Loop = 12210,

        /// <summary>
        /// Break loop.
        /// </summary>
        BreakLoop = 12220,

        /// <summary>
        /// End event processing.
        /// </summary>
        EndEventProcessing = 12310,

        /// <summary>
        /// Erase event.
        /// </summary>
        EraseEvent = 12320,

        /// <summary>
        /// Call event.
        /// </summary>
        CallEvent = 12330,

        /// <summary>
        /// Comment.
        /// </summary>
        Comment = 12410,

        /// <summary>
        /// Game over.
        /// </summary>
        GameOver = 12420,

        /// <summary>
        /// Return to title screen.
        /// </summary>
        ReturntoTitleScreen = 12510,

        /// <summary>
        /// Change monster HP.
        /// </summary>
        ChangeMonsterHP = 13110,

        /// <summary>
        /// Change monster MP.
        /// </summary>
        ChangeMonsterMP = 13120,

        /// <summary>
        /// Change monster condition.
        /// </summary>
        ChangeMonsterCondition = 13130,

        /// <summary>
        /// Show hidden monster.
        /// </summary>
        ShowHiddenMonster = 13150,

        /// <summary>
        /// Change battle background.
        /// </summary>
        ChangeBattleBG = 13210,

        /// <summary>
        /// Show battle animation (B).
        /// </summary>
        ShowBattleAnimation_B = 13260,

        /// <summary>
        /// Conditional branch (B).
        /// </summary>
        ConditionalBranch_B = 13310,

        /// <summary>
        /// Terminate battle.
        /// </summary>
        TerminateBattle = 13410,

        /// <summary>
        /// Show message (2).
        /// </summary>
        ShowMessage_2 = 20110,

        /// <summary>
        /// Show choice option.
        /// </summary>
        ShowChoiceOption = 20140,

        /// <summary>
        /// End show choice.
        /// </summary>
        ShowChoiceEnd = 20141,

        /// <summary>
        /// Victory handler.
        /// </summary>
        VictoryHandler = 20710,

        /// <summary>
        /// Escape handler.
        /// </summary>
        EscapeHandler = 20711,

        /// <summary>
        /// Defeat handler.
        /// </summary>
        DefeatHandler = 20712,

        /// <summary>
        /// End battle.
        /// </summary>
        EndBattle = 20713,

        /// <summary>
        /// Transaction.
        /// </summary>
        Transaction = 20720,

        /// <summary>
        /// No transaction.
        /// </summary>
        NoTransaction = 20721,

        /// <summary>
        /// End shop.
        /// </summary>
        EndShop = 20722,

        /// <summary>
        /// Stay.
        /// </summary>
        Stay = 20730,

        /// <summary>
        /// No stay.
        /// </summary>
        NoStay = 20731,

        /// <summary>
        /// End inn.
        /// </summary>
        EndInn = 20732,

        /// <summary>
        /// Else branch.
        /// </summary>
        ElseBranch = 22010,

        /// <summary>
        /// End branch.
        /// </summary>
        EndBranch = 22011,

        /// <summary>
        /// End loop.
        /// </summary>
        EndLoop = 22210,

        /// <summary>
        /// Comment (2).
        /// </summary>
        Comment_2 = 22410,

        /// <summary>
        /// Else branch (B).
        /// </summary>
        ElseBranch_B = 23310,

        /// <summary>
        /// End branch (B).
        /// </summary>
        EndBranch_B = 23311
    }
}