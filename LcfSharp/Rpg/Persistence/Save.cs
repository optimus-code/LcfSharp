using LcfSharp.Rpg.Persistence.Events;
using LcfSharp.Rpg.Persistence.Maps;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Persistence
{
    public class Save
    {
        public SaveTitle Title
        {
            get;
            set;
        }

        public SaveSystem System
        {
            get;
            set;
        }

        public SaveScreen Screen
        {
            get;
            set;
        }

        public List<SavePicture> Pictures
        {
            get;
            set;
        } = new List<SavePicture>();

        public SavePartyLocation PartyLocation
        {
            get;
            set;
        }

        public SaveVehicleLocation BoatLocation
        {
            get;
            set;
        }

        public SaveVehicleLocation ShipLocation
        {
            get;
            set;
        }

        public SaveVehicleLocation AirshipLocation
        {
            get;
            set;
        }

        public List<SaveActor> Actors
        {
            get;
            set;
        } = new List<SaveActor>();

        public SaveInventory Inventory
        {
            get;
            set;
        }

        public List<SaveTarget> Targets
        {
            get;
            set;
        } = new List<SaveTarget>();

        public SaveMapInfo MapInfo
        {
            get;
            set;
        }

        public SavePanorama Panorama
        {
            get;
            set;
        }

        public SaveEventExecState ForegroundEventExecState
        {
            get;
            set;
        }

        public List<SaveCommonEvent> CommonEvents
        {
            get;
            set;
        } = new List<SaveCommonEvent>();
    }
}
