using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Troops;
using LcfSharp.IO.Types;

namespace LcfSharp.Rpg
{
    public enum SwitchChunk : int
    {
        /** String */
        Name = 0x01
    }

    [LcfChunk<SwitchChunk>]
    public class Switch
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        public DbString Name
        {
            get;
            set;
        }
    }
}