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
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Extensions;

namespace LcfSharp.IO.Converters.Types
{
    /// <summary>
    /// Provides methods to convert lists of type <typeparamref name="T"/> in the LCF (RPG Maker 2000 format).
    /// </summary>
    /// <typeparam name="T">The element type of the list.</typeparam>
    public class LcfListConverter<T> : LcfConverter<List<T>>
    {
        private readonly LcfConverter _elementConverter;
        private readonly bool _hasIDAttribute;
        private readonly bool _noIndex;

        /// <summary>
        /// Initialises a new instance of the <see cref="LcfListConverter{T}"/> class.
        /// </summary>
        public LcfListConverter( )
        {
            _elementConverter = LcfConverterFactory.GetConverter( typeof( T ) );
            _hasIDAttribute = LcfConverterFactory.GetProperties( _elementConverter.Type )
                .Count( p => p.GetCustomAttribute<LcfIDAttribute>( ) != null ) > 0;
            _noIndex = typeof( T ).GetCustomAttribute<LcfCalculatedSizeAttribute>( ) != null;
        }

        /// <summary>
        /// Reads a list of elements of type <typeparamref name="T"/> from the specified binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="length">The length of the data to read.</param>
        /// <returns>The list of elements read from the binary reader.</returns>
        public override object Read( BinaryReader reader, int? length )
        {
            if ( _noIndex && length.HasValue )
            {
                var startPosition = reader.BaseStream.Position;
                var list = new List<T>( );
                while ( reader.BaseStream.Position < ( startPosition + length.Value ) )
                {
                    list.Add( ( T ) _elementConverter.Read( reader, null ) );
                }
                return list;
            }
            else
            {
                var count = !_hasIDAttribute && length.HasValue ? length.Value : reader.ReadVarInt32( );
                var list = new List<T>( count );
                for ( var i = 0; i < count; i++ )
                {
                    list.Add( ( T ) _elementConverter.Read( reader, null ) );
                }
                return list;
            }
        }

        /// <summary>
        /// Writes the specified list of elements to the binary writer.
        /// </summary>
        /// <param name="writer">The binary writer to write to.</param>
        /// <param name="value">The list of elements to write.</param>
        public override void Write( BinaryWriter writer, object value )
        {
            var list = ( List<T> ) value;
            writer.WriteVarInt32( list.Count );
            foreach ( var item in list )
            {
                _elementConverter.Write( writer, item );
            }
#warning Come back to this as length can come from chunk!
        }
    }
}