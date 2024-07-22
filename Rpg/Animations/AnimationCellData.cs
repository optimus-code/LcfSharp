using LcfSharp.IO;

namespace LcfSharp.Rpg.Animations
{
    public enum AnimationCellDataChunk : int
    {
        /** Bool */
        Valid = 0x01,
        /** Integer */
        CellId = 0x02,
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

    public class AnimationCellData
    {
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

        public AnimationCellData(LcfReader reader)
        {
            TypeHelpers.ReadChunks<AnimationCellDataChunk>(reader, (chunk) =>
            {
                switch ((AnimationCellDataChunk)chunk.ID)
                {
                    case AnimationCellDataChunk.Valid:
                        Valid = reader.ReadInt();
                        return true;

                    case AnimationCellDataChunk.CellId:
                        CellID = reader.ReadInt();
                        return true;

                    case AnimationCellDataChunk.X:
                        X = reader.ReadInt();
                        return true;

                    case AnimationCellDataChunk.Y:
                        Y = reader.ReadInt();
                        return true;

                    case AnimationCellDataChunk.Zoom:
                        Zoom = reader.ReadInt();
                        return true;

                    case AnimationCellDataChunk.ToneRed:
                        ToneRed = reader.ReadInt();
                        return true;

                    case AnimationCellDataChunk.ToneGreen:
                        ToneGreen = reader.ReadInt();
                        return true;

                    case AnimationCellDataChunk.ToneBlue:
                        ToneBlue = reader.ReadInt();
                        return true;

                    case AnimationCellDataChunk.ToneGray:
                        ToneGray = reader.ReadInt();
                        return true;

                    case AnimationCellDataChunk.Transparency:
                        Transparency = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }

}
