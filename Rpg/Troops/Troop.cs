using LcfSharp.IO;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Troops
{
    public enum TroopChunk : byte
    {
        Name = 0x01,
        Members = 0x02,
        AutoAlignment = 0x03,
        TerrainSetSize = 0x04,
        TerrainSet = 0x05,
        AppearRandomly = 0x06,
        Pages = 0x0B
    }

    public class Troop
    {
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

        public DbBitArray TerrainSet
        {
            get;
            set;
        }

        public bool AppearRandomly
        {
            get;
            set;
        }

        public List<TroopPage> Pages
        {
            get;
            set;
        } = new List<TroopPage>();

        public Troop(LcfReader reader)
        {
            int eventCommandsCount = 0;

            TypeHelpers.ReadChunks<TroopChunk>(reader, (chunk) =>
            {
                switch ((TroopChunk)chunk.ID)
                {
                    case TroopChunk.Name:
                        Name = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case TroopChunk.Members:
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Members.Add(new TroopMember(reader));
                        });
                        return true;

                    case TroopChunk.EventCommandsSize:
                        eventCommandsCount = reader.ReadInt();
                        return true;

                    case TroopChunk.EventCommands:
                        if (eventCommandsCount > 0)
                        {
                            for ( var i = 0; i < eventCommandsCount; i++)
                            {
                                EventCommands.Add(new EventCommand(reader));
                            }
                            return true;
                        }
                        break;
                }
                return false;
            });
        }
    }
}
