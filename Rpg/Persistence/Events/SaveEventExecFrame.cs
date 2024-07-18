using LcfSharp.Rpg.Events;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Persistence.Events
{
    public class SaveEventExecFrame
    {
        public int ID
        {
            get;
            set;
        }

        public List<EventCommand> Commands
        {
            get;
            set;
        } = new List<EventCommand>();

        public int CurrentCommand
        {
            get;
            set;
        }

        public int EventID
        {
            get;
            set;
        }

        public bool TriggeredByDecisionKey
        {
            get;
            set;
        }

        public List<byte> SubcommandPath
        {
            get;
            set;
        } = new List<byte>();

        public int ManiacEventInfo
        {
            get;
            set;
        }

        public int ManiacEventID
        {
            get;
            set;
        }

        public int ManiacEventPageID
        {
            get;
            set;
        }

        public int ManiacLoopInfoSize
        {
            get;
            set;
        }

        public List<int> ManiacLoopInfo
        {
            get;
            set;
        } = new List<int>();
    }
}
