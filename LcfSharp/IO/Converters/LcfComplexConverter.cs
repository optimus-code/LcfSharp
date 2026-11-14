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
using System;
using System.IO;
using System.Reflection;

namespace LcfSharp.IO.Converters
{
    /// <summary>
    /// Base converter for complex LCF records.
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
        /// Cached metadata for the converted type.
        /// </summary>
        protected readonly LcfTypeInfo _cache;

        /// <summary>
        /// Creates a converter for a complex LCF type.
        /// </summary>
        /// <param name="type">The model type.</param>
        public LcfComplexConverter( Type type )
        {
            Type = type;
            _cache = GetCache( );
        }

        /// <summary>
        /// Reads and assigns a model property.
        /// </summary>
        /// <param name="scope">The read scope.</param>
        /// <param name="obj">The model instance.</param>
        /// <param name="property">The property to process.</param>
        /// <exception cref="InvalidDataException">Thrown when no converter is found for the property type.</exception>
        protected void ReadProperty( ref LcfReadScope scope, object obj, PropertyInfo property )
        {
            var converter = LcfConverterFactory.GetConverter( property.PropertyType );
            if ( converter is not null )
            {
                var value = converter.Read( ref scope );
                property.SetValue( obj, value );
            }
            else
            {
                throw new InvalidDataException( $"No converter found for type {property.PropertyType}" );
            }
        }

        /// <summary>
        /// Writes a model property.
        /// </summary>
        /// <param name="scope">The write scope.</param>
        /// <param name="obj">The model instance.</param>
        /// <param name="property">The property to process.</param>
        /// <exception cref="InvalidDataException">Thrown when no converter is found for the property type.</exception>
        protected void WriteProperty( ref LcfWriteScope scope, object obj, PropertyInfo property )
        {
            var converter = LcfConverterFactory.GetConverter( property.PropertyType );
            if ( converter is not null )
            {
                converter.Write( ref scope, property.GetValue( obj ) );
            }
            else
            {
                throw new InvalidDataException( $"No converter found for type {property.PropertyType}" );
            }
        }

        /// <summary>
        /// Creates an instance of the target model type.
        /// </summary>
        /// <returns>The type metadata.</returns>
        protected object Build( )
        {
            return Activator.CreateInstance( Type );
        }

        /// <summary>
        /// Gets cached metadata for the target model type.
        /// </summary>
        /// <returns>The type metadata.</returns>
        private LcfTypeInfo GetCache( )
        {
            return LcfTypeInfo.Get( Type );
        }
    }
}