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
    public enum SavePartyLocationChunk : int
    {
        Active = 0x01,
        MapID = 0x0B,
        PositionX = 0x0C,
        PositionY = 0x0D,
        Direction = 0x15,
        Facing = 0x16,
        AnimFrame = 0x17,
        Transparency = 0x18,
        RemainingStep = 0x1F,
        MoveFrequency = 0x20,
        Layer = 0x21,
        OverlapForbidden = 0x22,
        AnimationType = 0x23,
        LockFacing = 0x24,
        MoveSpeed = 0x25,
        MoveRoute = 0x29,
        MoveRouteOverwrite = 0x2A,
        MoveRouteIndex = 0x2B,
        MoveRouteFinished = 0x2C,
        SpriteHidden = 0x2E,
        MoveRouteThrough = 0x2F,
        AnimPaused = 0x30,
        Through = 0x33,
        StopCount = 0x34,
        AnimCount = 0x35,
        MaxStopCount = 0x36,
        Jumping = 0x3D,
        BeginJumpX = 0x3E,
        BeginJumpY = 0x3F,
        Pause = 0x47,
        Flying = 0x48,
        SpriteName = 0x49,
        SpriteID = 0x4A,
        Processed = 0x4B,
        FlashRed = 0x51,
        FlashGreen = 0x52,
        FlashBlue = 0x53,
        FlashCurrentLevel = 0x54,
        FlashTimeLeft = 0x55,
        Boarding = 0x65,
        Aboard = 0x66,
        Vehicle = 0x67,
        Unboarding = 0x68,
        PreboardMoveSpeed = 0x69,
        MenuCalling = 0x6C,
        PanState = 0x6F,
        PanCurrentX = 0x70,
        PanCurrentY = 0x71,
        PanFinishX = 0x72,
        PanFinishY = 0x73,
        PanSpeed = 0x79,
        TotalEncounterRate = 0x7C,
        EncounterCalling = 0x7D,
        MapSaveCount = 0x83,
        DatabaseSaveCount = 0x84
    }
}