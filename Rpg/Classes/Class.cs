using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Classes
{
    public enum ClassChunk : byte
    {
        Name = 0x01,
        TwoWeapon = 0x15,
        LockEquipment = 0x16,
        AutoBattle = 0x17,
        SuperGuard = 0x18,
        Parameters = 0x1F,
        ExpBase = 0x29,
        ExpInflation = 0x2A,
        ExpCorrection = 0x2B,
        BattlerAnimation = 0x3E,
        Skills = 0x3F,
        StateRanksSize = 0x47,
        StateRanks = 0x48,
        AttributeRanksSize = 0x49,
        AttributeRanks = 0x4A,
        BattleCommands = 0x50
    }

    public class Class
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

        public bool TwoWeapon
        {
            get;
            set;
        }

        public bool LockEquipment
        {
            get;
            set;
        }

        public bool AutoBattle
        {
            get;
            set;
        }

        public bool SuperGuard
        {
            get;
            set;
        }

        public Parameters Parameters
        {
            get;
            set;
        }

        public int ExpBase
        {
            get;
            set;
        }

        public int ExpInflation
        {
            get;
            set;
        }

        public int ExpCorrection
        {
            get;
            set;
        }

        public int BattlerAnimation
        {
            get;
            set;
        }

        public List<Learning> Skills
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

        public List<int> BattleCommands
        {
            get;
            set;
        }
        public Class(LcfReader reader)
        {
            TypeHelpers.ReadChunks<ClassChunk>(reader, (chunkID) =>
            {
                switch ((ClassChunk)chunkID)
                {
                    case ClassChunk.Name:
                        Name = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case ClassChunk.TwoWeapon:
                        TwoWeapon = reader.ReadBool();
                        return true;

                    case ClassChunk.LockEquipment:
                        LockEquipment = reader.ReadBool();
                        return true;

                    case ClassChunk.AutoBattle:
                        AutoBattle = reader.ReadBool();
                        return true;

                    case ClassChunk.SuperGuard:
                        SuperGuard = reader.ReadBool();
                        return true;

                    case ClassChunk.Parameters:
                        Parameters = new Parameters(reader);
                        return true;

                    case ClassChunk.ExpBase:
                        ExpBase = reader.ReadInt();
                        return true;

                    case ClassChunk.ExpInflation:
                        ExpInflation = reader.ReadInt();
                        return true;

                    case ClassChunk.ExpCorrection:
                        ExpCorrection = reader.ReadInt();
                        return true;

                    case ClassChunk.BattlerAnimation:
                        BattlerAnimation = reader.ReadInt();
                        return true;

                    case ClassChunk.Skills:
                        int skillCount = reader.ReadInt();
                        for (int i = 0; i < skillCount; i++)
                        {
                            Skills.Add(new Learning(reader));
                        }
                        return true;

                    case ClassChunk.StateRanksSize:
                        reader.Skip(4); // Skipping the size
                        return true;

                    case ClassChunk.StateRanks:
                        StateRanks = reader.ReadByteList(256);
                        return true;

                    case ClassChunk.AttributeRanksSize:
                        reader.Skip(4); // Skipping the size
                        return true;

                    case ClassChunk.AttributeRanks:
                        AttributeRanks = reader.ReadByteList(256);
                        return true;

                    case ClassChunk.BattleCommands:
                        int commandCount = reader.ReadInt();
                        for (int i = 0; i < commandCount; i++)
                        {
                            BattleCommands.Add(reader.ReadInt());
                        }
                        return true;
                }
                return false;
            });
        }
    }
}
