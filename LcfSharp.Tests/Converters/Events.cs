using LcfSharp.IO.Converters;
using LcfSharp.Rpg.Events;

namespace LcfSharp.Tests.Converters
{
    [TestClass]
    public class Events
    {
        byte[] data = [0x81, 0x9D, 0x0E, 0x01, 0x26, 0x53, 0x77, 0x6F, 0x72, 0x64, 0x73, 0x5C, 0x43, 0x5B, 0x30, 0x5D, 0x20, 0x61, 0x6E, 0x64, 0x20, 0x6F, 0x74, 0x68, 0x65, 0x72, 0x20, 0x70, 0x68, 0x79, 0x73, 0x69, 0x63, 0x61, 0x6C, 0x20, 0x61, 0x74, 0x74, 0x61, 0x63, 0x6B, 0x73, 0x00];

        EventCommand instance = new EventCommand
        {
            Code = ( EventCommandCode ) 20110,
            Indent = 1,
            String = "Swords\\C[0] and other physical attacks",
            Parameters = []
        };

        [TestMethod]
        public void ReadEventCommand( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new BinaryReader( ms );
                var lcfConverter = LcfConverterFactory.GetConverter( typeof( EventCommand ) );
                var eventCommand = ( EventCommand ) lcfConverter.Read( reader, null );

                Assert.AreEqual( eventCommand.Code, instance.Code );
                Assert.AreEqual( eventCommand.Indent, instance.Indent );
                Assert.AreEqual( eventCommand.String, instance.String );
                CollectionAssert.AreEqual( eventCommand.Parameters, instance.Parameters );
            }
        }

        [TestMethod]
        public void WriteEventCommand( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new BinaryWriter( ms );
                var lcfConverter = LcfConverterFactory.GetConverter( typeof( EventCommand ) );
                lcfConverter.Write( writer, instance, false );

                var output = ms.ToArray( );
                CollectionAssert.AreEqual( output, data );
            }
        }
    }
}