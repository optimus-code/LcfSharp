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
using System.Buffers.Binary;
using System.Diagnostics;
using System.IO;

namespace LcfSharp.IO.Scopes
{
    /// <summary>
    /// An isolated read scope for a buffer.
    /// </summary>
    public ref struct LcfReadScope
    {
        private readonly ReadOnlySpan<byte> _buffer;
        private int _basePosition;
        private int _position;

        /// <summary>
        /// The current position in the scope.
        /// </summary>
        public int Position
        {
            get
            {
                return _position;
            }
        }

        /// <summary>
        /// The absolute current position in the outer-array.
        /// </summary>
        public int AbsolutePosition
        {
            get
            {
                return _basePosition + _position;
            }
        }

        /// <summary>
        /// The length of the scope.
        /// </summary>
        public readonly int Length => _buffer.Length;

        /// <summary>
        /// The remaining length of bytes available
        /// in the scope.
        /// </summary>
        public readonly int Remaining => _buffer.Length - _position;

        /// <summary>
        /// Whether the scope has any remaining bytes.
        /// </summary>
        public readonly bool IsFinished => Remaining == 0;

        /// <summary>
        /// Create a read scope from a memory buffer.
        /// </summary>
        /// <param name="buffer">The memory buffer.</param>
        /// <param name="start">The start offset.</param>
        /// <param name="length">The length of the scope in bytes.</param>
        public LcfReadScope( ReadOnlyMemory<byte> buffer, int start, int length )
        {
            _buffer = buffer.Slice( start, length ).Span;
            _basePosition = start;
            _position = 0;
        }

        /// <summary>
        /// Create a read scope from an existing memory span.
        /// </summary>
        /// <param name="buffer">The memory buffer.</param>
        /// <param name="basePosition">The base offset of the span in the outer array.</param>
        public LcfReadScope( int basePosition, ReadOnlySpan<byte> buffer )
        {
            _basePosition = basePosition;
            _buffer = buffer;
            _position = 0;
        }

        /// <summary>
        /// Peek a collection of bytes.
        /// </summary>
        /// <param name="length">The amount of bytes to peek</param>
        /// <returns>The byte buffer.</returns>
        public ReadOnlySpan<byte> ReadBytes( int length )
        {
            if ( length < 0 || length > Remaining )
                throw new EndOfStreamException(
                    "Attempted to read beyond the scope." );

            var result = _buffer.Slice( _position, length );
            _position += length;

            return result;
        }

        /// <summary>
        /// Peek a byte.
        /// </summary>
        /// <param name="offset">The offset in bytes.</param>
        /// <returns>The byte value.</returns>
        public byte PeekByte( int offset = 0 )
        {
            if ( Remaining + offset == 0 )
                throw new EndOfStreamException( );

            return _buffer[_position + offset];
        }

        /// <summary>
        /// Reads a byte.
        /// </summary>
        /// <returns>The byte value.</returns>
        public byte ReadByte( )
        {
            return ReadBytes( 1 )[0];
        }

        /// <summary>
        /// Reads an sbyte.
        /// </summary>
        /// <returns>The byte value.</returns>
        public sbyte ReadSByte( )
        {
            return unchecked(( sbyte ) ReadByte( ));
        }

        /// <summary>
        /// Reads a 16-bit signed integer.
        /// </summary>
        /// <returns>The integer value.</returns>
        public short ReadInt16( )
        {
            return BinaryPrimitives.ReadInt16LittleEndian(
                ReadBytes( sizeof( short ) ) );
        }

        /// <summary>
        /// Reads a 16-bit unsigned integer.
        /// </summary>
        /// <returns>The integer value.</returns>
        public ushort ReadUInt16( )
        {
            return BinaryPrimitives.ReadUInt16LittleEndian(
                ReadBytes( sizeof( ushort ) ) );
        }

        /// <summary>
        /// Reads a 32-bit signed integer.
        /// </summary>
        /// <returns>The integer value.</returns>
        public int ReadInt32( )
        {
            return BinaryPrimitives.ReadInt32LittleEndian(
                ReadBytes( sizeof( int ) ) );
        }

        /// <summary>
        /// Reads a 32-bit unsigned integer.
        /// </summary>
        /// <returns>The integer value.</returns>
        public uint ReadUInt32( )
        {
            return BinaryPrimitives.ReadUInt32LittleEndian(
                ReadBytes( sizeof( uint ) ) );
        }

        /// <summary>
        /// Reads a double-precision floating point number.
        /// </summary>
        /// <returns>The double value.</returns>
        public double ReadDouble( )
        {
            return BinaryPrimitives.ReadDoubleLittleEndian(
                ReadBytes( sizeof( double ) ) );
        }

        /// <summary>
        /// Reads a 7-bit encoded integer.
        /// </summary>
        /// <remarks>(Output differs slightly to built-in .NET one due to the OR
        /// that occurs before. Hence needing this version for RM2K compatibility.</remarks>
        /// <returns>The decoded integer.</returns>
        public int ReadVarInt32( )
        {
            var result = 0;
            var loops = 0;
            var byteReadJustNow = 0;
            do
            {
                result <<= 7;

                byteReadJustNow = ReadByte( );
                result |= byteReadJustNow & 0x7F;

                if ( loops > 5 )
                {
                    // Log a warning instead of throwing an exception, and continue
                    Debug.WriteLine( "Invalid compressed integer" );
                }

                loops++;
            } while ( ( byteReadJustNow & 0x80 ) != 0 );

            return loops > 5 ? 0 : result;
        }

        /// <summary>
        /// Reads a 7-bit encoded enumeration value.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <returns>The resulting value.</returns>
        public TEnum ReadEnum<TEnum>()
             where TEnum : struct, Enum
        {
            return ( TEnum ) Enum.ToObject( typeof( TEnum ), ReadVarInt32() );
        }

        /// <summary>
        /// Reads a 7-bit encoded integer.
        /// </summary>
        /// <remarks>(Output differs slightly to built-in .NET one due to the OR
        /// that occurs before. Hence needing this version for RM2K compatibility.</remarks>
        /// <param name="length">The length of bytes read.</param>
        /// <returns>The resulting value.</returns>
        public int PeekVarInt32( out int length )
        {
            var result = 0;
            var loops = 0;
            var byteReadJustNow = 0;
            length = 0;
            do
            {
                result <<= 7;

                byteReadJustNow = PeekByte( length++ );
                result |= byteReadJustNow & 0x7F;

                if ( loops > 5 )
                {
                    // Log a warning instead of throwing an exception, and continue
                    Debug.WriteLine( "Invalid compressed integer" );
                }

                loops++;
            } while ( ( byteReadJustNow & 0x80 ) != 0 );

            return loops > 5 ? 0 : result;
        }

        /// <summary>
        /// Reads a 7-bit variable-length encoded 64-bit integer.
        /// </summary>
        /// <remarks>(Output differs slightly to built-in .NET one due to the OR
        /// that occurs before. Hence needing this version for RM2K compatibility.</remarks>
        /// <returns>The 64-bit integer value.</returns>
        /// <exception cref="FormatException">Thrown when the encoded integer is invalid.</exception>
        public long ReadVarInt64( )
        {
            long result = 0;
            var loops = 0;

            while ( true )
            {
                var byteReadJustNow = ReadByte( );
                result <<= 7;
                result |= ( long ) ( byteReadJustNow & 0x7F );

                if ( ( byteReadJustNow & 0x80 ) == 0 )
                {
                    break;
                }

                if ( loops > 9 ) // 9 loops for 64-bit integer (63 bits, last loop does not shift)
                {
                    throw new FormatException( "Bad 7-bit encoded integer." );
                }

                loops++;
            }

            return loops > 9 ? 0 : result;
        }

        /// <summary>
        /// Read a string that has a proceding length in
        /// the buffer.
        /// </summary>
        /// <param name="encodingType">The encoding type.</param>
        /// <returns>The LcfString buffer.</returns>
        public LcfString ReadString( LcfEncodingType encodingType = LcfEncodingType.WesternEurope1252 )
        {
            return ReadString( ReadVarInt32( ), encodingType );
        }

        /// <summary>
        /// Read a string of specified length.
        /// </summary>
        /// <param name="length">The length in bytes.</param>
        /// <param name="encodingType">The encoding type.</param>
        /// <returns>The LcfString buffer.</returns>
        public LcfString ReadString( int length, LcfEncodingType encodingType = LcfEncodingType.WesternEurope1252 )
        {
            if ( length == 0 )
                return null;

            var buffer = ReadBytes( length );

            return new( buffer.ToArray( ), encodingType );
        }

        /// <summary>
        /// Create a new read scope of specified length from
        /// the current position and progress the current scope.
        /// </summary>
        /// <param name="length">The length of bytes</param>
        /// <returns>A read scope.</returns>
        public LcfReadScope TakeScope( int length )
        {
            return new LcfReadScope( _position, ReadBytes( length ) );
        }

        /// <summary>
        /// Create a new read scope of specified length from
        /// the current position and progress the current scope.
        /// </summary>
        /// <param name="position">The position to take the scope from.</param>        /// <param name="length">The length of bytes</param>
        /// <returns>A read scope.</returns>
        public LcfReadScope TakeScope( int position, int length )
        {
            return new LcfReadScope( position, ReadBytes( length ) );
        }

        /// <summary>
        /// Peek a new read scope of specified length from
        /// the current position.
        /// </summary>
        /// <param name="length">The length of bytes</param>
        /// <returns>A read scope.</returns>
        public LcfReadScope PeekScope( int length )
        {
            if ( length < 0 || length > Remaining )
                throw new EndOfStreamException( );

            return new LcfReadScope( AbsolutePosition,
                _buffer.Slice( _position, length ) );
        }

        /// <summary>
        /// Peek a read scope of the remaining length from
        /// the current position.
        /// </summary>
        /// <returns>A read scope.</returns>
        public LcfReadScope PeekRemainingScope( )
        {
            return PeekScope( Remaining );
        }

        /// <summary>
        /// Advance the current scope by the specified
        /// length.
        /// </summary>
        /// <param name="length">LThe length in bytes.</param>
        /// <exception cref="EndOfStreamException"></exception>
        public void Advance( int length )
        {
            if ( length < 0 || length > Remaining )
                throw new EndOfStreamException( );

            _position += length;
        }
    }
}