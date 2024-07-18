using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Attributes
{
    public enum AttributeTypes
    {
        Physical = 0,
        Magical = 1
    }

    public class Attribute
    {

        public static readonly Dictionary<AttributeTypes, string> TypeTags = new Dictionary<AttributeTypes, string>
        {
            { AttributeTypes.Physical, "physical" },
            { AttributeTypes.Magical, "magical" }
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

        public AttributeTypes AttributeType
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
