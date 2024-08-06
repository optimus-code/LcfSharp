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

namespace LcfSharp.Chunks.MapTree
{
    public enum MapInfoChunk : int
    {
        /* String. Note: Map ID 0 used to be game title but it should be ignored (TreeCtrl dummy editor dumped data); always use RPG_RT.ini GameTitle instead */
        Name = 0x01,
        /* Integer. Used to inherit parent map properties */
        ParentMap = 0x02,
        /* Integer. Dummy editor dumped data. Branch indentation level in TreeCtrl */
        Indentation = 0x03,
        /* Integer */
        Type = 0x04,
        /* Integer. Editor only */
        ScrollbarX = 0x05,
        /* Integer. Editor only */
        ScrollbarY = 0x06,
        /* Flag. Editor only */
        ExpandedNode = 0x07,
        /* Integer. 0=inherit; 1=from event; 2=specified in 0x0C */
        MusicType = 0x0B,
        /* Array - rpg::Music */
        Music = 0x0C,
        /* Integer. 0=inherit; 1=from terrain ldb data; 2=specified in 0x16 */
        BackgroundType = 0x15,
        /* String */
        BackgroundName = 0x16,
        /* Flag. 0=inherit; 1=allow; 2=disallow */
        Teleport = 0x1F,
        /* Flag. 0=inherit; 1=allow; 2=disallow */
        Escape = 0x20,
        /* Flag. 0=inherit; 1=allow; 2=disallow */
        Save = 0x21,
        /* Array - rpg::Encounter */
        Encounters = 0x29,
        /* 0=Encounters Disabled; 1=Encounter Rate for the map */
        EncounterSteps = 0x2C,
        /* Uint32 x 4 (Left; Top; Right; Bottom). Normal map (non-area) is 0; 0; 0; 0 */
        AreaRect = 0x33
    }
}