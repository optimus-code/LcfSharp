using LcfSharp.Types;

namespace LcfSharp.Rpg.Audio
{
    public class Sound
    {
        public DbString Name
        {
            get;
            set;
        } = "(OFF)";

        public int Volume
        {
            get;
            set;
        } = 100;

        public int Tempo
        {
            get;
            set;
        } = 100;

        public int Balance
        {
            get;
            set;
        } = 50;
    }
}
