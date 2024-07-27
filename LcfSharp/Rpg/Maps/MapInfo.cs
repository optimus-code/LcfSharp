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

using LcfSharp.Rpg.Audio;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Maps
{
    public enum MapInfoMusicType
    {
        Parent = 0,
        Event = 1,
        Specific = 2
    }

    public enum MapInfoBGMType
    {
        Parent = 0,
        Terrain = 1,
        Specific = 2
    }

    public enum MapInfoTriState
    {
        Parent = 0,
        Allow = 1,
        Forbid = 2
    }

    public class MapInfo
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int ParentMap
        {
            get;
            set;
        }

        public int Indentation
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        } = -1;

        public int ScrollbarX
        {
            get;
            set;
        }

        public int ScrollbarY
        {
            get;
            set;
        }

        public bool ExpandedNode
        {
            get;
            set;
        }

        public int MusicType
        {
            get;
            set;
        }

        public Music Music
        {
            get;
            set;
        }

        public int BackgroundType
        {
            get;
            set;
        }

        public string BackgroundName
        {
            get;
            set;
        }

        public int Teleport
        {
            get;
            set;
        }

        public int Escape
        {
            get;
            set;
        }

        public int Save
        {
            get;
            set;
        }

        public List<Encounter> Encounters
        {
            get;
            set;
        } = [];

        public int EncounterSteps
        {
            get;
            set;
        } = 25;

        public Rect AreaRect
        {
            get;
            set;
        }

        // Temp
        public struct Rect
        {
        }
    }
}
