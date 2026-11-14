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
using LcfSharp.Rpg.Chipsets;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests chipset conversion and serialization.
    /// </summary>
    [TestClass]
    public class Chipsets
    {
        byte[] data = [
            0x01, 0x05, 0x42, 0x61, 0x73, 0x69, 0x63, 0x02, 0x05, 0x43, 0x68, 0x69,
            0x70, 0x41, 0x03, 0x04, 0x01, 0x00, 0x02, 0x00, 0x04, 0x02, 0x0F, 0x00,
            0x05, 0x02, 0x1F, 0x0F, 0x0C, 0x01, 0x02, 0x00
        ];

        Chipset instance = new( )
        {
            Name = "Basic",
            ChipsetName = "ChipA",
            TerrainData = [1, 2],
            PassableDataLower = [15, 0],
            PassableDataUpper = [31, 15],
            AnimationSpeed = 2
        };

        /// <summary>
        /// Checks chipset deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( Chipset ) );
                var result = ( Chipset ) converter.Read( ref scope );

                Assert.AreEqual( instance.Name, result.Name );
                Assert.AreEqual( instance.ChipsetName, result.ChipsetName );
                CollectionAssert.AreEqual( instance.TerrainData, result.TerrainData );
                TestHelpers.AssertBuffer( instance.PassableDataLower.ToArray( ), result.PassableDataLower.ToArray( ) );
                TestHelpers.AssertBuffer( instance.PassableDataUpper.ToArray( ), result.PassableDataUpper.ToArray( ) );
                Assert.AreEqual( instance.AnimationSpeed, result.AnimationSpeed );
                Assert.IsTrue( scope.IsFinished );
            }
        }

        /// <summary>
        /// Checks chipset serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( Chipset ) );

                converter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}
