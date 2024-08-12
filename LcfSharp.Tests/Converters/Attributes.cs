using LcfSharp.Rpg.Attributes;
using LcfSharp.IO.Converters;
using LcfSharp.IO.Extensions;
using System.IO;
using System.Linq;

namespace LcfSharp.Tests.Converters
{
    [TestClass]
    public class Attributes
    {
        // Binary data representing the serialized form of the Attribute instance
        byte[] data = [0x03, 0x01, 0x08, 0x50, 0x6F, 0x75, 0x6E, 0x64, 0x69, 0x6E, 0x67, 0x02, 0x01, 0x00, 0x0B, 0x02, 0x81, 0x48, 0x0C, 0x02, 0x81, 0x16, 0x00];

        // Attribute instance based on provided data
        Attribute instance = new( )
        {
            ID = 3,
            Name = "Pounding",
            Type = 0,
            ARate = 200,
            BRate = 150,
            CRate = 0,
            DRate = 0,
            ERate = 0
        };

        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new BinaryReader( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Attribute ) );
                var attribute = ( Attribute ) lcfConverter.Read( reader, null );

                Assert.AreEqual( instance.ID, attribute.ID );
                Assert.AreEqual( instance.Name, attribute.Name );
                Assert.AreEqual( instance.Type, attribute.Type );
                Assert.AreEqual( instance.ARate, attribute.ARate );
                Assert.AreEqual( instance.BRate, attribute.BRate );
                Assert.AreEqual( instance.CRate, attribute.CRate );
                Assert.AreEqual( instance.DRate, attribute.DRate );
                Assert.AreEqual( instance.ERate, attribute.ERate );
            }
        }

        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new BinaryWriter( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Attribute ) );
                lcfConverter.Write( writer, instance, false );

                var buffer = ms.ToArray( );
                int minLength = System.Math.Min( buffer.Length, data.Length );
                int contextBytes = 5; // Number of bytes to show before and after the deviation

                for ( int i = 0; i < minLength; i++ )
                {
                    if ( buffer[i] != data[i] )
                    {
                        // Show surrounding bytes for context
                        int start = System.Math.Max( 0, i - contextBytes );
                        int end = System.Math.Min( minLength - 1, i + contextBytes );

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