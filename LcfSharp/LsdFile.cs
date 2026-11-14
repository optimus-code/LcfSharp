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

using LcfSharp.Chunks.Persistence;
using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using LcfSharp.IO.Types.Generic;
using LcfSharp.Rpg.Persistence;
using LcfSharp.Rpg.Persistence.Events;
using LcfSharp.Rpg.Persistence.Maps;
using System.IO;

namespace LcfSharp
{
    /// <summary>
    /// Represents LsdFile in the LCF data model.
    /// </summary>
    [LcfChunk<SaveChunk>]
    public class LsdFile : ILcfRootChunk
    {
        [LcfIgnore]
        public string Header
        {
            get;
            set;
        }

        public SaveTitle Title
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public SaveSystem System
        {
            get;
            set;
        } = new SaveSystem( );

        [LcfAlwaysPersist]
        public SaveScreen Screen
        {
            get;
            set;
        } = new SaveScreen( );

        [LcfAlwaysPersist]
        public LcfIndexedList<SavePicture> Pictures
        {
            get;
            set;
        } = [];

        [LcfAlwaysPersist]
        public SavePartyLocation PartyLocation
        {
            get;
            set;
        } = new SavePartyLocation( );

        [LcfAlwaysPersist]
        public SaveVehicleLocation BoatLocation
        {
            get;
            set;
        } = new SaveVehicleLocation( );

        [LcfAlwaysPersist]
        public SaveVehicleLocation ShipLocation
        {
            get;
            set;
        } = new SaveVehicleLocation( );

        [LcfAlwaysPersist]
        public SaveVehicleLocation AirshipLocation
        {
            get;
            set;
        } = new SaveVehicleLocation( );

        [LcfAlwaysPersist]
        public LcfIndexedList<SaveActor> Actors
        {
            get;
            set;
        } = [];

        [LcfAlwaysPersist]
        public SaveInventory Inventory
        {
            get;
            set;
        } = new SaveInventory( );

        [LcfAlwaysPersist]
        public LcfIndexedList<SaveTarget> Targets
        {
            get;
            set;
        } = [];

        [LcfAlwaysPersist]
        public SaveMapInfo MapInfo
        {
            get;
            set;
        } = new SaveMapInfo( );

        [LcfAlwaysPersist]
        public SavePanorama Panorama
        {
            get;
            set;
        } = new SavePanorama( );

        [LcfAlwaysPersist]
        public SaveEventExecState ForegroundEventExecState
        {
            get;
            set;
        } = new SaveEventExecState( );

        [LcfAlwaysPersist]
        public LcfIndexedList<SaveCommonEvent> CommonEvents
        {
            get;
            set;
        } = [];

        /// <summary>
        /// Loads the LSD file from the specified file path.
        /// </summary>
        /// <param name="path">The file path of the save.</param>
        /// <param name="encodingType">The string encoding type.</param>
        /// <returns>The loaded <see cref="LsdFile"/> object.</returns>
        public static LsdFile Load( string path, LcfEncodingType encodingType = LcfEncodingType.WesternEurope1252 )
        {
            using ( var stream = File.OpenRead( path ) )
            {
                return LcfSerialiser.Deserialise<LsdFile>( stream, new LcfSerialiserOptions 
                { 
                    Format = LcfFormat.LSD,
                    EncodingType = encodingType
                } );
            }
        }

        /// <summary>
        /// Save an LSD file to the specified file path.
        /// </summary>
        /// <param name="path">The file path of the save.</param>
        /// <param name="file">The file data.</param>
        /// <param name="encodingType">The string encoding type.</param>
        public static void Save( string path, LsdFile file, LcfEncodingType encodingType = LcfEncodingType.WesternEurope1252 )
        {
            using ( var stream = File.OpenWrite( path ) )
            {
                LcfSerialiser.Serialise( stream, file, new LcfSerialiserOptions
                { 
                    Format = LcfFormat.LSD,
                    EncodingType = encodingType
                } );
            }
        }
    }
}