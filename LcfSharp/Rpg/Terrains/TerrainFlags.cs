using LcfSharp.IO.Types;

namespace LcfSharp.Rpg.Terrains
{
    public class TerrainFlags : IDbFlags
    {
        public bool BackParty
        {
            get;
            set;
        }

        public bool BackEnemies
        {
            get;
            set;
        }

        public bool LateralParty
        {
            get;
            set;
        }

        public bool LateralEnemies
        {
            get;
            set;
        }
    }
}