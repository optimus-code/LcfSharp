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
namespace LcfSharp.Rpg.GameSystems
{
    /// <summary>
    /// Enum representing the system fade in options.
    /// </summary>
    public enum GameSystemFadeIn : int
    {
        /// <summary>
        /// Default fade in.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Simple fade in.
        /// </summary>
        FadeIn = 1,

        /// <summary>
        /// Reconstitute blocks fade in.
        /// </summary>
        ReconstituteBlocks = 2,

        /// <summary>
        /// Unwipe downward fade in.
        /// </summary>
        UnwipeDownward = 3,

        /// <summary>
        /// Unwipe upward fade in.
        /// </summary>
        UnwipeUpward = 4,

        /// <summary>
        /// Venetian blinds fade in.
        /// </summary>
        VenetianBlinds = 5,

        /// <summary>
        /// Vertical blinds fade in.
        /// </summary>
        VerticalBlinds = 6,

        /// <summary>
        /// Horizontal blinds fade in.
        /// </summary>
        HorizontalBlinds = 7,

        /// <summary>
        /// Receding square fade in.
        /// </summary>
        RecedingSquare = 8,

        /// <summary>
        /// Expanding square fade in.
        /// </summary>
        ExpandingSquare = 9,

        /// <summary>
        /// Screen moves down fade in.
        /// </summary>
        ScreenMovesDown = 10,

        /// <summary>
        /// Screen moves up fade in.
        /// </summary>
        ScreenMovesUp = 11,

        /// <summary>
        /// Screen moves right fade in.
        /// </summary>
        ScreenMovesRight = 12,

        /// <summary>
        /// Screen moves left fade in.
        /// </summary>
        ScreenMovesLeft = 13,

        /// <summary>
        /// Vertical unify fade in.
        /// </summary>
        VerticalUnify = 14,

        /// <summary>
        /// Horizontal unify fade in.
        /// </summary>
        HorizontalUnify = 15,

        /// <summary>
        /// Unify quadrants fade in.
        /// </summary>
        UnifyQuadrants = 16,

        /// <summary>
        /// Zoom out fade in.
        /// </summary>
        ZoomOut = 17,

        /// <summary>
        /// Mosaic fade in.
        /// </summary>
        Mosaic = 18,

        /// <summary>
        /// Waver screen fade in.
        /// </summary>
        WaverScreen = 19,

        /// <summary>
        /// Instantaneous fade in.
        /// </summary>
        Instantaneous = 20,

        /// <summary>
        /// No fade in.
        /// </summary>
        None = 21
    }
}