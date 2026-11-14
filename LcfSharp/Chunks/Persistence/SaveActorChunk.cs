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
    public enum SaveActorChunk : int
    {
        Name = 0x01,
        Title = 0x02,
        SpriteName = 0x0B,
        SpriteID = 0x0C,
        Transparency = 0x0D,
        FaceName = 0x15,
        FaceID = 0x16,
        Level = 0x1F,
        Exp = 0x20,
        HPMod = 0x21,
        SPMod = 0x22,
        AttackMod = 0x29,
        DefenseMod = 0x2A,
        SpiritMod = 0x2B,
        AgilityMod = 0x2C,
        SkillsSize = 0x33,
        Skills = 0x34,
        Equipped = 0x3D,
        CurrentHP = 0x47,
        CurrentSP = 0x48,
        BattleCommands = 0x50,
        StatusSize = 0x51,
        Status = 0x52,
        ChangedBattleCommands = 0x53,
        ClassID = 0x5A,
        Row = 0x5B,
        TwoWeapon = 0x5C,
        LockEquipment = 0x5D,
        AutoBattle = 0x5E,
        SuperGuard = 0x5F,
        BattlerAnimation = 0x60,
    }
}