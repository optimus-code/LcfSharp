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
using System;
using System.IO;

namespace LcfSharp.IO.Converters
{
    /// <summary>
    /// Converts class types.
    /// </summary>
    public class LcfClassConverter : LcfComplexConverter
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LcfClassConverter"/> class for the specified class type.
        /// </summary>
        /// <param name="classType">The class type to convert.</param>
        public LcfClassConverter( Type classType )
            : base( classType )
        {
        }

        /// <summary>
        /// Reads a class record from the source scope.
        /// </summary>
        /// <param name="scope">The read scope.</param>
        /// <returns>The object read from the binary reader.</returns>
        public override object Read( ref LcfReadScope scope )
        {
            var instance = Build( );

            foreach ( var property in _cache.Properties )
            {
                if ( scope.IsFinished )
                    break;

                if ( property.IsAllowed )
                    ReadProperty( ref scope, instance, property.Property );
            }

            return instance;
        }

        /// <summary>
        /// Writes a class record to the destination scope.
        /// </summary>
        /// <param name="scope">The write scope.</param>
        /// <param name="value">The object to write.</param>
        /// <exception cref="InvalidDataException">Thrown when no converter is found for a property type.</exception>
        public override void Write( ref LcfWriteScope scope, object value )
        {
            foreach ( var property in _cache.Properties )
            {
                if ( property.IsAllowed )
                    WriteProperty( ref scope, value, property.Property );
            }
        }
    }
}