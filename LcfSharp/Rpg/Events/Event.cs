using LcfSharp.IO.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Events
{
    public class Event
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

        public List<EventPage> Pages
        {
            get;
            set;
        } = new List<EventPage>();
    }
}
