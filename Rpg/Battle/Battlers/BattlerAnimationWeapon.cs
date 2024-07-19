using LcfSharp.IO;
using LcfSharp.Types;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationWeaponChunk : byte
    {
        /** String */
        Name = 0x01,
        /** String */
        WeaponName = 0x02,
        /** Integer */
        WeaponIndex = 0x03
    }

    public class BattlerAnimationWeapon
    {
        public int ID
        {
            get;
            set;
        } = 0;

        public DbString Name
        {
            get;
            set;
        }

        public DbString WeaponName
        {
            get;
            set;
        }

        public int WeaponIndex
        {
            get;
            set;
        } = 0;

        public BattlerAnimationWeapon(LcfReader reader)
        {
            TypeHelpers.ReadChunks<BattlerAnimationWeaponChunk>(reader, (chunkID) =>
            {
                switch ((BattlerAnimationWeaponChunk)chunkID)
                {
                    case BattlerAnimationWeaponChunk.Name:
                        Name = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case BattlerAnimationWeaponChunk.WeaponName:
                        WeaponName = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case BattlerAnimationWeaponChunk.WeaponIndex:
                        WeaponIndex = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}