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
using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    /// <summary>
    /// Converter class for reading and writing MoveCommand objects.
    /// </summary>
    public class LcfMoveCommandConverter : LcfConverter<MoveCommand>
    {
        /// <summary>
        /// Reads a MoveCommand object from the binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="length">The length of the data to read, if specified.</param>
        /// <returns>A MoveCommand object read from the binary reader.</returns>
        public override object Read( BinaryReader reader, int? length )
        {
            var instance = new MoveCommand( );
            instance.CommandID = ( MoveCommandCode ) reader.ReadVarInt32( );

            switch ( instance.CommandID )
            {
                case MoveCommandCode.SwitchOn:
                case MoveCommandCode.SwitchOff:
                    instance.ParameterA = reader.ReadVarInt32( );
                    break;

                case MoveCommandCode.ChangeGraphic:
                    instance.ParameterString = reader.ReadString( reader.ReadVarInt32() );
                    instance.ParameterA = reader.ReadVarInt32( );
                    break;

                case MoveCommandCode.PlaySoundEffect:
                    instance.ParameterString = reader.ReadString( reader.ReadVarInt32( ) );
                    instance.ParameterA = reader.ReadVarInt32( );
                    instance.ParameterB = reader.ReadVarInt32( );
                    instance.ParameterC = reader.ReadVarInt32( );
                    break;
            }

            return instance;
        }

        /// <summary>
        /// Writes a MoveCommand object to the binary writer.
        /// </summary>
        /// <param name="writer">The binary writer to write to.</param>
        /// <param name="value">The MoveCommand object to write.</param>
        /// <param name="writeLength">Not applicable</param>
        public override void Write( BinaryWriter writer, object value, bool writeLength )
        {
            var instance = value as MoveCommand;
            if ( instance == null )
            {
                throw new ArgumentException( "Value must be of type MoveCommand", nameof( value ) );
            }

            writer.WriteVarInt32( ( int ) instance.CommandID );

            switch ( instance.CommandID )
            {
                case MoveCommandCode.SwitchOn:
                case MoveCommandCode.SwitchOff:
                    writer.WriteVarInt32( instance.ParameterA );
                    break;

                case MoveCommandCode.ChangeGraphic:
                    writer.WriteVarInt32( instance.ParameterString.Length );
                    writer.WriteString( instance.ParameterString );
                    writer.WriteVarInt32( instance.ParameterA );
                    break;

                case MoveCommandCode.PlaySoundEffect:
                    writer.WriteVarInt32( instance.ParameterString.Length );
                    writer.WriteString( instance.ParameterString );
                    writer.WriteVarInt32( instance.ParameterA );
                    writer.WriteVarInt32( instance.ParameterB );
                    writer.WriteVarInt32( instance.ParameterC );
                    break;
            }
        }
    }
}