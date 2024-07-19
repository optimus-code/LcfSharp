using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Animations
{
    public enum AnimationFrameChunk : byte
    {
        /** Array - rpg::AnimationCellData */
        Cells = 0x01
    }

    public class AnimationFrame
    {
        public int ID
        {
            get;
            set;
        }

        public List<AnimationCellData> Cells
        {
            get;
            set;
        } = [];

        public AnimationFrame(LcfReader reader)
        {
            TypeHelpers.ReadChunks<AnimationFrameChunk>(reader, (chunkID) =>
            {
                switch ((AnimationFrameChunk)chunkID)
                {
                    case AnimationFrameChunk.Cells:
                        var cellCount = reader.ReadInt();

                        for (var i = 0; i < cellCount; i++)
                        {
                            Cells.Add(new AnimationCellData(reader));
                        }
                        return true;
                }
                return false;
            });
        }
    }
}
