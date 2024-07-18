namespace LcfSharp.Rpg.Troops
{
    public class TroopPageCondition
    {
        public TroopPageConditionFlags Flags { get; set; } = new TroopPageConditionFlags();

        public int SwitchAID
        {
            get;
            set;
        } = 1;

        public int SwitchBID
        {
            get;
            set;
        } = 1;

        public int VariableID
        {
            get;
            set;
        } = 1;

        public int VariableValue
        {
            get;
            set;
        }

        public int TurnA
        {
            get;
            set;
        }

        public int TurnB
        {
            get;
            set;
        }

        public int FatigueMin
        {
            get;
            set;
        }

        public int FatigueMax
        {
            get;
            set;
        } = 100;

        public int EnemyID
        {
            get;
            set;
        }

        public int EnemyHPMin
        {
            get;
            set;
        }

        public int EnemyHPMax
        {
            get;
            set;
        } = 100;

        public int ActorID
        {
            get;
            set;
        } = 1;

        public int ActorHPMin
        {
            get;
            set;
        }

        public int ActorHPMax
        {
            get;
            set;
        } = 100;

        public int TurnEnemyID
        {
            get;
            set;
        }

        public int TurnEnemyA
        {
            get;
            set;
        }

        public int TurnEnemyB
        {
            get;
            set;
        }

        public int TurnActorID
        {
            get;
            set;
        } = 1;

        public int TurnActorA
        {
            get;
            set;
        }

        public int TurnActorB
        {
            get;
            set;
        }

        public int CommandActorID
        {
            get;
            set;
        } = 1;

        public int CommandID
        {
            get;
            set;
        } = 1;
    }
}
