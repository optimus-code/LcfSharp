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
using LcfSharp.IO.Converters;
using LcfSharp.Rpg.Events;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests event conversion and serialization.
    /// </summary>
    [TestClass]
    public class Events
    {
        byte[] data = [0x81, 0x9D, 0x0E, 0x01, 0x26, 0x53, 0x77, 0x6F, 0x72, 0x64, 0x73, 0x5C, 0x43, 0x5B, 0x30, 0x5D, 0x20, 0x61, 0x6E, 0x64, 0x20, 0x6F, 0x74, 0x68, 0x65, 0x72, 0x20, 0x70, 0x68, 0x79, 0x73, 0x69, 0x63, 0x61, 0x6C, 0x20, 0x61, 0x74, 0x74, 0x61, 0x63, 0x6B, 0x73, 0x00];

        EventCommand instance = new EventCommand
        {
            Code = ( EventCommandCode ) 20110,
            Indent = 1,
            String = "Swords\\C[0] and other physical attacks",
            Parameters = []
        };

        /// <summary>
        /// Checks the eventcommand event deserialization.
        /// </summary>
        [TestMethod]
        public void ReadEventCommand( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var lcfConverter = LcfConverterFactory.GetConverter( typeof( EventCommand ) );
                var eventCommand = ( EventCommand ) lcfConverter.Read( ref scope );

                Assert.AreEqual( eventCommand.Code, instance.Code );
                Assert.AreEqual( eventCommand.Indent, instance.Indent );
                Assert.AreEqual( eventCommand.String, instance.String );
                CollectionAssert.AreEqual( eventCommand.Parameters, instance.Parameters );
            }
        }

        /// <summary>
        /// Checks the eventcommand event serialization.
        /// </summary>
        [TestMethod]
        public void WriteEventCommand( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( EventCommand ) );
                lcfConverter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
        /// <summary>
        /// Checks map event page encoding.
        /// </summary>
        [TestMethod]
        public void MapEventPage( )
        {
            byte[] eventData =
            [
                0x01, 0x05, 0x45, 0x56, 0x30, 0x30, 0x35,
                0x02, 0x01, 0x02,
                0x03, 0x01, 0x01,
                0x05, 0x15, 0x01, 0x01,
                0x33, 0x01, 0x0D,
                0x34, 0x0D, 0xCF, 0x62, 0x00, 0x00, 0x04, 0x00, 0x56, 0x56, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00
            ];

            var instance = new Event( )
            {
                Name = "EV005",
                X = 2,
                Y = 1,
                Pages =
                [
                    new( )
                    {
                        ID = 1,
                        EventCommands =
                        [
                            new( ) { Code = ( EventCommandCode ) 10210, Parameters = [0, 86, 86, 0] }
                        ]
                    }
                ]
            };

            var converter = LcfConverterFactory.GetConverter( typeof( Event ) );

            using ( var ms = new MemoryStream( eventData ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var result = ( Event ) converter.Read( ref scope );

                Assert.AreEqual( "EV005", ( string ) result.Name );
                Assert.AreEqual( 2, result.X );
                Assert.AreEqual( 1, result.Y );
                Assert.AreEqual( 1, result.Pages.Count );
                Assert.AreEqual( 1, result.Pages[0].ID );
                Assert.AreEqual( 1, result.Pages[0].EventCommands.Count );
                Assert.AreEqual( ( EventCommandCode ) 10210, result.Pages[0].EventCommands[0].Code );
                CollectionAssert.AreEqual( new int[] { 0, 86, 86, 0 }, result.Pages[0].EventCommands[0].Parameters );
                Assert.IsTrue( scope.IsFinished );
            }

            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                converter.Write( ref scope, instance );
                writer.Commit( ref scope );
                TestHelpers.AssertBuffer( eventData, ms.ToArray( ) );
            }
        }
    }
}