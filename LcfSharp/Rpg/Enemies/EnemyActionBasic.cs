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

namespace LcfSharp.Rpg.Enemies
{
    /// <summary>
    /// Enum representing the basic enemy actions.
    /// </summary>
    public enum EnemyActionBasic
    {
        /// <summary>
        /// Basic attack.
        /// </summary>
        Attack = 0,

        /// <summary>
        /// Dual attack.
        /// </summary>
        DualAttack = 1,

        /// <summary>
        /// Defense action.
        /// </summary>
        Defense = 2,

        /// <summary>
        /// Observe action.
        /// </summary>
        Observe = 3,

        /// <summary>
        /// Charge action.
        /// </summary>
        Charge = 4,

        /// <summary>
        /// Autodestruction action.
        /// </summary>
        Autodestruction = 5,

        /// <summary>
        /// Escape action.
        /// </summary>
        Escape = 6,

        /// <summary>
        /// Do nothing action.
        /// </summary>
        Nothing = 7
    }
}
