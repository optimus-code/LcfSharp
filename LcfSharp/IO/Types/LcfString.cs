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

using System;
using System.Text;

namespace LcfSharp.IO.Types
{
    /// <summary>
    /// Represents an encoded LCF string.
    /// </summary>
    /// <remarks>
    /// Preserves the original bytes and the selected character encoding.
    /// </remarks>
    public class LcfString : IEquatable<LcfString>
    {
        /// <summary>
        /// The string value.
        /// </summary>
        public string Value
        {
            get;
            set;
        }

        /// <summary>
        /// The original byte buffer.
        /// </summary>
        public byte[] OriginalBuffer
        {
            get;
        }

        /// <summary>
        /// The encoding type.
        /// </summary>
        public LcfEncodingType EncodingType
        {
            get;
        }

        /// <summary>
        /// Gets the number of characters in the string.
        /// </summary>
        public int Length
        {
            get
            {
                if ( Value == null )
                    return 0;

                return Value.Length;
            }
        }
        private readonly Encoding _encoder;

        /// <summary>
        /// Creates an LCF string.
        /// </summary>
        public LcfString( ) : this( string.Empty )
        {
        }
        /// <summary>
        /// Decodes an LCF string from its original bytes.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="encodingType">The text encoding.</param>
        public LcfString( byte[] buffer, LcfEncodingType encodingType = LcfEncodingType.WesternEurope1252 )
        {
            EncodingType = encodingType;
            OriginalBuffer = buffer ?? Array.Empty<byte>( );
            _encoder = LcfEncoding.GetEncoder( EncodingType );
            Value = _encoder.GetString( OriginalBuffer );
        }

        /// <summary>
        /// Creates an encoded LCF string from text.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="encodingType">The text encoding.</param>
        public LcfString( string value, LcfEncodingType encodingType = LcfEncodingType.WesternEurope1252 )
        {
            EncodingType = encodingType;
            _encoder = LcfEncoding.GetEncoder( EncodingType );
            Value = value ?? string.Empty;
            OriginalBuffer = _encoder.GetBytes( Value );
        }

        /// <summary>
        /// Encodes the current string value.
        /// </summary>
        /// <returns>The byte buffer.</returns>
        public byte[] ToBuffer( )
        {
            return _encoder.GetBytes( Value ?? string.Empty );
        }

        /// <summary>
        /// Compares the string values.
        /// </summary>
        /// <param name="other">The other string.</param>
        /// <returns>Whether the values are equal.</returns>
        public bool Equals( LcfString other )
        {
            if ( ReferenceEquals( this, other ) )
                return true;

            return other is not null &&
                string.Equals( Value, other.Value, StringComparison.Ordinal );
        }

        /// <summary>
        /// Compares the string values.
        /// </summary>
        /// <param name="other">The other string.</param>
        /// <returns>Whether the values are equal.</returns>
        public override bool Equals( object other ) =>
            other is LcfString value && Equals( value );

        /// <summary>
        /// Gets the hash code of the string value.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode( )
        {
            return Value == null ? 0 : StringComparer.Ordinal.GetHashCode( Value );
        }

        /// <summary>
        /// Compares the string values.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The resulting value.</returns>
        public static bool operator ==( LcfString left, LcfString right )
        {
            if ( left is null )
                return right is null;

            return left.Equals( right );
        }

        /// <summary>
        /// Compares the string values.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The resulting value.</returns>
        public static bool operator !=( LcfString left, LcfString right )
        {
            return !( left == right );
        }

        /// <summary>
        /// Gets the decoded string value.
        /// </summary>
        /// <remarks>
        /// Loses the stored encoding type so should be used
        /// for display and read-only scenarios.
        /// </remarks>
        /// <param name="lcfString">The lcf string.</param>
        public static implicit operator string( LcfString lcfString )
        {
            if ( lcfString is null )
                return null;

            return lcfString.Value;
        }

        /// <summary>
        /// Creates an LCF string from a .NET string.
        /// </summary>
        /// <remarks>
        /// Assumes ANSI encoding.
        /// </remarks>
        /// <param name="value">The lcf string.</param>
        public static implicit operator LcfString( string value )
        {
            if ( value == null )
                return null;

            return new( value );
        }
    }
}