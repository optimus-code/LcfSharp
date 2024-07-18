using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Events
{
    public enum CommonEventTrigger
    {
        Automatic = 3,
        Parallel = 4,
        Call = 5
    }

    public class CommonEvent
    {
        public static readonly Dictionary<CommonEventTrigger, string> Tags = new Dictionary<CommonEventTrigger, string>
        {
            { CommonEventTrigger.Automatic, "automatic" },
            { CommonEventTrigger.Parallel, "parallel" },
            { CommonEventTrigger.Call, "call" }
        };

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

        public int Trigger
        {
            get;
            set;
        }

        public bool SwitchFlag
        {
            get;
            set;
        }

        public int SwitchID
        {
            get;
            set;
        } = 1;

        public List<EventCommand> EventCommands
        {
            get;
            set;
        } = new List<EventCommand>();
    }
}
