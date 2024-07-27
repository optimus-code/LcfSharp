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

namespace LcfSharp.Chunks.Database.Enemies
{
    public enum EnemyChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        BattlerName = 0x02,
        /** Integer */
        BattlerHue = 0x03,
        /** Integer */
        MaxHP = 0x04,
        /** Integer */
        MaxSP = 0x05,
        /** Integer */
        Attack = 0x06,
        /** Integer */
        Defense = 0x07,
        /** Integer */
        Spirit = 0x08,
        /** Integer */
        Agility = 0x09,
        /** Flag */
        Transparent = 0x0A,
        /** Integer */
        Exp = 0x0B,
        /** Integer */
        Gold = 0x0C,
        /** Integer */
        DropID = 0x0D,
        /** Integer */
        DropProb = 0x0E,
        /** Flag */
        CriticalHit = 0x15,
        /** Integer */
        CriticalHitChance = 0x16,
        /** Flag */
        Miss = 0x1A,
        /** Flag */
        Levitate = 0x1C,
        /** Integer */
        StateRanksSize = 0x1F,
        /** Array - Short */
        StateRanks = 0x20,
        /** Integer */
        AttributeRanksSize = 0x21,
        /** Array - Short */
        AttributeRanks = 0x22,
        /** Array - rpg::EnemyAction */
        Actions = 0x2A
    }
}
