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

using LcfSharp.IO.Types;
using System;
using System.Buffers;
using System.Buffers.Binary;

namespace LcfSharp.IO.Scopes
{
    public ref struct LcfWriteScope
    {
        private readonly ArrayBufferWriter<byte> _buffer;

        public readonly int Length => _buffer.WrittenCount;

        public readonly ReadOnlySpan<byte> WrittenSpan => _buffer.WrittenSpan;

        /// <summary>
        /// Creates a write scope over a byte buffer.
        /// </summary>
        /// <param name="buffer">The destination buffer.</param>
        public LcfWriteScope( ArrayBufferWriter<byte> buffer )
        {
            _buffer = buffer;
        }

        /// <summary>
        /// Writes a span of bytes.
        /// </summary>
        /// <param name="bytes">The bytes to write.</param>
        public void WriteBytes( ReadOnlySpan<byte> bytes )
        {
            if ( bytes.IsEmpty )
                return;

            var destination = _buffer.GetSpan( bytes.Length );

            bytes.CopyTo( destination );
            _buffer.Advance( bytes.Length );
        }

        /// <summary>
        /// Writes an unsigned byte.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteByte( byte value )
        {
            Span<byte> span = _buffer.GetSpan( 1 );
            span[0] = value;
            _buffer.Advance( 1 );
        }

        /// <summary>
        /// Writes a signed byte.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteSByte( sbyte value )
        {
            WriteByte( unchecked(( byte ) value) );
        }

        /// <summary>
        /// Writes a little-endian 16-bit integer.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteInt16( short value )
        {
            Span<byte> span = _buffer.GetSpan( 2 );

            BinaryPrimitives.WriteInt16LittleEndian(
                span, value );

            _buffer.Advance( 2 );
        }

        /// <summary>
        /// Writes a little-endian unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteUInt16( ushort value )
        {
            Span<byte> span = _buffer.GetSpan( 2 );

            BinaryPrimitives.WriteUInt16LittleEndian(
                span, value );

            _buffer.Advance( 2 );
        }

        /// <summary>
        /// Writes a little-endian 32-bit integer.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteInt32( int value )
        {
            Span<byte> span = _buffer.GetSpan( 4 );

            BinaryPrimitives.WriteInt32LittleEndian(
                span, value );

            _buffer.Advance( 4 );
        }

        /// <summary>
        /// Writes a little-endian unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteUInt32( uint value )
        {
            Span<byte> span = _buffer.GetSpan( 4 );

            BinaryPrimitives.WriteUInt32LittleEndian(
                span, value );

            _buffer.Advance( 4 );
        }

        /// <summary>
        /// Writes a double-precision floating point number.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteDouble( double value )
        {
            Span<byte> span = _buffer.GetSpan( 8 );

            BinaryPrimitives.WriteDoubleLittleEndian( span, value );

            _buffer.Advance( 8 );
        }

        /// <summary>
        /// Writes a 7-bit encoded 32-bit integer.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteVarInt32( int value )
        {
            uint unsignedValue = ( uint ) value;

            for ( int i = 28; i >= 0; i -= 7 )
            {
                if ( i > 0 && unsignedValue < ( 1U << i ) )
                {
                    continue; // Skip unnecessary writes
                }

                // Cast the result of the shift operation to byte to avoid the warning
                byte byteToWrite = ( byte ) ( ( unsignedValue >> i ) & 0x7F );

                // Set the MSB if there are more bytes to write
                if ( i > 0 )
                {
                    byteToWrite |= 0x80;
                }

                WriteByte( byteToWrite );
            }
        }

        public void WriteEnum<TEnum>( TEnum value )
             where TEnum : struct, Enum
        {
            WriteVarInt32( Convert.ToInt32( value ) );
        }

        /// <summary>
        /// Writes a 7-bit encoded 64-bit integer.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteVarInt64( long value )
        {
            if ( value < 0 )
                throw new ArgumentOutOfRangeException( nameof( value ), "Value must be non-negative." );

            var loops = 0;
            while ( value >= 0x80 )
            {
                WriteByte( ( byte ) ( ( value & 0x7F ) | 0x80 ) );
                value >>= 7;
                loops++;
                if ( loops > 9 )
                    throw new ArgumentOutOfRangeException( nameof( value ), "Value is too large to be a valid 7-bit encoded integer." );
            }
            WriteByte( ( byte ) value );
        }

        /// <summary>
        /// Writes an LCF length-prefixed string.
        /// </summary>
        /// <param name="value">The string to write.</param>
        public void WriteString( LcfString value )
        {
            if ( value == null )
            {
                WriteVarInt32( 0 );
            }
            else
            {
                var buffer = value.ToBuffer( );
                WriteVarInt32( buffer.Length );
                WriteBytes( buffer );
            }
        }

        /// <summary>
        /// Creates an independent write scope.
        /// </summary>
        /// <returns>The new scope.</returns>
        public LcfWriteScope CreateScope( )
        {
            return new LcfWriteScope( new ArrayBufferWriter<byte>( ) );
        }
    }
}
