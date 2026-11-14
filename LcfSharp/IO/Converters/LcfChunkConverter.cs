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
using LcfSharp.IO.Scopes;
using LcfSharp.IO.Types;
using LcfSharp.IO.Types.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LcfSharp.IO.Converters
{
    /// <summary>
    /// Converts chunk types.
    /// </summary>
    public class LcfChunkConverter : LcfComplexConverter
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LcfChunkConverter"/> class for the specified chunk type.
        /// </summary>
        /// <param name="chunkType">The chunk type to convert.</param>
        public LcfChunkConverter( Type chunkType )
            : base( chunkType )
        {
        }

        /// <summary>
        /// Reads a chunk record from the source scope.
        /// </summary>
        /// <param name="scope">The read scope.</param>
        /// <returns>The decoded record.</returns>
        public override object Read( ref LcfReadScope scope )
        {
            var instance = Build( );
            var parsedProperties = new HashSet<string>( );

            if ( _cache.IDProperty != null )
            {
                parsedProperties.Add( _cache.IDProperty.Property.Name );
            }

            var properties = _cache.Properties;
            var chunkEnumType = _cache.ChunkEnumType;

            while ( !scope.IsFinished )
            {
                var chunkID = scope.ReadVarInt32( );

                if ( chunkID == 0 )
                    break;

                var chunkLength = scope.PeekVarInt32( out var bytesPeeked );

                if ( Enum.IsDefined( chunkEnumType, chunkID ) )
                {
                    LcfPropertyInfo match = _cache.GetPropertyByChunkID( chunkID );

                    if ( match?.IsAllowed == true )
                    {
                        var isStringType = match.Property.PropertyType == typeof( LcfString );

                        // Strings normally carry their own length, but chunk strings use
                        // the enclosing chunk length rather than an additional string length.
                        if ( !isStringType )
                            scope.Advance( bytesPeeked );

                        var chunkScope = scope.TakeScope( scope.Position, isStringType ? bytesPeeked + chunkLength : chunkLength );
                        
                        if ( parsedProperties.Contains( match.Property.Name ) )
                            throw new LcfException( $"{match.Property.Name} has already been parsed, there's a read error somewhere." );

                        ReadProperty( ref chunkScope, instance, match.Property );
                        parsedProperties.Add( match.Property.Name );
                    }
                    else if ( _cache.SizeChunks?.TryGetValue( chunkID, out var targetProperty ) == true )
                    {
                        // Discard "Size" chunks as they are not needed for reading
                        scope.Advance( bytesPeeked + chunkLength );
                    }
                    else
                    {
#if DEBUG
                        Debug.WriteLine( $"Missing property match for chunk: '0x{chunkID:X}' in '{Type.FullName}'." );
#endif
                        scope.Advance( bytesPeeked + chunkLength );
                    }
                }
                else
                {
                    scope.Advance( bytesPeeked + chunkLength );
                }
            }
#if DEBUG
            CollectDebugInfo( parsedProperties );
#endif            

            return instance;
        }

        /// <summary>
        /// Reports persistent properties that were absent from the input.
        /// </summary>
        /// <param name="parsedProperties">The parsed properties.</param>
        private void CollectDebugInfo( HashSet<string> parsedProperties )
        {
            var unusedProperties = _cache.Chunks.Values
                .Where( p => !parsedProperties.Contains( p.Property.Name ) &&
                    p.AlwaysPersist != null &&
                    p.Property.PropertyType != typeof( string ) )
                .ToList( );

            if ( unusedProperties.Any( ) )
            {
                var properties = string.Join( ", ", unusedProperties.Select( p => p.Property.Name ).ToArray( ) );
                Debug.WriteLine( $"Unparsed properties in type '{Type.FullName}': {unusedProperties.Count} = {properties}" );
            }
        }

        /// <summary>
        /// Writes the specified object.
        /// </summary>
        /// <param name="scope">The write scope.</param>
        /// <param name="value">The object to write.</param>
        /// <exception cref="InvalidDataException">Thrown when no converter is found for a property type.</exception>
        public override void Write( ref LcfWriteScope scope, object value )
        {
            foreach ( var property in _cache.Properties )
            {
                if ( !property.IsAllowed || property == _cache.IDProperty )
                    continue;

                var propertyType = property.Property.PropertyType;
                var propertyValue = property.Property.GetValue( value );

                bool writeProperty = ShouldWrite( property, propertyValue );
                bool writeSize = false;

                if ( property.Size != null )
                {
                    int count = ( propertyValue as IList )?.Count ?? 0;
                    int defaultCount = ( property.DefaultValue as IList )?.Count ?? 0;

                    writeSize = property.Size.AlwaysPersist ||
                        count != defaultCount;
                }

                if ( !writeProperty && !writeSize )
                    continue;

                var converter = LcfConverterFactory.GetConverter( propertyType );

                if ( converter == null )
                {
                    throw new InvalidDataException(
                        $"No converter found for {propertyType}" );
                }

                if ( property.Size != null && propertyValue == null )
                {
                    propertyValue = Activator.CreateInstance( propertyType );
                }

                var chunkScope = scope.CreateScope( );

                converter.Write( ref chunkScope, propertyValue );

                if ( writeSize )
                {
                    int sizeValue = GetCompanionSizeValue(
                        property, propertyValue, chunkScope.Length );

                    var sizePayload = scope.CreateScope( );
                    sizePayload.WriteVarInt32( sizeValue );

                    WriteChunk(
                        ref scope,
                        property.Size.ChunkID,
                        sizePayload.WrittenSpan );
                }

                if ( writeProperty &&
                    ( chunkScope.Length > 0 ||
                      property.AlwaysPersist != null ||
                      writeSize ) )
                {
                    int chunkID = _cache.GetChunkIDByProperty( property );

                    WriteChunk(
                        ref scope,
                        chunkID,
                        chunkScope.WrittenSpan,
                        propertyType == typeof( LcfString ) );
                }
            }

            if ( value is not LdbFile && value is not LmtFile && value is not LsdFile )
                scope.WriteVarInt32( 0 );
        }

        /// <summary>
        /// Writes a chunk identifier, length and payload.
        /// </summary>
        /// <param name="scope">The destination scope.</param>
        /// <param name="chunkID">The chunk identifier.</param>
        /// <param name="payload">The encoded payload.</param>
        /// <param name="payloadContainsLength">Whether the payload already contains its length.</param>
        private static void WriteChunk( ref LcfWriteScope scope, 
            int chunkID, 
            ReadOnlySpan<byte> payload, 
            bool payloadContainsLength = false )
        {
            scope.WriteVarInt32( chunkID );

            if ( !payloadContainsLength )
                scope.WriteVarInt32( payload.Length );

            scope.WriteBytes( payload );
        }

        /// <summary>
        /// Checks whether a property must be serialized.
        /// </summary>
        /// <param name="property">The property metadata.</param>
        /// <param name="value">The current property value.</param>
        /// <returns>Whether the property chunk should be written.</returns>
        private static bool ShouldWrite( LcfPropertyInfo property, object value )
        {
            if ( property.AlwaysPersist != null )
                return true;

            var defaultValue = property.DefaultValue;

            if ( value is IList || defaultValue is IList )
            {
                var list = value as IList;
                var defaultList = defaultValue as IList;

                int count = list?.Count ?? 0;
                int defaultCount = defaultList?.Count ?? 0;

                if ( count != defaultCount )
                    return true;

                for ( int i = 0; i < count; i++ )
                {
                    if ( !Equals( list[i], defaultList[i] ) )
                        return true;
                }

                return false;
            }
            else if ( value is IDbFlags flags && defaultValue is IDbFlags defaultFlags )
            {
                foreach ( var flagProperty in property.Property.PropertyType.GetProperties( ) )
                {
                    if ( flagProperty.PropertyType != typeof( bool ) )
                        continue;

                    if ( ( bool ) flagProperty.GetValue( flags ) !=
                            ( bool ) flagProperty.GetValue( defaultFlags ) )
                        return true;
                }

                return false;
            }

            return !Equals( value, defaultValue );
        }

        /// <summary>
        /// Gets the encoded size or element count for a companion chunk.
        /// </summary>
        /// <param name="property">The property metadata.</param>
        /// <param name="value">The collection value.</param>
        /// <param name="payloadLength">The encoded payload length.</param>
        /// <returns>The companion size value.</returns>
        private static int GetCompanionSizeValue(
            LcfPropertyInfo property,
            object value,
            int payloadLength )
        {
            var type = property.Property.PropertyType;

            // The current packed-list size fields contain element counts.
            if ( type.IsGenericType &&
                type.GetGenericTypeDefinition( ) == typeof( LcfPackedList<> ) )
            {
                return ( value as ICollection )?.Count ?? 0;
            }

            // Event and move commands use encoded byte lengths.
            return payloadLength;
        }

    }
}