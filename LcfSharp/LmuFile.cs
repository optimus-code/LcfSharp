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
using LcfSharp.IO.Types.Generic;
using LcfSharp.Rpg.Events;
using System.IO;

namespace LcfSharp
{
    /// <summary>
    /// Represents LmuFile in the LCF data model.
    /// </summary>
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

        public LcfString ParallaxName
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

        public int ParallaxSX
        {
            get;
            set;
        }

        public bool ParallaxAutoLoopY
        {
            get;
            set;
        }

        public int ParallaxSY
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
        public LcfPackedList<uint> GeneratorX
        {
            get;
            set;
        } = [];

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public LcfPackedList<uint> GeneratorY
        {
            get;
            set;
        } = [];

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public LcfPackedList<short> GeneratorTileIDs
        {
            get;
            set;
        } = [];

        public LcfPackedList<short> LowerLayer
        {
            get;
            set;
        } = [];

        public LcfPackedList<short> UpperLayer
        {
            get;
            set;
        } = [];

        public LcfIndexedList<Event> Events
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
        /// Loads the LMU file from the specified file path.
        /// </summary>
        /// <param name="path">The file path of the map.</param>
        /// <param name="encodingType">The string encoding type.</param>
        /// <returns>The loaded <see cref="LmuFile"/> object.</returns>
        public static LmuFile Load( string path, LcfEncodingType encodingType = LcfEncodingType.WesternEurope1252 )
        {
            using ( var stream = File.OpenRead( path ) )
            {
                return LcfSerialiser.Deserialise<LmuFile>( stream, new LcfSerialiserOptions 
                { 
                    Format = LcfFormat.LMU,
                    EncodingType = encodingType
                } );
            }
        }

        /// <summary>
        /// Save an LMU file to the specified file path.
        /// </summary>
        /// <param name="path">The file path of the map.</param>
        /// <param name="file">The file data.</param>
        /// <param name="encodingType">The string encoding type.</param>
        public static void Save( string path, LmuFile file, LcfEncodingType encodingType = LcfEncodingType.WesternEurope1252 )
        {
            using ( var stream = File.OpenWrite( path ) )
            {
                LcfSerialiser.Serialise( stream, file, new LcfSerialiserOptions 
                { 
                    Format = LcfFormat.LMU,
                    EncodingType = encodingType
                } );
            }
        }
    }
}