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
using LcfSharp.Rpg.Enemies;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests enemie conversion and serialization.
    /// </summary>
    [TestClass]
    public class Enemies
    {
        byte[] data = [
            0x01, 0x05, 0x53, 0x6C, 0x69, 0x6D, 0x65, 0x04, 0x01, 0x18, 0x1F, 0x01,
            0x03, 0x20, 0x03, 0x01, 0x02, 0x03, 0x21, 0x01, 0x02, 0x22, 0x02, 0x02,
            0x01, 0x2A, 0x0F, 0x01, 0x01, 0x01, 0x01, 0x00, 0x02, 0x01, 0x00, 0x05,
            0x01, 0x00, 0x0D, 0x01, 0x05, 0x00, 0x00
        ];

        Enemy instance = new( )
        {
            Name = "Slime",
            MaxHP = 24,
            StateRanks = [1, 2, 3],
            AttributeRanks = [2, 1],
            Actions = [new( ) { ID = 1, Rating = 5 }]
        };

        /// <summary>
        /// Checks enemie deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( Enemy ) );
                var result = ( Enemy ) converter.Read( ref scope );

                Assert.AreEqual( instance.Name, result.Name );
                Assert.AreEqual( instance.MaxHP, result.MaxHP );
                TestHelpers.AssertBuffer( instance.StateRanks.ToArray( ), result.StateRanks.ToArray( ) );
                TestHelpers.AssertBuffer( instance.AttributeRanks.ToArray( ), result.AttributeRanks.ToArray( ) );
                Assert.AreEqual( 1, result.Actions.Count );
                Assert.AreEqual( 1, result.Actions[0].ID );
                Assert.AreEqual( 5, result.Actions[0].Rating );
                Assert.IsTrue( scope.IsFinished );
            }
        }

        /// <summary>
        /// Checks enemie serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( Enemy ) );

                converter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}
