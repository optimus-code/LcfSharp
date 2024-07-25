using LcfSharp.IO.Types;

namespace LcfSharp.Rpg.Troops
{
    public class TroopPageConditionFlags : IDbFlags
    {
        public bool SwitchA
        {
            get;
            set;
        }

        public bool SwitchB
        {
            get;
            set;
        }

        public bool Variable
        {
            get;
            set;
        }

        public bool Turn
        {
            get;
            set;
        }

        public bool Fatigue
        {
            get;
            set;
        }

        public bool EnemyHP
        {
            get;
            set;
        }

        public bool ActorHP
        {
            get;
            set;
        }

        public bool TurnEnemy
        {
            get;
            set;
        }

        public bool TurnActor
        {
            get;
            set;
        }

        public bool CommandActor
        {
            get;
            set;
        }
    }
}