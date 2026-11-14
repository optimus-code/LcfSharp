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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace LcfSharp.IO.Types
{
    /// <summary>
    /// Represents metadata and utilities for LCF (RPG Maker 2000 format) types.
    /// </summary>
    public class LcfTypeInfo
    {
        /// <summary>
        /// Cache for storing <see cref="LcfTypeInfo"/> instances for different types.
        /// </summary>
        static Dictionary<Type, LcfTypeInfo> _typeCache = [];

        /// <summary>
        /// Gets the list of <see cref="LcfPropertyInfo"/> objects for the type.
        /// </summary>
        public List<LcfPropertyInfo> Properties
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the enum type used for chunk identifiers.
        /// </summary>
        public Type ChunkEnumType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the property representing the ID of the chunk.
        /// </summary>
        public LcfPropertyInfo IDProperty
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the dictionary mapping chunk identifiers to <see cref="LcfPropertyInfo"/> objects.
        /// </summary>
        public IReadOnlyDictionary<int, LcfPropertyInfo> Chunks
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the dictionary mapping size chunk identifiers to <see cref="LcfPropertyInfo"/> objects.
        /// </summary>
        public IReadOnlyDictionary<int, LcfPropertyInfo> SizeChunks
        {
            get;
            private set;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="LcfTypeInfo"/> class for the specified type.
        /// </summary>
        /// <param name="type">The type to create an <see cref="LcfTypeInfo"/> for.</param>
        /// <exception cref="LcfException">Thrown when the type is missing the <see cref="LcfChunkAttribute"/>.</exception>
        public LcfTypeInfo( Type type )
        {
            Properties = LcfPropertyInfo.Get( type );

            IDProperty = GetIDProperty( );

            var chunkAttribute = type.GetCustomAttribute<LcfChunkAttribute>( );

            if ( chunkAttribute != null )
            {
                ChunkEnumType = chunkAttribute.ChunkEnumType;
                MapChunks( );
            }
        }

        /// <summary>
        /// Maps the properties of the type to their corresponding chunk identifiers.
        /// </summary>
        private void MapChunks( )
        {
            var chunks = new Dictionary<int, LcfPropertyInfo>( );
            var sizeChunks = new Dictionary<int, LcfPropertyInfo>( );

            foreach ( var property in Properties )
            {
                // Attempt to parse the enum value using reflection
                object enumValue = null;
                bool isValidEnum;

                try
                {
                    enumValue = Enum.Parse( ChunkEnumType, property.Property.Name );
                    isValidEnum = Enum.IsDefined( ChunkEnumType, enumValue );
                }
                catch
                {
                    // Parsing failed, invalid enum value
                    isValidEnum = false;
                }

                if ( isValidEnum && property.IsAllowed )
                {
                    // Cast the enumValue to the actual enum type
                    var enumIntValue = ( int ) enumValue;
                    chunks[enumIntValue] = property;

                    if ( property.Size != null )
                        sizeChunks.Add( property.Size.ChunkID, property );
                }
            }

            if ( chunks.Count > 0 )
                Chunks = new ReadOnlyDictionary<int, LcfPropertyInfo>( chunks );

            if ( sizeChunks.Count > 0 )
                SizeChunks = new ReadOnlyDictionary<int, LcfPropertyInfo>( sizeChunks );            
        }

        /// <summary>
        /// Gets the property representing the ID of the chunk.
        /// </summary>
        /// <returns>The property representing the ID of the chunk.</returns>
        private LcfPropertyInfo GetIDProperty( )
        {
            foreach ( var property in Properties )
            {
                if ( property.ID != null )
                {
                    return property;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets an <see cref="LcfTypeInfo"/> instance for the specified type.
        /// </summary>
        /// <param name="type">The type to get the <see cref="LcfTypeInfo"/> for.</param>
        /// <returns>The <see cref="LcfTypeInfo"/> instance for the specified type.</returns>
        public static LcfTypeInfo Get( Type type )
        {
            if ( !_typeCache.TryGetValue( type, out var lcfType ) )
            {
                lcfType = new LcfTypeInfo( type );
                _typeCache[type] = lcfType;
            }
            return lcfType;
        }

        /// <summary>
        /// Gets the property corresponding to the specified chunk identifier.
        /// </summary>
        /// <param name="chunkID">The chunk identifier to get the property for.</param>
        /// <returns>The property corresponding to the specified chunk identifier.</returns>
        public LcfPropertyInfo GetPropertyByChunkID( int chunkID )
        {
            if ( Chunks?.TryGetValue( chunkID, out var property ) == true )
                return property;

            return null;
        }

        /// <summary>
        /// Gets the chunk identifier corresponding to the specified property.
        /// </summary>
        /// <param name="property">The property to get the chunk identifier for.</param>
        /// <returns>The chunk identifier corresponding to the specified property.</returns>
        /// <exception cref="LcfException">Thrown when the property does not have an associated chunk identifier.</exception>
        public int GetChunkIDByProperty( LcfPropertyInfo property )
        {
            foreach ( var chunk in Chunks )
            {
                if ( chunk.Value == property )
                    return chunk.Key;
            }
            throw new LcfException( $"Property {property.Property.Name} does not have an associated chunk id." );
        }
    }
}