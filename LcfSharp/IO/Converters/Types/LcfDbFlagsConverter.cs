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
using LcfSharp.IO.Exceptions;
using LcfSharp.IO.Scopes;
using LcfSharp.IO.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LcfSharp.IO.Converters.Types
{
    /// <summary>
    /// Converts DbFlags types.
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

            if ( !typeof( IDbFlags ).IsAssignableFrom( Type ) )
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
        /// <param name="scope">The read scope.</param>
        /// <returns>The DbFlags object.</returns>
        public override object Read( ref LcfReadScope scope )
        {
            var instance = Activator.CreateInstance( Type );
            var flagCount = Properties.Count;
            var byteCount = Math.Min( scope.Remaining, ( flagCount + 7 ) / 8 );
            var flagIndex = 0;

            for ( var byteIndex = 0; byteIndex < byteCount; byteIndex++ )
            {
                var byteValue = scope.ReadByte( );

                for ( var bitIndex = 0; bitIndex < 8 && flagIndex < flagCount; bitIndex++ )
                {
                    var flagValue = ( byteValue & ( 1 << bitIndex ) ) != 0;
                    Properties[flagIndex].SetValue( instance, flagValue );
                    flagIndex++;
                }
            }

            // Consume any additional bytes beyond the flags known to this model.
            scope.Advance( scope.Remaining );

            return instance;
        }

        /// <summary>
        /// Writes the specified DbFlags object.
        /// </summary>
        /// <param name="scope">The write scope.</param>
        /// <param name="value">The object to write.</param>
        public override void Write( ref LcfWriteScope scope, object value )
        {
            if ( value == null )
                throw new ArgumentNullException( nameof( value ) );

            var is2k3 = LcfConverterFactory.EngineVersion ==
                LcfEngineVersion.RM2K3;

            byte byteValue = 0;
            var bitIndex = 0;

            foreach ( var property in Properties )
            {
                var version = property.GetCustomAttribute<LcfVersionAttribute>( );

                // Omit RM2K3-only flags when writing an RM2K file.
                if ( version?.Version == LcfEngineVersion.RM2K3 && !is2k3 )
                    continue;

                if ( ( bool ) property.GetValue( value ) )
                    byteValue |= ( byte ) ( 1 << ( bitIndex % 8 ) );

                bitIndex++;

                if ( bitIndex % 8 == 0 )
                {
                    scope.WriteByte( byteValue );
                    byteValue = 0;
                }
            }

            // Flush any remaining bits.
            if ( bitIndex % 8 != 0 )
                scope.WriteByte( byteValue );
        }
    }
}