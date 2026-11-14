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
    public enum SavePictureChunk : int
    {
        Name = 0x01,
        StartX = 0x02,
        StartY = 0x03,
        CurrentX = 0x04,
        CurrentY = 0x05,
        FixedToMap = 0x06,
        CurrentMagnify = 0x07,
        CurrentTopTrans = 0x08,
        UseTransparentColor = 0x09,
        CurrentRed = 0x0B,
        CurrentGreen = 0x0C,
        CurrentBlue = 0x0D,
        CurrentSat = 0x0E,
        EffectMode = 0x0F,
        CurrentEffectPower = 0x10,
        CurrentBotTrans = 0x12,
        SpritesheetCols = 0x13,
        SpritesheetRows = 0x14,
        SpritesheetFrame = 0x15,
        SpritesheetSpeed = 0x16,
        Frames = 0x17,
        SpritesheetPlayOnce = 0x18,
        MapLayer = 0x19,
        BattleLayer = 0x1A,
        Flags = 0x1B,
        FinishX = 0x1F,
        FinishY = 0x20,
        FinishMagnify = 0x21,
        FinishTopTrans = 0x22,
        FinishBotTrans = 0x23,
        FinishRed = 0x29,
        FinishGreen = 0x2A,
        FinishBlue = 0x2B,
        FinishSat = 0x2C,
        FinishEffectPower = 0x2E,
        TimeLeft = 0x33,
        CurrentRotation = 0x34,
        CurrentWaver = 0x35
    }
}