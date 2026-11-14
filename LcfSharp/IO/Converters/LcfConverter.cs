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

namespace LcfSharp.IO.Converters
{
    /// <summary>
    /// Provides an abstract base class for LCF (RPG Maker 2000 format) converters.
    /// </summary>
    public abstract class LcfConverter
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LcfConverter"/> class.
        /// </summary>
        internal LcfConverter( )
        {
        }

        /// <summary>
        /// Gets the type that this converter handles.
        /// </summary>
        public abstract Type Type
        {
            get; 
            protected set;
        }

        /// <summary>
        /// Determines whether this converter can convert the specified type.
        /// </summary>
        /// <param name="typeToConvert">The type to check for conversion support.</param>
        /// <returns><c>true</c> if this converter can convert the specified type; otherwise, <c>false</c>.</returns>
        public abstract bool CanConvert( Type typeToConvert );

        /// <summary>
        /// Reads an object.
        /// </summary>
        /// <param name="scope">The read scope.</param>
        /// <returns>The decoded value.</returns>
        public abstract object Read( ref LcfReadScope scope );

        /// <summary>
        /// Writes the specified object.
        /// </summary>
        /// <param name="scope">The write scope.</param>
        /// <param name="value">The object to write.</param>
        public abstract void Write( ref LcfWriteScope scope, object value );
    }

    /// <summary>
    /// Provides an abstract base class for LCF converters for a specific type.
    /// </summary>
    /// <typeparam name="T">The type that this converter handles.</typeparam>
    public abstract class LcfConverter<T> : LcfConverter
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LcfConverter{T}"/> class.
        /// </summary>
        protected internal LcfConverter( )
        {
        }

        /// <summary>
        /// Gets the type that this converter handles.
        /// </summary>
        public sealed override Type Type 
        { 
            get; 
            protected set; 
        } = typeof( T );

        /// <summary>
        /// Determines whether this converter can convert the specified type.
        /// </summary>
        /// <param name="typeToConvert">The type to check for conversion support.</param>
        /// <returns><c>true</c> if this converter can convert the specified type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert( Type typeToConvert )
        {
            return typeToConvert == typeof( T );
        }
    }
}