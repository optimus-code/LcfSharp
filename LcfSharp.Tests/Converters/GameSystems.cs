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
using LcfSharp.Rpg.GameSystems;
using System;
using System.IO;
using System.Text;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests game-system conversion and serialization.
    /// </summary>
    [TestClass]
    public class GameSystems
    {
        byte[] data =
        [
            0x0B, 0x04, 0x42, 0x6F, 0x61, 0x74, // BoatName
            0x11, 0x06, 0x54, 0x69, 0x74, 0x6C, 0x65, 0x31, // TitleName

            0x15, 0x01, 0x02, // PartySize = 2
            0x16, 0x04, 0x01, 0x00, 0x02, 0x00, // Party = [1, 2]

            0x3D, 0x01, 0x00, // TransitionOut
            0x3E, 0x01, 0x00, // TransitionIn
            0x3F, 0x01, 0x00, // BattleStartFadeOut
            0x40, 0x01, 0x00, // BattleStartFadeIn
            0x41, 0x01, 0x00, // BattleEndFadeOut
            0x42, 0x01, 0x00, // BattleEndFadeIn

            0x52, 0x01, 0x00, // SelectedHero
            0x5B, 0x01, 0x07, // SaveCount = 7
            0x00
        ];

        GameSystem instance = new( )
        {
            BoatName = "Boat",
            TitleName = "Title1",
            Party = [1, 2],
            SaveCount = 7
        };

        /// <summary>
        /// Checks gamesystem deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( GameSystem ) );
                var result = ( GameSystem ) converter.Read( ref scope );

                Assert.AreEqual( instance.BoatName, result.BoatName );
                Assert.AreEqual( instance.TitleName, result.TitleName );
                CollectionAssert.AreEqual( instance.Party, result.Party );
                Assert.AreEqual( instance.SaveCount, result.SaveCount );
                Assert.IsTrue( scope.IsFinished );
            }
        }

        /// <summary>
        /// Checks gamesystem serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( GameSystem ) );

                converter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }

        /// <summary>
        /// Reads game-system data from an LDB fixture.
        /// </summary>
        /// <param name="file">The fixture file name.</param>
        /// <param name="expectedBoatName">The expected boat name.</param>
        [TestMethod]
        [DataRow( "RPG_RT.ldb", "Vehicles" )]
        [DataRow( "RPG_RT_rw.ldb", "RWPeople12" )]
        public void Read( string file, string expectedBoatName )
        {
            byte[] data = GetGameSystemPayload( file );

            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                var converter = LcfConverterFactory.GetConverter( typeof( GameSystem ) );
                var result = ( GameSystem ) converter.Read( ref scope );

                Assert.IsNotNull( result );
                Assert.AreEqual( expectedBoatName, ( string ) result.BoatName );
                Assert.IsTrue( scope.IsFinished, $"GameSystem payload not fully read in {file}." );
            }
        }

        /// <summary>
        /// Checks that a game-system payload round-trips unchanged.
        /// </summary>
        /// <param name="file">The fixture file name.</param>
        [TestMethod]
        [DataRow( "RPG_RT.ldb" )]
        [DataRow( "RPG_RT_rw.ldb" )]
        public void Write( string file )
        {
            byte[] data = GetGameSystemPayload( file );
            GameSystem instance;
            var converter = LcfConverterFactory.GetConverter( typeof( GameSystem ) );

            // Deserialize exactly the GameSystem payload from the original LDB.
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );
                instance = ( GameSystem ) converter.Read( ref scope );
                Assert.IsTrue( scope.IsFinished, $"GameSystem payload not fully read in {file}." );
            }

            // Serialize just that object, using the same converter pattern
            // as the other Converters tests.
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                converter.Write( ref scope, instance );
                writer.Commit( ref scope );

                // Reports a mismatch relative to the start of GameSystem,
                // bypassing the database's 0x16 length prefix entirely.
                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }

        /// <summary>
        /// Extracts the game-system payload from an LDB fixture.
        /// </summary>
        /// <param name="file">The fixture file name.</param>
        /// <returns>The section payload.</returns>
        private static byte[] GetGameSystemPayload( string file )
        {
            byte[] data = File.ReadAllBytes( Path.Combine( "Data", file ) );
            int offset = 0;

            // RPG_RT.ldb starts with a length-prefixed ASCII header.
            int headerLength = ReadVarInt32( data, ref offset );
            if ( headerLength != 11 ||
                Encoding.ASCII.GetString( data, offset, headerLength ) != "LcfDataBase" )
            {
                throw new InvalidDataException( $"Invalid LDB header in {file}." );
            }
            offset += headerLength;

            // Top-level LDB sections are: varint ID, varint length, payload.
            while ( offset < data.Length )
            {
                int chunkId = ReadVarInt32( data, ref offset );
                if ( chunkId == 0 )
                    break;

                int length = ReadVarInt32( data, ref offset );
                if ( length < 0 || length > data.Length - offset )
                    throw new InvalidDataException( $"Invalid LDB section length in {file}." );

                if ( chunkId == 0x16 ) // GameSystem
                {
                    byte[] payload = new byte[length];
                    Array.Copy( data, offset, payload, 0, length );
                    return payload;
                }

                offset += length;
            }

            throw new InvalidDataException( $"GameSystem (0x16) not found in {file}." );
        }

        /// <summary>
        /// Reads a variable-length integer from a fixture buffer.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="offset">The current byte offset.</param>
        /// <returns>The decoded integer.</returns>
        private static int ReadVarInt32( byte[] data, ref int offset )
        {
            int value = 0;
            for ( int i = 0; i < 5; i++ )
            {
                if ( offset >= data.Length )
                    throw new EndOfStreamException( "Truncated LCF variable-length integer." );

                byte b = data[offset++];
                if ( value > ( int.MaxValue >> 7 ) )
                    throw new InvalidDataException( "LCF variable-length integer overflow." );

                value = ( value << 7 ) | ( b & 0x7F );
                if ( ( b & 0x80 ) == 0 )
                    return value;
            }

            throw new InvalidDataException( "LCF variable-length integer exceeds 5 bytes." );
        }
    }
}
