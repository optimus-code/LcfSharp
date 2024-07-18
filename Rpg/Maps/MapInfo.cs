
using LcfSharp.Rpg.Audio;
using LcfSharp.Rpg.Shared;
using LcfSharp.Rpg.Troops;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Maps
{
    public enum MapInfoMusicType
    {
        Parent = 0,
        Event = 1,
        Specific = 2
    }

    public enum MapInfoBGMType
    {
        Parent = 0,
        Terrain = 1,
        Specific = 2
    }

    public enum MapInfoTriState
    {
        Parent = 0,
        Allow = 1,
        Forbid = 2
    }

    public class MapInfo
    {
        public static readonly Dictionary<MapInfoMusicType, string> MusicTypeTags = new Dictionary<MapInfoMusicType, string>
        {
            { MapInfoMusicType.Parent, "parent" },
            { MapInfoMusicType.Event, "event" },
            { MapInfoMusicType.Specific, "specific" }
        };

        public static readonly Dictionary<MapInfoBGMType, string> BGMTypeTags = new Dictionary<MapInfoBGMType, string>
        {
            { MapInfoBGMType.Parent, "parent" },
            { MapInfoBGMType.Terrain, "terrain" },
            { MapInfoBGMType.Specific, "specific" }
        };

        public static readonly Dictionary<MapInfoTriState, string> TriStateTags = new Dictionary<MapInfoTriState, string>
        {
            { MapInfoTriState.Parent, "parent" },
            { MapInfoTriState.Allow, "allow" },
            { MapInfoTriState.Forbid, "forbid" }
        };

        public int ID
        {
            get;
            set;
        }

        public DbString Name
        {
            get;
            set;
        }

        public int ParentMap
        {
            get;
            set;
        }

        public int Indentation
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        } = -1;

        public int ScrollbarX
        {
            get;
            set;
        }

        public int ScrollbarY
        {
            get;
            set;
        }

        public bool ExpandedNode
        {
            get;
            set;
        }

        public int MusicType
        {
            get;
            set;
        }

        public Music Music
        {
            get;
            set;
        }

        public int BackgroundType
        {
            get;
            set;
        }

        public DbString BackgroundName
        {
            get;
            set;
        }

        public int Teleport
        {
            get;
            set;
        }

        public int Escape
        {
            get;
            set;
        }

        public int Save
        {
            get;
            set;
        }

        public List<Encounter> Encounters
        {
            get;
            set;
        } = new List<Encounter>();

        public int EncounterSteps
        {
            get;
            set;
        } = 25;

        public Rect AreaRect
        {
            get;
            set;
        }
    }
}
