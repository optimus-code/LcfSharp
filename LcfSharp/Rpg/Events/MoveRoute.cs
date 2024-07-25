using System.Collections.Generic;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Events
{
    public class MoveRoute
    {
        public List<MoveCommand> Commands
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool Repeat
        {
            get;
            set;
        } = true;

        [XmlAttribute]
        public bool Skippable
        {
            get;
            set;
        } = false;
    }
}
