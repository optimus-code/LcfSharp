using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Collections;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Troops
{
    public enum TroopChunk : int
    {
        Name = 0x01,
        Members = 0x02,
        AutoAlignment = 0x03,
        TerrainSetSize = 0x04,
        TerrainSet = 0x05,
        AppearRandomly = 0x06,
        Pages = 0x0B
    }

    [LcfChunk<TroopChunk>]
    public class Troop
    {
        [LcfID]
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

        [LcfAlwaysPersist]
        public List<TroopMember> Members
        {
            get;
            set;
        } = new List<TroopMember>();

        public bool AutoAlignment
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)TroopChunk.TerrainSetSize)]
        public BitArray TerrainSet
        {
            get;
            set;
        }

        public bool AppearRandomly
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public List<TroopPage> Pages
        {
            get;
            set;
        } = [];
    }
}