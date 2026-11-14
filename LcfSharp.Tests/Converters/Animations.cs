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
using LcfSharp.Rpg.Animations;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests animation conversion and serialization.
    /// </summary>
    [TestClass]
    public class Animations
    {
        byte[] data = [
            0x01, 0x05, 0x46, 0x6C, 0x61, 0x73, 0x68, 0x02, 0x06, 0x45, 0x66, 0x66,
            0x65, 0x63, 0x74, 0x06, 0x01, 0x00, 0x09, 0x01, 0x00, 0x0A, 0x01, 0x00,
            0x0C, 0x01, 0x00, 0x00
        ];

        Animation instance = new( )
        {
            Name = "Flash",
            AnimationName = "Effect",
            Position = AnimationPosition.Up
        };

        /// <summary>
        /// Checks animation deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( Animation ) );
                var result = ( Animation ) converter.Read( ref scope );

                Assert.AreEqual( instance.Name, result.Name );
                Assert.AreEqual( instance.AnimationName, result.AnimationName );
                Assert.AreEqual( instance.Scope, result.Scope );
                Assert.AreEqual( instance.Position, result.Position );
                Assert.AreEqual( 0, result.Timings.Count );
                Assert.AreEqual( 0, result.Frames.Count );
                Assert.IsTrue( scope.IsFinished );
            }
        }

        /// <summary>
        /// Checks animation serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( Animation ) );

                converter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}
