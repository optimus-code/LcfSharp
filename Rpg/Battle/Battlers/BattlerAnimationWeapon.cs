using LcfSharp.Types;

namespace LcfSharp.Rpg.Battle.Battlers
{
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
    }
}
