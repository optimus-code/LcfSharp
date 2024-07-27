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
    [LcfChunk<GameSystemChunk>]
    public class GameSystem
    {
        public int LdbID
        {
            get;
            set;
        }

        public string BoatName
        {
            get;
            set;
        }

        public string ShipName
        {
            get;
            set;
        }

        public string AirshipName
        {
            get;
            set;
        }

        public int BoatIndex
        {
            get;
            set;
        }

        public int ShipIndex
        {
            get;
            set;
        }

        public int AirshipIndex
        {
            get;
            set;
        }

        public string TitleName
        {
            get;
            set;
        }

        public string GameoverName
        {
            get;
            set;
        }

        public string SystemName
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public string System2Name
        {
            get;
            set;
        }

        public List<short> Party
        {
            get;
            set;
        } = [1];

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        [LcfSize(( int ) GameSystemChunk.MenuCommandsSize)]
        public List<short> MenuCommands
        {
            get;
            set;
        } = [1];

        public Music TitleMusic
        {
            get;
            set;
        }

        public Music BattleMusic
        {
            get;
            set;
        }

        public Music BattleEndMusic
        {
            get;
            set;
        }

        public Music InnMusic
        {
            get;
            set;
        }

        public Music BoatMusic
        {
            get;
            set;
        }

        public Music ShipMusic
        {
            get;
            set;
        }

        public Music AirshipMusic
        {
            get;
            set;
        }

        public Music GameoverMusic
        {
            get;
            set;
        }

        public Sound CursorSe
        {
            get;
            set;
        }

        public Sound DecisionSe
        {
            get;
            set;
        }

        public Sound CancelSe
        {
            get;
            set;
        }

        public Sound BuzzerSe
        {
            get;
            set;
        }

        public Sound BattleSe
        {
            get;
            set;
        }

        public Sound EscapeSe
        {
            get;
            set;
        }

        public Sound EnemyAttackSe
        {
            get;
            set;
        }

        public Sound EnemyDamagedSe
        {
            get;
            set;
        }

        public Sound ActorDamagedSe
        {
            get;
            set;
        }

        public Sound DodgeSe
        {
            get;
            set;
        }

        public Sound EnemyDeathSe
        {
            get;
            set;
        }

        public Sound ItemSe
        {
            get;
            set;
        }

        public GameSystemFadeOut TransitionOut
        {
            get;
            set;
        }

        public GameSystemFadeIn TransitionIn
        {
            get;
            set;
        }

        public GameSystemFadeOut BattleStartFadeOut
        {
            get;
            set;
        }

        public GameSystemFadeIn BattleStartFadeIn
        {
            get;
            set;
        }

        public GameSystemFadeOut BattleEndFadeOut
        {
            get;
            set;
        }

        public GameSystemFadeIn BattleEndFadeIn
        {
            get;
            set;
        }

        public GameSystemStretch MessageStretch
        {
            get;
            set;
        }

        public GameSystemFont FontID
        {
            get;
            set;
        }

        public GameSystemBattleCondition SelectedCondition
        {
            get;
            set;
        }

        public int SelectedHero
        {
            get;
            set;
        }

        public string BattleTestBackground
        {
            get;
            set;
        }

        public List<TestBattler> BattleTestData
        {
            get;
            set;
        }

        public int SaveCount
        {
            get;
            set;
        }

        public int BattleTestTerrain
        {
            get;
            set;
        }

        public GameSystemBattleFormation BattleTestFormation
        {
            get;
            set;
        }

        public GameSystemBattleCondition BattleTestCondition
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public GameSystemEquipmentSetting EquipmentSetting
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public int BattleTestAltTerrain
        {
            get;
            set;
        } = -1;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public bool ShowFrame
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public string FrameName
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public bool InvertAnimations
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public bool ShowTitle
        {
            get;
            set;
        } = true;
    }
}