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

using LcfSharp.IO.Exceptions;
using LcfSharp.IO.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LcfSharp.IO.Converters.Types
{
    /// <summary>
    /// Provides methods to convert DbFlags types in the LCF (RPG Maker 2000 format).
    /// </summary>
    public class LcfDbFlagsConverter : LcfConverter
    {
        /// <summary>
        /// Gets the type of the DbFlags this converter is for.
        /// </summary>
        public sealed override Type Type
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets or sets the list of boolean properties in the DbFlags type.
        /// </summary>
        private List<PropertyInfo> Properties
        {
            get;
            set;
        }

        /// <summary>
        /// Determines whether this converter can convert the specified type.
        /// </summary>
        /// <param name="typeToConvert">The type to check for conversion support.</param>
        /// <returns><c>true</c> if this converter can convert the specified type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert( Type typeToConvert ) => typeToConvert == Type;

        /// <summary>
        /// Initializes a new instance of the <see cref="LcfDbFlagsConverter"/> class for the specified type.
        /// </summary>
        /// <param name="type">The DbFlags type to convert.</param>
        /// <exception cref="LcfException">Thrown when the type is invalid or has no boolean properties.</exception>
        public LcfDbFlagsConverter( Type type )
        {
            Type = type;

            if ( !Type.IsAssignableTo( typeof( IDbFlags ) ) )
                throw new LcfException( "Invalid DbFlags type, does not inherit from IDbFlags." );

            Properties = LcfConverterFactory.GetProperties( type )
                .Where( p => p.PropertyType == typeof( bool ) )
                .ToList( );

            if ( Properties == null || Properties.Count == 0 )
                throw new LcfException( "DbFlags type has no Boolean properties." );
        }

        /// <summary>
        /// Reads a DbFlags object from the specified binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="length">The length of the data to read.</param>
        /// <returns>The DbFlags object read from the binary reader.</returns>
        public override object Read( BinaryReader reader, int? length )
        {
            var instance = Activator.CreateInstance( Type );
            var size = length.HasValue ? length.Value : Properties.Count;
            var byteCount = ( size + 7 ) / 8;
            var flagIndex = 0;

            for ( var byteIndex = 0; byteIndex < byteCount; byteIndex++ )
            {
                var byteValue = reader.ReadByte( );

                for ( var bitIndex = 0; bitIndex < 8 && flagIndex < size; bitIndex++ )
                {
                    var flagValue = ( byteValue & ( 1 << bitIndex ) ) != 0;
                    Properties[flagIndex].SetValue( instance, flagValue );
                    flagIndex++;
                }
            }

            return instance;
        }

        /// <summary>
        /// Writes the specified DbFlags object to the binary writer.
        /// </summary>
        /// <param name="writer">The binary writer to write to.</param>
        /// <param name="value">The DbFlags object to write.</param>
        public override void Write( BinaryWriter writer, object value )
        {
            if ( value == null )
                throw new ArgumentNullException( nameof( value ) );

            if ( value.GetType( ) != Type )
                throw new ArgumentException( $"Invalid value type. Expected {Type}, got {value.GetType( )}.", nameof( value ) );

            var size = Properties.Count;
            var byteCount = ( size + 7 ) / 8;
            var flagIndex = 0;

            for ( var byteIndex = 0; byteIndex < byteCount; byteIndex++ )
            {
                byte byteValue = 0;

                for ( var bitIndex = 0; bitIndex < 8 && flagIndex < size; bitIndex++ )
                {
                    var flagValue = ( bool ) Properties[flagIndex].GetValue( value );
                    if ( flagValue )
                    {
                        byteValue |= ( byte ) ( 1 << bitIndex );
                    }
                    flagIndex++;
                }

                writer.Write( byteValue );
            }
        }
    }
}