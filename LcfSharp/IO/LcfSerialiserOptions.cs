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

using LcfSharp.IO.Converters;
using LcfSharp.IO.Types;
using System.Collections.Generic;

namespace LcfSharp.IO
{
    /// <summary>
    /// Provides options for serialising and deserialising LCF (RPG Maker 2000 format) data.
    /// </summary>
    public class LcfSerialiserOptions
    {
        /// <summary>
        /// Gets or sets the LCF format.
        /// </summary>
        public LcfFormat Format
        {
            get;
            set;
        } = LcfFormat.LDB;

        /// <summary>
        /// Gets or sets a value indicating whether unknown chunks should be ignored.
        /// </summary>
        public bool IgnoreUnknownChunks
        {
            get;
            set;
        } = true;

        /// <summary>
        /// Gets or sets the list of custom converters to use.
        /// </summary>
        public List<LcfConverter> Converters
        {
            get;
            set;
        } = [];

        /// <summary>
        /// Gets or sets the engine version for the LCF data.
        /// </summary>
        public LcfEngineVersion Version
        {
            get;
            set;
        } = LcfEngineVersion.RM2K;
    }
}