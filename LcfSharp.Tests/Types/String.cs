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

namespace LcfSharp.Tests.Types
{
    /// <summary>
    /// Tests string conversion and serialization.
    /// </summary>
    [TestClass]
    public class String
    {
        private static readonly byte[] EnglishData = [0x05, 0x48, 0x65, 0x6C, 0x6C, 0x6F]; // "Hello" in ASCII
        private static readonly byte[] JapaneseData = [0x0A, 0x82, 0xA0, 0x82, 0xA2, 0x82, 0xA4, 0x82, 0xA6, 0x82, 0xA8]; // "あいうえお" in SHIFT-JIS


        /// <summary>
        /// Checks the ascii string deserialization.
        /// </summary>
        [TestMethod]
        public void ReadAscii( )
        {

            using ( var ms = new MemoryStream( EnglishData ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var value = scope.ReadString( );
                Assert.AreEqual( "Hello", ( string ) value );
            }
        }

        /// <summary>
        /// Checks the shiftjis string deserialization.
        /// </summary>
        [TestMethod]
        public void ReadShiftJis( )
        {
            using ( var ms = new MemoryStream( JapaneseData ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var value = scope.ReadString( LcfEncodingType.JapaneseShiftJis );
                Assert.AreEqual( "あいうえお", ( string ) value );
            }
        }

        /// <summary>
        /// Checks the ascii string serialization.
        /// </summary>
        [TestMethod]
        public void WriteAscii( )
        {
            LcfString input = "Hello";

            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                scope.WriteString( input );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( EnglishData, ms.ToArray( ) );
            }
        }

        /// <summary>
        /// Checks the shiftjis string serialization.
        /// </summary>
        [TestMethod]
        public void WriteShiftJis( )
        {
            LcfString input = new( "あいうえお", LcfEncodingType.JapaneseShiftJis );
        
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                scope.WriteString( input );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( JapaneseData, ms.ToArray( ) );
            }
        }
    }
}