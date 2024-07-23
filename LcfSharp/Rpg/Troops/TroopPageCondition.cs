using LcfSharp.IO;
using LcfSharp.Types;

namespace LcfSharp.Rpg.Troops
{
    public enum TroopPageConditionChunk : int
    {
        Flags = 0x01,
        SwitchAId = 0x02,
        SwitchBId = 0x03,
        VariableId = 0x04,
        VariableValue = 0x05,
        TurnA = 0x06,
        TurnB = 0x07,
        FatigueMin = 0x08,
        FatigueMax = 0x09,
        EnemyId = 0x0A,
        EnemyHpMin = 0x0B,
        EnemyHpMax = 0x0C,
        ActorId = 0x0D,
        ActorHpMin = 0x0E,
        ActorHpMax = 0x0F,
        TurnEnemyId = 0x10,
        TurnEnemyA = 0x11,
        TurnEnemyB = 0x12,
        TurnActorId = 0x13,
        TurnActorA = 0x14,
        TurnActorB = 0x15,
        CommandActorId = 0x16,
        CommandId = 0x17
    }

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

        public TroopPageCondition(LcfReader reader)
        {
            TypeHelpers.ReadChunks<TroopPageConditionChunk>(reader, (chunk) =>
            {
                switch ((TroopPageConditionChunk)chunk.ID)
                {
                    case TroopPageConditionChunk.Flags:
                        Flags = DbFlags.Read<TroopPageConditionFlags>(reader);
                        return true;

                    case TroopPageConditionChunk.SwitchAId:
                        SwitchAID = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.SwitchBId:
                        SwitchBID = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.VariableId:
                        VariableID = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.VariableValue:
                        VariableValue = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.TurnA:
                        TurnA = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.TurnB:
                        TurnB = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.FatigueMin:
                        FatigueMin = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.FatigueMax:
                        FatigueMax = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.EnemyId:
                        EnemyID = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.EnemyHpMin:
                        EnemyHPMin = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.EnemyHpMax:
                        EnemyHPMax = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.ActorId:
                        ActorID = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.ActorHpMin:
                        ActorHPMin = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.ActorHpMax:
                        ActorHPMax = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.TurnEnemyId:
                        EnemyID = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.TurnEnemyA:
                        TurnEnemyA = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.TurnEnemyB:
                        TurnEnemyB = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.TurnActorId:
                        TurnActorID = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.TurnActorA:
                        TurnActorA = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.TurnActorB:
                        TurnActorB = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.CommandActorId:
                        CommandActorID = reader.ReadInt();
                        return true;

                    case TroopPageConditionChunk.CommandId:
                        CommandID = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}
