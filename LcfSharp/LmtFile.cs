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

using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using LcfSharp.Rpg.MapTree;
using System.Collections.Generic;
using System.IO;

namespace LcfSharp
{
    /// <summary>
    /// Represents the map tree file
    /// </summary>
    public class LmtFile : ILcfRootChunk
    {
        /// <summary>
        /// The header of the file
        /// </summary>
        [LcfIgnore]
        public string Header
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list of map information.
        /// </summary>
        public List<MapInfo> Maps
        {
            get;
            set;
        } = new List<MapInfo>();

        /// <summary>
        /// Gets or sets the order of the map tree nodes.
        /// </summary>
        public List<int> TreeOrder
        {
            get;
            set;
        } = new List<int>();

        /// <summary>
        /// Gets or sets the ID of the active node in the map tree.
        /// </summary>
        public int ActiveNode
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the starting positions for various entities in the map tree.
        /// </summary>
        public Start Start
        {
            get;
            set;
        } = new Start();

        /// <summary>
        /// Loads the map tree from the specified file path.
        /// </summary>
        /// <param name="path">The file path of the map tree.</param>
        /// <returns>The loaded <see cref="LmtFile"/> object.</returns>
        public static LmtFile Load(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return LcfSerialiser.Deserialise<LmtFile>(stream, new LcfSerialiserOptions { Format = LcfFormat.LMT });
            }
        }
    }
}