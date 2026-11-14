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

using LcfSharp.IO.Scopes;
using LcfSharp.IO.Types;

namespace LcfSharp.IO.Converters.Types
{
    /// <summary>
    /// Converts 7-bit variable-length encoded integer values.
    /// </summary>
    public class LcfRectangleConverter : LcfConverter<Rectangle>
    {
        /// <summary>
        /// Reads a rectangle.
        /// </summary>
        /// <param name="scope">The read scope.</param>
        /// <returns>The rectangle.</returns>
        public override object Read( ref LcfReadScope scope )
        {
            return new Rectangle( scope.ReadUInt32( ), scope.ReadUInt32( ),
                scope.ReadUInt32( ), scope.ReadUInt32( ) );
        }

        /// <summary>
        /// Writes a rectangle.
        /// </summary>
        /// <param name="scope">The write scope.</param>
        /// <param name="value">The value to write.</param>
        public override void Write( ref LcfWriteScope scope, object value )
        {
            var rectValue = ( Rectangle ) value;
            scope.WriteUInt32( rectValue.Left );
            scope.WriteUInt32( rectValue.Top );
            scope.WriteUInt32( rectValue.Right );
            scope.WriteUInt32( rectValue.Bottom );
        }
    }
}