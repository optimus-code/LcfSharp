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
using System.Collections.Generic;
using System.Text;

namespace LcfSharp.IO.Types
{
    /// <summary>
    /// Resolves the encodings supported by LCF strings.
    /// </summary>
    public static class LcfEncoding
    {
        /// <summary>
        /// Holds standard and strict variants of an encoding.
        /// </summary>
        public record EncodingPair
        {
            public Encoding Standard
            {
                get;
                set;
            }

            public Encoding Strict
            {
                get;
                set;
            }
        }

        private static readonly Dictionary<LcfEncodingType, EncodingPair> _registry = [];

        static LcfEncoding( )
        {
            Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );

            var decoderFallback = new DecoderExceptionFallback( );
            var encoderFallback = new EncoderExceptionFallback( );

            var codePageMap = new Dictionary<LcfEncodingType, int>
            {
                { LcfEncodingType.WesternEurope1252, 1252 },
                { LcfEncodingType.JapaneseShiftJis, 932 },
                { LcfEncodingType.Cyrillic1251, 1251 },
                { LcfEncodingType.CentralEurope1250, 1250 },
                { LcfEncodingType.SimplifiedChineseGb2312, 936 },
                { LcfEncodingType.TraditionalChineseBig5, 950 },
                { LcfEncodingType.KoreanUhc, 949 }
            };

            foreach ( var kvp in codePageMap )
            {
                Encoding standard = Encoding.GetEncoding( kvp.Value );
                Encoding strict = Encoding.GetEncoding( kvp.Value, encoderFallback, decoderFallback );

                _registry.Add( kvp.Key, new EncodingPair
                {
                    Standard = standard,
                    Strict = strict
                } );
            }
        }

        /// <summary>
        /// Gets the encoding for the specified LCF encoding type.
        /// </summary>
        /// <param name="encodingType">The targeted encoding type.</param>
        /// <returns>The encoding instance.</returns>
        public static Encoding GetEncoder( LcfEncodingType encodingType )
        {
            if ( _registry.TryGetValue( encodingType, out var pair ) )
            {
                return pair.Standard;
            }

            throw new ArgumentOutOfRangeException( nameof( encodingType ), encodingType, "Unsupported RPG Maker 2000 encoding configuration requested." );
        }
    }
}