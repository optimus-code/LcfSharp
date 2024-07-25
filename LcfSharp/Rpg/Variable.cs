using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;

namespace LcfSharp.Rpg
{
    public enum VariableChunk : int
    {
        /** String */
        Name = 0x01
    }

    [LcfChunk<VariableChunk>]
    public class Variable
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