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
using System.IO;
using System.Reflection;

namespace LcfSharp.IO.Converters
{
    /// <summary>
    /// Core type for complex converters, e.g. Class and Chunk
    /// </summary>
    public abstract class LcfComplexConverter : LcfConverter
    {
        /// <summary>
        /// Gets the type that this converter handles.
        /// </summary>
        public sealed override Type Type
        {
            get;
            protected set;
        }

        /// <summary>
        /// Determines whether this converter can convert the specified type.
        /// </summary>
        /// <param name="typeToConvert">The type to check for conversion support.</param>
        /// <returns><c>true</c> if this converter can convert the specified type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert( Type typeToConvert ) => typeToConvert == Type;

        /// <summary>
        /// The type cache
        /// </summary>
        protected readonly LcfType _cache;

        public LcfComplexConverter( Type type )
        {
            Type = type;
            _cache = GetCache( );
        }

        /// <summary>
        /// Processes the specified property by reading its value from the binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="obj">The object to set the property value on.</param>
        /// <param name="property">The property to process.</param>
        /// <param name="length">The length of the data to read.</param>
        /// <exception cref="InvalidDataException">Thrown when no converter is found for the property type.</exception>
        protected void ReadProperty( BinaryReader reader, object obj, PropertyInfo property, int? length )
        {
            var converter = LcfConverterFactory.GetConverter( property.PropertyType );
            if ( converter is not null )
            {
                var value = converter.Read( reader, length );
                property.SetValue( obj, value );
            }
            else
            {
                throw new InvalidDataException( $"No converter found for type {property.PropertyType}" );
            }
        }

        /// <summary>
        /// Processes the specified property by write its value from the binary writer.
        /// </summary>
        /// <param name="writer">The binary reader to read from.</param>
        /// <param name="obj">The object to set the property value on.</param>
        /// <param name="property">The property to process.</param>
        /// <param name="writeLength">Whether to write the length</param>
        /// <exception cref="InvalidDataException">Thrown when no converter is found for the property type.</exception>
        protected void WriteProperty( BinaryWriter writer, object obj, PropertyInfo property, bool writeLength )
        {
            var converter = LcfConverterFactory.GetConverter( property.PropertyType );
            if ( converter is not null )
            {
                converter.Write( writer, property.GetValue( obj ), writeLength );
            }
            else
            {
                throw new InvalidDataException( $"No converter found for type {property.PropertyType}" );
            }
        }

        /// <summary>
        /// Build a complex type instance
        /// </summary>
        /// <returns></returns>
        protected object Build( )
        {
            return Activator.CreateInstance( Type );
        }

        /// <summary>
        /// Get the type cache
        /// </summary>
        /// <returns></returns>
        private LcfType GetCache( )
        {
            return LcfType.Get( Type );
        }
    }
}