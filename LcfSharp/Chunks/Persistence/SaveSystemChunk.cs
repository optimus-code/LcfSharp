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

namespace LcfSharp.Chunks.Persistence
{
    public enum SaveSystemChunk : int
    {
        Scene = 0x01,
        FrameCount = 0x0B,
        GraphicsName = 0x15,
        MessageStretch = 0x16,
        FontID = 0x17,
        SwitchesSize = 0x1F,
        Switches = 0x20,
        VariablesSize = 0x21,
        Variables = 0x22,
        MessageTransparent = 0x29,
        MessagePosition = 0x2A,
        MessagePreventOverlap = 0x2B,
        MessageContinueEvents = 0x2C,
        FaceName = 0x33,
        FaceID = 0x34,
        FaceRight = 0x35,
        FaceFlip = 0x36,
        EventMessageActive = 0x37,
        MusicStopping = 0x3D,
        TitleMusic = 0x47,
        BattleMusic = 0x48,
        BattleEndMusic = 0x49,
        InnMusic = 0x4A,
        CurrentMusic = 0x4B,
        BeforeVehicleMusic = 0x4C,
        BeforeBattleMusic = 0x4D,
        StoredMusic = 0x4E,
        BoatMusic = 0x4F,
        ShipMusic = 0x50,
        AirshipMusic = 0x51,
        GameoverMusic = 0x52,
        CursorSE = 0x5B,
        DecisionSE = 0x5C,
        CancelSE = 0x5D,
        BuzzerSE = 0x5E,
        BattleSE = 0x5F,
        EscapeSE = 0x60,
        EnemyAttackSE = 0x61,
        EnemyDamagedSE = 0x62,
        ActorDamagedSE = 0x63,
        DodgeSE = 0x64,
        EnemyDeathSE = 0x65,
        ItemSE = 0x66,
        TransitionOut = 0x6F,
        TransitionIn = 0x70,
        BattleStartFadeout = 0x71,
        BattleStartFadein = 0x72,
        BattleEndFadeout = 0x73,
        BattleEndFadein = 0x74,
        TeleportAllowed = 0x79,
        EscapeAllowed = 0x7A,
        SaveAllowed = 0x7B,
        MenuAllowed = 0x7C,
        Background = 0x7D,
        SaveCount = 0x83,
        SaveSlot = 0x84,
        AtbMode = 0x8C
    }
}