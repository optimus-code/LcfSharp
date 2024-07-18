namespace LcfSharp.Rpg.Troops
{
    public class TroopMember
    {
        public int ID
        {
            get;
            set;
        }

        public int EnemyID
        {
            get;
            set;
        } = 1;

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public bool Invisible
        {
            get;
            set;
        }
    }
}
