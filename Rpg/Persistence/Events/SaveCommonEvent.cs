namespace LcfSharp.Rpg.Persistence.Events
{
    public class SaveCommonEvent
    {
        public int ID
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
