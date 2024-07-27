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
    public enum ActorChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        Title = 0x02,
        /** String */
        CharacterName = 0x03,
        /** Integer */
        CharacterIndex = 0x04,
        /** Flag */
        Transparent = 0x05,
        /** Integer */
        InitialLevel = 0x07,
        /** Integer */
        FinalLevel = 0x08,
        /** Flag */
        CriticalHit = 0x09,
        /** Integer */
        CriticalHitChance = 0x0A,
        /** String */
        FaceName = 0x0F,
        /** Integer */
        FaceIndex = 0x10,
        /** Flag */
        TwoWeapon = 0x15,
        /** Flag */
        LockEquipment = 0x16,
        /** Flag */
        AutoBattle = 0x17,
        /** Flag */
        SuperGuard = 0x18,
        /** Array x 6 - Short */
        Parameters = 0x1F,
        /** Integer */
        ExpBase = 0x29,
        /** Integer */
        ExpInflation = 0x2A,
        /** Integer */
        ExpCorrection = 0x2B,
        /** Integer x 5 */
        InitialEquipment = 0x33,
        /** Integer */
        UnarmedAnimation = 0x38,
        /** Integer - RPG2003 */
        ClassId = 0x39,
        /** Integer - RPG2003 */
        BattleX = 0x3B,
        /** Integer - RPG2003 */
        BattleY = 0x3C,
        /** Integer - RPG2003 */
        BattlerAnimation = 0x3E,
        /** Array - rpg::Learning */
        Skills = 0x3F,
        /** Flag */
        RenameSkill = 0x42,
        /** String */
        SkillName = 0x43,
        /** Integer */
        StateRanksSize = 0x47,
        /** Array - Short */
        StateRanks = 0x48,
        /** Integer */
        AttributeRanksSize = 0x49,
        /** Array - Short */
        AttributeRanks = 0x4A,
        /** Array - rpg::BattleCommand - RPG2003 */
        BattleCommands = 0x50,
    }
}
