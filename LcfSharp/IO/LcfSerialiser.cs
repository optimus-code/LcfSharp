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

using LcfSharp.IO.Converters;
using LcfSharp.IO.Exceptions;
using LcfSharp.IO.Types;
using System.IO;
using System.Linq;
using System.Text;

namespace LcfSharp.IO
{
    /// <summary>
    /// Provides methods to serialise and deserialise LCF (RPG Maker 2000 format) data.
    /// </summary>
    public static class LcfSerialiser
    {
        private static readonly LcfSerialiserOptions _defaultOptions = new( );

        static LcfSerialiser( )
        {
            Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );
        }

        /// <summary>
        /// Prepares the converters based on the provided options.
        /// </summary>
        /// <param name="options">The serialiser options.</param>
        private static void PrepareConverters( LcfSerialiserOptions options )
        {
            if ( options.Converters.Any( ) )
            {
                foreach ( var converter in options.Converters )
                {
                    LcfConverterFactory.RegisterConverter( converter );
                }
            }

            LcfConverterFactory.EngineVersion = options.Version;
        }

        /// <summary>
        /// Deserialises data from the stream into an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialise.</typeparam>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="options">The serialiser options.</param>
        /// <returns>An object of type <typeparamref name="T"/>.</returns>
        public static T Deserialise<T>( Stream stream, LcfSerialiserOptions options = null )
            where T : ILcfRootChunk
        {
            var currentOptions = options ?? _defaultOptions;
            PrepareConverters( currentOptions );

            using ( var reader = new LcfReader( stream ) )
            {
                var header = ReadHeader( reader, currentOptions );

                var instance = reader.Deserialise<T>( );

                if ( instance != null )
                    instance.Header = header;

                return instance;
            }
        }

        /// <summary>
        /// Serialises the specified object and writes it to the stream.
        /// </summary>
        /// <typeparam name="T">The type of object to serialise.</typeparam>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The object to serialise.</param>
        /// <param name="options">The serialiser options.</param>
        public static void Serialise<T>( Stream stream, T value, LcfSerialiserOptions options = null )
            where T : ILcfRootChunk
        {
            var currentOptions = options ?? _defaultOptions;
            PrepareConverters( currentOptions );

            using ( var writer = new LcfWriter( stream ) )
            {
                WriteHeader( writer, currentOptions );
                writer.Serialise( value );
            }
        }

        /// <summary>
        /// Reads the header from the stream based on the specified options.
        /// </summary>
        /// <param name="reader">The LcfReader instance.</param>
        /// <param name="options">The serialiser options.</param>
        /// <returns>The header string.</returns>
        /// <exception cref="LcfInvalidHeaderException">Thrown when the header is invalid.</exception>
        private static string ReadHeader( LcfReader reader, LcfSerialiserOptions options )
        {
            switch ( options.Format )
            {
                case LcfFormat.LDB:
                    var headerLength = reader.ReadVarInt32( );
                    var header = reader.ReadString( headerLength );

                    if ( string.IsNullOrEmpty( header )
                        || header.Length != 11
                        || header != "LcfDataBase" )
                    {
                        throw new LcfInvalidHeaderException( "LcfDatabase", header ?? "NULL" );
                    }
                    return header;

                case LcfFormat.LMT:
                    headerLength = reader.ReadVarInt32( );
                    header = reader.ReadString( headerLength );

                    if ( string.IsNullOrEmpty( header )
                        || header.Length != 10
                        || header != "LcfMapTree" )
                    {
                        throw new LcfInvalidHeaderException( "LcfMapTree", header ?? "NULL" );
                    }
                    return header;
            }

            return null;
        }

        /// <summary>
        /// Writes the header to the stream based on the specified options.
        /// </summary>
        /// <param name="writer">The LcfWriter instance.</param>
        /// <param name="options">The serialiser options.</param>
        private static void WriteHeader( LcfWriter writer, LcfSerialiserOptions options )
        {
            switch ( options.Format )
            {
                case LcfFormat.LDB:
                    var header = "LcfDataBase";
                    writer.WriteVarInt32( header.Length );
                    writer.WriteString( header );
                    break;

                case LcfFormat.LMT:
                    header = "LcfMapTree";
                    writer.WriteVarInt32( header.Length );
                    writer.WriteString( header );
                    break;
            }
        }
    }
}