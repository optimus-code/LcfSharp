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

using LcfSharp.Chunks.Database;
using LcfSharp.IO.Attributes;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Events
{
    public enum CommonEventTrigger : int
    {
        Automatic = 3,
        Parallel = 4,
        Call = 5
    }

    [LcfChunk<CommonEventChunk>]
    public class CommonEvent
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
		public string Name
        {
            get;
            set;
        }

        public CommonEventTrigger Trigger
        {
            get;
            set;
        }

        public bool SwitchFlag
        {
            get;
            set;
        }

        public int SwitchID
        {
            get;
            set;
        } = 1;

        [LcfAlwaysPersist]
        [LcfSize(( int ) CommonEventChunk.EventCommandsSize)]
        public List<EventCommand> EventCommands
        {
            get;
            set;
        } = [];
    }
}