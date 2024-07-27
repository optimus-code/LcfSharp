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

using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LcfSharp.IO.Converters
{
    /// <summary>
    /// Provides methods to convert class types in the LCF (RPG Maker 2000 format).
    /// </summary>
    public class LcfClassConverter : LcfConverter
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
        /// Initialises a new instance of the <see cref="LcfClassConverter"/> class for the specified class type.
        /// </summary>
        /// <param name="classType">The class type to convert.</param>
        public LcfClassConverter( Type classType )
        {
            Type = classType;
        }

        /// <summary>
        /// Determines whether the specified property is allowed based on the version attribute.
        /// </summary>
        /// <param name="property">The property to check.</param>
        /// <returns><c>true</c> if the property is allowed; otherwise, <c>false</c>.</returns>
        private bool IsAllowed( PropertyInfo property )
        {
            var versionAttribute = property.GetCustomAttribute<LcfVersionAttribute>( );

            return property != null && versionAttribute?.Version == LcfConverterFactory.EngineVersion
                || versionAttribute == null && LcfConverterFactory.EngineVersion == LcfEngineVersion.RM2K;
        }

        /// <summary>
        /// Processes the specified property by reading its value from the binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="obj">The object to set the property value on.</param>
        /// <param name="property">The property to process.</param>
        /// <exception cref="InvalidDataException">Thrown when no converter is found for the property type.</exception>
        private void ProcessProperty( BinaryReader reader, object obj, PropertyInfo property )
        {
            var converter = LcfConverterFactory.GetConverter( property.PropertyType );
            if ( converter is not null )
            {
                var value = converter.Read( reader, null );
                property.SetValue( obj, value );
            }
            else
            {
                throw new InvalidDataException( $"No converter found for type {property.PropertyType}" );
            }
        }

        /// <summary>
        /// Reads an object of the specified class type from the binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="length">The length of the data to read (not used).</param>
        /// <returns>The object read from the binary reader.</returns>
        public override object Read( BinaryReader reader, int? length )
        {
            var obj = Activator.CreateInstance( Type );
            var properties = LcfConverterFactory.GetProperties( Type )
                .Where( p => p.GetCustomAttribute<LcfIgnoreAttribute>( ) == null );

            foreach ( var property in properties )
            {
                if ( reader.BaseStream.Position >= reader.BaseStream.Length )
                    break;

                if ( IsAllowed( property ) )
                    ProcessProperty( reader, obj, property );
            }

            return obj;
        }

        /// <summary>
        /// Writes the specified object to the binary writer.
        /// </summary>
        /// <param name="writer">The binary writer to write to.</param>
        /// <param name="value">The object to write.</param>
        /// <exception cref="InvalidDataException">Thrown when no converter is found for a property type.</exception>
        public override void Write( BinaryWriter writer, object value )
        {
            var properties = LcfConverterFactory.GetProperties( Type )
                .Where( p => p.GetCustomAttribute<LcfIgnoreAttribute>( ) == null );

            foreach ( var property in properties )
            {
                if ( IsAllowed( property ) )
                {
                    var propertyValue = property.GetValue( value );
                    var converter = LcfConverterFactory.GetConverter( property.PropertyType );

                    if ( converter is not null )
                    {
                        converter.Write( writer, propertyValue );
                    }
                    else
                    {
                        throw new InvalidDataException( $"No converter found for type {property.PropertyType}" );
                    }
                }
            }
        }
    }
}