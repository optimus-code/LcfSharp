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
using LcfSharp.IO.Converters.Types;
using LcfSharp.IO.Exceptions;
using LcfSharp.IO.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LcfSharp.IO.Converters
{
    /// <summary>
    /// Provides methods to manage and retrieve LCF (RPG Maker 2000 format) converters.
    /// </summary>
    public static class LcfConverterFactory
    {
        /// <summary>
        /// Gets or sets the engine version for the LCF converters.
        /// </summary>
        public static LcfEngineVersion EngineVersion
        {
            get;
            set;
        }

        /// <summary>
        /// A dictionary containing basic type converters.
        /// </summary>
        private static readonly Dictionary<Type, LcfConverter> Converters = new( )
        {
            { typeof(string), new LcfStringConverter() },
            { typeof(byte), new LcfByteConverter() },
            { typeof(bool), new LcfBooleanConverter() },
            { typeof(short), new LcfInt16Converter() },
            { typeof(int), new LcfInt32Converter() },
            { typeof(long), new LcfInt64Converter() }
        };

        /// <summary>
        /// Gets or sets the cache for storing type properties.
        /// </summary>
        private static Dictionary<Type, List<PropertyInfo>> Cache
        {
            get;
            set;
        } = [];

        /// <summary>
        /// Gets or sets the custom converters registered by the user.
        /// </summary>
        private static Dictionary<Type, LcfConverter> CustomConverters
        {
            get;
            set;
        } = [];

        /// <summary>
        /// Gets or sets the dynamic converters created at runtime.
        /// </summary>
        private static Dictionary<Type, LcfConverter> DynamicConverters
        {
            get;
            set;
        } = [];

        /// <summary>
        /// Gets the properties of the specified type.
        /// </summary>
        /// <param name="type">The type to get properties from.</param>
        /// <returns>A list of properties of the specified type.</returns>
        public static List<PropertyInfo> GetProperties( Type type )
        {
            if ( Cache.TryGetValue( type, out var properties ) )
                return properties;

            properties = type.GetProperties( BindingFlags.Instance | BindingFlags.Public ).ToList( );
            Cache[type] = properties;
            return properties;
        }

        /// <summary>
        /// Registers a custom converter.
        /// </summary>
        /// <param name="converter">The converter to register.</param>
        /// <exception cref="LcfException">Thrown when the converter is null.</exception>
        public static void RegisterConverter( LcfConverter converter )
        {
            if ( converter == null )
                throw new LcfException( "Cannot add a NULL converter!" );

            if ( CustomConverters.ContainsKey( converter.Type ) )
                return;

            CustomConverters.Add( converter.Type, converter );
        }

        /// <summary>
        /// Gets a converter for the specified type.
        /// </summary>
        /// <param name="type">The type to get the converter for.</param>
        /// <returns>The converter for the specified type.</returns>
        /// <exception cref="LcfMissingConverterException">Thrown when no converter is found for the specified type.</exception>
        public static LcfConverter GetConverter( Type type )
        {
            if ( DynamicConverters.TryGetValue( type, out var dynamicConverter ) )
                return dynamicConverter;

            var isBasicConverter = false;
            LcfConverter resultantConverter = null;

            if ( type.IsEnum )
            {
                resultantConverter = new LcfEnumConverter( type );
            }
            else if ( type.IsAssignableTo( typeof( IDbFlags ) ) )
            {
                resultantConverter = new LcfDbFlagsConverter( type );
            }
            else if ( type.IsClass && type.GetCustomAttribute<LcfListCollectionAttribute>( ) != null )
            {
                resultantConverter = new LcfListCollectionConverter( type );
            }
            else if ( type.IsClass && type.GetCustomAttribute<LcfChunkAttribute>( ) != null )
            {
                resultantConverter = new LcfChunkConverter( type );
            }
            else if ( CustomConverters.TryGetValue( type, out var customConverter ) )
            {
                resultantConverter = customConverter;
                isBasicConverter = true;
            }
            else if ( Converters.TryGetValue( type, out var converter ) )
            {
                resultantConverter = converter;
                isBasicConverter = true;
            }
            else if ( type.IsGenericType && type.GetGenericTypeDefinition( ) == typeof( List<> ) )
            {
                var elementType = type.GetGenericArguments( )[0];
                var listConverterType = typeof( LcfListConverter<> ).MakeGenericType( elementType );
                resultantConverter = ( LcfConverter ) Activator.CreateInstance( listConverterType );
            }
            else if ( type.IsClass )
            {
                resultantConverter = new LcfClassConverter( type );
            }

            if ( resultantConverter == null )
                throw new LcfMissingConverterException( type );

            // Cache the result
            if ( !isBasicConverter )
                DynamicConverters.Add( type, resultantConverter );

            return resultantConverter;
        }
    }
}