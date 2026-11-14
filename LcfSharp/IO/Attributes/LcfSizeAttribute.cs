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

namespace LcfSharp.IO.Attributes
{
    /// <summary>
    /// Indicates that this property depends on another chunk being read to 
    /// get the size for an array or list.
    /// </summary>
    /// <param name="chunkID">The chunk ID that determines the size of the
    /// array or list.</param>
    /// <param name="alwaysPersist">The size chunk should always be emitted.</param>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LcfSizeAttribute( int chunkID, bool alwaysPersist = false ) : Attribute
    {
        /// <summary>
        /// Gets the chunk ID that determines the size of the array or list.
        /// </summary>
        public int ChunkID
        {
            get;
        } = chunkID;

        /// <summary>
        /// The size chunk should be emitted even if the element count is 
        /// equal to the default element count.
        /// </summary>
        public bool AlwaysPersist
        {
            get;
            set;
        } = alwaysPersist;
    }
}