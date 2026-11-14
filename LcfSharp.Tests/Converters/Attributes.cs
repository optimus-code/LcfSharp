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
using LcfSharp.Rpg.Attributes;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests attribute conversion and serialization.
    /// </summary>
    [TestClass]
    public class Attributes
    {
        // Binary data representing the serialized form of the Attribute instance
        byte[] data = [0x01, 0x08, 0x50, 0x6F, 0x75, 0x6E, 0x64, 0x69, 0x6E, 0x67, 0x02, 0x01, 0x00, 0x0B, 0x02, 0x81, 0x48, 0x0C, 0x02, 0x81, 0x16, 0x00];

        // Attribute instance based on provided data
        Attribute instance = new( )
        {
            Name = "Pounding",
            Type = 0,
            ARate = 200,
            BRate = 150,
            CRate = 0,
            DRate = 0,
            ERate = 0
        };

        /// <summary>
        /// Checks attribute deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Attribute ) );
                var attribute = ( Attribute ) lcfConverter.Read( ref scope );

                Assert.AreEqual( instance.Name, attribute.Name );
                Assert.AreEqual( instance.Type, attribute.Type );
                Assert.AreEqual( instance.ARate, attribute.ARate );
                Assert.AreEqual( instance.BRate, attribute.BRate );
                Assert.AreEqual( instance.CRate, attribute.CRate );
                Assert.AreEqual( instance.DRate, attribute.DRate );
                Assert.AreEqual( instance.ERate, attribute.ERate );
            }
        }

        /// <summary>
        /// Checks attribute serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Attribute ) );
                lcfConverter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}