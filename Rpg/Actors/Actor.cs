using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using LcfSharp.Rpg.Skills;
using LcfSharp.Types;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LcfSharp.Rpg.Actors
{
    public enum ActorChunk : byte
    {
        /** String */
        Name = 0x01,
        /** String */
        Title = 0x02,
        /** String */
        CharacterName = 0x03,
        /** Integer */
        CharacterIndex = 0x04,
        /** Flag */
        Transparent = 0x05,
        /** Integer */
        InitialLevel = 0x07,
        /** Integer */
        FinalLevel = 0x08,
        /** Flag */
        CriticalHit = 0x09,
        /** Integer */
        CriticalHitChance = 0x0A,
        /** String */
        FaceName = 0x0F,
        /** Integer */
        FaceIndex = 0x10,
        /** Flag */
        TwoWeapon = 0x15,
        /** Flag */
        LockEquipment = 0x16,
        /** Flag */
        AutoBattle = 0x17,
        /** Flag */
        SuperGuard = 0x18,
        /** Array x 6 - Short */
        Parameters = 0x1F,
        /** Integer */
        ExpBase = 0x29,
        /** Integer */
        ExpInflation = 0x2A,
        /** Integer */
        ExpCorrection = 0x2B,
        /** Integer x 5 */
        InitialEquipment = 0x33,
        /** Integer */
        UnarmedAnimation = 0x38,
        /** Integer - RPG2003 */
        ClassId = 0x39,
        /** Integer - RPG2003 */
        BattleX = 0x3B,
        /** Integer - RPG2003 */
        BattleY = 0x3C,
        /** Integer - RPG2003 */
        BattlerAnimation = 0x3E,
        /** Array - rpg::Learning */
        Skills = 0x3F,
        /** Flag */
        RenameSkill = 0x42,
        /** String */
        SkillName = 0x43,
        /** Integer */
        StateRanksSize = 0x47,
        /** Array - Short */
        StateRanks = 0x48,
        /** Integer */
        AttributeRanksSize = 0x49,
        /** Array - Short */
        AttributeRanks = 0x4A,
        /** Array - rpg::BattleCommand - RPG2003 */
        BattleCommands = 0x50,
    }

    public class Actor
    {
        public int ID
        {
            get;
            set;
        } = 0;

        public DbString Name
        {
            get;
            set;
        }

        public DbString Title
        {
            get;
            set;
        }

        public DbString CharacterName
        {
            get;
            set;
        }

        public int CharacterIndex
        {
            get;
            set;
        } = 0;

        public bool Transparent
        {
            get;
            set;
        } = false;

        public int InitialLevel
        {
            get;
            set;
        } = 1;

        public int FinalLevel
        {
            get;
            set;
        } = -1;

        public bool CriticalHit
        {
            get;
            set;
        } = true;

        public int CriticalHitChance
        {
            get;
            set;
        } = 30;

        public DbString FaceName
        {
            get;
            set;
        }

        public int FaceIndex
        {
            get;
            set;
        } = 0;

        public bool TwoWeapon
        {
            get;
            set;
        } = false;

        public bool LockEquipment
        {
            get;
            set;
        } = false;

        public bool AutoBattle
        {
            get;
            set;
        } = false;

        public bool SuperGuard
        {
            get;
            set;
        } = false;

        public Parameters Parameters
        {
            get;
            set;
        }

        public int ExpBase
        {
            get;
            set;
        } = -1;

        public int ExpInflation
        {
            get;
            set;
        } = -1;

        public int ExpCorrection
        {
            get;
            set;
        } = 0;

        public Equipment InitialEquipment
        {
            get;
            set;
        }

        public int UnarmedAnimation
        {
            get;
            set;
        } = 1;

        public int ClassId
        {
            get;
            set;
        } = 0;

        public int BattleX
        {
            get;
            set;
        } = 220;

        public int BattleY
        {
            get;
            set;
        } = 120;

        public int BattlerAnimation
        {
            get;
            set;
        } = 1;

        public List<Learning> Skills
        {
            get; set;
        } = new List<Learning>();

        public bool RenameSkill
        {
            get;
            set;
        } = false;

        public DbString SkillName
        {
            get;
            set;
        }

        public List<byte> StateRanks
        {
            get;
            set;
        } = new List<byte>();

        public List<byte> AttributeRanks
        {
            get;
            set;
        } = new List<byte>();

        public List<int> BattleCommands
        {
            get;
            set;
        } = new List<int>();

        public Actor(LcfReader reader)
        {
            TypeHelpers.ReadChunks<LearningChunk>(reader, (chunkID) =>
            {
                switch ((ActorChunk)chunkID)
                {
                    case ActorChunk.Name:
                        Name = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case ActorChunk.Title:
                        Title = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case ActorChunk.CharacterName:
                        CharacterName = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case ActorChunk.CharacterIndex:
                        CharacterIndex = reader.ReadInt();
                        return true;

                    case ActorChunk.Transparent:
                        Transparent = reader.ReadBool();
                        return true;

                    case ActorChunk.InitialLevel:
                        InitialLevel = reader.ReadInt();
                        return true;

                    case ActorChunk.FinalLevel:
                        FinalLevel = reader.ReadInt();
                        return true;

                    case ActorChunk.CriticalHit:
                        CriticalHit = reader.ReadBool();
                        return true;

                    case ActorChunk.CriticalHitChance:
                        CriticalHitChance = reader.ReadInt();
                        return true;

                    case ActorChunk.FaceName:
                        FaceName = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case ActorChunk.FaceIndex:
                        FaceIndex = reader.ReadInt();
                        return true;

                    case ActorChunk.TwoWeapon:
                        TwoWeapon = reader.ReadBool();
                        return true;

                    case ActorChunk.LockEquipment:
                        LockEquipment = reader.ReadBool();
                        return true;

                    case ActorChunk.AutoBattle:
                        AutoBattle = reader.ReadBool();
                        return true;

                    case ActorChunk.SuperGuard:
                        SuperGuard = reader.ReadBool();
                        return true;

                    case ActorChunk.Parameters:
                        Parameters = reader.ReadParameters();
                        return true;

                    case ActorChunk.ExpBase:
                        ExpBase = reader.ReadInt();
                        return true;

                    case ActorChunk.ExpInflation:
                        ExpInflation = reader.ReadInt();
                        return true;

                    case ActorChunk.ExpCorrection:
                        ExpCorrection = reader.ReadInt();
                        return true;

                    case ActorChunk.InitialEquipment:
                        InitialEquipment = reader.ReadEquipment();
                        return true;

                    case ActorChunk.UnarmedAnimation:
                        UnarmedAnimation = reader.ReadInt();
                        return true;

                    case ActorChunk.ClassId:
                        ClassId = reader.ReadInt();
                        return true;

                    case ActorChunk.BattleX:
                        BattleX = reader.ReadInt();
                        return true;

                    case ActorChunk.BattleY:
                        BattleY = reader.ReadInt();
                        return true;

                    case ActorChunk.BattlerAnimation:
                        BattlerAnimation = reader.ReadInt();
                        return true;

                    case ActorChunk.Skills:
                        Skills = reader.ReadLearningList();
                        return true;

                    case ActorChunk.RenameSkill:
                        RenameSkill = reader.ReadBool();
                        return true;

                    case ActorChunk.SkillName:
                        SkillName = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case ActorChunk.StateRanks:
                        StateRanks = reader.ReadByteList(chunk.Length);
                        return true;

                    case ActorChunk.AttributeRanks:
                        AttributeRanks = reader.ReadByteList(chunk.Length);
                        return true;

                    case ActorChunk.BattleCommands:
                        BattleCommands = reader.ReadIntList(chunk.Length);
                        return true;
                }
                return false;
            });
        }

    }
}