using System;
using System.IO;
using System.Text.Json;

namespace LcfSharp.IO.Utilities
{
    internal static class LcfDataDumper
    {
        /// <summary>
        /// Dumps a range of bytes from a BinaryReader stream to a .cs file.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="reader">The BinaryReader to read from.</param>
        /// <param name="onRead">The reading to happen inside this wrapper</param>
        public static void Dump( Type type, BinaryReader reader, Func<object> onRead )
        {


            long startOffset = reader.BaseStream.Position;

            var instance = onRead?.Invoke( );

            long endOffset = reader.BaseStream.Position;

            byte[] buffer = new byte[endOffset - startOffset];

            reader.BaseStream.Seek( startOffset, SeekOrigin.Begin );
            reader.BaseStream.Read( buffer, 0, buffer.Length );
            reader.BaseStream.Seek( endOffset, SeekOrigin.Begin );

            string hexArray = BitConverter.ToString( buffer ).Replace( "-", ", 0x" );

            string output = $@"
// {type.FullName}
// Start Offset: 0x{startOffset:X}
// End Offset: 0x{endOffset:X}
byte[] data = new byte[] {{ 0x{hexArray} }};
string json = {JsonSerializer.Serialize(instance)}
";
            File.AppendAllText( Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Generated2.cs" ), output );
        }
    }
}
