using System.Collections.Generic;
using LcfSharp.Rpg.Events;
using LcfSharp.Types;

namespace LcfSharp.Rpg.Maps
{
    public enum MapScrollType
    {
        None = 0,
        Vertical = 1,
        Horizontal = 2,
        Both = 3
    }

    public enum MapGeneratorMode
    {
        SinglePassage = 0,
        LinkedRooms = 1,
        MazePassage = 2,
        OpenRoom = 3
    }

    public enum MapGeneratorTiles
    {
        One = 0,
        Two = 1
    }

    public class Map
    {
        public static readonly Dictionary<MapScrollType, string> ScrollTypeTags = new Dictionary<MapScrollType, string>
        {
            { MapScrollType.None, "none" },
            { MapScrollType.Vertical, "vertical" },
            { MapScrollType.Horizontal, "horizontal" },
            { MapScrollType.Both, "both" }
        };

        public static readonly Dictionary<MapGeneratorMode, string> GeneratorModeTags = new Dictionary<MapGeneratorMode, string>
        {
            { MapGeneratorMode.SinglePassage, "single_passage" },
            { MapGeneratorMode.LinkedRooms, "linked_rooms" },
            { MapGeneratorMode.MazePassage, "maze_passage" },
            { MapGeneratorMode.OpenRoom, "open_room" }
        };

        public static readonly Dictionary<MapGeneratorTiles, string> GeneratorTilesTags = new Dictionary<MapGeneratorTiles, string>
        {
            { MapGeneratorTiles.One, "one" },
            { MapGeneratorTiles.Two, "two" }
        };

        public string LmuHeader
        {
            get;
            set;
        }

        public int ChipsetID
        {
            get;
            set;
        } = 1;

        public int Width
        {
            get;
            set;
        } = 20;

        public int Height
        {
            get;
            set;
        } = 15;

        public int ScrollType
        {
            get;
            set;
        }

        public bool ParallaxFlag
        {
            get;
            set;
        }

        public DbString ParallaxName
        {
            get;
            set;
        }

        public bool ParallaxLoopX
        {
            get;
            set;
        }

        public bool ParallaxLoopY
        {
            get;
            set;
        }

        public bool ParallaxAutoLoopX
        {
            get;
            set;
        }

        public int ParallaxSx
        {
            get;
            set;
        }

        public bool ParallaxAutoLoopY
        {
            get;
            set;
        }

        public int ParallaxSy
        {
            get;
            set;
        }

        public bool GeneratorFlag
        {
            get;
            set;
        }

        public int GeneratorMode
        {
            get;
            set;
        }

        public bool TopLevel
        {
            get;
            set;
        }

        public int GeneratorTiles
        {
            get;
            set;
        }

        public int GeneratorWidth
        {
            get;
            set;
        } = 4;

        public int GeneratorHeight
        {
            get;
            set;
        } = 1;

        public bool GeneratorSurround
        {
            get;
            set;
        } = true;

        public bool GeneratorUpperWall
        {
            get;
            set;
        } = true;

        public bool GeneratorFloorB
        {
            get;
            set;
        } = true;

        public bool GeneratorFloorC
        {
            get;
            set;
        } = true;

        public bool GeneratorExtraB
        {
            get;
            set;
        } = true;

        public bool GeneratorExtraC
        {
            get;
            set;
        } = true;

        public List<uint> GeneratorX
        {
            get;
            set;
        } = new List<uint>();

        public List<uint> GeneratorY
        {
            get;
            set;
        } = new List<uint>();

        public List<short> GeneratorTileIDs
        {
            get;
            set;
        } = new List<short>();

        public List<short> LowerLayer
        {
            get;
            set;
        } = new List<short>();

        public List<short> UpperLayer
        {
            get;
            set;
        } = new List<short>();

        public List<Event> Events
        {
            get;
            set;
        } = new List<Event>();

        public int SaveCount2k3e
        {
            get;
            set;
        }

        public int SaveCount
        {
            get;
            set;
        }
    }
}