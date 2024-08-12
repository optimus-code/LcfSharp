using LcfSharp.IO;
using LcfSharp.IO.Converters;

namespace LcfSharp.Tests
{
    [TestClass]
    public class Numbers
    {
        private readonly (byte[] data, int value)[] testCases = new[]
{
    (new byte[] { 0x84, 0x58 }, 600),              // Correct: 600 -> 0x84, 0x58
    (new byte[] { 0x81, 0x9D, 0x0E }, 20110),      // Correct: 20110 -> 0x81, 0x9D, 0x0E
    (new byte[] { 0x00 }, 0),                      // Correct: 0 -> 0x00
    (new byte[] { 0x7F }, 127),                    // Correct: 127 -> 0x7F
    (new byte[] { 0x81, 0x00 }, 128),              // Correct: 128 -> 0x81, 0x00
    (new byte[] { 0xFF, 0x7F }, 16383),            // Correct: 16383 -> 0xFF, 0x7F
    (new byte[] { 0x81, 0x80, 0x00 }, 16384),      // Correct: 16384 -> 0x81, 0x80, 0x00
    (new byte[] { 0xFF, 0xFF, 0x7F }, 2097151),    // Correct: 2097151 -> 0xFF, 0xFF, 0x7F
    (new byte[] { 0xFF, 0xFF, 0xFF, 0x7F }, 268435455) // Correct: 268435455 -> 0xFF, 0xFF, 0xFF, 0x7F
};



        [TestMethod]
        public void ReadVarInt32( )
        {
            var lcfConverter = LcfConverterFactory.GetConverter( typeof( int ) );

            foreach ( var (data, expectedValue) in testCases )
            {
                using ( var ms = new MemoryStream( data ) )
                {
                    var reader = new BinaryReader( ms );
                    var actualValue = ( int ) lcfConverter.Read( reader, null );

                    Assert.AreEqual( expectedValue, actualValue, $"Failed reading {expectedValue}" );
                }
            }
        }

        [TestMethod]
        public void WriteVarInt32( )
        {
            var lcfConverter = LcfConverterFactory.GetConverter( typeof( int ) );

            foreach ( var (expectedData, value) in testCases )
            {
                using ( var ms = new MemoryStream( ) )
                {
                    var writer = new BinaryWriter( ms );
                    lcfConverter.Write( writer, value, false );

                    var actualData = ms.ToArray( );
                    CollectionAssert.AreEqual( expectedData, actualData, $"Failed writing {value}" );
                }
            }
        }
    }
}