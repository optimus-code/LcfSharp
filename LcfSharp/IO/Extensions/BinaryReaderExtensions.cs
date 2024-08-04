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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UtfUnknown;

namespace LcfSharp.IO.Extensions
{
    public static class BinaryReaderExtensions
    {
        private static readonly Encoding _shiftJis = Encoding.GetEncoding( 932 );

        /// <summary>
        /// Read an ASCII string with no length prefixed
        /// </summary>
        /// <param name="br"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ReadString(this BinaryReader br, int length )
        {
            if ( length == 0 )
                return null;

            var buffer = br.ReadBytes( length );
            var result = CharsetDetector.DetectFromBytes( buffer );

            if ( result?.Detected?.Encoding == _shiftJis )
                return _shiftJis.GetString( buffer );

            return Encoding.ASCII.GetString(buffer);
        }

        /// <summary>
        /// Reads a list of short values from the stream.
        /// </summary>
        /// <param name="br"></param>
        /// <param name="size">The number of short values to read.</param>
        /// <returns>A list of short values.</returns>
        public static List<short> ReadInt16List(this BinaryReader br, int size )
        {
            if (size == 0)
                return [];

            var buffer = new List<short>();

            for (var i = 0; i < size; i++)
                buffer.Add(br.ReadInt16());

            return buffer;
        }

        /// <summary>
        /// Read a 7-bit variable-length encoded integer
        /// </summary>
        /// <remarks>(Output differs slightly to built-in .NET one due to the OR
        /// that occurs before. Hence needing this version for RM2K compatibility.</remarks>
        /// <param name="br"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static int ReadVarInt32(this BinaryReader br)
        {
            var result = 0;
            var loops = 0;

            while (true)
            {
                var byteReadJustNow = br.ReadByte();
                result <<= 7;
                result |= byteReadJustNow & 0x7F;

                if ((byteReadJustNow & 0x80) == 0)
                {
                    break;
                }

                if (loops > 5)
                {
                    throw new FormatException("Bad 7-bit encoded integer.");
                }

                loops++;
            }

            return loops > 5 ? 0 : result;
        }

        /// <summary>
        /// Reads a 7-bit variable-length encoded 64-bit integer.
        /// </summary>
        /// <remarks>(Output differs slightly to built-in .NET one due to the OR
        /// that occurs before. Hence needing this version for RM2K compatibility.</remarks>
        /// <param name="br">The binary reader to read from.</param>
        /// <returns>The 64-bit integer value.</returns>
        /// <exception cref="FormatException">Thrown when the encoded integer is invalid.</exception>
        public static long ReadVarInt64( this BinaryReader br )
        {
            long result = 0;
            var loops = 0;

            while ( true )
            {
                var byteReadJustNow = br.ReadByte( );
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


        public static byte? PeekByte(this BinaryReader br)
        {
            var stream = br.BaseStream;

            if (stream.Position >= stream.Length)
                return null;

            if (!stream.CanSeek)
                return null;

            var origPos = stream.Position;
            var value = br.ReadByte();
            stream.Position = origPos;
            return value;
        }
    }
}
