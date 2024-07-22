using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Animations
{
    public enum AnimationFrameChunk : int
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
            TypeHelpers.ReadChunks<AnimationFrameChunk>(reader, (chunk) =>
            {
                switch ((AnimationFrameChunk)chunk.ID)
                {
                    case AnimationFrameChunk.Cells:
                        Cells = new List<AnimationCellData>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Cells.Add(new AnimationCellData(reader));
                        });
                        return true;
                }
                return false;
            });
        }
    }
}
