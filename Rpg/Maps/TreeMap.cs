using System.Collections.Generic;

namespace LcfSharp.Rpg.Maps
{
    public enum TreeMapMapType
    {
        Root = 0,
        Map = 1,
        Area = 2
    }

    public class TreeMap
    {
        public static readonly Dictionary<TreeMapMapType, string> MapTypeTags = new Dictionary<TreeMapMapType, string>
        {
            { TreeMapMapType.Root, "root" },
            { TreeMapMapType.Map, "map" },
            { TreeMapMapType.Area, "area" }
        };

        public string LmtHeader
        {
            get;
            set;
        }

        public List<MapInfo> Maps
        {
            get;
            set;
        } = new List<MapInfo>();

        public List<int> TreeOrder
        {
            get;
            set;
        } = new List<int>();

        public int ActiveNode
        {
            get;
            set;
        } = 0;

        public Start Start
        {
            get;
            set;
        } = new Start();
    }
}