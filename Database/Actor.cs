using LcfSharp.Actors;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Database
{
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
    }

    public class EasyRPGActor : Actor
    {
        public int ActorAI
        {
            get;
            set;
        } = -1;

        public bool PreventCritical
        {
            get;
            set;
        } = false;

        public bool RaiseEvasion
        {
            get;
            set;
        } = false;

        public bool ImmuneToAttributeDownshifts
        {
            get;
            set;
        } = false;

        public bool IgnoreEvasion
        {
            get;
            set;
        } = false;

        public int UnarmedHit
        {
            get;
            set;
        } = -1;

        public DbBitArray UnarmedStateSet
        {
            get;
            set;
        }

        public int UnarmedStateChance
        {
            get;
            set;
        } = 0;

        public DbBitArray UnarmedAttributeSet
        {
            get;
            set;
        }

        public bool DualAttack
        {
            get;
            set;
        } = false;

        public bool AttackAll
        {
            get;
            set;
        } = false;
    }
}
