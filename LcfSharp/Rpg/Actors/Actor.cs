using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using LcfSharp.Rpg.Skills;
using LcfSharp.Types;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace LcfSharp.Rpg.Actors
{
    public enum ActorChunk : int
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
            int stateRanksSize = 0;
            int attributeRanksSize = 0;
            int expectedCount = System.Enum.GetValues<ActorChunk>().Length + (!Database.IsRM2K3 ? -5 : 0);
            var readCount = 0;

            TypeHelpers.ReadChunks<ActorChunk>(reader, (chunk) =>
            {
                switch ((ActorChunk)chunk.ID)
                {
                    case ActorChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        readCount++;
                        return true;

                    case ActorChunk.Title:
                        Title = reader.ReadDbString(chunk.Length);
                        readCount++;
                        return true;

                    case ActorChunk.CharacterName:
                        CharacterName = reader.ReadDbString(chunk.Length);
                        readCount++;
                        return true;

                    case ActorChunk.CharacterIndex:
                        CharacterIndex = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.Transparent:
                        Transparent = reader.ReadBool();
                        readCount++;
                        return true;

                    case ActorChunk.InitialLevel:
                        InitialLevel = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.FinalLevel:
                        FinalLevel = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.CriticalHit:
                        CriticalHit = reader.ReadBool();
                        readCount++;
                        return true;

                    case ActorChunk.CriticalHitChance:
                        CriticalHitChance = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.FaceName:
                        FaceName = reader.ReadDbString(chunk.Length);
                        readCount++;
                        return true;

                    case ActorChunk.FaceIndex:
                        FaceIndex = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.TwoWeapon:
                        TwoWeapon = reader.ReadBool();
                        readCount++;
                        return true;

                    case ActorChunk.LockEquipment:
                        LockEquipment = reader.ReadBool();
                        readCount++;
                        return true;

                    case ActorChunk.AutoBattle:
                        AutoBattle = reader.ReadBool();
                        readCount++;
                        return true;

                    case ActorChunk.SuperGuard:
                        SuperGuard = reader.ReadBool();
                        readCount++;
                        return true;

                    case ActorChunk.Parameters:
                        Parameters = new Parameters(reader, chunk.Length / 2);
                        readCount++;
                        return true;

                    case ActorChunk.ExpBase:
                        ExpBase = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.ExpInflation:
                        ExpInflation = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.ExpCorrection:
                        ExpCorrection = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.InitialEquipment:
                        InitialEquipment = new Equipment(reader);
                        readCount++;
                        return true;

                    case ActorChunk.UnarmedAnimation:
                        UnarmedAnimation = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.ClassId:
                        if (!Database.IsRM2K3)
                            return false;
                        ClassId = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.BattleX:
                        if (!Database.IsRM2K3)
                            return false;
                        BattleX = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.BattleY:
                        if (!Database.IsRM2K3)
                            return false;
                        BattleY = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.BattlerAnimation:
                        if (!Database.IsRM2K3)
                            return false;
                        BattlerAnimation = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.Skills:
                        Skills = new List<Learning>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Skills.Add(new Learning(reader));
                        });
                        readCount++;
                        return true;

                    case ActorChunk.RenameSkill:
                        RenameSkill = reader.ReadBool();
                        readCount++;
                        return true;

                    case ActorChunk.SkillName:
                        SkillName = reader.ReadDbString(chunk.Length);
                        readCount++;
                        return true;

                    case ActorChunk.StateRanksSize:
                        stateRanksSize = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.StateRanks:
                        if (stateRanksSize > 0)
                        {
                            StateRanks = reader.ReadByteList(stateRanksSize);
                            return true;
                        }
                        readCount++;
                        break;

                    case ActorChunk.AttributeRanksSize:
                        attributeRanksSize = reader.ReadInt();
                        readCount++;
                        return true;

                    case ActorChunk.AttributeRanks:
                        if (attributeRanksSize > 0)
                        {
                            AttributeRanks = reader.ReadByteList(attributeRanksSize);
                            return true;
                        }
                        readCount++;
                        return true;

                    case ActorChunk.BattleCommands:
                        if (!Database.IsRM2K3)
                            return false;

                        BattleCommands = TypeHelpers.ReadChunkIntList(reader, chunk.Length);
                        readCount++;
                        return true;
                }
                return false;
            }, () =>
            {
                return expectedCount == readCount;
            });
        }

    }
}