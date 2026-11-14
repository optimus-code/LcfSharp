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
    public enum SaveScreenChunk : int
    {
        TintFinishRed = 0x01,
        TintFinishGreen = 0x02,
        TintFinishBlue = 0x03,
        TintFinishSat = 0x04,
        TintCurrentRed = 0x0B,
        TintCurrentGreen = 0x0C,
        TintCurrentBlue = 0x0D,
        TintCurrentSat = 0x0E,
        TintTimeLeft = 0x0F,
        FlashContinuous = 0x14,
        FlashRed = 0x15,
        FlashGreen = 0x16,
        FlashBlue = 0x17,
        FlashCurrentLevel = 0x18,
        FlashTimeLeft = 0x19,
        ShakeContinuous = 0x1E,
        ShakeStrength = 0x1F,
        ShakeSpeed = 0x20,
        ShakePosition = 0x21,
        ShakePositionY = 0x22,
        ShakeTimeLeft = 0x23,
        PanX = 0x29,
        PanY = 0x2A,
        BattleAnimID = 0x2B,
        BattleAnimTarget = 0x2C,
        BattleAnimFrame = 0x2D,
        BattleAnimActive = 0x2E,
        BattleAnimGlobal = 0x2F,
        Weather = 0x30,
        WeatherStrength = 0x31,
    }
}