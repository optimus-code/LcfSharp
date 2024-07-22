using LcfSharp.IO;
using LcfSharp.Rpg.Actors;
using LcfSharp.Rpg.Shared;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Enemies
{
    public enum EnemyChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        BattlerName = 0x02,
        /** Integer */
        BattlerHue = 0x03,
        /** Integer */
        MaxHp = 0x04,
        /** Integer */
        MaxSp = 0x05,
        /** Integer */
        Attack = 0x06,
        /** Integer */
        Defense = 0x07,
        /** Integer */
        Spirit = 0x08,
        /** Integer */
        Agility = 0x09,
        /** Flag */
        Transparent = 0x0A,
        /** Integer */
        Exp = 0x0B,
        /** Integer */
        Gold = 0x0C,
        /** Integer */
        DropId = 0x0D,
        /** Integer */
        DropProb = 0x0E,
        /** Flag */
        CriticalHit = 0x15,
        /** Integer */
        CriticalHitChance = 0x16,
        /** Flag */
        Miss = 0x1A,
        /** Flag */
        Levitate = 0x1C,
        /** Integer */
        StateRanksSize = 0x1F,
        /** Array - Short */
        StateRanks = 0x20,
        /** Integer */
        AttributeRanksSize = 0x21,
        /** Array - Short */
        AttributeRanks = 0x22,
        /** Array - rpg::EnemyAction */
        Actions = 0x2A
    }

    public class Enemy
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

        public DbString BattlerName
        {
            get;
            set;
        }

        public int BattlerHue
        {
            get;
            set;
        }

        public int MaxHP
        {
            get;
            set;
        }

        public int MaxSP
        {
            get;
            set;
        }

        public int Attack
        {
            get;
            set;
        }

        public int Defense
        {
            get;
            set;
        }

        public int Spirit
        {
            get;
            set;
        }

        public int Agility
        {
            get;
            set;
        }

        public bool Transparent
        {
            get;
            set;
        }

        public int Exp
        {
            get;
            set;
        }

        public int Gold
        {
            get;
            set;
        }

        public int DropID
        {
            get;
            set;
        }

        public int DropProb
        {
            get;
            set;
        }

        public bool CriticalHit
        {
            get;
            set;
        }

        public int CriticalHitChance
        {
            get;
            set;
        }

        public bool Miss
        {
            get;
            set;
        }

        public bool Levitate
        {
            get;
            set;
        }

        public List<byte> StateRanks
        {
            get;
            set;
        }

        public List<byte> AttributeRanks
        {
            get;
            set;
        }

        public List<EnemyAction> Actions
        {
            get;
            set;
        }

        public Enemy(LcfReader reader)
        {
            int stateRanksSize = 0;
            int attributeRanksSize = 0;
            TypeHelpers.ReadChunks<EnemyChunk>(reader, (chunk) =>
            {
                switch ((EnemyChunk)chunk.ID)
                {
                    case EnemyChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;

                    case EnemyChunk.BattlerName:
                        BattlerName = reader.ReadDbString(chunk.Length);
                        return true;

                    case EnemyChunk.BattlerHue:
                        BattlerHue = reader.ReadInt();
                        return true;

                    case EnemyChunk.MaxHp:
                        MaxHP = reader.ReadInt();
                        return true;

                    case EnemyChunk.MaxSp:
                        MaxSP = reader.ReadInt();
                        return true;

                    case EnemyChunk.Attack:
                        Attack = reader.ReadInt();
                        return true;

                    case EnemyChunk.Defense:
                        Defense = reader.ReadInt();
                        return true;

                    case EnemyChunk.Spirit:
                        Spirit = reader.ReadInt();
                        return true;

                    case EnemyChunk.Agility:
                        Agility = reader.ReadInt();
                        return true;

                    case EnemyChunk.Transparent:
                        Transparent = reader.ReadBool();
                        return true;

                    case EnemyChunk.Exp:
                        Exp = reader.ReadInt();
                        return true;

                    case EnemyChunk.Gold:
                        Gold = reader.ReadInt();
                        return true;

                    case EnemyChunk.DropId:
                        DropID = reader.ReadInt();
                        return true;

                    case EnemyChunk.DropProb:
                        DropProb = reader.ReadInt();
                        return true;

                    case EnemyChunk.CriticalHit:
                        CriticalHit = reader.ReadBool();
                        return true;

                    case EnemyChunk.CriticalHitChance:
                        CriticalHitChance = reader.ReadInt();
                        return true;

                    case EnemyChunk.Miss:
                        Miss = reader.ReadBool();
                        return true;

                    case EnemyChunk.Levitate:
                        Levitate = reader.ReadBool();
                        return true;

                    case EnemyChunk.StateRanksSize:
                        stateRanksSize = reader.ReadInt();
                        return true;

                    case EnemyChunk.StateRanks:
                        if (stateRanksSize > 0)
                        {
                            StateRanks = reader.ReadByteList(stateRanksSize);
                            return true;
                        }
                        break;

                    case EnemyChunk.AttributeRanksSize:
                        attributeRanksSize = reader.ReadInt();
                        return true;

                    case EnemyChunk.AttributeRanks:
                        if (attributeRanksSize > 0)
                        {
                            AttributeRanks = reader.ReadByteList(attributeRanksSize);
                            return true;
                        }
                        return true;

                    case EnemyChunk.Actions:
                        Actions = new List<EnemyAction>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Actions.Add(new EnemyAction(reader));
                        });
                        return true;
                }
                return false;
            });
        }
    }
}