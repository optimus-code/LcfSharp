using LcfSharp.IO;
using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg.Troops
{
    public enum TroopMemberChunk : int
    {
        EnemyID = 0x01,
        X = 0x02,
        Y = 0x03,
        Invisible = 0x04
    }

    [LcfChunk<TroopMemberChunk>]
    public class TroopMember
    {
        [LcfID]
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
    }
}
