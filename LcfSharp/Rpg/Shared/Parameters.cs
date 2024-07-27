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

using System.Collections.Generic;
using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg.Shared
{
    /// <summary>
    /// Class representing a collection of parameters for a character.
    /// </summary>
    [LcfListCollection]
    public class Parameters
    {
        /// <summary>
        /// List of maximum HP (Health Points) values.
        /// </summary>
        public List<short> MaxHP
        {
            get;
            set;
        } = new List<short>( );

        /// <summary>
        /// List of maximum SP (Spirit Points) values.
        /// </summary>
        public List<short> MaxSP
        {
            get;
            set;
        } = new List<short>( );

        /// <summary>
        /// List of attack values.
        /// </summary>
        public List<short> Attack
        {
            get;
            set;
        } = new List<short>( );

        /// <summary>
        /// List of defense values.
        /// </summary>
        public List<short> Defense
        {
            get;
            set;
        } = new List<short>( );

        /// <summary>
        /// List of spirit values.
        /// </summary>
        public List<short> Spirit
        {
            get;
            set;
        } = new List<short>( );

        /// <summary>
        /// List of agility values.
        /// </summary>
        public List<short> Agility
        {
            get;
            set;
        } = new List<short>( );
    }
}