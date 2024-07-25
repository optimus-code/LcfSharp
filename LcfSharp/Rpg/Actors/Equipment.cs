using System;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Actors
{
    public class Equipment
    {
        [XmlAttribute]
        public short WeaponID
        {
            get;
            set;
        } = 0;

        [XmlAttribute]
        public short ShieldID
        {
            get;
            set;
        } = 0;

        [XmlAttribute]
        public short ArmorID
        {
            get;
            set;
        } = 0;

        [XmlAttribute]
        public short HelmetID
        {
            get;
            set;
        } = 0;

        [XmlAttribute]
        public short AccessoryID
        {
            get;
            set;
        } = 0;
    }
}