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
using LcfSharp.IO.Types.Generic;
using LcfSharp.Rpg.Events;
using LcfSharp.Rpg.Troops;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests collection conversion and serialization.
    /// </summary>
    [TestClass]
    public class Collections
    {
        /// <summary>
        /// Checks packed int16 encoding.
        /// </summary>
        [TestMethod]
        public void PackedInt16( )
        {
            byte[] data = [0x01, 0x00, 0xFF, 0xFF, 0x00, 0x01];
            LcfPackedList<short> instance = [1, -1, 256];
            var converter = LcfConverterFactory.GetConverter( typeof( LcfPackedList<short> ) );

            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var result = ( LcfPackedList<short> ) converter.Read( ref scope );
                CollectionAssert.AreEqual( instance, result );
                Assert.IsTrue( scope.IsFinished );
            }

            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                converter.Write( ref scope, instance );
                writer.Commit( ref scope );
                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }

        /// <summary>
        /// Checks counted var int32 encoding.
        /// </summary>
        [TestMethod]
        public void CountedVarInt32( )
        {
            byte[] data = [0x04, 0x00, 0x7F, 0x81, 0x00, 0x81, 0x80, 0x00];
            LcfList<int> instance = [0, 127, 128, 16384];
            var converter = LcfConverterFactory.GetConverter( typeof( LcfList<int> ) );

            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var result = ( LcfList<int> ) converter.Read( ref scope );
                CollectionAssert.AreEqual( instance, result );
                Assert.IsTrue( scope.IsFinished );
            }

            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                converter.Write( ref scope, instance );
                writer.Commit( ref scope );
                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }

        /// <summary>
        /// Checks indexed troop members encoding.
        /// </summary>
        [TestMethod]
        public void IndexedTroopMembers( )
        {
            byte[] data = [0x02, 0x01, 0x01, 0x01, 0x02, 0x02, 0x01, 0x68, 0x03, 0x01, 0x48, 0x00, 0x02, 0x00];
            LcfIndexedList<TroopMember> instance =
            [
                new( ) { ID = 1, EnemyID = 2, X = 104, Y = 72 },
                new( ) { ID = 2 }
            ];
            var converter = LcfConverterFactory.GetConverter( typeof( LcfIndexedList<TroopMember> ) );

            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var result = ( LcfIndexedList<TroopMember> ) converter.Read( ref scope );

                Assert.AreEqual( 2, result.Count );
                Assert.AreEqual( 1, result[0].ID );
                Assert.AreEqual( 2, result[0].EnemyID );
                Assert.AreEqual( 104, result[0].X );
                Assert.AreEqual( 72, result[0].Y );
                Assert.AreEqual( 2, result[1].ID );
                Assert.AreEqual( 1, result[1].EnemyID );
                Assert.IsTrue( scope.IsFinished );
            }

            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                converter.Write( ref scope, instance );
                writer.Commit( ref scope );
                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }

        /// <summary>
        /// Checks empty event commands encoding.
        /// </summary>
        [TestMethod]
        public void EmptyEventCommands( )
        {
            byte[] data = [0x00, 0x00, 0x00, 0x00];
            var converter = LcfConverterFactory.GetConverter( typeof( EventCommandCollection ) );

            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var result = ( EventCommandCollection ) converter.Read( ref scope );
                Assert.AreEqual( 0, result.Count );
            }

            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                converter.Write( ref scope, new EventCommandCollection( ) );
                writer.Commit( ref scope );
                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}
