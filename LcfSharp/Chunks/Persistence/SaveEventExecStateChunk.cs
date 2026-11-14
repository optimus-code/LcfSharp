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

namespace LcfSharp.Chunks.Persistence
{
    public enum SaveEventExecStateChunk : int
    {
        Stack = 0x01,
        ShowMessage = 0x04,
        AbortOnEscape = 0x0B,
        WaitMovement = 0x0D,
        KeyInputWait = 0x15,
        KeyInputVariable = 0x16,
        KeyInputAllDirections = 0x17,
        KeyInputDecision = 0x18,
        KeyInputCancel = 0x19,
        KeyInput2kShift2k3Numbers = 0x1A,
        KeyInput2kDown2k3Operators = 0x1B,
        KeyInput2kLeft2k3Shift = 0x1C,
        KeyInput2kRight = 0x1D,
        KeyInput2kUp = 0x1E,
        WaitTime = 0x1F,
        KeyInputTimeVariable = 0x20,
        KeyInput2k3Down = 0x23,
        KeyInput2k3Left = 0x24,
        KeyInput2k3Right = 0x25,
        KeyInput2k3Up = 0x26,
        KeyInputTimed = 0x29,
        WaitKeyEnter = 0x2A
    }
}