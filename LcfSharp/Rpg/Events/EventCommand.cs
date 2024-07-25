using LcfSharp.IO;
using LcfSharp.IO.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Events
{
    public class EventCommand
    {
        public static readonly Dictionary<EventCommandCode, string> Tags = new Dictionary<EventCommandCode, string>
        {
            { EventCommandCode.END, "END" },
            { EventCommandCode.CallCommonEvent, "CallCommonEvent" },
            { EventCommandCode.ForceFlee, "ForceFlee" },
            { EventCommandCode.EnableCombo, "EnableCombo" },
            { EventCommandCode.ChangeClass, "ChangeClass" },
            { EventCommandCode.ChangeBattleCommands, "ChangeBattleCommands" },
            { EventCommandCode.OpenLoadMenu, "OpenLoadMenu" },
            { EventCommandCode.ExitGame, "ExitGame" },
            { EventCommandCode.ToggleAtbMode, "ToggleAtbMode" },
            { EventCommandCode.ToggleFullscreen, "ToggleFullscreen" },
            { EventCommandCode.OpenVideoOptions, "OpenVideoOptions" },
            { EventCommandCode.ShowMessage, "ShowMessage" },
            { EventCommandCode.MessageOptions, "MessageOptions" },
            { EventCommandCode.ChangeFaceGraphic, "ChangeFaceGraphic" },
            { EventCommandCode.ShowChoice, "ShowChoice" },
            { EventCommandCode.InputNumber, "InputNumber" },
            { EventCommandCode.ControlSwitches, "ControlSwitches" },
            { EventCommandCode.ControlVars, "ControlVars" },
            { EventCommandCode.TimerOperation, "TimerOperation" },
            { EventCommandCode.ChangeGold, "ChangeGold" },
            { EventCommandCode.ChangeItems, "ChangeItems" },
            { EventCommandCode.ChangePartyMembers, "ChangePartyMembers" },
            { EventCommandCode.ChangeExp, "ChangeExp" },
            { EventCommandCode.ChangeLevel, "ChangeLevel" },
            { EventCommandCode.ChangeParameters, "ChangeParameters" },
            { EventCommandCode.ChangeSkills, "ChangeSkills" },
            { EventCommandCode.ChangeEquipment, "ChangeEquipment" },
            { EventCommandCode.ChangeHP, "ChangeHP" },
            { EventCommandCode.ChangeSP, "ChangeSP" },
            { EventCommandCode.ChangeCondition, "ChangeCondition" },
            { EventCommandCode.FullHeal, "FullHeal" },
            { EventCommandCode.SimulatedAttack, "SimulatedAttack" },
            { EventCommandCode.ChangeHeroName, "ChangeHeroName" },
            { EventCommandCode.ChangeHeroTitle, "ChangeHeroTitle" },
            { EventCommandCode.ChangeSpriteAssociation, "ChangeSpriteAssociation" },
            { EventCommandCode.ChangeActorFace, "ChangeActorFace" },
            { EventCommandCode.ChangeVehicleGraphic, "ChangeVehicleGraphic" },
            { EventCommandCode.ChangeSystemBGM, "ChangeSystemBGM" },
            { EventCommandCode.ChangeSystemSFX, "ChangeSystemSFX" },
            { EventCommandCode.ChangeSystemGraphics, "ChangeSystemGraphics" },
            { EventCommandCode.ChangeScreenTransitions, "ChangeScreenTransitions" },
            { EventCommandCode.EnemyEncounter, "EnemyEncounter" },
            { EventCommandCode.OpenShop, "OpenShop" },
            { EventCommandCode.ShowInn, "ShowInn" },
            { EventCommandCode.EnterHeroName, "EnterHeroName" },
            { EventCommandCode.Teleport, "Teleport" },
            { EventCommandCode.MemorizeLocation, "MemorizeLocation" },
            { EventCommandCode.RecallToLocation, "RecallToLocation" },
            { EventCommandCode.EnterExitVehicle, "EnterExitVehicle" },
            { EventCommandCode.SetVehicleLocation, "SetVehicleLocation" },
            { EventCommandCode.ChangeEventLocation, "ChangeEventLocation" },
            { EventCommandCode.TradeEventLocations, "TradeEventLocations" },
            { EventCommandCode.StoreTerrainID, "StoreTerrainID" },
            { EventCommandCode.StoreEventID, "StoreEventID" },
            { EventCommandCode.EraseScreen, "EraseScreen" },
            { EventCommandCode.ShowScreen, "ShowScreen" },
            { EventCommandCode.TintScreen, "TintScreen" },
            { EventCommandCode.FlashScreen, "FlashScreen" },
            { EventCommandCode.ShakeScreen, "ShakeScreen" },
            { EventCommandCode.PanScreen, "PanScreen" },
            { EventCommandCode.WeatherEffects, "WeatherEffects" },
            { EventCommandCode.ShowPicture, "ShowPicture" },
            { EventCommandCode.MovePicture, "MovePicture" },
            { EventCommandCode.ErasePicture, "ErasePicture" },
            { EventCommandCode.ShowBattleAnimation, "ShowBattleAnimation" },
            { EventCommandCode.PlayerVisibility, "PlayerVisibility" },
            { EventCommandCode.FlashSprite, "FlashSprite" },
            { EventCommandCode.MoveEvent, "MoveEvent" },
            { EventCommandCode.ProceedWithMovement, "ProceedWithMovement" },
            { EventCommandCode.HaltAllMovement, "HaltAllMovement" },
            { EventCommandCode.Wait, "Wait" },
            { EventCommandCode.PlayBGM, "PlayBGM" },
            { EventCommandCode.FadeOutBGM, "FadeOutBGM" },
            { EventCommandCode.MemorizeBGM, "MemorizeBGM" },
            { EventCommandCode.PlayMemorizedBGM, "PlayMemorizedBGM" },
            { EventCommandCode.PlaySound, "PlaySound" },
            { EventCommandCode.PlayMovie, "PlayMovie" },
            { EventCommandCode.KeyInputProc, "KeyInputProc" },
            { EventCommandCode.ChangeMapTileset, "ChangeMapTileset" },
            { EventCommandCode.ChangePBG, "ChangePBG" },
            { EventCommandCode.ChangeEncounterSteps, "ChangeEncounterSteps" },
            { EventCommandCode.TileSubstitution, "TileSubstitution" },
            { EventCommandCode.TeleportTargets, "TeleportTargets" },
            { EventCommandCode.ChangeTeleportAccess, "ChangeTeleportAccess" },
            { EventCommandCode.EscapeTarget, "EscapeTarget" },
            { EventCommandCode.ChangeEscapeAccess, "ChangeEscapeAccess" },
            { EventCommandCode.OpenSaveMenu, "OpenSaveMenu" },
            { EventCommandCode.ChangeSaveAccess, "ChangeSaveAccess" },
            { EventCommandCode.OpenMainMenu, "OpenMainMenu" },
            { EventCommandCode.ChangeMainMenuAccess, "ChangeMainMenuAccess" },
            { EventCommandCode.ConditionalBranch, "ConditionalBranch" },
            { EventCommandCode.Label, "Label" },
            { EventCommandCode.JumpToLabel, "JumpToLabel" },
            { EventCommandCode.Loop, "Loop" },
            { EventCommandCode.BreakLoop, "BreakLoop" },
            { EventCommandCode.EndEventProcessing, "EndEventProcessing" },
            { EventCommandCode.EraseEvent, "EraseEvent" },
            { EventCommandCode.CallEvent, "CallEvent" },
            { EventCommandCode.Comment, "Comment" },
            { EventCommandCode.GameOver, "GameOver" },
            { EventCommandCode.ReturntoTitleScreen, "ReturntoTitleScreen" },
            { EventCommandCode.ChangeMonsterHP, "ChangeMonsterHP" },
            { EventCommandCode.ChangeMonsterMP, "ChangeMonsterMP" },
            { EventCommandCode.ChangeMonsterCondition, "ChangeMonsterCondition" },
            { EventCommandCode.ShowHiddenMonster, "ShowHiddenMonster" },
            { EventCommandCode.ChangeBattleBG, "ChangeBattleBG" },
            { EventCommandCode.ShowBattleAnimation_B, "ShowBattleAnimation_B" },
            { EventCommandCode.ConditionalBranch_B, "ConditionalBranch_B" },
            { EventCommandCode.TerminateBattle, "TerminateBattle" },
            { EventCommandCode.ShowMessage_2, "ShowMessage_2" },
            { EventCommandCode.ShowChoiceOption, "ShowChoiceOption" },
            { EventCommandCode.ShowChoiceEnd, "ShowChoiceEnd" },
            { EventCommandCode.VictoryHandler, "VictoryHandler" },
            { EventCommandCode.EscapeHandler, "EscapeHandler" },
            { EventCommandCode.DefeatHandler, "DefeatHandler" },
            { EventCommandCode.EndBattle, "EndBattle" },
            { EventCommandCode.Transaction, "Transaction" },
            { EventCommandCode.NoTransaction, "NoTransaction" },
            { EventCommandCode.EndShop, "EndShop" },
            { EventCommandCode.Stay, "Stay" },
            { EventCommandCode.NoStay, "NoStay" },
            { EventCommandCode.EndInn, "EndInn" },
            { EventCommandCode.ElseBranch, "ElseBranch" },
            { EventCommandCode.EndBranch, "EndBranch" },
            { EventCommandCode.EndLoop, "EndLoop" },
            { EventCommandCode.Comment_2, "Comment_2" },
            { EventCommandCode.ElseBranch_B, "ElseBranch_B" },
            { EventCommandCode.EndBranch_B, "EndBranch_B" }
        };

        public EventCommandCode Code
        {
            get;
            set;
        }

        public int Indent
        {
            get;
            set;
        }

        public DbString String
        {
            get;
            set;
        }

        public List<int> Parameters
        {
            get;
            set;
        } = new List<int>();
    }
}