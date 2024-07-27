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
    public enum DatabaseChunk : int
    {
        /** rpg::Actor */
        Actors = 0x0B,
        /** rpg::Skill */
        Skills = 0x0C,
        /** rpg::Item */
        Items = 0x0D,
        /** rpg::Enemy */
        Enemies = 0x0E,
        /** rpg::Troop */
        Troops = 0x0F,
        /** rpg::Terrain */
        Terrains = 0x10,
        /** rpg::Attribute */
        Attributes = 0x11,
        /** rpg::State */
        States = 0x12,
        /** rpg::Animation */
        Animations = 0x13,
        /** rpg::Chipset */
        Chipsets = 0x14,
        /** rpg::Terms */
        Terms = 0x15,
        /** rpg::System */
        System = 0x16,
        /** rpg::Switches */
        Switches = 0x17,
        /** rpg::Variables */
        Variables = 0x18,
        /** rpg::CommonEvent */
        CommonEvents = 0x19,
        /** Indicates version of database. When 1 the database was converted to RPG Maker 2000 v1.61 */
        Version = 0x1A,
        /** Duplicated? - Not used - RPG2003 */
        CommonEventD2 = 0x1B,
        /** Duplicated? - Not used - RPG2003 */
        CommonEventD3 = 0x1C,
        /** rpg::BattleCommand - RPG2003 */
        BattleCommands = 0x1D,
        /** rpg::Class - RPG2003 */
        Classes = 0x1E,
        /** Duplicated? - Not used - RPG2003 */
        ClassD1 = 0x1F,
        /** rpg::BattlerAnimation - RPG2003 */
        BattlerAnimations = 0x20
    }
}
