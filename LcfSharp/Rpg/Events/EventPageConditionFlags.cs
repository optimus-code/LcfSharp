using LcfSharp.IO.Types;

namespace LcfSharp.Rpg.Events
{
    public class EventPageConditionFlags : IDbFlags
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
    }
}