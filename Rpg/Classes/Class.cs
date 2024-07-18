using LcfSharp.Rpg.Shared;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Classes
{
    public class Class
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

        public bool TwoWeapon
        {
            get;
            set;
        }

        public bool LockEquipment
        {
            get;
            set;
        }

        public bool AutoBattle
        {
            get;
            set;
        }

        public bool SuperGuard
        {
            get;
            set;
        }

        public Parameters Parameters
        {
            get;
            set;
        }

        public int ExpBase
        {
            get;
            set;
        }

        public int ExpInflation
        {
            get;
            set;
        }

        public int ExpCorrection
        {
            get;
            set;
        }

        public int BattlerAnimation
        {
            get;
            set;
        }

        public List<Learning> Skills
        {
            get;
            set;
        }

        public List<byte> StateRanks
        {
            get;
            set;
        }

        public List<byte> AttributeRanks
        {
            get;
            set;
        }

        public List<int> BattleCommands
        {
            get;
            set;
        }
    }
}
