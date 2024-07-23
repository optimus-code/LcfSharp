using LcfSharp.IO;
using LcfSharp.Rpg.Battle;
using LcfSharp.Types;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LcfSharp.Rpg.Chipsets
{
    public enum ChipsetChunk : int
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
            TypeHelpers.ReadChunks<ChipsetChunk>(reader, (chunk) =>
            {
                switch ((ChipsetChunk)chunk.ID)
                {
                    case ChipsetChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;

                    case ChipsetChunk.ChipsetName:
                        ChipsetName = reader.ReadDbString(chunk.Length);
                        return true;

                    case ChipsetChunk.TerrainData:
                        TerrainData = TypeHelpers.ReadChunkShortList(reader, chunk.Length);
                        return true;

                    case ChipsetChunk.PassableDataLower:
                        PassableDataLower = TypeHelpers.ReadChunkByteList(reader, chunk.Length);
                        return true;

                    case ChipsetChunk.PassableDataUpper:
                        PassableDataUpper = TypeHelpers.ReadChunkByteList(reader, chunk.Length);
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
