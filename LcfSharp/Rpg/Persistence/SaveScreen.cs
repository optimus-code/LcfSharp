namespace LcfSharp.Rpg.Persistence
{
    public class SaveScreen
    {
        public int TintFinishRed
        {
            get;
            set;
        } = 100;

        public int TintFinishGreen
        {
            get;
            set;
        } = 100;

        public int TintFinishBlue
        {
            get;
            set;
        } = 100;

        public int TintFinishSat
        {
            get;
            set;
        } = 100;

        public double TintCurrentRed
        {
            get;
            set;
        } = 100.0;

        public double TintCurrentGreen
        {
            get;
            set;
        } = 100.0;

        public double TintCurrentBlue
        {
            get;
            set;
        } = 100.0;

        public double TintCurrentSat
        {
            get;
            set;
        } = 100.0;

        public int TintTimeLeft
        {
            get;
            set;
        }

        public bool FlashContinuous
        {
            get;
            set;
        }

        public int FlashRed
        {
            get;
            set;
        }

        public int FlashGreen
        {
            get;
            set;
        }

        public int FlashBlue
        {
            get;
            set;
        }

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

        public bool ShakeContinuous
        {
            get;
            set;
        }

        public int ShakeStrength
        {
            get;
            set;
        }

        public int ShakeSpeed
        {
            get;
            set;
        }

        public int ShakePosition
        {
            get;
            set;
        }

        public int ShakePositionY
        {
            get;
            set;
        }

        public int ShakeTimeLeft
        {
            get;
            set;
        }

        public int PanX
        {
            get;
            set;
        }

        public int PanY
        {
            get;
            set;
        }

        public int BattleAnimID
        {
            get;
            set;
        }

        public int BattleAnimTarget
        {
            get;
            set;
        }

        public int BattleAnimFrame
        {
            get;
            set;
        }

        public bool BattleAnimActive
        {
            get;
            set;
        }

        public bool BattleAnimGlobal
        {
            get;
            set;
        }

        public int Weather
        {
            get;
            set;
        }

        public int WeatherStrength
        {
            get;
            set;
        }
    }
}
