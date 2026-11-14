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

using LcfSharp.IO.Converters.Types.Generic;
using LcfSharp.IO.Exceptions;
using LcfSharp.IO.Scopes;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace LcfSharp.IO.Converters.Types
{
    /// <summary>
    /// Converts list collection types (multiple lists).
    /// </summary>
    public class LcfListCollectionConverter : LcfComplexConverter
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LcfListCollectionConverter"/> class for the specified class type.
        /// </summary>
        /// <param name="classType">The class type to convert.</param>
        public LcfListCollectionConverter( Type classType )
            : base( classType )
        {
            Type = classType;
        }

        /// <summary>
        /// Reads an object of the specified list collection type.
        /// </summary>
        /// <param name="scope">The read scope.</param>
        /// <returns>The object read.</returns>
        /// <exception cref="LcfException">Thrown when no length is specified, no list properties are found, or the list item count is invalid.</exception>
        public override object Read( ref LcfReadScope scope )
        {
            var properties = _cache.Properties
                .Where( p => p.IsGenericListType );

            var listCount = properties.Count( );

            if ( listCount == 0 )
                throw new LcfException( "No list properties found in type marked as an LcfListCollection" );

            var elementType = properties.First( ).GenericListInnerType;
            var listConverterType = typeof( LcfPackedListConverter<> ).MakeGenericType( elementType );
            var converter = ( LcfConverter ) Activator.CreateInstance( listConverterType );

            // The lists in the class all are the same size, divided by the amount of individual lists
            var listItemCount = scope.Length / Marshal.SizeOf( elementType ) / listCount;

            if ( listItemCount <= 0 )
                throw new LcfException( "Invalid list item count in LcfListCollection." );

            var subListLength = Marshal.SizeOf( elementType ) * listItemCount;
            var obj = Activator.CreateInstance( Type );
            foreach ( var property in properties )
            {
                var subListScope = scope.TakeScope( subListLength );
                var list = ( IList ) converter.Read( ref subListScope );
                property.Property.SetValue( obj, list );
            }
            return obj;
        }

        /// <summary>
        /// Writes the specified List collection object.
        /// </summary>
        /// <param name="scope">The write scope.</param>
        /// <param name="value">The object to write.</param>
        public override void Write( ref LcfWriteScope scope, object value )
        {
            var properties = _cache.Properties
                .Where( p => p.IsGenericListType );

            var listCount = properties.Count( );
            var elementType = properties.First().GenericListInnerType;

            foreach ( var property in properties )
            {
                var list = ( IList ) property.Property.GetValue( value );
                if ( list != null )
                {
                    var listConverterType = typeof( LcfPackedListConverter<> ).MakeGenericType( elementType );
                    var converter = ( LcfConverter ) Activator.CreateInstance( listConverterType );
                    converter.Write( ref scope, list );
                }
                else
                {
                    throw new InvalidDataException( $"Property {property.Property.Name} has a null value." );
                }
            }
        }
    }
}