using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using LcfSharp.Rpg.Skills;
using LcfSharp.Types;
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

        public Attribute(LcfReader reader)
        {
            TypeHelpers.ReadChunks<AttributeChunk>(reader, (chunk) =>
            {
                switch ((AttributeChunk)chunk.ID)
                {
                    case AttributeChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;

                    case AttributeChunk.Type:
                        AttributeType = (AttributeTypes)reader.ReadInt();
                        return true;

                    case AttributeChunk.ARate:
                        ARate = reader.ReadInt();
                        return true;

                    case AttributeChunk.BRate:
                        BRate = reader.ReadInt();
                        return true;

                    case AttributeChunk.CRate:
                        CRate = reader.ReadInt();
                        return true;

                    case AttributeChunk.DRate:
                        DRate = reader.ReadInt();
                        return true;

                    case AttributeChunk.ERate:
                        ERate = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}
