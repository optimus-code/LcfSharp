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
using System.Linq;

namespace LcfSharp.Tests
{
    /// <summary>
    /// Tests buffer comparison conversion and serialization.
    /// </summary>
    public static class TestHelpers
    {
        /// <summary>
        /// Checks two buffers for byte-for-byte equality.
        /// </summary>
        /// <param name="source">The source buffer.</param>
        /// <param name="target">The target buffer.</param>
        public static void AssertBuffer( byte[] source, byte[] target )
        {
            int minLength = Math.Min( target.Length, source.Length );
            int contextBytes = 5; // Number of bytes to show before and after the deviation

            for ( int i = 0; i < minLength; i++ )
            {
                if ( target[i] != source[i] )
                {
                    // Show surrounding bytes for context
                    int start = Math.Max( 0, i - contextBytes );
                    int end = Math.Min( minLength - 1, i + contextBytes );

                    var targetSnippet = string.Join( " ", target.Skip( start ).Take( end - start + 1 ).Select( b => $"0x{b:X2}" ) );
                    var dataSnippet = string.Join( " ", source.Skip( start ).Take( end - start + 1 ).Select( b => $"0x{b:X2}" ) );

                    Assert.Fail( $"Targets differ at index {i:N0}. Expected: 0x{source[i]:X2}, Actual: 0x{target[i]:X2}\n" +
                                $"Written:\t{targetSnippet}\n" +
                                $"Expected:\t{dataSnippet}" );
                }
            }

            // If no differences found, check if one target is longer than the other
            if ( target.Length != source.Length )
            {
                Assert.Fail( $"Targets have different lengths. Expected: {source.Length}, Actual: {target.Length}" );
            }
        }
    }
}