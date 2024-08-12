using LcfSharp.IO;
using LcfSharp.IO.Extensions;
using System.Text;

namespace LcfSharp.Tests
{
    [TestClass]
    public class String
    {
        [TestMethod]
        public void ReadAscii( )
        {
            byte[] data = { 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello" in ASCII

            using ( var ms = new MemoryStream( data ) )
            {
                var br = new BinaryReader( ms );
                var value = br.ReadString( data.Length );
                Assert.AreEqual( "Hello", value );
            }
        }

        [TestMethod]
        public void ReadShiftJis( )
        {
            var encoding = LcfSerialiser.SHIFT_JIS;

            byte[] data = { 0x82, 0xA0, 0x82, 0xA2, 0x82, 0xA4, 0x82, 0xA6, 0x82, 0xA8 }; // "あいうえお" in SHIFT-JIS
            
            using ( var ms = new MemoryStream( data ) )
            {
                var br = new BinaryReader( ms );
                var value = br.ReadString( data.Length, encoding );
                Assert.AreEqual( "あいうえお", value );
            }
        }

        [TestMethod]
        public void WriteAscii( )
        {
            var input = "Hello";
            byte[] expectedData = { 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello" in ASCII

            using ( var ms = new MemoryStream( ) )
            {
                var bw = new BinaryWriter( ms );

                bw.WriteString( input );

                CollectionAssert.AreEqual( expectedData, ms.ToArray( ) );
            }
        }

        [TestMethod]
        public void WriteShiftJis( )
        {
            var input = "あいうえお";
            var encoding = LcfSerialiser.SHIFT_JIS;
            byte[] expectedData = { 0x82, 0xA0, 0x82, 0xA2, 0x82, 0xA4, 0x82, 0xA6, 0x82, 0xA8 }; // "あいうえお" in SHIFT-JIS

            using ( var ms = new MemoryStream( ) )
            {
                var bw = new BinaryWriter( ms );

                bw.WriteString( input, encoding );

                CollectionAssert.AreEqual( expectedData, ms.ToArray( ) );
            }
        }
    }
}