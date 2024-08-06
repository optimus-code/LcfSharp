using LcfSharp.Chunks.MapTree;
using LcfSharp.IO.Attributes;

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

namespace LcfSharp.Rpg.MapTree
{
    /// <summary>
    /// Represents the starting positions for various entities in the game.
    /// </summary>
    [LcfChunk<StartChunk>]
    public class Start
    {
        /// <summary>
        /// Gets or sets the map ID where the party starts.
        /// </summary>
        public int PartyMapID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the X coordinate where the party starts.
        /// </summary>
        public int PartyX
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the Y coordinate where the party starts.
        /// </summary>
        public int PartyY
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the map ID where the boat starts.
        /// </summary>
        public int BoatMapID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the X coordinate where the boat starts.
        /// </summary>
        public int BoatX
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the Y coordinate where the boat starts.
        /// </summary>
        public int BoatY
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the map ID where the ship starts.
        /// </summary>
        public int ShipMapID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the X coordinate where the ship starts.
        /// </summary>
        public int ShipX
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the Y coordinate where the ship starts.
        /// </summary>
        public int ShipY
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the map ID where the airship starts.
        /// </summary>
        public int AirshipMapID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the X coordinate where the airship starts.
        /// </summary>
        public int AirshipX
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Gets or sets the Y coordinate where the airship starts.
        /// </summary>
        public int AirshipY
        {
            get;
            set;
        } = 0;
    }
}