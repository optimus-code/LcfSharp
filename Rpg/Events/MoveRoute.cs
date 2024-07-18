using System.Collections.Generic;

namespace LcfSharp.Rpg.Events
{
    public class MoveRoute
    {
        public List<MoveCommand> Commands
        {
            get;
            set;
        }

        public bool Repeat
        {
            get;
            set;
        } = true;

        public bool Skippable
        {
            get;
            set;
        } = false;
    }
}
