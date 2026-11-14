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

using LcfSharp.IO.Attributes;
using LcfSharp.IO.Converters;
using LcfSharp.IO.Scopes;
using LcfSharp.IO.Types;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace LcfSharp.IO
{
    /// <summary>
    /// Provides methods to read data from an LCF (RPG Maker 2000 format) stream.
    /// </summary>
    public class LcfReader : IDisposable
    {
        private readonly ReadOnlyMemory<byte> _buffer;
        private int _position;

        public int Position => _position;
        public int Remaining => _buffer.Length - _position;

        /// <summary>
        /// Initialises a new instance of the <see cref="LcfReader"/> class with the specified stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public LcfReader( Stream stream )
        {
            if ( stream == null )
                throw new ArgumentNullException( nameof( stream ) );

            using ( stream )
            using ( var memory = new MemoryStream( ) )
            {
                stream.CopyTo( memory );
                _buffer = memory.ToArray( );
            }

            _position = 0;
        }

        /// <summary>
        /// Creates a scope over the unread portion of
        /// the buffer without advancing the root cursor.
        /// </summary>
        public LcfReadScope CreateRootScope( )
        {
            return new LcfReadScope( _buffer, _position, Remaining );
        }

        /// <summary>
        /// Commits bytes consumed by a temporary scope.
        /// </summary>
        private void Commit( ref LcfReadScope scope )
        {
            _position += scope.Position;
        }

        /// <summary>
        /// Deserialises data from the stream into an
        /// object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialise.</typeparam>
        /// <returns>An object of type <typeparamref name="T"/>.</returns>
        public T Deserialise<T>( )
            where T : ILcfRootChunk
        {
            return ( T ) Deserialise( typeof( T ) );
        }

        /// <summary>
        /// Deserialises data from the stream into an object of type.
        /// </summary>
        /// <param name="type">The type of object to deserialise.</param>
        /// <returns>An object of declared type.</returns>
        private ILcfRootChunk Deserialise( Type type )
        {
            var scope = CreateRootScope( );

            var isChunked = type.GetCustomAttribute<LcfChunkAttribute>(
                    true ) != null;

            LcfConverter converter = isChunked
                ? new LcfChunkConverter( type )
                : new LcfClassConverter( type );

            var result = ( ILcfRootChunk ) converter.Read( ref scope );

            Commit( ref scope );

            return result;
        }

        /// <summary>
        /// Reads a 7-bit variable-length encoded integer from the stream.
        /// </summary>
        /// <returns>The integer value.</returns>
        public int ReadVarInt32( )
        {
            var scope = CreateRootScope( );

            int result = scope.ReadVarInt32( );

            Commit( ref scope );

            return result;
        }

        /// <summary>
        /// Reads a string of the specified length from the stream.
        /// </summary>
        /// <param name="length">The length of the string to read.</param>
        /// <returns>The string value.</returns>
        public string ReadString( int length )
        {
            var scope = CreateRootScope( );

            // The LCF file signature is ASCII.
            // Model string codecs can use Shift-JIS.
            var bytes = scope.ReadBytes( length );
            string result = Encoding.ASCII.GetString(
                bytes.ToArray( ) );

            Commit( ref scope );

            return result;
        }

        /// <summary>
        /// Releases all resources used by the current instance of the <see cref="LcfReader"/> class.
        /// </summary>
        public void Dispose( )
        {
        }
    }
}