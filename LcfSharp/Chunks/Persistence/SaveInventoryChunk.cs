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
    public enum SaveInventoryChunk : int
    {
        PartySize = 0x01,
        Party = 0x02,
        ItemIDsSize = 0x0B,
        ItemIDs = 0x0C,
        ItemCounts = 0x0D,
        ItemUsage = 0x0E,
        Gold = 0x15,
        Timer1Frames = 0x17,
        Timer1Active = 0x18,
        Timer1Visible = 0x19,
        Timer1Battle = 0x1A,
        Timer2Frames = 0x1B,
        Timer2Active = 0x1C,
        Timer2Visible = 0x1D,
        Timer2Battle = 0x1E,
        Battles = 0x20,
        Defeats = 0x21,
        Escapes = 0x22,
        Victories = 0x23,
        Turns = 0x29,
        Steps = 0x2A,
    }
}