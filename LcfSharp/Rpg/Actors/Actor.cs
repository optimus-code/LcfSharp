using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Shared;
using LcfSharp.Rpg.Skills;
using LcfSharp.IO.Types;
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

    [LcfChunk<ActorChunk>]
    public class Actor
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        } = 0;
[LcfAlwaysPersistAttribute]
		public DbString Name
        {
            get;
            set;
        }
[LcfAlwaysPersistAttribute]
		public DbString Title
        {
            get;
            set;
        }
[LcfAlwaysPersistAttribute]
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
[LcfAlwaysPersistAttribute]
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

        [LcfAlwaysPersistAttribute]
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

        [LcfAlwaysPersistAttribute]
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

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int ClassId
        {
            get;
            set;
        } = 0;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int BattleX
        {
            get;
            set;
        } = 220;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int BattleY
        {
            get;
            set;
        } = 120;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int BattlerAnimation
        {
            get;
            set;
        } = 1;


        [LcfAlwaysPersistAttribute]
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

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)ActorChunk.StateRanksSize)]
        public List<byte> StateRanks
        {
            get;
            set;
        } = new List<byte>();

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)ActorChunk.AttributeRanksSize)]
        public List<byte> AttributeRanks
        {
            get;
            set;
        } = new List<byte>();

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
        public List<int> BattleCommands
        {
            get;
            set;
        } = new List<int>();
    }
}