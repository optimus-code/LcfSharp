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
    /// Enum representing the system fade out options.
    /// </summary>
    public enum GameSystemFadeOut : int
    {
        /// <summary>
        /// Default fade out.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Simple fade out.
        /// </summary>
        FadeOut = 1,

        /// <summary>
        /// Remove blocks fade out.
        /// </summary>
        RemoveBlocks = 2,

        /// <summary>
        /// Wipe downward fade out.
        /// </summary>
        WipeDownward = 3,

        /// <summary>
        /// Wipe upward fade out.
        /// </summary>
        WipeUpward = 4,

        /// <summary>
        /// Venetian blinds fade out.
        /// </summary>
        VenetianBlinds = 5,

        /// <summary>
        /// Vertical blinds fade out.
        /// </summary>
        VerticalBlinds = 6,

        /// <summary>
        /// Horizontal blinds fade out.
        /// </summary>
        HorizontalBlinds = 7,

        /// <summary>
        /// Receding square fade out.
        /// </summary>
        RecedingSquare = 8,

        /// <summary>
        /// Expanding square fade out.
        /// </summary>
        ExpandingSquare = 9,

        /// <summary>
        /// Screen moves up fade out.
        /// </summary>
        ScreenMovesUp = 10,

        /// <summary>
        /// Screen moves down fade out.
        /// </summary>
        ScreenMovesDown = 11,

        /// <summary>
        /// Screen moves left fade out.
        /// </summary>
        ScreenMovesLeft = 12,

        /// <summary>
        /// Screen moves right fade out.
        /// </summary>
        ScreenMovesRight = 13,

        /// <summary>
        /// Vertical division fade out.
        /// </summary>
        VerticalDiv = 14,

        /// <summary>
        /// Horizontal division fade out.
        /// </summary>
        HorizontalDiv = 15,

        /// <summary>
        /// Quadrasection fade out.
        /// </summary>
        Quadrasection = 16,

        /// <summary>
        /// Zoom in fade out.
        /// </summary>
        ZoomIn = 17,

        /// <summary>
        /// Mosaic fade out.
        /// </summary>
        Mosaic = 18,

        /// <summary>
        /// Waver screen fade out.
        /// </summary>
        WaverScreen = 19,

        /// <summary>
        /// Instantaneous fade out.
        /// </summary>
        Instantaneous = 20,

        /// <summary>
        /// No fade out.
        /// </summary>
        None = 21
    }
}