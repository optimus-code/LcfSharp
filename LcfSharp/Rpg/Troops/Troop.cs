using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

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
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        [XmlElement("Member")]
        public List<TroopMember> Members
        {
            get;
            set;
        } = new List<TroopMember>();

        [XmlAttribute]
        public bool AutoAlignment
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)TroopChunk.TerrainSetSize)]
        public List<bool> TerrainSet
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool AppearRandomly
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [XmlElement("Page")]
        public List<TroopPage> Pages
        {
            get;
            set;
        } = [];
    }
}