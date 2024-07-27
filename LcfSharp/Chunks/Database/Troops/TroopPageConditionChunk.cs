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

namespace LcfSharp.Chunks.Database.Troops
{
    public enum TroopPageConditionChunk : int
    {
        Flags = 0x01,
        SwitchAID = 0x02,
        SwitchBID = 0x03,
        VariableID = 0x04,
        VariableValue = 0x05,
        TurnA = 0x06,
        TurnB = 0x07,
        FatigueMin = 0x08,
        FatigueMax = 0x09,
        EnemyID = 0x0A,
        EnemyHPMin = 0x0B,
        EnemyHPMax = 0x0C,
        ActorID = 0x0D,
        ActorHPMin = 0x0E,
        ActorHPMax = 0x0F,
        TurnEnemyID = 0x10,
        TurnEnemyA = 0x11,
        TurnEnemyB = 0x12,
        TurnActorID = 0x13,
        TurnActorA = 0x14,
        TurnActorB = 0x15,
        CommandActorID = 0x16,
        CommandID = 0x17
    }
}
