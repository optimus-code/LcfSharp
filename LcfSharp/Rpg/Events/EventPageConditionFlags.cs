using LcfSharp.Types;

namespace LcfSharp.Rpg.Events
{
    public class EventPageConditionFlags : DbFlags
    {
        public bool SwitchA
        {
            get;
            set;
        }

        public bool SwitchB
        {
            get;
            set;
        }

        public bool Variable
        {
            get;
            set;
        }

        public bool Item
        {
            get;
            set;
        }

        public bool Actor
        {
            get;
            set;
        }

        public bool Timer
        {
            get;
            set;
        }

        public bool Timer2
        {
            get;
            set;
        }

        public EventPageConditionFlags()
        {
            SwitchA = false;
            SwitchB = false;
            Variable = false;
            Item = false;
            Actor = false;
            Timer = false;
            Timer2 = false;
        }
    }
}
