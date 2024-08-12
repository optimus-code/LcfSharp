using LcfSharp.Rpg.Troops;
using LcfSharp.IO.Converters;
using LcfSharp.IO.Extensions;
using System.IO;
using System.Linq;
using System;

namespace LcfSharp.Tests.Converters
{
    [TestClass]
    public class TroopMembers
    {
        byte[] data = [0x01, 0x01, 0x01, 0x02, 0x02, 0x01, 0x68, 0x03, 0x01, 0x48, 0x00];

        TroopMember instance = new( )
        {
            ID = 1,
            EnemyID = 2,
            X = 104,
            Y = 72,
            Invisible = false
        };

        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new BinaryReader( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopMember ) );
                var troopMember = ( TroopMember ) lcfConverter.Read( reader, null );

                Assert.AreEqual( instance.ID, troopMember.ID );
                Assert.AreEqual( instance.EnemyID, troopMember.EnemyID );
                Assert.AreEqual( instance.X, troopMember.X );
                Assert.AreEqual( instance.Y, troopMember.Y );
                Assert.AreEqual( instance.Invisible, troopMember.Invisible );
            }
        }

        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new BinaryWriter( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopMember ) );
                lcfConverter.Write( writer, instance, false );

                var buffer = ms.ToArray( );
                int minLength = Math.Min( buffer.Length, data.Length );
                int contextBytes = 5; // Number of bytes to show before and after the deviation

                for ( int i = 0; i < minLength; i++ )
                {
                    if ( buffer[i] != data[i] )
                    {
                        // Show surrounding bytes for context
                        int start = Math.Max( 0, i - contextBytes );
                        int end = Math.Min( minLength - 1, i + contextBytes );

                        var bufferSnippet = string.Join( " ", buffer.Skip( start ).Take( end - start + 1 ).Select( b => $"0x{b:X2}" ) );
                        var dataSnippet = string.Join( " ", data.Skip( start ).Take( end - start + 1 ).Select( b => $"0x{b:X2}" ) );

                        Assert.Fail( $"Buffers differ at index {i}. Expected: 0x{data[i]:X2}, Actual: 0x{buffer[i]:X2}\n" +
                                    $"Written:\t{bufferSnippet}\n" +
                                    $"Expected:\t{dataSnippet}" );
                    }
                }

                // If no differences found, check if one buffer is longer than the other
                if ( buffer.Length != data.Length )
                {
                    Assert.Fail( $"Buffers have different lengths. Expected: {data.Length}, Actual: {buffer.Length}" );
                }
            }
        }
    }
}