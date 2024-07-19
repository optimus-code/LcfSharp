using LcfSharp.IO;
using LcfSharp.Rpg.Battle;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Chipsets
{
    public enum ChipsetChunk : byte
    {
        Name = 0x01,
        ChipsetName = 0x02,
        TerrainData = 0x03,
        PassableDataLower = 0x04,
        PassableDataUpper = 0x05,
        AnimationType = 0x0B,
        AnimationSpeed = 0x0C
    }

    public enum ChipsetAnimType
    {
        Reciprocating = 0,
        Cyclic = 1
    }

    public class Chipset
    {
        public static readonly Dictionary<ChipsetAnimType, string> Tags = new Dictionary<ChipsetAnimType, string>
        {
            { ChipsetAnimType.Reciprocating, "reciprocating" },
            { ChipsetAnimType.Cyclic, "cyclic" }
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

        public DbString ChipsetName
        {
            get;
            set;
        }

        public List<short> TerrainData
        {
            get;
            set;
        } = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1];

        public List<byte> PassableDataLower
        {
            get;
            set;
        } = [15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15];

        public List<byte> PassableDataUpper
        {
            get;
            set;
        } = [31, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15];

        public int AnimationType
        {
            get;
            set;
        }

        public int AnimationSpeed
        {
            get;
            set;
        }
        public Chipset(LcfReader reader)
        {
            TypeHelpers.ReadChunks<ChipsetChunk>(reader, (chunkID) =>
            {
                switch ((ChipsetChunk)chunkID)
                {
                    case ChipsetChunk.Name:
                        Name = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case ChipsetChunk.ChipsetName:
                        ChipsetName = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case ChipsetChunk.TerrainData:
                        TerrainData = reader.ReadShortList(reader.ReadInt());
                        return true;

                    case ChipsetChunk.PassableDataLower:
                        PassableDataLower = reader.ReadByteList(reader.ReadInt());
                        return true;

                    case ChipsetChunk.PassableDataUpper:
                        PassableDataUpper = reader.ReadByteList(reader.ReadInt());
                        return true;

                    case ChipsetChunk.AnimationType:
                        AnimationType = reader.ReadInt();
                        return true;

                    case ChipsetChunk.AnimationSpeed:
                        AnimationSpeed = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}
