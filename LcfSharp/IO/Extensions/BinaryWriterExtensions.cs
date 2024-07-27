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
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LcfSharp.IO.Extensions
{
    public static class BinaryWriterExtensions
    {
        /// <summary>
        /// Write an ASCII string with no length prefixed
        /// </summary>
        /// <param name="bw"></param>
        /// <param name="value"></param>
        public static void WriteString(this BinaryWriter bw, string value )
        {
            bw.Write(Encoding.ASCII.GetBytes(value));
        }

        /// <summary>
        /// Writes a list of short values to the stream.
        /// </summary>
        /// <param name="bw"></param>
        /// <param name="values">The list of short values to write.</param>
        public static void WriteInt16List( this BinaryWriter bw, List<short> values )
        {
            if ( values == null || values.Count == 0 )
                return;

            foreach ( var value in values )
                bw.Write( value );
        }

        /// <summary>
        /// Write a 7-bit variable-length encoded integer.
        /// </summary>
        /// <remarks>(Output differs slightly to built-in .NET one due to the OR
        /// that occurs before. Hence needing this version for RM2K compatibility.</remarks>
        /// <param name="bw"></param>
        /// <param name="value">The integer value to write.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void WriteVarInt32( this BinaryWriter bw, int value )
        {
            if ( value < 0 )
                throw new ArgumentOutOfRangeException( nameof( value ), "Value must be non-negative." );

            var loops = 0;
            while ( value >= 0x80 )
            {
                bw.Write( ( byte ) ( ( value & 0x7F ) | 0x80 ) );
                value >>= 7;
                loops++;
                if ( loops > 5 )
                    throw new ArgumentOutOfRangeException( nameof( value ), "Value is too large to be a valid 7-bit encoded integer." );
            }
            bw.Write( ( byte ) value );
        }

        /// <summary>
        /// Writes a 7-bit variable-length encoded 64-bit integer to the stream.
        /// </summary>
        /// <remarks>(Output differs slightly to built-in .NET one due to the OR
        /// that occurs before. Hence needing this version for RM2K compatibility.</remarks>
        /// <param name="bw">The binary writer to write to.</param>
        /// <param name="value">The 64-bit integer value to write.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is negative.</exception>
        public static void WriteVarInt64( this BinaryWriter bw, long value )
        {
            if ( value < 0 )
                throw new ArgumentOutOfRangeException( nameof( value ), "Value must be non-negative." );

            var loops = 0;
            while ( value >= 0x80 )
            {
                bw.Write( ( byte ) ( ( value & 0x7F ) | 0x80 ) );
                value >>= 7;
                loops++;
                if ( loops > 9 )
                    throw new ArgumentOutOfRangeException( nameof( value ), "Value is too large to be a valid 7-bit encoded integer." );
            }
            bw.Write( ( byte ) value );
        }
    }
}