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
    /// Tests animation timing conversion and serialization.
    /// </summary>
    [TestClass]
    public class AnimationTimings
    {
        byte[] data = [
            0x01, 0x01, 0x02, 0x02, 0x08, 0x01, 0x05, 0x28, 0x4F, 0x46, 0x46, 0x29,
            0x00, 0x03, 0x01, 0x00, 0x00
        ];

        AnimationTiming instance = new( )
        {
            Frame = 2,
            Se = new LcfSharp.Rpg.Audio.Sound( )
        };

        /// <summary>
        /// Checks animationtiming deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( AnimationTiming ) );
                var result = ( AnimationTiming ) converter.Read( ref scope );

                Assert.AreEqual( instance.Frame, result.Frame );
                Assert.AreEqual( instance.Se.Name, result.Se.Name );
                Assert.AreEqual( instance.FlashScope, result.FlashScope );
                Assert.IsTrue( scope.IsFinished );
            }
        }

        /// <summary>
        /// Checks animationtiming serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( AnimationTiming ) );

                converter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}
