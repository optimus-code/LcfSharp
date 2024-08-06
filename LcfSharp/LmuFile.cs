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

using LcfSharp.Chunks.Maps;
using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using LcfSharp.Rpg.Events;
using System.Collections.Generic;
using System.IO;

namespace LcfSharp
{
    [LcfChunk<MapChunk>]
    public class LmuFile : ILcfRootChunk
    {
        [LcfIgnore]
        public string Header
        {
            get;
            set;
        }

        public int ChipsetID
        {
            get;
            set;
        } = 1;

        public int Width
        {
            get;
            set;
        } = 20;

        public int Height
        {
            get;
            set;
        } = 15;

        public int ScrollType
        {
            get;
            set;
        }

        public bool ParallaxFlag
        {
            get;
            set;
        }

        public string ParallaxName
        {
            get;
            set;
        }

        public bool ParallaxLoopX
        {
            get;
            set;
        }

        public bool ParallaxLoopY
        {
            get;
            set;
        }

        public bool ParallaxAutoLoopX
        {
            get;
            set;
        }

        public int ParallaxSx
        {
            get;
            set;
        }

        public bool ParallaxAutoLoopY
        {
            get;
            set;
        }

        public int ParallaxSy
        {
            get;
            set;
        }

        public bool GeneratorFlag
        {
            get;
            set;
        }

        public int GeneratorMode
        {
            get;
            set;
        }

        public bool TopLevel
        {
            get;
            set;
        }

        public int GeneratorTiles
        {
            get;
            set;
        }

        public int GeneratorWidth
        {
            get;
            set;
        } = 4;

        public int GeneratorHeight
        {
            get;
            set;
        } = 1;

        public bool GeneratorSurround
        {
            get;
            set;
        } = true;

        public bool GeneratorUpperWall
        {
            get;
            set;
        } = true;

        public bool GeneratorFloorB
        {
            get;
            set;
        } = true;

        public bool GeneratorFloorC
        {
            get;
            set;
        } = true;

        public bool GeneratorExtraB
        {
            get;
            set;
        } = true;

        public bool GeneratorExtraC
        {
            get;
            set;
        } = true;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public List<uint> GeneratorX
        {
            get;
            set;
        } = [];

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public List<uint> GeneratorY
        {
            get;
            set;
        } = [];

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public List<short> GeneratorTileIDs
        {
            get;
            set;
        } = [];

        public List<short> LowerLayer
        {
            get;
            set;
        } = [];

        public List<short> UpperLayer
        {
            get;
            set;
        } = [];

        public List<Event> Events
        {
            get;
            set;
        } = [];

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int SaveCount2k3e
        {
            get;
            set;
        }

        public int SaveCount
        {
            get;
            set;
        }

        /// <summary>
        /// Loads the map from the specified file path.
        /// </summary>
        /// <param name="path">The file path of the map.</param>
        /// <returns>The loaded <see cref="LmuFile"/> object.</returns>
        public static LmuFile Load( string path )
        {
            using ( var stream = File.OpenRead( path ) )
            {
                return LcfSerialiser.Deserialise<LmuFile>( stream, new LcfSerialiserOptions { Format = LcfFormat.LMU } );
            }
        }
    }
}