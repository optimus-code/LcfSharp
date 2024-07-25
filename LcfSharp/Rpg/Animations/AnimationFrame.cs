using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Shared;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Animations
{
    public enum AnimationFrameChunk : int
    {
        /** Array - rpg::AnimationCellData */
        Cells = 0x01
    }

    [LcfChunk<AnimationFrameChunk>]
    public class AnimationFrame
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public List<AnimationCellData> Cells
        {
            get;
            set;
        } = [];
    }
}