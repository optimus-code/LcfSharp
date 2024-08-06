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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LcfSharp.IO.Converters
{
    /// <summary>
    /// Provides methods to convert chunk types in the LCF (RPG Maker 2000 format).
    /// </summary>
    public class LcfChunkConverter : LcfConverter
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

        private Dictionary<string, int> _lengthEvaluations = [];

        /// <summary>
        /// Initialises a new instance of the <see cref="LcfChunkConverter"/> class for the specified chunk type.
        /// </summary>
        /// <param name="chunkType">The chunk type to convert.</param>
        public LcfChunkConverter( Type chunkType )
        {
            Type = chunkType;
        }

        /// <summary>
        /// Processes the specified property by reading its value from the binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="obj">The object to set the property value on.</param>
        /// <param name="property">The property to process.</param>
        /// <param name="length">The length of the data to read.</param>
        /// <exception cref="InvalidDataException">Thrown when no converter is found for the property type.</exception>
        private void ProcessProperty( BinaryReader reader, object obj, PropertyInfo property, int? length )
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
        /// Reads an object of the specified chunk type from the binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="length">The length of the data to read (not used).</param>
        /// <returns>The object read from the binary reader.</returns>
        public override object Read( BinaryReader reader, int? length )
        {
            var obj = Activator.CreateInstance( Type );
            var lcfType = LcfType.Get( Type );
            var parsedProperties = new HashSet<string>( );

            // If it has an ID property read in that first!
            if ( lcfType.IDProperty != null )
            {
                lcfType.IDProperty.Property.SetValue( obj, reader.ReadVarInt32( ) );
                parsedProperties.Add( lcfType.IDProperty.Property.Name );
            }

            var properties = lcfType.Properties;
            var chunkEnumType = lcfType.ChunkEnumType;

            if ( lcfType.ChunkEnumType == typeof(MapInfoChunk))
            {

            }
            while ( reader.BaseStream.Position < reader.BaseStream.Length )
            {
                var chunkID = reader.ReadVarInt32( );

                if ( chunkID == 0 )
                    break;

                var chunkLength = reader.ReadVarInt32( );

                if ( lcfType.ChunkEnumType == typeof( MapInfoChunk ) )
                {

                }
                if ( Enum.IsDefined( chunkEnumType, chunkID ) )
                {
                    LcfProperty match = lcfType.GetPropertyByChunkID( chunkID );

                    if ( match != null && match.IsAllowed )
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
                        ProcessProperty( reader, obj, match.Property, propertyLength );
                        parsedProperties.Add( match.Property.Name );
                    }
                    // If there's a property with a size value dependent on this
                    else if ( lcfType.SizeChunks.TryGetValue( chunkID, out var targetProperty ) )
                    {
                        _lengthEvaluations.Add( targetProperty.Property.Name, reader.ReadVarInt32( ) );
                    }
                    else
                    {
                        Console.WriteLine( $"Missing property match for chunk: '0x{chunkID:X}' in '{Type.FullName}'." );

                        reader.BaseStream.Seek( chunkLength, SeekOrigin.Current );
                    }
                }
                else
                {
                    reader.BaseStream.Seek( chunkLength, SeekOrigin.Current );
                }
            }

            var unusedProperties = lcfType.Chunks.Values
                .Where( p => !parsedProperties.Contains( p.Property.Name ) &&
                    p.AlwaysPersist != null &&
                    p.Property.PropertyType != typeof( string ) )
                .ToList( );

            if ( unusedProperties.Any( ) )
                Debug.WriteLine( $"Unparsed properties in type '{Type.FullName}': {unusedProperties.Count}" );

            _lengthEvaluations.Clear( );

            if ( lcfType.ChunkEnumType == typeof( MapInfoChunk ) )
            {

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
            var lcfType = LcfType.Get( Type );
            var properties = lcfType.Properties;

            // If it has an ID property, write that first.
            if ( lcfType.IDProperty != null )
            {
                writer.WriteVarInt32( ( int ) lcfType.IDProperty.Property.GetValue( value ) );
            }

            foreach ( var property in properties )
            {
                if ( property.IsAllowed )
                {
                    var chunkID = lcfType.GetChunkIDByProperty( property );
                    var propertyValue = property.Property.GetValue( value );
                    var converter = LcfConverterFactory.GetConverter( property.Property.PropertyType );

                    if ( converter is not null )
                    {
                        writer.WriteVarInt32( chunkID );
                        converter.Write( writer, propertyValue );
                    }
                    else
                    {
                        throw new InvalidDataException( $"No converter found for type {property.Property.PropertyType}" );
                    }
                }
            }

            // Write the chunk end marker
            writer.WriteVarInt32( 0 );
#warning Come back to this as Database and another type cause crashes if they end with 0 with rm2k editor
        }
    }
}