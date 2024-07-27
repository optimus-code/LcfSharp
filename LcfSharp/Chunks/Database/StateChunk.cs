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
    public enum StateChunk : int
    {
        Name = 0x01,
        Type = 0x02,
        Color = 0x03,
        Priority = 0x04,
        Restriction = 0x05,
        ARate = 0x0B,
        BRate = 0x0C,
        CRate = 0x0D,
        DRate = 0x0E,
        ERate = 0x0F,
        HoldTurn = 0x15,
        AutoReleaseProb = 0x16,
        ReleaseByDamage = 0x17,
        AffectType = 0x1E,
        AffectAttack = 0x1F,
        AffectDefense = 0x20,
        AffectSpirit = 0x21,
        AffectAgility = 0x22,
        ReduceHitRatio = 0x23,
        AvoidAttacks = 0x24,
        ReflectMagic = 0x25,
        Cursed = 0x26,
        BattlerAnimationId = 0x27,
        RestrictSkill = 0x29,
        RestrictSkillLevel = 0x2A,
        RestrictMagic = 0x2B,
        RestrictMagicLevel = 0x2C,
        HPChangeType = 0x2D,
        SPChangeType = 0x2E,
        MessageActor = 0x33,
        MessageEnemy = 0x34,
        MessageAlready = 0x35,
        MessageAffected = 0x36,
        MessageRecovery = 0x37,
        HPChangeMax = 0x3D,
        HPChangeVal = 0x3E,
        HPChangeMapSteps = 0x3F,
        HPChangeMapVal = 0x40,
        SPChangeMax = 0x41,
        SPChangeVal = 0x42,
        SPChangeMapSteps = 0x43,
        SPChangeMapVal = 0x44
    }
}
