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

using LcfSharp.Chunks.MapTree;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using LcfSharp.Rpg.Audio;
using System.Collections.Generic;

namespace LcfSharp.Rpg.MapTree
{
    /// <summary>
    /// Represents the information for a map
    /// </summary>
    [LcfChunk<MapInfoChunk>]
    public class MapInfo
    {
        /// <summary>
        /// Gets or sets the unique identifier for the map.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the map.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ID of the parent map.
        /// </summary>
        public int ParentMap
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the indentation level of the map.
        /// </summary>
        public int Indentation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the map.
        /// </summary>
        public int Type
        {
            get;
            set;
        } = -1;

        /// <summary>
        /// Gets or sets the X coordinate of the scrollbar position.
        /// </summary>
        public int ScrollbarX
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Y coordinate of the scrollbar position.
        /// </summary>
        public int ScrollbarY
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the node is expanded in the editor.
        /// </summary>
        public bool ExpandedNode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the music type for the map.
        /// </summary>
        public MapInfoMusicType MusicType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the music settings for the map.
        /// </summary>
        public Music Music
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the background music type for the map.
        /// </summary>
        public MapInfoBGMType BackgroundType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the background for the map.
        /// </summary>
        public string BackgroundName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the teleportation setting for the map.
        /// </summary>
        public MapInfoTriState Teleport
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the escape setting for the map.
        /// </summary>
        public MapInfoTriState Escape
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the save setting for the map.
        /// </summary>
        public MapInfoTriState Save
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list of encounters on the map.
        /// </summary>
        public List<Encounter> Encounters
        {
            get;
            set;
        } = new List<Encounter>( );

        /// <summary>
        /// Gets or sets the number of steps between encounters.
        /// </summary>
        public int EncounterSteps
        {
            get;
            set;
        } = 25;

        /// <summary>
        /// Gets or sets the area rectangle for the map.
        /// </summary>
        public Rectangle AreaRect
        {
            get;
            set;
        }
    }
}