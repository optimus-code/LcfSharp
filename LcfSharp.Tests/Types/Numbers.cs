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
using System.IO;

namespace LcfSharp.Tests.Types
{
    /// <summary>
    /// Tests number conversion and serialization.
    /// </summary>
    [TestClass]
    public class Numbers
    {
        /// <summary>
        /// Checks readonly encoding.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="value">The value to write.</param>
        private readonly (byte[] data, int value)[] testCases =
        [
            ([0x84, 0x58], 600),              // Correct: 600 -> 0x84, 0x58
            ([0x81, 0x9D, 0x0E], 20110),      // Correct: 20110 -> 0x81, 0x9D, 0x0E
            ([0x00], 0),                      // Correct: 0 -> 0x00
            ([0x7F], 127),                    // Correct: 127 -> 0x7F
            ([0x81, 0x00], 128),              // Correct: 128 -> 0x81, 0x00
            ([0xFF, 0x7F], 16383),            // Correct: 16383 -> 0xFF, 0x7F
            ([0x81, 0x80, 0x00], 16384),      // Correct: 16384 -> 0x81, 0x80, 0x00
            ([0xFF, 0xFF, 0x7F], 2097151),    // Correct: 2097151 -> 0xFF, 0xFF, 0x7F
            ([0xFF, 0xFF, 0xFF, 0x7F], 268435455) // Correct: 268435455 -> 0xFF, 0xFF, 0xFF, 0x7F
        ];



        /// <summary>
        /// Checks the varint32 number deserialization.
        /// </summary>
        [TestMethod]
        public void ReadVarInt32( )
        {
            var lcfConverter = LcfConverterFactory.GetConverter( typeof( int ) );

            foreach ( var (data, expectedValue) in testCases )
            {
                using ( var ms = new MemoryStream( data ) )
                {
                    var reader = new LcfReader( ms );
                    var scope = reader.CreateRootScope( );

                    var actualValue = ( int ) lcfConverter.Read( ref scope );

                    Assert.AreEqual( expectedValue, actualValue, $"Failed reading {expectedValue}" );
                    Assert.IsTrue( scope.IsFinished );
                }
            }
        }

        /// <summary>
        /// Checks the varint32 number serialization.
        /// </summary>
        [TestMethod]
        public void WriteVarInt32( )
        {
            var lcfConverter = LcfConverterFactory.GetConverter( typeof( int ) );

            foreach ( var (expectedData, value) in testCases )
            {
                using ( var ms = new MemoryStream( ) )
                {
                    var writer = new LcfWriter( ms );
                    var scope = writer.CreateRootScope( );

                    lcfConverter.Write( ref scope, value );
                    writer.Commit( ref scope );

                    var actualData = ms.ToArray( );
                    TestHelpers.AssertBuffer( expectedData, actualData );
                }
            }
        }
    }
}