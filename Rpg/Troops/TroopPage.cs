using LcfSharp.Rpg.Events;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Troops
{
    public class TroopPage
    {
        public int ID
        {
            get;
            set;
        }

        public TroopPageCondition Condition
        {
            get;
            set;
        }

        public List<EventCommand> EventCommands
        {
            get;
            set;
        }
    }
}
