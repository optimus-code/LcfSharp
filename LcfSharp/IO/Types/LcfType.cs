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
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;

namespace LcfSharp.IO.Types
{
    /// <summary>
    /// Represents metadata and utilities for LCF (RPG Maker 2000 format) types.
    /// </summary>
    internal class LcfType
    {
        /// <summary>
        /// Cache for storing <see cref="LcfType"/> instances for different types.
        /// </summary>
        static Dictionary<Type, LcfType> _typeCache = [];

        /// <summary>
        /// Gets the list of <see cref="LcfProperty"/> objects for the type.
        /// </summary>
        public List<LcfProperty> Properties
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
        public LcfProperty IDProperty
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the dictionary mapping chunk identifiers to <see cref="LcfProperty"/> objects.
        /// </summary>
        public Dictionary<int, LcfProperty> Chunks
        {
            get;
            private set;
        } = [];

        /// <summary>
        /// Gets the dictionary mapping size chunk identifiers to <see cref="LcfProperty"/> objects.
        /// </summary>
        public Dictionary<int, LcfProperty> SizeChunks
        {
            get;
            private set;
        } = [];

        /// <summary>
        /// Initialises a new instance of the <see cref="LcfType"/> class for the specified type.
        /// </summary>
        /// <param name="type">The type to create an <see cref="LcfType"/> for.</param>
        /// <exception cref="LcfException">Thrown when the type is missing the <see cref="LcfChunkAttribute"/>.</exception>
        public LcfType( Type type )
        {
            Properties = LcfProperty.Get( type );

            var chunkAttribute = type.GetCustomAttribute<LcfChunkAttribute>( );

            if ( chunkAttribute == null )
                throw new LcfException( $"Missing LcfChunk attribute on '{type.FullName}'." );

            ChunkEnumType = chunkAttribute.ChunkEnumType;
            IDProperty = GetIDProperty( );
            MapChunks( );
        }

        /// <summary>
        /// Maps the properties of the type to their corresponding chunk identifiers.
        /// </summary>
        private void MapChunks( )
        {
            foreach ( var property in Properties )
            {
                if ( Enum.TryParse( ChunkEnumType, property.Property.Name, out var enumValue )
                    && property.IsAllowed )
                {
                    Chunks[( int ) enumValue] = property;

                    if ( property.Size != null )
                        SizeChunks.Add( property.Size.ChunkID, property );
                }
            }
        }

        /// <summary>
        /// Gets the property representing the ID of the chunk.
        /// </summary>
        /// <returns>The property representing the ID of the chunk.</returns>
        private LcfProperty GetIDProperty( )
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
        /// Gets an <see cref="LcfType"/> instance for the specified type.
        /// </summary>
        /// <param name="type">The type to get the <see cref="LcfType"/> for.</param>
        /// <returns>The <see cref="LcfType"/> instance for the specified type.</returns>
        public static LcfType Get( Type type )
        {
            if ( !_typeCache.TryGetValue( type, out var lcfType ) )
            {
                lcfType = new LcfType( type );
                _typeCache[type] = lcfType;
            }
            return lcfType;
        }

        /// <summary>
        /// Gets the property corresponding to the specified chunk identifier.
        /// </summary>
        /// <param name="chunkID">The chunk identifier to get the property for.</param>
        /// <returns>The property corresponding to the specified chunk identifier.</returns>
        public LcfProperty GetPropertyByChunkID( int chunkID )
        {
            Chunks.TryGetValue( chunkID, out var property );
            return property;
        }

        /// <summary>
        /// Gets the chunk identifier corresponding to the specified property.
        /// </summary>
        /// <param name="property">The property to get the chunk identifier for.</param>
        /// <returns>The chunk identifier corresponding to the specified property.</returns>
        /// <exception cref="LcfException">Thrown when the property does not have an associated chunk identifier.</exception>
        public int GetChunkIDByProperty( LcfProperty property )
        {
            if ( Chunks.Count( c => c.Value == property ) == 0 )
                throw new LcfException( $"Property {property.Property.Name} does not have an associated chunk id." );

            return Chunks.FirstOrDefault( c => c.Value == property ).Key;
        }
    }
}