using LcfSharp.IO;
using LcfSharp.IO.Attributes;

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
        public int ID
        {
            get;
            set;
        }

        public int Valid
        {
            get;
            set;
        }

        public int CellID
        {
            get;
            set;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int Zoom
        {
            get;
            set;
        }

        public int ToneRed
        {
            get;
            set;
        }

        public int ToneGreen
        {
            get;
            set;
        }

        public int ToneBlue
        {
            get;
            set;
        }

        public int ToneGray
        {
            get;
            set;
        }

        public int Transparency
        {
            get;
            set;
        }
    }
}
