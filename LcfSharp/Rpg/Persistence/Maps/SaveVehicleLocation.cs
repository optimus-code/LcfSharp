using System.Collections.Generic;

namespace LcfSharp.Rpg.Persistence.Maps
{
    public enum SaveVehicleLocationVehicleType
    {
        None = 0,
        Skiff = 1,
        Ship = 2,
        Airship = 3
    }

    public class SaveVehicleLocation : SaveMapEventBase
    {
        public static readonly Dictionary<SaveVehicleLocationVehicleType, string> VehicleTypeTags = new Dictionary<SaveVehicleLocationVehicleType, string>
        {
            { SaveVehicleLocationVehicleType.None, "none" },
            { SaveVehicleLocationVehicleType.Skiff, "skiff" },
            { SaveVehicleLocationVehicleType.Ship, "ship" },
            { SaveVehicleLocationVehicleType.Airship, "airship" }
        };

        public int Vehicle
        {
            get;
            set;
        }

        public int RemainingAscent
        {
            get;
            set;
        }

        public int RemainingDescent
        {
            get;
            set;
        }

        public string OrigSpriteName
        {
            get;
            set;
        }

        public int OrigSpriteID
        {
            get;
            set;
        }
    }
}
