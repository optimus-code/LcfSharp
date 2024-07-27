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
    public enum ItemChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        Description = 0x02,
        /** Integer */
        Type = 0x03,
        /** Integer */
        Price = 0x05,
        /** Integer */
        Uses = 0x06,
        /** Integer */
        AtkPoints1 = 0x0B,
        /** Integer */
        DefPoints1 = 0x0C,
        /** Integer */
        SpiPoints1 = 0x0D,
        /** Integer */
        AgiPoints1 = 0x0E,
        /** Flag */
        TwoHanded = 0x0F,
        /** Integer */
        SpCost = 0x10,
        /** Integer */
        Hit = 0x11,
        /** Integer */
        CriticalHit = 0x12,
        /** Integer */
        AnimationID = 0x14,
        /** Flag */
        Preemptive = 0x15,
        /** Flag */
        DualAttack = 0x16,
        /** Flag */
        AttackAll = 0x17,
        /** Flag */
        IgnoreEvasion = 0x18,
        /** Flag */
        PreventCritical = 0x19,
        /** Flag */
        RaiseEvasion = 0x1A,
        /** Flag */
        HalfSPCost = 0x1B,
        /** Flag */
        NoTerrainDamage = 0x1C,
        /** Flag - RPG2003 */
        Cursed = 0x1D,
        /** Flag */
        EntireParty = 0x1F,
        /** Integer */
        RecoverHPRate = 0x20,
        /** Integer */
        RecoverHP = 0x21,
        /** Integer */
        RecoverSPRate = 0x22,
        /** Integer */
        RecoverSP = 0x23,
        /** Flag */
        OccasionField1 = 0x25,
        /** Flag */
        KOOnly = 0x26,
        /** Integer */
        MaxHPPoints = 0x29,
        /** Integer */
        MaxSPPoints = 0x2A,
        /** Integer */
        AtkPoints2 = 0x2B,
        /** Integer */
        DefPoints2 = 0x2C,
        /** Integer */
        SpiPoints2 = 0x2D,
        /** Integer */
        AgiPoints2 = 0x2E,
        /** Integer */
        UsingMessage = 0x33,
        /** Integer */
        SkillID = 0x35,
        /** Integer */
        SwitchID = 0x37,
        /** Flag */
        OccasionField2 = 0x39,
        /** Flag */
        OccasionBattle = 0x3A,
        /** Integer */
        ActorSetSize = 0x3D,
        /** Array - Flag */
        ActorSet = 0x3E,
        /** Integer */
        StateSetSize = 0x3F,
        /** Array - Flag */
        StateSet = 0x40,
        /** Integer */
        AttributeSetSize = 0x41,
        /** Array - Flag */
        AttributeSet = 0x42,
        /** Integer */
        StateChance = 0x43,
        /** Flag */
        ReverseStateEffect = 0x44,
        /** Integer - RPG2003 */
        WeaponAnimation = 0x45,
        /** Array - RPG2003 */
        AnimationData = 0x46,
        /** Flag - RPG2003 */
        UseSkill = 0x47,
        /** Integer - RPG2003 */
        ClassSetSize = 0x48,
        /** Array - Flag - RPG2003 */
        ClassSet = 0x49,
        /** Integer */
        RangedTrajectory = 0x4B,
        /** Integer */
        RangedTarget = 0x4C
    }
}
