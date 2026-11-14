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
using System.Buffers;
using System.IO;
using System.Reflection;

namespace LcfSharp.IO
{
    /// <summary>
    /// Provides methods to write data to an LCF (RPG Maker 2000 format) stream.
    /// </summary>
    public class LcfWriter : IDisposable
    {
        private readonly Stream _stream;

        /// <summary>
        /// Initialises a new instance of the <see cref="LcfWriter"/>
        /// class with the specified stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        public LcfWriter( Stream stream )
        {
            _stream = stream;
        }

        /// <summary>
        /// Creates a scope over the unread portion of
        /// the buffer without advancing the root cursor.
        /// </summary>
        public LcfWriteScope CreateRootScope( )
        {
            return new LcfWriteScope( new ArrayBufferWriter<byte>( ) );
        }

        /// <summary>
        /// Commits bytes to the stream.
        /// </summary>
        public void Commit( ref LcfWriteScope scope )
        {
            _stream.Write( scope.WrittenSpan );
        }

        /// <summary>
        /// Serialises the specified object and writes it to the stream.
        /// </summary>
        /// <typeparam name="T">The type of object to serialise.</typeparam>
        /// <param name="value">The object to serialise.</param>
        public void Serialise<T>( T value )
            where T : ILcfRootChunk
        {
            Serialise( typeof( T ), value );
        }

        /// <summary>
        /// Serialises the specified object and writes it to the stream.
        /// </summary>
        /// <param name="type">The type of object to serialise.</param>
        /// <param name="value">The object to serialise.</param>
        private void Serialise( Type type, ILcfRootChunk value )
        {
            var scope = CreateRootScope( );

            var isChunked = type.GetCustomAttribute<LcfChunkAttribute>(
                    true ) != null;

            LcfConverter converter = isChunked
                ? new LcfChunkConverter( type )
                : new LcfClassConverter( type );

            converter.Write( ref scope, value );
            Commit( ref scope );
        }

        /// <summary>
        /// Writes a 7-bit variable-length encoded integer to the stream.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        public void WriteVarInt32( int value )
        {
            var scope = CreateRootScope( );
            scope.WriteVarInt32( value );
            Commit( ref scope );
        }

        /// <summary>
        /// Writes a string of the specified length to the stream.
        /// </summary>
        /// <param name="value">The string value to write.</param>
        public void WriteString( string value )
        {
            var scope = CreateRootScope( );
            scope.WriteString( value );
            Commit( ref scope );
        }

        /// <summary>
        /// Releases all resources used by the current instance of the <see cref="LcfWriter"/> class.
        /// </summary>
        public void Dispose( )
        {
            _stream?.Dispose( );
        }
    }
}