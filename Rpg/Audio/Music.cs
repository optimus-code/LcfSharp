using LcfSharp.Types;
using System;

namespace LcfSharp.Rpg.Audio
{
    public class Music
    {
        public DbString Name
        {
            get;
            set;
        } = "(OFF)";

        public int Fadein
        {
            get;
            set;
        } = 0;

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
