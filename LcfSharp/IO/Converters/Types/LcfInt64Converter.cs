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

using LcfSharp.IO.Extensions;
using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    /// <summary>
    /// Provides methods to convert 64-bit integer values in the LCF (RPG Maker 2000 format).
    /// </summary>
    public class LcfInt64Converter : LcfConverter<long>
    {
        /// <summary>
        /// Reads a 64-bit integer from the specified binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="length">The length of the data to read (not used).</param>
        /// <returns>The 64-bit integer value read from the binary reader.</returns>
        public override object Read( BinaryReader reader, int? length )
        {
            return reader.ReadVarInt64( );
        }

        /// <summary>
        /// Writes the specified 64-bit integer value to the binary writer.
        /// </summary>
        /// <param name="writer">The binary writer to write to.</param>
        /// <param name="value">The 64-bit integer value to write.</param>
        public override void Write( BinaryWriter writer, object value )
        {
            writer.WriteVarInt64( ( long ) value );
        }
    }
}