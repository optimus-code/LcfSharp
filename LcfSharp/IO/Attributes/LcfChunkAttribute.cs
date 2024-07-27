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
    /// Indicates that the class represents an LCF chunk and specifies the enum type used for chunk identifiers.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
    public class LcfChunkAttribute : Attribute
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LcfChunkAttribute"/> class with the specified chunk enum type.
        /// </summary>
        /// <param name="chunkEnumType">The enum type used for chunk identifiers.</param>
        public LcfChunkAttribute( Type chunkEnumType )
        {
            ChunkEnumType = chunkEnumType;
        }

        /// <summary>
        /// Gets the enum type used for chunk identifiers.
        /// </summary>
        public Type ChunkEnumType
        {
            get;
            protected set;
        }
    }

    /// <summary>
    /// Indicates that the class represents an LCF chunk and specifies the enum type used for chunk identifiers.
    /// </summary>
    /// <typeparam name="TEnum">The enum type used for chunk identifiers.</typeparam>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
    public class LcfChunkAttribute<TEnum> : LcfChunkAttribute
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LcfChunkAttribute{TEnum}"/> class.
        /// </summary>
        public LcfChunkAttribute( )
            : base( typeof( TEnum ) )
        {
        }
    }
}