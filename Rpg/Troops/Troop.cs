using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Troops
{
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
    }
}
