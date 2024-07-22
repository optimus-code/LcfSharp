using LcfSharp.IO;
using LcfSharp.Rpg.Troops;
using LcfSharp.Types;

namespace LcfSharp.Rpg
{
    public enum SwitchChunk : int
    {
        /** String */
        Name = 0x01
    }

    public class Switch
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

        public Switch(LcfReader reader)
        {
            TypeHelpers.ReadChunks<SwitchChunk>(reader, (chunk) =>
            {
                switch ((SwitchChunk)chunk.ID)
                {
                    case SwitchChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;
                }
                return false;
            });
        }
    }
}