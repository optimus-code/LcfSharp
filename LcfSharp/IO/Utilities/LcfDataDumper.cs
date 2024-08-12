using System;
using System.IO;
using System.Text.Json;

namespace LcfSharp.IO.Utilities
{
    internal static class LcfDataDumper
    {
        public static void Dump( Type type, BinaryReader reader, long startPosition, long endPosition, object instance )
        {
            var buffer = new byte[endPosition - startPosition];

            reader.BaseStream.Seek( startPosition, SeekOrigin.Begin );
            reader.BaseStream.Read( buffer, 0, buffer.Length );
            reader.BaseStream.Seek( endPosition, SeekOrigin.Begin );


            string hexArray = BitConverter.ToString( buffer ).Replace( "-", ", 0x" );

            string output = $@"
// {type.FullName}
// Start Offset: 0x{startPosition:X}
// End Offset: 0x{endPosition:X}
byte[] data = [0x{hexArray}];
var instance = new {type.Name} {{ {JsonSerializer.Serialize( instance ).Replace( "\"", "" )} }};
";
            File.AppendAllText( Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Generated2.cs" ), output );
        }
    }
}
