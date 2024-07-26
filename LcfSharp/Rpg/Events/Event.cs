using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Events
{
    public class Event
    {
        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        [XmlAttribute]
        public int X
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Y
        {
            get;
            set;
        }

        public List<EventPage> Pages
        {
            get;
            set;
        } = new List<EventPage>();
    }
}
