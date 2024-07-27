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

namespace LcfSharp.Rpg.Persistence.Events
{
    public class SaveEventExecState
    {
        public List<SaveEventExecFrame> Stack
        {
            get;
            set;
        } = [];

        public bool ShowMessage
        {
            get;
            set;
        }

        public bool AbortOnEscape
        {
            get;
            set;
        }

        public bool WaitMovement
        {
            get;
            set;
        }

        public bool KeyinputWait
        {
            get;
            set;
        }

        public byte KeyinputVariable
        {
            get;
            set;
        }

        public bool KeyinputAllDirections
        {
            get;
            set;
        }

        public int KeyinputDecision
        {
            get;
            set;
        }

        public int KeyinputCancel
        {
            get;
            set;
        }

        public int Keyinput2kShift2k3Numbers
        {
            get;
            set;
        }

        public int Keyinput2kDown2k3Operators
        {
            get;
            set;
        }

        public int Keyinput2kLeft2k3Shift
        {
            get;
            set;
        }

        public int Keyinput2kRight
        {
            get;
            set;
        }

        public int Keyinput2kUp
        {
            get;
            set;
        }

        public int WaitTime
        {
            get;
            set;
        }

        public int KeyinputTimeVariable
        {
            get;
            set;
        }

        public int Keyinput2k3Down
        {
            get;
            set;
        }

        public int Keyinput2k3Left
        {
            get;
            set;
        }

        public int Keyinput2k3Right
        {
            get;
            set;
        }

        public int Keyinput2k3Up
        {
            get;
            set;
        }

        public bool KeyinputTimed
        {
            get;
            set;
        }

        public bool WaitKeyEnter
        {
            get;
            set;
        }
    }
}
