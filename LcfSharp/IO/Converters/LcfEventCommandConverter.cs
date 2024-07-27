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

using LcfSharp.IO.Extensions;
using LcfSharp.Rpg.Events;
using System;
using System.Collections.Generic;
using System.IO;

namespace LcfSharp.IO.Converters
{
    /// <summary>
    /// Converter class for reading and writing EventCommand objects.
    /// </summary>
    public class LcfEventCommandConverter : LcfConverter<EventCommand>
    {
        /// <summary>
        /// Reads an EventCommand object from the binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="length">The length of the data to read, if specified.</param>
        /// <returns>An EventCommand object read from the binary reader.</returns>
        public override object Read( BinaryReader reader, int? length )
        {
            var instance = new EventCommand( );
            instance.Code = ( EventCommandCode ) reader.ReadVarInt32( );

            if ( instance.Code != EventCommandCode.None )
            {
                instance.Indent = reader.ReadVarInt32( );
                instance.String = reader.ReadString( reader.ReadVarInt32( ) );

                var parametersCount = reader.ReadVarInt32( );
                instance.Parameters = new List<int>( parametersCount );

                for ( var i = 0; i < parametersCount; i++ )
                {
                    instance.Parameters.Add( reader.ReadVarInt32( ) );
                }
            }

            return instance;
        }

        /// <summary>
        /// Writes an EventCommand object to the binary writer.
        /// </summary>
        /// <param name="writer">The binary writer to write to.</param>
        /// <param name="value">The EventCommand object to write.</param>
        public override void Write( BinaryWriter writer, object value )
        {
            var instance = value as EventCommand;
            if ( instance == null )
            {
                throw new ArgumentException( "Value must be of type EventCommand", nameof( value ) );
            }

            writer.WriteVarInt32( ( int ) instance.Code );

            if ( instance.Code != EventCommandCode.None )
            {
                writer.WriteVarInt32( instance.Indent );
                writer.WriteVarInt32( instance.String.Length );
                writer.Write( instance.String );

                writer.WriteVarInt32( instance.Parameters.Count );
                foreach ( var parameter in instance.Parameters )
                {
                    writer.WriteVarInt32( parameter );
                }
            }
        }
    }
}