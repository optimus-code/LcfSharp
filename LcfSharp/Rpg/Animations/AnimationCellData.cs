using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Animations
{
    public enum AnimationCellDataChunk : int
    {
        /** Bool */
        Valid = 0x01,
        /** Integer */
        CellID = 0x02,
        /** Integer */
        X = 0x03,
        /** Integer */
        Y = 0x04,
        /** Integer */
        Zoom = 0x05,
        /** Integer */
        ToneRed = 0x06,
        /** Integer */
        ToneGreen = 0x07,
        /** Integer */
        ToneBlue = 0x08,
        /** Integer */
        ToneGray = 0x09,
        /** Integer */
        Transparency = 0x0A
    }

    [LcfChunk<AnimationCellDataChunk>]
    public class AnimationCellData
    {
        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Valid
        {
            get;
            set;
        }

        [XmlAttribute]
        public int CellID
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

        [XmlAttribute]
        public int Zoom
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ToneRed
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ToneGreen
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ToneBlue
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ToneGray
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Transparency
        {
            get;
            set;
        }
    }
}
