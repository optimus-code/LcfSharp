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

using LcfSharp.IO.Scopes;
using LcfSharp.IO.Types.Generic;
using LcfSharp.Rpg.Events;
using System;

namespace LcfSharp.IO.Converters.Types.Events
{
    /// <summary>
    /// Converter class for reading and writing EventCommand objects.
    /// </summary>
    public class LcfEventCommandConverter : LcfConverter<EventCommand>
    {
        /// <summary>
        /// Reads an EventCommand object from the binary reader.
        /// </summary>
        /// <param name="scope">The read scope.</param>
        /// <returns>An EventCommand object.</returns>
        public override object Read( ref LcfReadScope scope )
        {
            var instance = new EventCommand
            {
                Code = scope.ReadEnum<EventCommandCode>( ),
                Indent = scope.ReadVarInt32( ),
                String = scope.ReadString( LcfConverterFactory.EncodingType )
            };

            var parametersCount = scope.ReadVarInt32( );
            instance.Parameters = new LcfList<int>( parametersCount );

            for ( var i = 0; i < parametersCount; i++ )
            {
                instance.Parameters.Add( scope.ReadVarInt32( ) );
            }

            return instance;
        }

        /// <summary>
        /// Writes the specified EventCommand.
        /// </summary>
        /// <param name="scope">The write scope.</param>
        /// <param name="value">The value to write.</param>
        public override void Write( ref LcfWriteScope scope, object value )
        {
            var instance = value as EventCommand;
            if ( instance == null )
            {
                throw new ArgumentException( "Value must be of type EventCommand", nameof( value ) );
            }

            scope.WriteVarInt32( ( int ) instance.Code );

            scope.WriteVarInt32( instance.Indent );
            scope.WriteString( instance.String );

            scope.WriteVarInt32( instance.Parameters.Count );
            foreach ( var parameter in instance.Parameters )
            {
                scope.WriteVarInt32( parameter );
            }
        }
    }
}