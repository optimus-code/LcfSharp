using LcfSharp.IO;
using LcfSharp.Rpg.Shared;

namespace LcfSharp.Rpg.Troops
{
    public enum TroopMemberChunk : byte
    {
        EnemyId = 0x01,
        X = 0x02,
        Y = 0x03,
        Invisible = 0x04
    }

    public class TroopMember
    {
        public int ID
        {
            get;
            set;
        }

        public int EnemyID
        {
            get;
            set;
        } = 1;

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public bool Invisible
        {
            get;
            set;
        }

        public TroopMember(LcfReader reader)
        {
            TypeHelpers.ReadChunks<TroopMemberChunk>(reader, (chunkID) =>
            {
                switch ((TroopMemberChunk)chunkID)
                {
                    case TroopMemberChunk.EnemyId:
                        EnemyID = reader.ReadInt();
                        return true;

                    case TroopMemberChunk.X:
                        X = reader.ReadInt();
                        return true;

                    case TroopMemberChunk.Y:
                        Y = reader.ReadInt();
                        return true;

                    case TroopMemberChunk.Invisible:
                        Invisible = reader.ReadBool();
                        return true;
                }
                return false;
            });
        }
    }
}
