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

using LcfSharp.Rpg.Events;

namespace LcfSharp.Rpg.Persistence.Maps
{
    public class SaveMapEventBase
    {
        public bool Active
        {
            get;
            set;
        } = true;

        public int MapID
        {
            get;
            set;
        }

        public int PositionX
        {
            get;
            set;
        }

        public int PositionY
        {
            get;
            set;
        }

        public int Direction
        {
            get;
            set;
        } = 2;

        public int Facing
        {
            get;
            set;
        } = 2;

        public int AnimFrame
        {
            get;
            set;
        } = 1;

        public int Transparency
        {
            get;
            set;
        }

        public int RemainingStep
        {
            get;
            set;
        }

        public int MoveFrequency
        {
            get;
            set;
        } = 2;

        public int Layer
        {
            get;
            set;
        } = 1;

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

        public bool LockFacing
        {
            get;
            set;
        }

        public int MoveSpeed
        {
            get;
            set;
        } = 4;

        public MoveRoute MoveRoute
        {
            get;
            set;
        }

        public bool MoveRouteOverwrite
        {
            get;
            set;
        }

        public int MoveRouteIndex
        {
            get;
            set;
        }

        public bool MoveRouteFinished
        {
            get;
            set;
        }

        public bool SpriteHidden
        {
            get;
            set;
        }

        public bool MoveRouteThrough
        {
            get;
            set;
        }

        public int AnimPaused
        {
            get;
            set;
        }

        public bool Through
        {
            get;
            set;
        }

        public int StopCount
        {
            get;
            set;
        }

        public int AnimCount
        {
            get;
            set;
        }

        public int MaxStopCount
        {
            get;
            set;
        }

        public bool Jumping
        {
            get;
            set;
        }

        public int BeginJumpX
        {
            get;
            set;
        }

        public int BeginJumpY
        {
            get;
            set;
        }

        public bool Pause
        {
            get;
            set;
        }

        public bool Flying
        {
            get;
            set;
        }

        public string SpriteName
        {
            get;
            set;
        }

        public int SpriteID
        {
            get;
            set;
        }

        public bool Processed
        {
            get;
            set;
        }

        public int FlashRed
        {
            get;
            set;
        } = -1;

        public int FlashGreen
        {
            get;
            set;
        } = -1;

        public int FlashBlue
        {
            get;
            set;
        } = -1;

        public double FlashCurrentLevel
        {
            get;
            set;
        }

        public int FlashTimeLeft
        {
            get;
            set;
        }
    }
}
