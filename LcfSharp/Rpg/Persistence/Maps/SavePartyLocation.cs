using System.Collections.Generic;

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
        public static readonly Dictionary<SavePartyLocationVehicleType, string> VehicleTypeTags = new Dictionary<SavePartyLocationVehicleType, string>
        {
            { SavePartyLocationVehicleType.None, "none" },
            { SavePartyLocationVehicleType.Skiff, "skiff" },
            { SavePartyLocationVehicleType.Ship, "ship" },
            { SavePartyLocationVehicleType.Airship, "airship" }
        };

        public static readonly Dictionary<SavePartyLocationPanState, string> PanStateTags = new Dictionary<SavePartyLocationPanState, string>
        {
            { SavePartyLocationPanState.Fixed, "fixed" },
            { SavePartyLocationPanState.Follow, "follow" }
        };

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
