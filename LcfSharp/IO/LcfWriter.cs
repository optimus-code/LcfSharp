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

using System;
using System.IO;
using LcfSharp.IO.Extensions;
using LcfSharp.IO.Converters;
using LcfSharp.IO.Types;

namespace LcfSharp.IO
{
    /// <summary>
    /// Provides methods to write data to an LCF (RPG Maker 2000 format) stream.
    /// </summary>
    public class LcfWriter : IDisposable
    {
        private readonly BinaryWriter _writer;

        /// <summary>
        /// Initialises a new instance of the <see cref="LcfWriter"/> class with the specified stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        public LcfWriter( Stream stream )
        {
            _writer = new BinaryWriter( stream );
        }

        /// <summary>
        /// Gets the current position within the stream.
        /// </summary>
        public long Position
        {
            get
            {
                return _writer.BaseStream.Position;
            }
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
            var chunkWriter = new LcfChunkConverter( type );
            chunkWriter.Write( _writer, value );
        }

        /// <summary>
        /// Writes a 7-bit variable-length encoded integer to the stream.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        public void WriteVarInt32( int value )
        {
            _writer.WriteVarInt32( value );
        }

        /// <summary>
        /// Writes a string of the specified length to the stream.
        /// </summary>
        /// <param name="value">The string value to write.</param>
        public void WriteString( string value )
        {
            _writer.WriteString( value );
        }

        /// <summary>
        /// Releases all resources used by the current instance of the <see cref="LcfWriter"/> class.
        /// </summary>
        public void Dispose( )
        {
            _writer?.Dispose( );
        }
    }
}