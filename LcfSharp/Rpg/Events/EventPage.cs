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

using LcfSharp.Chunks.Events;
using LcfSharp.IO.Attributes;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Events
{
    /// <summary>
    /// Enum representing the direction of an event page.
    /// </summary>
    public enum EventPageDirection
    {
        /// <summary>
        /// Up direction.
        /// </summary>
        Up = 0,

        /// <summary>
        /// Right direction.
        /// </summary>
        Right = 1,

        /// <summary>
        /// Down direction.
        /// </summary>
        Down = 2,

        /// <summary>
        /// Left direction.
        /// </summary>
        Left = 3
    }

    /// <summary>
    /// Enum representing the frame of an event page.
    /// </summary>
    public enum EventPageFrame
    {
        /// <summary>
        /// Left frame.
        /// </summary>
        Left = 0,

        /// <summary>
        /// Middle frame.
        /// </summary>
        Middle = 1,

        /// <summary>
        /// Right frame.
        /// </summary>
        Right = 2,

        /// <summary>
        /// Secondary middle frame.
        /// </summary>
        Middle2 = 3
    }

    /// <summary>
    /// Enum representing the move type of an event page.
    /// </summary>
    public enum EventPageMoveType
    {
        /// <summary>
        /// Stationary move type.
        /// </summary>
        Stationary = 0,

        /// <summary>
        /// Random move type.
        /// </summary>
        Random = 1,

        /// <summary>
        /// Vertical move type.
        /// </summary>
        Vertical = 2,

        /// <summary>
        /// Horizontal move type.
        /// </summary>
        Horizontal = 3,

        /// <summary>
        /// Move toward target.
        /// </summary>
        Toward = 4,

        /// <summary>
        /// Move away from target.
        /// </summary>
        Away = 5,

        /// <summary>
        /// Custom move type.
        /// </summary>
        Custom = 6
    }

    /// <summary>
    /// Enum representing the trigger of an event page.
    /// </summary>
    public enum EventPageTrigger
    {
        /// <summary>
        /// Triggered by action.
        /// </summary>
        Action = 0,

        /// <summary>
        /// Triggered by being touched.
        /// </summary>
        Touched = 1,

        /// <summary>
        /// Triggered by collision.
        /// </summary>
        Collision = 2,

        /// <summary>
        /// Automatically starts.
        /// </summary>
        AutoStart = 3,

        /// <summary>
        /// Runs in parallel.
        /// </summary>
        Parallel = 4
    }

    /// <summary>
    /// Enum representing the layers of an event page.
    /// </summary>
    public enum EventPageLayers
    {
        /// <summary>
        /// Below layer.
        /// </summary>
        Below = 0,

        /// <summary>
        /// Same layer.
        /// </summary>
        Same = 1,

        /// <summary>
        /// Above layer.
        /// </summary>
        Above = 2
    }

    /// <summary>
    /// Enum representing the animation type of an event page.
    /// </summary>
    public enum EventPageAnimType
    {
        /// <summary>
        /// Non-continuous animation.
        /// </summary>
        NonContinuous = 0,

        /// <summary>
        /// Continuous animation.
        /// </summary>
        Continuous = 1,

        /// <summary>
        /// Fixed non-continuous animation.
        /// </summary>
        FixedNonContinuous = 2,

        /// <summary>
        /// Fixed continuous animation.
        /// </summary>
        FixedContinuous = 3,

        /// <summary>
        /// Fixed graphic animation.
        /// </summary>
        FixedGraphic = 4,

        /// <summary>
        /// Spin animation.
        /// </summary>
        Spin = 5,

        /// <summary>
        /// Step frame fix animation.
        /// </summary>
        StepFrameFix = 6
    }

    /// <summary>
    /// Enum representing the move speed of an event page.
    /// </summary>
    public enum EventPageMoveSpeed
    {
        /// <summary>
        /// Eighth speed.
        /// </summary>
        Eighth = 1,

        /// <summary>
        /// Quarter speed.
        /// </summary>
        Quarter = 2,

        /// <summary>
        /// Half speed.
        /// </summary>
        Half = 3,

        /// <summary>
        /// Normal speed.
        /// </summary>
        Normal = 4,

        /// <summary>
        /// Double speed.
        /// </summary>
        Double = 5,

        /// <summary>
        /// Fourfold speed.
        /// </summary>
        Fourfold = 6
    }

    /// <summary>
    /// Class representing an event page in the game.
    /// </summary>
    [LcfChunk<EventPageChunk>]
    public class EventPage
    {
        /// <summary>
        /// The unique identifier for the event page.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The condition of the event page.
        /// </summary>
        public EventPageCondition Condition
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the character graphic.
        /// </summary>
        public string CharacterName
        {
            get;
            set;
        }

        /// <summary>
        /// The index of the character graphic.
        /// </summary>
        public int CharacterIndex
        {
            get;
            set;
        }

        /// <summary>
        /// The direction of the character graphic. Default is 2 (down).
        /// </summary>
        public EventPageDirection CharacterDirection
        {
            get;
            set;
        } = EventPageDirection.Down;

        /// <summary>
        /// The pattern of the character graphic. Default is 1 (middle).
        /// </summary>
        public int CharacterPattern
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// Indicates whether the character is translucent.
        /// </summary>
        public bool Translucent
        {
            get;
            set;
        }

        /// <summary>
        /// The move type of the event page. Default is 1 (random).
        /// </summary>
        public EventPageMoveType MoveType
        {
            get;
            set;
        } = EventPageMoveType.Random;

        /// <summary>
        /// The move frequency of the event page. Default is 3.
        /// </summary>
        public EventPageMoveSpeed MoveFrequency
        {
            get;
            set;
        } = EventPageMoveSpeed.Half;

        /// <summary>
        /// The trigger of the event page.
        /// </summary>
        public EventPageTrigger Trigger
        {
            get;
            set;
        }

        /// <summary>
        /// The layer of the event page.
        /// </summary>
        public EventPageLayers Layer
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether overlapping is forbidden.
        /// </summary>
        public bool OverlapForbidden
        {
            get;
            set;
        }

        /// <summary>
        /// The animation type of the event page.
        /// </summary>
        public EventPageAnimType AnimationType
        {
            get;
            set;
        }

        /// <summary>
        /// The move speed of the event page. Default is 3 (half speed).
        /// </summary>
        public EventPageMoveSpeed MoveSpeed
        {
            get;
            set;
        } = EventPageMoveSpeed.Half;

        /// <summary>
        /// The move route of the event page.
        /// </summary>
        public MoveRoute MoveRoute
        {
            get;
            set;
        }

        /// <summary>
        /// The list of event commands associated with the event page.
        /// </summary>
        public List<EventCommand> EventCommands
        {
            get;
            set;
        } = [];
    }
}