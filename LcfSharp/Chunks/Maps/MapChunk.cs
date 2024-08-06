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

namespace LcfSharp.Chunks.Maps
{
    public enum MapChunk : int
    {
        /* Integer */
        ChipsetID = 0x01,

        /* Integer */
        Width = 0x02,

        /* Integer */
        Height = 0x03,

        /* Integer */
        ScrollType = 0x0B,

        /* Flag */
        ParallaxFlag = 0x1F,

        /* String */
        ParallaxName = 0x20,

        /* Flag */
        ParallaxLoopX = 0x21,

        /* Flag */
        ParallaxLoopY = 0x22,

        /* Flag */
        ParallaxAutoLoopX = 0x23,

        /* Integer */
        ParallaxSX = 0x24,

        /* Flag */
        ParallaxAutoLoopY = 0x25,

        /* Integer */
        ParallaxSY = 0x26,

        /* Flag */
        GeneratorFlag = 0x28,

        /* Integer */
        GeneratorMode = 0x29,

        /* Bool */
        TopLevel = 0x2A,

        /* Integer */
        GeneratorTiles = 0x30,

        /* Integer */
        GeneratorWidth = 0x31,

        /* Integer */
        GeneratorHeight = 0x32,

        /* Flag */
        GeneratorSurround = 0x33,

        /* Flag */
        GeneratorUpperWall = 0x34,

        /* Flag */
        GeneratorFloorB = 0x35,

        /* Flag */
        GeneratorFloorC = 0x36,

        /* Flag */
        GeneratorExtraB = 0x37,

        /* Flag */
        GeneratorExtraC = 0x38,

        /* Uint32 x 9 RPG2003 */
        GeneratorX = 0x3C,

        /* Uint32 x 9 RPG2003 */
        GeneratorY = 0x3D,

        /* Array - Short RPG2003 */
        GeneratorTileIDs = 0x3E,

        /* Array - Short */
        LowerLayer = 0x47,

        /* Array - Short */
        UpperLayer = 0x48,

        /* Array - rpg::Event */
        Events = 0x51,

        /* Integer - Used by steam version of rm2k3 instead of 0x5B. */
        SaveCount2K3E = 0x5A,

        /* Integer */
        SaveCount = 0x5B
    }
}