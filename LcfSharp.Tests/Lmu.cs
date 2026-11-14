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
    /// Tests LMU conversion and serialization.
    /// </summary>
    [TestClass]
    public class Lmu
    {
        /// <summary>
        /// Checks lmu deserialization.
        /// </summary>
        /// <param name="file">The fixture file name.</param>
        /// <param name="chipset">The expected chipset ID.</param>
        /// <param name="width">The expected width.</param>
        /// <param name="height">The expected height.</param>
        /// <param name="eventCount">The expected event count.</param>
        /// <param name="firstEventName">The expected first event name.</param>
        /// <param name="firstEventPages">The expected page count for the first event.</param>
        [TestMethod]
        [DataRow( "Map0001.lmu", 20, 100, 135, 115, "Lavas Ville", 9 )]
        [DataRow( "Map0003.lmu", 80, 20, 15, 1, "At the Beginning...", 2 )]
        [DataRow( "Map0006.lmu", 25, 45, 60, 96, "InnR", 2 )]
        [DataRow( "Map0056.lmu", 38, 60, 45, 69, "Rock Block Event", 3 )]
        [DataRow( "Map0168.lmu", 12, 40, 40, 44, "Exit", 1 )]
        public void Read( string file, int chipset, int width, int height, int eventCount, string firstEventName, int firstEventPages )
        {
            var map = LmuFile.Load( Path.Combine( "Data", file ) );

            Assert.IsNotNull( map );
            Assert.AreEqual( "LcfMapUnit", map.Header );
            Assert.AreEqual( chipset, map.ChipsetID );
            Assert.AreEqual( width, map.Width );
            Assert.AreEqual( height, map.Height );
            Assert.AreEqual( width * height, map.LowerLayer.Count );
            Assert.AreEqual( width * height, map.UpperLayer.Count );
            Assert.AreEqual( eventCount, map.Events.Count );
            Assert.AreEqual( 1, map.Events[0].ID );
            Assert.AreEqual( firstEventName, ( string ) map.Events[0].Name );
            Assert.AreEqual( firstEventPages, map.Events[0].Pages.Count );
        }

        /// <summary>
        /// Checks the movefrequency lmu deserialization.
        /// </summary>
        [TestMethod]
        public void ReadMoveFrequency( )
        {
            var map = LmuFile.Load( Path.Combine( "Data", "Map0006.lmu" ) );
            var page = map.Events[30].Pages[0];

            Assert.AreEqual( 31, map.Events[30].ID );
            Assert.AreEqual( 8, page.MoveFrequency );
            Assert.AreEqual( 1, ( int ) page.MoveSpeed );
        }

        /// <summary>
        /// Checks the default lmu serialization.
        /// </summary>
        [TestMethod]
        public void WriteDefault( )
        {
            byte[] data = [0x0A, 0x4C, 0x63, 0x66, 0x4D, 0x61, 0x70, 0x55, 0x6E, 0x69, 0x74, 0x00];

            using ( var ms = new MemoryStream( ) )
            {
                LcfSerialiser.Serialise( ms, new LmuFile( ), new LcfSerialiserOptions { Format = LcfFormat.LMU } );
                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }

        /// <summary>
        /// Checks lmu serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            var map = new LmuFile( )
            {
                ChipsetID = 2,
                Width = 3,
                Height = 2,
                ScrollType = 1,
                LowerLayer = [1, 2, 3, 4, 5, 6],
                UpperLayer = [0, 0, 1, 1, 0, 0],
                Events = [new( ) { ID = 5, Name = "EV005", X = 2, Y = 1 }],
                SaveCount = 7
            };

            byte[] data =
            [
                0x0A, 0x4C, 0x63, 0x66, 0x4D, 0x61, 0x70, 0x55, 0x6E, 0x69, 0x74,
                0x01, 0x01, 0x02,
                0x02, 0x01, 0x03,
                0x03, 0x01, 0x02,
                0x0B, 0x01, 0x01,
                0x47, 0x0C, 0x01, 0x00, 0x02, 0x00, 0x03, 0x00, 0x04, 0x00, 0x05, 0x00, 0x06, 0x00,
                0x48, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x51, 0x10, 0x01, 0x05, 0x01, 0x05, 0x45, 0x56, 0x30, 0x30, 0x35,
                0x02, 0x01, 0x02, 0x03, 0x01, 0x01, 0x00,
                0x5B, 0x01, 0x07,
                0x00
            ];

            using ( var ms = new MemoryStream( ) )
            {
                LcfSerialiser.Serialise( ms, map, new LcfSerialiserOptions { Format = LcfFormat.LMU } );
                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }

            using ( var ms = new MemoryStream( data ) )
            {
                var result = LcfSerialiser.Deserialise<LmuFile>( ms, new LcfSerialiserOptions { Format = LcfFormat.LMU } );

                Assert.AreEqual( map.ChipsetID, result.ChipsetID );
                Assert.AreEqual( map.Width, result.Width );
                Assert.AreEqual( map.Height, result.Height );
                Assert.AreEqual( map.ScrollType, result.ScrollType );
                CollectionAssert.AreEqual( map.LowerLayer, result.LowerLayer );
                CollectionAssert.AreEqual( map.UpperLayer, result.UpperLayer );
                Assert.AreEqual( 1, result.Events.Count );
                Assert.AreEqual( 5, result.Events[0].ID );
                Assert.AreEqual( "EV005", ( string ) result.Events[0].Name );
                Assert.AreEqual( 2, result.Events[0].X );
                Assert.AreEqual( 1, result.Events[0].Y );
                Assert.AreEqual( 7, result.SaveCount );
            }
        }

        /// <summary>
        /// Checks that lmu fixtures round-trip without byte changes.
        /// </summary>
        /// <param name="file">The fixture file name.</param>
        [TestMethod]
        [DataRow( "Map0001.lmu" )]
        [DataRow( "Map0003.lmu" )]
        [DataRow( "Map0006.lmu" )]
        [DataRow( "Map0056.lmu" )]
        [DataRow( "Map0168.lmu" )]
        public void RoundTrip( string file )
        {
            var source = LmuFile.Load( Path.Combine( "Data", file ) );
            byte[] buffer;

            using ( var ms = new MemoryStream( ) )
            {
                LcfSerialiser.Serialise( ms, source, new LcfSerialiserOptions { Format = LcfFormat.LMU } );
                buffer = ms.ToArray( );
            }

            LmuFile result;
            using ( var ms = new MemoryStream( buffer ) )
                result = LcfSerialiser.Deserialise<LmuFile>( ms, new LcfSerialiserOptions { Format = LcfFormat.LMU } );

            Assert.AreEqual( source.ChipsetID, result.ChipsetID );
            Assert.AreEqual( source.Width, result.Width );
            Assert.AreEqual( source.Height, result.Height );
            Assert.AreEqual( source.ScrollType, result.ScrollType );
            Assert.AreEqual( source.ParallaxFlag, result.ParallaxFlag );
            Assert.AreEqual( source.ParallaxName, result.ParallaxName );
            Assert.AreEqual( source.SaveCount, result.SaveCount );
            CollectionAssert.AreEqual( source.LowerLayer, result.LowerLayer );
            CollectionAssert.AreEqual( source.UpperLayer, result.UpperLayer );
            Assert.AreEqual( source.Events.Count, result.Events.Count );

            for ( int i = 0; i < source.Events.Count; i++ )
            {
                var expectedEvent = source.Events[i];
                var actualEvent = result.Events[i];

                Assert.AreEqual( expectedEvent.ID, actualEvent.ID, $"Event {i}" );
                Assert.AreEqual( expectedEvent.Name, actualEvent.Name, $"Event {i}" );
                Assert.AreEqual( expectedEvent.X, actualEvent.X, $"Event {i}" );
                Assert.AreEqual( expectedEvent.Y, actualEvent.Y, $"Event {i}" );
                Assert.AreEqual( expectedEvent.Pages.Count, actualEvent.Pages.Count, $"Event {i}" );

                for ( int p = 0; p < expectedEvent.Pages.Count; p++ )
                {
                    var expectedPage = expectedEvent.Pages[p];
                    var actualPage = actualEvent.Pages[p];

                    Assert.AreEqual( expectedPage.ID, actualPage.ID, $"Event {i}, page {p}" );
                    Assert.AreEqual( expectedPage.MoveFrequency, actualPage.MoveFrequency, $"Event {i}, page {p}" );
                    Assert.AreEqual( expectedPage.MoveSpeed, actualPage.MoveSpeed, $"Event {i}, page {p}" );
                    Assert.AreEqual( expectedPage.EventCommands.Count, actualPage.EventCommands.Count, $"Event {i}, page {p}" );

                    for ( int c = 0; c < expectedPage.EventCommands.Count; c++ )
                    {
                        var expectedCommand = expectedPage.EventCommands[c];
                        var actualCommand = actualPage.EventCommands[c];

                        Assert.AreEqual( expectedCommand.Code, actualCommand.Code, $"Event {i}, page {p}, command {c}" );
                        Assert.AreEqual( expectedCommand.Indent, actualCommand.Indent, $"Event {i}, page {p}, command {c}" );
                        Assert.AreEqual( expectedCommand.String, actualCommand.String, $"Event {i}, page {p}, command {c}" );
                        CollectionAssert.AreEqual( expectedCommand.Parameters, actualCommand.Parameters, $"Event {i}, page {p}, command {c}" );
                    }
                }
            }
        }
    }
}
