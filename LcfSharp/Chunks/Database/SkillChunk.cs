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
    public enum SkillChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        Description = 0x02,
        /** String - RPG2000 */
        UsingMessage1 = 0x03,
        /** String - RPG2000 */
        UsingMessage2 = 0x04,
        /** Integer - RPG2000 */
        FailureMessage = 0x07,
        /** Integer */
        SkillType = 0x08,
        /** Integer - RPG2003 */
        SPType = 0x09,
        /** Integer - RPG2003 */
        SPPercent = 0x0A,
        /** Integer */
        SPCost = 0x0B,
        /** Integer */
        SkillScope = 0x0C,
        /** Integer */
        SwitchID = 0x0D,
        /** Integer */
        AnimationID = 0x0E,
        /** rpg::Sound */
        SoundEffect = 0x10,
        /** Flag */
        OccasionField = 0x12,
        /** Flag */
        OccasionBattle = 0x13,
        /** Flag - RPG2003 */
        ReverseStateEffect = 0x14,
        /** Integer */
        PhysicalRate = 0x15,
        /** Integer */
        MagicalRate = 0x16,
        /** Integer */
        Variance = 0x17,
        /** Integer */
        Power = 0x18,
        /** Integer */
        Hit = 0x19,
        /** Flag */
        AffectHP = 0x1F,
        /** Flag */
        AffectSP = 0x20,
        /** Flag */
        AffectAttack = 0x21,
        /** Flag */
        AffectDefense = 0x22,
        /** Flag */
        AffectSpirit = 0x23,
        /** Flag */
        AffectAgility = 0x24,
        /** Flag */
        AbsorbDamage = 0x25,
        /** Flag */
        IgnoreDefense = 0x26,
        /** Integer */
        StateEffectsSize = 0x29,
        /** Array - Flag */
        StateEffects = 0x2A,
        /** Integer */
        AttributeEffectsSize = 0x2B,
        /** Array - Flag */
        AttributeEffects = 0x2C,
        /** Flag */
        AffectAttrDefence = 0x2D,
        /** Integer - RPG2003 */
        BattlerAnimation = 0x31,
        /** ? - RPG2003 */
        BattlerAnimationData = 0x32
    }
}
