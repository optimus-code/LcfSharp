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
    public enum TerrainChunk : int
    {
        /** String */
        Name = 0x01,
        /** Integer */
        Damage = 0x02,
        /** Integer */
        EncounterRate = 0x03,
        /** String */
        BackgroundName = 0x04,
        /** Flag */
        BoatPass = 0x05,
        /** Flag */
        ShipPass = 0x06,
        /** Flag */
        AirshipPass = 0x07,
        /** Flag */
        AirshipLand = 0x09,
        /** Integer */
        BushDepth = 0x0B,
        /** rpg::Sound - RPG2003 */
        Footstep = 0x0F,
        /** Flag - RPG2003 */
        OnDamageSe = 0x10,
        /** Integer - RPG2003 */
        BackgroundType = 0x11,
        /** String - RPG2003 */
        BackgroundAName = 0x15,
        /** Flag - RPG2003 */
        BackgroundAScrollH = 0x16,
        /** Flag - RPG2003 */
        BackgroundAScrollV = 0x17,
        /** Integer - RPG2003 */
        BackgroundAScrollHSpeed = 0x18,
        /** Integer - RPG2003 */
        BackgroundAScrollVSpeed = 0x19,
        /** Flag - RPG2003 */
        BackgroundB = 0x1E,
        /** String - RPG2003 */
        BackgroundBName = 0x1F,
        /** Flag - RPG2003 */
        BackgroundBScrollH = 0x20,
        /** Flag - RPG2003 */
        BackgroundBScrollV = 0x21,
        /** Integer - RPG2003 */
        BackgroundBScrollHSpeed = 0x22,
        /** Integer - RPG2003 */
        BackgroundBScrollVSpeed = 0x23,
        /** Bitflag - RPG2003 */
        SpecialFlags = 0x28,
        /** Integer - RPG2003 */
        SpecialBackParty = 0x29,
        /** Integer - RPG2003 */
        SpecialBackEnemies = 0x2A,
        /** Integer - RPG2003 */
        SpecialLateralParty = 0x2B,
        /** Integer - RPG2003 */
        SpecialLateralEnemies = 0x2C,
        /** Integer - RPG2003 */
        GridLocation = 0x2D,
        /** Integer - RPG2003 */
        GridTopY = 0x2E,
        /** Integer - RPG2003 */
        GridElongation = 0x2F,
        /** Integer - RPG2003 */
        GridInclination = 0x30
    }
}
