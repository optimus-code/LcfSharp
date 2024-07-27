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
using System;
using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    /// <summary>
    /// Provides conversion methods for enum types in the LCF (RPG Maker 2000 format).
    /// </summary>
    public class LcfEnumConverter : LcfConverter
    {
        /// <summary>
        /// Gets or sets the type of enum this converter is for.
        /// </summary>
        public sealed override Type Type
        {
            get;
            protected set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LcfEnumConverter"/> class for the specified enum type.
        /// </summary>
        /// <param name="enumType">The enum type to convert.</param>
        public LcfEnumConverter( Type enumType )
        {
            Type = enumType;
        }

        /// <summary>
        /// Determines whether this converter can convert the specified type.
        /// </summary>
        /// <param name="typeToConvert">The type to check for conversion support.</param>
        /// <returns><c>true</c> if this converter can convert the specified type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert( Type typeToConvert ) => typeToConvert == Type;

        /// <summary>
        /// Reads an enum value from the specified binary reader.
        /// </summary>
        /// <param name="reader">The binary reader to read from.</param>
        /// <param name="length">The length of the data to read (not used).</param>
        /// <returns>The enum value read from the binary reader.</returns>
        public override object Read( BinaryReader reader, int? length )
        {
            return Enum.ToObject( Type, reader.ReadVarInt32( ) );
        }

        /// <summary>
        /// Writes the specified enum value to the binary writer.
        /// </summary>
        /// <param name="writer">The binary writer to write to.</param>
        /// <param name="value">The enum value to write.</param>
        public override void Write( BinaryWriter writer, object value )
        {
            if ( value == null )
                throw new ArgumentNullException( nameof( value ) );

            if ( !Enum.IsDefined( Type, value ) )
                throw new ArgumentException( $"Invalid value for enum type {Type}", nameof( value ) );

            writer.WriteVarInt32( ( int ) value );
        }
    }
}