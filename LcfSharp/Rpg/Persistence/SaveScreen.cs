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
