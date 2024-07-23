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
