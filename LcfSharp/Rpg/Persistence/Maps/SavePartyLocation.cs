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

namespace LcfSharp.Rpg.Persistence.Maps
{
    public enum SavePartyLocationVehicleType
    {
        None = 0,
        Skiff = 1,
        Ship = 2,
        Airship = 3
    }

    public enum SavePartyLocationPanState
    {
        Fixed = 0,
        Follow = 1
    }

    public class SavePartyLocation : SaveMapEventBase
    {
        // Equal to 9 tiles in 1/16th pixels
        public const int PanXDefault = 9 * 256;
        // Equal to 7 tiles in 1/16th pixels
        public const int PanYDefault = 7 * 256;
        // Frame speed in 1/16th pixels
        public const int PanSpeedDefault = 2 << 3;

        public bool Boarding
        {
            get;
            set;
        }

        public bool Aboard
        {
            get;
            set;
        }

        public int Vehicle
        {
            get;
            set;
        }

        public bool Unboarding
        {
            get;
            set;
        }

        public int PreboardMoveSpeed
        {
            get;
            set;
        } = 4;

        public bool MenuCalling
        {
            get;
            set;
        }

        public int PanState
        {
            get;
            set;
        } = 1;

        public int PanCurrentX
        {
            get;
            set;
        } = PanXDefault;

        public int PanCurrentY
        {
            get;
            set;
        } = PanYDefault;

        public int PanFinishX
        {
            get;
            set;
        } = PanXDefault;

        public int PanFinishY
        {
            get;
            set;
        } = PanYDefault;

        public int PanSpeed
        {
            get;
            set;
        } = PanSpeedDefault;

        public int TotalEncounterRate
        {
            get;
            set;
        }

        public bool EncounterCalling
        {
            get;
            set;
        }

        public int MapSaveCount
        {
            get;
            set;
        }

        public int DatabaseSaveCount
        {
            get;
            set;
        }
    }
}
