namespace LcfSharp.Rpg.Events
{
    using System.Collections.Generic;

    public enum EventPageConditionComparison
    {
        Equal = 0,
        GreaterEqual = 1,
        LessEqual = 2,
        Greater = 3,
        Less = 4,
        NotEqual = 5
    }

    public class EventPageCondition
    {
        public static readonly Dictionary<EventPageConditionComparison, string> Tags = new Dictionary<EventPageConditionComparison, string>
        {
            { EventPageConditionComparison.Equal, "equal" },
            { EventPageConditionComparison.GreaterEqual, "greater_equal" },
            { EventPageConditionComparison.LessEqual, "less_equal" },
            { EventPageConditionComparison.Greater, "greater" },
            { EventPageConditionComparison.Less, "less" },
            { EventPageConditionComparison.NotEqual, "not_equal" }
        };

        public EventPageConditionFlags Flags { get; set; } = new EventPageConditionFlags();

        public int SwitchAID
        {
            get;
            set;
        } = 1;

        public int SwitchBID
        {
            get;
            set;
        } = 1;

        public int VariableID
        {
            get;
            set;
        } = 1;

        public int VariableValue
        {
            get;
            set;
        }

        public int ItemID
        {
            get;
            set;
        } = 1;

        public int ActorID
        {
            get;
            set;
        } = 1;

        public int TimerSec
        {
            get;
            set;
        }

        public int Timer2Sec
        {
            get;
            set;
        }

        public int CompareOperator
        {
            get;
            set;
        } = 1;
    }
}
