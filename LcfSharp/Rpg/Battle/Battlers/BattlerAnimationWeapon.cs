using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationWeaponChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        WeaponName = 0x02,
        /** Integer */
        WeaponIndex = 0x03
    }

    [LcfChunk<BattlerAnimationWeaponChunk>]
    public class BattlerAnimationWeapon
    {
        [LcfID]
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
    }
}