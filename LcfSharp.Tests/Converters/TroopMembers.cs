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
using LcfSharp.Rpg.Troops;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests troop member conversion and serialization.
    /// </summary>
    [TestClass]
    public class TroopMembers
    {
        byte[] data = [0x01, 0x01, 0x02, 0x02, 0x01, 0x68, 0x03, 0x01, 0x48, 0x00];

        TroopMember instance = new( )
        {
            EnemyID = 2,
            X = 104,
            Y = 72,
            Invisible = false
        };

        /// <summary>
        /// Checks troopmember deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopMember ) );
                var troopMember = ( TroopMember ) lcfConverter.Read( ref scope );

                Assert.AreEqual( instance.ID, troopMember.ID );
                Assert.AreEqual( instance.EnemyID, troopMember.EnemyID );
                Assert.AreEqual( instance.X, troopMember.X );
                Assert.AreEqual( instance.Y, troopMember.Y );
                Assert.AreEqual( instance.Invisible, troopMember.Invisible );
            }
        }

        /// <summary>
        /// Checks troopmember serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopMember ) );
                lcfConverter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}