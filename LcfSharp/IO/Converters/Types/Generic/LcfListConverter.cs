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
using LcfSharp.IO.Types.Generic;

namespace LcfSharp.IO.Converters.Types.Generic
{
    /// <summary>
    /// Converts lists of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The element type of the list.</typeparam>
    public class LcfListConverter<T> : LcfConverter<LcfList<T>>
    {
        private readonly LcfConverter _elementConverter;

        /// <summary>
        /// Initialises a new instance of the <see cref="LcfListConverter{T}"/> class.
        /// </summary>
        public LcfListConverter( )
        {
            _elementConverter = LcfConverterFactory.GetConverter( typeof( T ) );
        }

        /// <summary>
        /// Reads a list of elements of type <typeparamref name="T"/> 
        /// from the specified binary reader.
        /// </summary>
        /// <param name="scope">The read scope.</param>
        /// <returns>The list of elements.</returns>
        public override object Read( ref LcfReadScope scope )
        {
            var count = scope.ReadVarInt32( );
            var list = new LcfList<T>( count );

            for ( var i = 0; i < count; i++ )
            {
                list.Add( ( T ) _elementConverter.Read( ref scope ) );
            }

            return list;
        }

        /// <summary>
        /// Writes the specified list of elements.
        /// </summary>
        /// <param name="scope">The write scope.</param>
        /// <param name="value">The list of elements to write.</param>
        public override void Write( ref LcfWriteScope scope, object value )
        {
            var list = ( LcfList<T> ) value;
            
            scope.WriteVarInt32( list.Count );

            for ( var i = 0; i < list.Count; i++ )
            {
                _elementConverter.Write( ref scope, list[i] );
            }
        }
    }
}