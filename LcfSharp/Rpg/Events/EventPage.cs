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

using LcfSharp.IO.Attributes;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Events
{
    public enum EventPageDirection
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    public enum EventPageFrame
    {
        Left = 0,
        Middle = 1,
        Right = 2,
        Middle2 = 3
    }

    public enum EventPageMoveType
    {
        Stationary = 0,
        Random = 1,
        Vertical = 2,
        Horizontal = 3,
        Toward = 4,
        Away = 5,
        Custom = 6
    }

    public enum EventPageTrigger
    {
        Action = 0,
        Touched = 1,
        Collision = 2,
        AutoStart = 3,
        Parallel = 4
    }

    public enum EventPageLayers
    {
        Below = 0,
        Same = 1,
        Above = 2
    }

    public enum EventPageAnimType
    {
        NonContinuous = 0,
        Continuous = 1,
        FixedNonContinuous = 2,
        FixedContinuous = 3,
        FixedGraphic = 4,
        Spin = 5,
        StepFrameFix = 6
    }

    public enum EventPageMoveSpeed
    {
        Eighth = 1,
        Quarter = 2,
        Half = 3,
        Normal = 4,
        Double = 5,
        Fourfold = 6
    }

    public enum EventPageManiacEventInfo
    {
        Action = 0,
        Touched = 1,
        Collision = 2,
        AutoStart = 3,
        Parallel = 4,
        Called = 5,
        BattleStart = 6,
        BattleParallel = 7,
        MapEvent = 16,
        CommonEvent = 32,
        BattleEvent = 64
    }

    public class EventPage
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        public EventPageCondition Condition
        {
            get;
            set;
        }

        public string CharacterName
        {
            get;
            set;
        }

        public int CharacterIndex
        {
            get;
            set;
        }

        public int CharacterDirection
        {
            get;
            set;
        } = 2;

        public int CharacterPattern
        {
            get;
            set;
        } = 1;

        public bool Translucent
        {
            get;
            set;
        }

        public int MoveType
        {
            get;
            set;
        } = 1;

        public int MoveFrequency
        {
            get;
            set;
        } = 3;

        public int Trigger
        {
            get;
            set;
        }

        public int Layer
        {
            get;
            set;
        }

        public bool OverlapForbidden
        {
            get;
            set;
        }

        public int AnimationType
        {
            get;
            set;
        }

        public int MoveSpeed
        {
            get;
            set;
        } = 3;

        public MoveRoute MoveRoute
        {
            get;
            set;
        }

        public List<EventCommand> EventCommands
        {
            get;
            set;
        } = [];
    }
}
