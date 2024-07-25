using LcfSharp.IO.Types;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Troops
{
    public class TroopPageConditionFlags : IDbFlags
    {
        [XmlAttribute]
        public bool SwitchA
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool SwitchB
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool Variable
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool Turn
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool Fatigue
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool EnemyHP
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool ActorHP
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool TurnEnemy
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool TurnActor
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool CommandActor
        {
            get;
            set;
        }
    }
}