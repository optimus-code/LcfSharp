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
    /// Tests LSD conversion and serialization.
    /// </summary>
    [TestClass]
    public class Lsd
    {
        /// <summary>
        /// Checks lsd deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            var save = LsdFile.Load( Path.Combine( "Data", "Save01.lsd" ) );

            Assert.IsNotNull( save );
        }

        /// <summary>
        /// Checks that lsd fixtures round-trip without byte changes.
        /// </summary>
        /// <param name="file">The fixture file name.</param>
        [TestMethod]
        [DataRow( "Save01.lsd" )]
        [DataRow( "Save02.lsd" )]
        [DataRow( "Save03.lsd" )]
        public void RoundTrip( string file )
        {
            var path = Path.Combine( "Data", file );
            var sourceBuffer = File.ReadAllBytes( path );
            var source = LsdFile.Load( path );
            byte[] buffer;

            using ( var ms = new MemoryStream( ) )
            {
                LcfSerialiser.Serialise( ms, source,
                    new LcfSerialiserOptions { Format = LcfFormat.LSD } );

                buffer = ms.ToArray( );
            }

            LsdFile result;
            using ( var ms = new MemoryStream( buffer ) )
            {
                result = LcfSerialiser.Deserialise<LsdFile>( ms,
                    new LcfSerialiserOptions { Format = LcfFormat.LSD } );
            }

            Assert.AreEqual( source.Header, result.Header );
            Assert.AreEqual( source.Pictures.Count, result.Pictures.Count );

            TestHelpers.AssertBuffer( sourceBuffer, buffer );
        }

    }
}