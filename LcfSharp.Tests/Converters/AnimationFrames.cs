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
    /// Tests animation frame conversion and serialization.
    /// </summary>
    [TestClass]
    public class AnimationFrames
    {
        byte[] data =
        [
            0x01, 0x09,       // Cells chunk, 9-byte payload
            0x01,             // One cell
            0x01,             // Cell ID = 1
            0x02, 0x01, 0x05, // CellID = 5
            0x05, 0x01, 0x50, // Zoom = 80
            0x00,             // End of cell
            0x00              // End of frame
        ];


        AnimationFrame instance = new( )
        {
            Cells = [new( ) 
            {
                ID = 1, 
                Valid = 1,
                CellID = 5, 
                Zoom = 80 
            }]
        };

        /// <summary>
        /// Checks animationframe deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( AnimationFrame ) );
                var result = ( AnimationFrame ) converter.Read( ref scope );

                Assert.AreEqual( 1, result.Cells.Count );
                Assert.AreEqual( 1, result.Cells[0].ID );
                Assert.AreEqual( 1, result.Cells[0].Valid );
                Assert.AreEqual( 5, result.Cells[0].CellID );
                Assert.AreEqual( 80, result.Cells[0].Zoom );
                Assert.IsTrue( scope.IsFinished );
            }
        }

        /// <summary>
        /// Checks animationframe serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( AnimationFrame ) );

                converter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}
