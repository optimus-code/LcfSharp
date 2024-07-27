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

using LcfSharp.Chunks.Database;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using LcfSharp.Rpg.Audio;

namespace LcfSharp.Rpg.Terrains
{
    /// <summary>
    /// Class representing terrain with various properties and settings.
    /// </summary>
    [LcfChunk<TerrainChunk>]
    public class Terrain
    {
        /// <summary>
        /// The unique identifier for the terrain.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the terrain.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The damage value associated with the terrain.
        /// </summary>
        public int Damage
        {
            get;
            set;
        }

        /// <summary>
        /// The encounter rate for the terrain. Default is 100.
        /// </summary>
        public int EncounterRate
        {
            get;
            set;
        } = 100;

        /// <summary>
        /// The name of the background associated with the terrain.
        /// </summary>
        public string BackgroundName
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether a boat can pass through the terrain.
        /// </summary>
        public bool BoatPass
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether a ship can pass through the terrain.
        /// </summary>
        public bool ShipPass
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether an airship can pass through the terrain. Default is true.
        /// </summary>
        public bool AirshipPass
        {
            get;
            set;
        } = true;

        /// <summary>
        /// Indicates whether an airship can land on the terrain. Default is true.
        /// </summary>
        public bool AirshipLand
        {
            get;
            set;
        } = true;

        /// <summary>
        /// The bush depth for the terrain.
        /// </summary>
        [LcfAlwaysPersist]
        public TerrainBushDepth BushDepth
        {
            get;
            set;
        }

        /// <summary>
        /// The sound for footsteps on the terrain. Only available in RM2K3.
        /// </summary>
        [LcfVersion( LcfEngineVersion.RM2K3 )]
        [LcfAlwaysPersist]
        public Sound Footstep
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the terrain plays a sound effect on damage.
        /// </summary>
        public bool OnDamageSe
        {
            get;
            set;
        }

        /// <summary>
        /// The type of background associated with the terrain.
        /// </summary>
        public TerrainBGAssociation BackgroundType
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the first background layer.
        /// </summary>
        public string BackgroundAName
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the first background layer scrolls horizontally.
        /// </summary>
        public bool BackgroundAScrollH
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the first background layer scrolls vertically.
        /// </summary>
        public bool BackgroundAScrollV
        {
            get;
            set;
        }

        /// <summary>
        /// The horizontal scroll speed of the first background layer.
        /// </summary>
        public int BackgroundAScrollHSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// The vertical scroll speed of the first background layer.
        /// </summary>
        public int BackgroundAScrollVSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the second background layer is enabled.
        /// </summary>
        public bool BackgroundB
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the second background layer.
        /// </summary>
        public string BackgroundBName
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the second background layer scrolls horizontally.
        /// </summary>
        public bool BackgroundBScrollH
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the second background layer scrolls vertically.
        /// </summary>
        public bool BackgroundBScrollV
        {
            get;
            set;
        }

        /// <summary>
        /// The horizontal scroll speed of the second background layer.
        /// </summary>
        public int BackgroundBScrollHSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// The vertical scroll speed of the second background layer.
        /// </summary>
        public int BackgroundBScrollVSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// Special flags associated with the terrain.
        /// </summary>
        public TerrainFlags SpecialFlags
        {
            get;
            set;
        } = new TerrainFlags( );

        /// <summary>
        /// The special background party value. Default is 15.
        /// </summary>
        public int SpecialBackParty
        {
            get;
            set;
        } = 15;

        /// <summary>
        /// The special background enemies value. Default is 10.
        /// </summary>
        public int SpecialBackEnemies
        {
            get;
            set;
        } = 10;

        /// <summary>
        /// The special lateral party value. Default is 10.
        /// </summary>
        public int SpecialLateralParty
        {
            get;
            set;
        } = 10;

        /// <summary>
        /// The special lateral enemies value. Default is 5.
        /// </summary>
        public int SpecialLateralEnemies
        {
            get;
            set;
        } = 5;

        /// <summary>
        /// The grid location of the terrain.
        /// </summary>
        public int GridLocation
        {
            get;
            set;
        }

        /// <summary>
        /// The top Y coordinate of the grid. Default is 120.
        /// </summary>
        public int GridTopY
        {
            get;
            set;
        } = 120;

        /// <summary>
        /// The elongation value of the grid. Default is 392.
        /// </summary>
        public int GridElongation
        {
            get;
            set;
        } = 392;

        /// <summary>
        /// The inclination value of the grid. Default is 16000.
        /// </summary>
        public int GridInclination
        {
            get;
            set;
        } = 16000;
    }
}