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

namespace LcfSharp.IO.Types
{
    /// <summary>
    /// Represents a 32-bit integer stored in fixed-width binary form.
    /// </summary>
    public readonly struct LcfFixedInt32 :
        IEquatable<LcfFixedInt32>,
        IEquatable<int>
    {
        public int Value
        {
            get;
        }

        /// <summary>
        /// Creates a fixed-width integer.
        /// </summary>
        /// <param name="value">The integer value.</param>
        public LcfFixedInt32( int value )
        {
            Value = value;
        }

        /// <summary>
        /// Compares this integer with another value.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns>Whether the values are equal.</returns>
        public bool Equals( LcfFixedInt32 other )
        {
            return Value == other.Value;
        }

        /// <summary>
        /// Compares this integer with another value.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns>Whether the values are equal.</returns>
        public bool Equals( int other )
        {
            return Value == other;
        }

        /// <summary>
        /// Compares this integer with another value.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns>Whether the values are equal.</returns>
        public override bool Equals( object other )
        {
            return other is LcfFixedInt32 value &&
                Equals( value );
        }

        /// <summary>
        /// Gets the hash code for this integer.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode( )
        {
            return Value.GetHashCode( );
        }

        /// <summary>
        /// Compares two fixed-width integers for equality.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>Whether the values are equal.</returns>
        public static bool operator ==(
            LcfFixedInt32 left, LcfFixedInt32 right )
        {
            return left.Equals( right );
        }

        /// <summary>
        /// Compares two fixed-width integers for inequality.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>Whether the values differ.</returns>
        public static bool operator !=(
            LcfFixedInt32 left, LcfFixedInt32 right )
        {
            return !left.Equals( right );
        }

        /// <summary>
        /// Converts an integer to a fixed-width integer.
        /// </summary>
        /// <param name="value">The integer value.</param>
        /// <returns>The fixed-width integer.</returns>
        public static implicit operator LcfFixedInt32( int value )
        {
            return new( value );
        }

        /// <summary>
        /// Gets the decimal representation of this integer.
        /// </summary>
        /// <returns>The formatted integer.</returns>
        public override string ToString( )
        {
            return Value.ToString( );
        }
    }
}