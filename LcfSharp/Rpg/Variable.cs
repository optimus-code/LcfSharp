using LcfSharp.IO;
using LcfSharp.Types;

namespace LcfSharp.Rpg
{
    public enum VariableChunk : int
    {
        /** String */
        Name = 0x01
    }

    public class Variable
    {
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

        public Variable(LcfReader reader)
        {
            TypeHelpers.ReadChunks<VariableChunk>(reader, (chunk) =>
            {
                switch ((VariableChunk)chunk.ID)
                {
                    case VariableChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;
                }
                return false;
            });
        }
    }
}