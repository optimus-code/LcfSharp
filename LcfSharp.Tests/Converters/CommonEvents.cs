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
    /// Tests common event conversion and serialization.
    /// </summary>
    [TestClass]
    public class CommonEvents
    {
        byte[] data = [
            0x01, 0x04, 0x54, 0x65, 0x73, 0x74, 0x0B, 0x01, 0x04, 0x0C, 0x01, 0x01,
            0x0D, 0x01, 0x09, 0x15, 0x01, 0x0D, 0x16, 0x0D, 0xCF, 0x62, 0x00, 0x00,
            0x04, 0x00, 0x56, 0x56, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        ];

        CommonEvent instance = new( )
        {
            Name = "Test",
            Trigger = CommonEventTrigger.Parallel,
            SwitchFlag = true,
            SwitchID = 9,
            EventCommands = [new( ) { Code = ( EventCommandCode ) 10210, Indent = 0, String = null, Parameters = [0, 86, 86, 0] }]
        };

        /// <summary>
        /// Checks commonevent deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( CommonEvent ) );
                var result = ( CommonEvent ) converter.Read( ref scope );

                Assert.AreEqual( instance.Name, result.Name );
                Assert.AreEqual( instance.Trigger, result.Trigger );
                Assert.AreEqual( instance.SwitchFlag, result.SwitchFlag );
                Assert.AreEqual( instance.SwitchID, result.SwitchID );
                Assert.AreEqual( 1, result.EventCommands.Count );
                Assert.AreEqual( instance.EventCommands[0].Code, result.EventCommands[0].Code );
                Assert.AreEqual( instance.EventCommands[0].Indent, result.EventCommands[0].Indent );
                CollectionAssert.AreEqual( instance.EventCommands[0].Parameters, result.EventCommands[0].Parameters );
                Assert.IsTrue( scope.IsFinished );
            }
        }

        /// <summary>
        /// Checks commonevent serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( CommonEvent ) );

                converter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}
