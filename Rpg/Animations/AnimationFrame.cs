using System.Collections.Generic;

namespace LcfSharp.Rpg.Animations
{
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
        }
    }
}
