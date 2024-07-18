using System.Collections.Generic;

namespace LcfSharp.Rpg.Persistence
{
    public class SaveInventory
    {
        public List<short> Party
        {
            get;
            set;
        } = new List<short>();

        public List<short> ItemIDs
        {
            get;
            set;
        } = new List<short>();

        public List<byte> ItemCounts
        {
            get;
            set;
        } = new List<byte>();

        public List<byte> ItemUsage
        {
            get;
            set;
        } = new List<byte>();

        public int Gold
        {
            get;
            set;
        }

        public int Timer1Frames
        {
            get;
            set;
        }

        public bool Timer1Active
        {
            get;
            set;
        }

        public bool Timer1Visible
        {
            get;
            set;
        }

        public bool Timer1Battle
        {
            get;
            set;
        }

        public int Timer2Frames
        {
            get;
            set;
        }

        public bool Timer2Active
        {
            get;
            set;
        }

        public bool Timer2Visible
        {
            get;
            set;
        }

        public bool Timer2Battle
        {
            get;
            set;
        }

        public int Battles
        {
            get;
            set;
        }

        public int Defeats
        {
            get;
            set;
        }

        public int Escapes
        {
            get;
            set;
        }

        public int Victories
        {
            get;
            set;
        }

        public int Turns
        {
            get;
            set;
        }

        public int Steps
        {
            get;
            set;
        }
    }
}
