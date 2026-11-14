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

using LcfSharp.IO;
using LcfSharp.IO.Types;
using System.IO;

namespace LcfSharp.Tests
{
    /// <summary>
    /// Tests LMT conversion and serialization.
    /// </summary>
    [TestClass]
    public class Lmt
    {
        /// <summary>
        /// Checks lmt deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            var mapTree = LmtFile.Load( Path.Combine( "Data", "RPG_RT.lmt" ) );

            Assert.IsNotNull( mapTree );

            Assert.AreEqual( "Romancing Walker", ( string ) mapTree.Maps[0].Name );
            Assert.AreEqual( "Main MAP", ( string ) mapTree.Maps[1].Name );
        }

        /// <summary>
        /// Checks the custom lmt deserialization.
        /// </summary>
        [TestMethod]
        public void ReadCustom( )
        {
            var mapTree = LmtFile.Load( Path.Combine( "Data", "RPG_RT_2.lmt" ) );

            Assert.AreEqual( "LcfMapTree", mapTree.Header );
            Assert.AreEqual( 2, mapTree.Maps.Count );
            Assert.AreEqual( 0, mapTree.Maps[0].ID );
            Assert.AreEqual( "Untitled", ( string ) mapTree.Maps[0].Name );
            Assert.AreEqual( 1, mapTree.Maps[1].ID );
            Assert.AreEqual( "MAP0001", ( string ) mapTree.Maps[1].Name );
            CollectionAssert.AreEqual( new int[] { 0, 1 }, mapTree.TreeOrder );
            Assert.AreEqual( 1, mapTree.ActiveNode );
            Assert.AreEqual( 204, mapTree.Start.PartyMapID );
            Assert.AreEqual( 9, mapTree.Start.PartyX );
            Assert.AreEqual( 14, mapTree.Start.PartyY );
        }

        /// <summary>
        /// Checks lmt serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            var data = File.ReadAllBytes( Path.Combine( "Data", "RPG_RT_2.lmt" ) );

            var lmtFile = new LmtFile( )
            {
                Header = "LcfMapTree",
                ActiveNode = 1,
                Start = new( )
                {
                    AirshipMapID = 0,
                    AirshipX = 0,
                    AirshipY = 0,
                    BoatMapID = 0,
                    BoatX = 0,
                    BoatY = 0,
                    ShipMapID = 0,
                    ShipX = 0,
                    ShipY = 0,
                    PartyMapID = 204,
                    PartyX = 9,
                    PartyY = 14,
                },
                TreeOrder = [0, 1],
                Maps = [
                    new()
                    {
                        ID = 0,
                        Indentation = 1,
                        AreaRect = new(),
                        BackgroundName = null,
                        BackgroundType = Rpg.MapTree.MapInfoBGMType.Parent,
                        Encounters = [],
                        EncounterSteps = 0,
                        Escape = Rpg.MapTree.MapInfoTriState.Parent,
                        ExpandedNode = false,
                        Music = new(),
                        MusicType = Rpg.MapTree.MapInfoMusicType.Parent,
                        Name = "Untitled",
                        ParentMap = 0,
                        Save = Rpg.MapTree.MapInfoTriState.Parent,
                        ScrollbarX = 0,
                        ScrollbarY = 0,
                        Teleport = Rpg.MapTree.MapInfoTriState.Parent,
                        Type = 0
                    },
                    new( )
                    {
                        ID = 1,
                        Indentation = 2,
                        AreaRect = new(),
                        BackgroundName = null,
                        BackgroundType = Rpg.MapTree.MapInfoBGMType.Terrain,
                        EncounterSteps = 25,
                        Encounters = [],
                        Escape = Rpg.MapTree.MapInfoTriState.Allow,
                        ExpandedNode = false,
                        Music = new(),
                        MusicType = Rpg.MapTree.MapInfoMusicType.Event,
                        Name = "MAP0001",
                        ParentMap = 0,
                        Save = Rpg.MapTree.MapInfoTriState.Allow,
                        ScrollbarX = 0,
                        ScrollbarY = 0,
                        Teleport = Rpg.MapTree.MapInfoTriState.Allow,
                        Type = 1
                    }
                ]
            };

            using ( var ms = new MemoryStream( ) )
            {
                LcfSerialiser.Serialise( ms, lmtFile, new LcfSerialiserOptions { Format = LcfFormat.LMT } );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }

        /// <summary>
        /// Checks that lmt fixtures round-trip without byte changes.
        /// </summary>
        /// <param name="file">The fixture file name.</param>
        [TestMethod]
        [DataRow( "RPG_RT.lmt" )]
        [DataRow( "RPG_RT_2.lmt" )]
        public void RoundTrip( string file )
        {
            var path = Path.Combine( "Data", file );
            var sourceBuffer = File.ReadAllBytes( path );
            var source = LmtFile.Load( path );
            byte[] buffer;

            using ( var ms = new MemoryStream( ) )
            {
                LcfSerialiser.Serialise( ms, source,
                    new LcfSerialiserOptions { Format = LcfFormat.LMT } );

                buffer = ms.ToArray( );
            }

            LmtFile result;
            using ( var ms = new MemoryStream( buffer ) )
            {
                result = LcfSerialiser.Deserialise<LmtFile>( ms,
                    new LcfSerialiserOptions { Format = LcfFormat.LMT } );
            }

            Assert.AreEqual( source.Header, result.Header );
            Assert.AreEqual( source.Maps.Count, result.Maps.Count );
            Assert.AreEqual( source.TreeOrder.Count, result.TreeOrder.Count );
            Assert.AreEqual( source.ActiveNode, result.ActiveNode );

            TestHelpers.AssertBuffer( sourceBuffer, buffer );
        }

    }
}