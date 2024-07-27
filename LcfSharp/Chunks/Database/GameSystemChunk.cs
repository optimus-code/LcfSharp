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

namespace LcfSharp.Chunks.Database
{
    public enum GameSystemChunk : int
    {
        /** Integer - RPG2003 */
        LdbID = 0x0A,
        /** String */
        BoatName = 0x0B,
        /** String */
        ShipName = 0x0C,
        /** String */
        AirshipName = 0x0D,
        /** Integer */
        BoatIndex = 0x0E,
        /** Integer */
        ShipIndex = 0x0F,
        /** Integer */
        AirshipIndex = 0x10,
        /** String */
        TitleName = 0x11,
        /** String */
        GameoverName = 0x12,
        /** String */
        SystemName = 0x13,
        /** String - RPG2003 */
        System2Name = 0x14,
        /** Integer */
        PartySize = 0x15,
        /** Array - Short */
        Party = 0x16,
        /** Integer - RPG2003 */
        MenuCommandsSize = 0x1A,
        /** Array - Short - RPG2003 */
        MenuCommands = 0x1B,
        /** rpg::Music */
        TitleMusic = 0x1F,
        /** rpg::Music */
        BattleMusic = 0x20,
        /** rpg::Music */
        BattleEndMusic = 0x21,
        /** rpg::Music */
        InnMusic = 0x22,
        /** rpg::Music */
        BoatMusic = 0x23,
        /** rpg::Music */
        ShipMusic = 0x24,
        /** rpg::Music */
        AirshipMusic = 0x25,
        /** rpg::Music */
        GameoverMusic = 0x26,
        /** rpg::Sound */
        CursorSe = 0x29,
        /** rpg::Sound */
        DecisionSe = 0x2A,
        /** rpg::Sound */
        CancelSe = 0x2B,
        /** rpg::Sound */
        BuzzerSe = 0x2C,
        /** rpg::Sound */
        BattleSe = 0x2D,
        /** rpg::Sound */
        EscapeSe = 0x2E,
        /** rpg::Sound */
        EnemyAttackSe = 0x2F,
        /** rpg::Sound */
        EnemyDamagedSe = 0x30,
        /** rpg::Sound */
        ActorDamagedSe = 0x31,
        /** rpg::Sound */
        DodgeSe = 0x32,
        /** rpg::Sound */
        EnemyDeathSe = 0x33,
        /** rpg::Sound */
        ItemSe = 0x34,
        /** Integer */
        TransitionOut = 0x3D,
        /** Integer */
        TransitionIn = 0x3E,
        /** Integer */
        BattleStartFadeOut = 0x3F,
        /** Integer */
        BattleStartFadeIn = 0x40,
        /** Integer */
        BattleEndFadeOut = 0x41,
        /** Integer */
        BattleEndFadeIn = 0x42,
        /** Integer */
        MessageStretch = 0x47,
        /** Integer */
        FontID = 0x48,
        /** Integer */
        SelectedCondition = 0x51,
        /** Integer */
        SelectedHero = 0x52,
        /** String */
        BattleTestBackground = 0x54,
        /** Array - rpg::TestBattler */
        BattleTestData = 0x55,
        /** Integer */
        SaveCount = 0x5B,
        /** Integer */
        BattleTestTerrain = 0x5E,
        /** Integer */
        BattleTestFormation = 0x5F,
        /** Integer */
        BattleTestCondition = 0x60,
        /** Integer RPG2003 - Whether equipment usage is by Actor or by Class. This is a global setting in RM2k3! */
        EquipmentSetting = 0x61,
        /** Integer RPG2003 (EDITOR ONLY) - Double click on Terrain in Troops changes this setting and 0x54. Affects only the RM2k3 editor. */
        BattletestAltTerrain = 0x62,
        /** Flag - RPG2003 */
        ShowFrame = 0x63,
        /** String - RPG2003 */
        FrameName = 0x64,
        /** Flag - RPG2003 */
        InvertAnimations = 0x65,
        /** When false the title is skipped and the game starts directly. In TestPlay mode skips directly to the Load scene. Added in RPG Maker 2003 v1.11 */
        ShowTitle = 0x6F
    }
}
