using LcfSharp.Rpg.Persistence.Events;

namespace LcfSharp.Rpg.Persistence.Maps
{
    public class SaveMapEvent : SaveMapEventBase
    {
        public int ID
        {
            get;
            set;
        }

        public bool WaitingExecution
        {
            get;
            set;
        }

        public int OriginalMoveRouteIndex
        {
            get;
            set;
        }

        public bool TriggeredByDecisionKey
        {
            get;
            set;
        }

        public SaveEventExecState ParallelEventExecState
        {
            get;
            set;
        }
    }
}
