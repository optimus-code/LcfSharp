using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Attributes
{
    public enum AttributeChunk : int
    {
        /** String */
        Name = 0x01,
        /** Integer */
        Type = 0x02,
        /** Integer */
        ARate = 0x0B,
        /** Integer */
        BRate = 0x0C,
        /** Integer */
        CRate = 0x0D,
        /** Integer */
        DRate = 0x0E,
        /** Integer */
        ERate = 0x0F
    }

    public enum AttributeTypes
    {
        Physical = 0,
        Magical = 1
    }

    [LcfChunk<AttributeChunk>]
    public class Attribute
    {

        public static readonly Dictionary<AttributeTypes, string> TypeTags = new Dictionary<AttributeTypes, string>
        {
            { AttributeTypes.Physical, "physical" },
            { AttributeTypes.Magical, "magical" }
        };

        [LcfID]
        public int ID
        {
            get;
            set;
        }
[LcfAlwaysPersistAttribute]
		public DbString Name
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public AttributeTypes Type
        {
            get;
            set;
        }

        public int ARate
        {
            get;
            set;
        }

        public int BRate
        {
            get;
            set;
        }

        public int CRate
        {
            get;
            set;
        }

        public int DRate
        {
            get;
            set;
        }

        public int ERate
        {
            get;
            set;
        }
    }
}