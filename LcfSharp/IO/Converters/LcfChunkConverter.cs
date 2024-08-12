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

using LcfSharp.Chunks.MapTree;
using LcfSharp.IO.Exceptions;
using LcfSharp.IO.Extensions;
using LcfSharp.IO.Types;
using LcfSharp.IO.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace LcfSharp.IO.Converters
{
    /// <summary>
    /// Provides methods to convert chunk types in the LCF (RPG Maker 2000 format).
    /// </summary>
    public class LcfChunkConverter : LcfComplexConverter
    {
        private Dictionary<string, int> _lengthEvaluations = [];

        /// <summary>
        /// Initialises a new instance of the <see cref="LcfChunkConverter"/> class for the specified chunk type.
        /// </summary>
        /// <param name="chunkType">The chunk type to convert.</param>
        public LcfChunkConverter( Type chunkType )
            : base( chunkType )
        {
        }

        /// <summary>
        /// Reads an object of the specified chunk type from the binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="length">The length of the data to read (not used).</param>
        /// <returns>The object read from the binary reader.</returns>
        public override object Read( BinaryReader reader, int? length )
        {
            var instance = Build( );
            var parsedProperties = new HashSet<string>( );

           // LcfDataDumper.Dump( Type, reader, ( ) => { 

            // If it has an ID property read in that first!
            if ( _cache.IDProperty != null )
            {
                _cache.IDProperty.Property.SetValue( instance, reader.ReadVarInt32( ) );
                parsedProperties.Add( _cache.IDProperty.Property.Name );
            }

            var properties = _cache.Properties;
            var chunkEnumType = _cache.ChunkEnumType;

            while ( reader.BaseStream.Position < reader.BaseStream.Length )
            {
                var chunkID = reader.ReadVarInt32( );

                if ( chunkID == 0 )
                    break;

                var chunkLength = reader.ReadVarInt32( );

                if ( Enum.IsDefined( chunkEnumType, chunkID ) )
                {
                    LcfProperty match = _cache.GetPropertyByChunkID( chunkID );

                    if ( match?.IsAllowed == true )
                    {
                        if ( parsedProperties.Contains( match.Property.Name ) )
                            throw new LcfException( $"{match.Property.Name} has already been parsed, there's a read error somewhere." );

                        var propertyLength = chunkLength;

                        if ( match.IsGenericListType )
                        {
                            if ( match.IsGenericListBasicType )
                                propertyLength = chunkLength / Marshal.SizeOf( match.GenericListInnerType );
                        }

                        if ( match.Size != null && _lengthEvaluations.ContainsKey( match.Property.Name ) )
                        {
                            propertyLength = _lengthEvaluations[match.Property.Name];
                            _lengthEvaluations.Remove( match.Property.Name );
                        }

                        ReadProperty( reader, instance, match.Property, propertyLength );
                        parsedProperties.Add( match.Property.Name );
                    }
                    // If there's a property with a size value dependent on this
                    else if ( _cache.SizeChunks?.TryGetValue( chunkID, out var targetProperty ) == true )
                    {
                        _lengthEvaluations.Add( targetProperty.Property.Name, reader.ReadVarInt32( ) );
                    }
                    else
                    {
#if DEBUG
                        Debug.WriteLine( $"Missing property match for chunk: '0x{chunkID:X}' in '{Type.FullName}'." );
#endif
                        reader.BaseStream.Seek( chunkLength, SeekOrigin.Current );
                    }
                }
                else
                {
                    reader.BaseStream.Seek( chunkLength, SeekOrigin.Current );
                }
            }
           //     return instance;
           // } );
#if DEBUG
            CollectDebugInfo( parsedProperties );
#endif

            _lengthEvaluations.Clear( );

            return instance;
        }

        /// <summary>
        /// Output some debug info when there's parsing issues
        /// </summary>
        /// <param name="parsedProperties"></param>
        private void CollectDebugInfo( HashSet<string> parsedProperties )
        {
            var unusedProperties = _cache.Chunks.Values
                .Where( p => !parsedProperties.Contains( p.Property.Name ) &&
                    p.AlwaysPersist != null &&
                    p.Property.PropertyType != typeof( string ) )
                .ToList( );
            if ( unusedProperties.Any( ) )
                Debug.WriteLine( $"Unparsed properties in type '{Type.FullName}': {unusedProperties.Count}" );
        }

        /// <summary>
        /// Writes the specified object to the binary writer.
        /// </summary>
        /// <param name="writer">The binary writer to write to.</param>
        /// <param name="value">The object to write.</param>
        /// <param name="writeLength">Not applicable for chunk converter</param>
        /// <exception cref="InvalidDataException">Thrown when no converter is found for a property type.</exception>
        public override void Write( BinaryWriter writer, object value, bool writeLength )
        {
            var properties = _cache.Properties;

            // If it has an ID property, write that first.
            if ( _cache.IDProperty != null )
            {
                writer.WriteVarInt32( ( int ) _cache.IDProperty.Property.GetValue( value ) );
            }

            foreach ( var property in properties )
            {
                if ( property.IsAllowed && property != _cache.IDProperty )
                {
                    var chunkID = _cache.GetChunkIDByProperty( property );
                    var propertyValue = property.Property.GetValue( value );
                    var converter = LcfConverterFactory.GetConverter( property.Property.PropertyType );

                    if ( converter is not null )
                    {
                        // We have to write to a sub-stream to get the length as length is pre-fixed
                        // before chunk content
                        using ( var ms = new MemoryStream( ) )
                        using ( var chunkWriter = new BinaryWriter( ms ) )
                        {
                            if ( writer.BaseStream.Position >= 670 )
                            {

                            }
                            if ( chunkID == 0x3F )
                            {

                            }
                            var alwaysPersist = property.AlwaysPersist != null;

                            if ( alwaysPersist ||
                                ( !alwaysPersist && !propertyValue.Equals( property.DefaultValue ) ) )
                            {
                                converter.Write( chunkWriter, propertyValue, false );

                                var chunkBuffer = ms.ToArray( );
                                var isEmpty = ( chunkBuffer == null || chunkBuffer.Length == 0 );

                                // If there is data or the property is marked with LcfAlwaysPersist then
                                // the chunk will always be written regardless of if it is default value or null / zero length
                                // Still need to handle default value acquisition to decide to exclude properties if theyre value types
                                if ( ( chunkBuffer?.Length > 0 ) ||
                                    ( alwaysPersist && isEmpty ) )
                                {
                                    var hasSizeChunk = false;

                                    if ( property.Property.PropertyType.IsClass )
                                    {
                                        // If there's a size chunk write that first
                                        if ( property.Size != null )
                                        {
                                            // Some weird quirk where the payload is encoded but not the size when empty
                                            if ( property.Size.NoSizeWhenEmpty && !isEmpty || 
                                                !property.Size.NoSizeWhenEmpty )
                                            {
                                                var sizeChunkID = property.Size.ChunkID;

                                                writer.WriteVarInt32( sizeChunkID );
                                                writer.WriteVarInt32( 1 ); // ?? NO idea why i need this
                                                writer.WriteVarInt32( property.IsGenericListType ? ( ( IList ) propertyValue ).Count : chunkBuffer.Length );
                                            }
                                            hasSizeChunk = true;
                                        }
                                    }

                                    writer.WriteVarInt32( chunkID );

                                    if ( isEmpty && !hasSizeChunk )
                                    {
                                        // Lists always have a blank that is never serialised
                                        if ( property.IsGenericListType )
                                        {
                                            writer.WriteVarInt32( 1 );
                                            writer.WriteVarInt32( 0 );
                                        }
                                        else
                                        {
                                            writer.WriteVarInt32( 0 );
                                        }
                                    }
                                    else if ( isEmpty && hasSizeChunk && 
                                        property.AlwaysPersist != null && 
                                        property.Size?.NoSizeWhenEmpty == true )
                                    {
                                        writer.WriteVarInt32( 0 );
                                    }
                                    else if ( isEmpty && property.Size?.NoSizeWhenEmpty == true ||
                                        isEmpty && property.AlwaysPersist == null )
                                    {
                                        // Do nothing
                                    }
                                    else
                                    {
                                        writer.WriteVarInt32( property.IsGenericListType ? ( ( IList ) propertyValue ).Count : chunkBuffer.Length );
                                        writer.Write( chunkBuffer );
                                    }


                                    //writer.WriteVarInt32( ( byte ) 0 );
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidDataException( $"No converter found for type {property.Property.PropertyType}" );
                    }
                }
            }

            // Apparently some types can't end in zero bytes
            if ( value is not LdbFile && value is not LmtFile )
            {
                writer.WriteVarInt32( 0 );
            }

#warning Come back to this as Database and another type cause crashes if they end with 0 with rm2k editor
        }
    }
}