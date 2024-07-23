using System.Collections.Generic;

namespace LcfSharp.Rpg.Persistence
{
    public enum SaveActorRowType
    {
        Front = 0,
        Back = 1
    }

    public class SaveActor
    {
        public static readonly Dictionary<SaveActorRowType, string> RowTypeTags = new Dictionary<SaveActorRowType, string>
        {
            { SaveActorRowType.Front, "front" },
            { SaveActorRowType.Back, "back" }
        };

        // Sentinel name used to denote that the default LDB name should be used.
        public static readonly string EmptyName = "\x1";

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        } = EmptyName;

        public string Title
        {
            get;
            set;
        } = EmptyName;

        public string SpriteName
        {
            get;
            set;
        }

        public int SpriteID
        {
            get;
            set;
        }

        public int Transparency
        {
            get;
            set;
        }

        public string FaceName
        {
            get;
            set;
        }

        public int FaceID
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        } = -1;

        public int Exp
        {
            get;
            set;
        } = -1;

        public int HPMod
        {
            get;
            set;
        } = -1;

        public int SPMod
        {
            get;
            set;
        } = -1;

        public int AttackMod
        {
            get;
            set;
        }

        public int DefenseMod
        {
            get;
            set;
        }

        public int SpiritMod
        {
            get;
            set;
        }

        public int AgilityMod
        {
            get;
            set;
        }

        public List<short> Skills
        {
            get;
            set;
        } = new List<short>();

        public List<short> Equipped
        {
            get;
            set;
        } = new List<short> { 0, 0, 0, 0, 0 };

        public int CurrentHP
        {
            get;
            set;
        } = -1;

        public int CurrentSP
        {
            get;
            set;
        } = -1;

        public List<int> BattleCommands
        {
            get;
            set;
        } = new List<int> { -1, -1, -1, -1, -1, -1, -1 };

        public List<short> Status
        {
            get;
            set;
        } = new List<short>();

        public bool ChangedBattleCommands
        {
            get;
            set;
        }

        public int ClassID
        {
            get;
            set;
        } = -1;

        public int Row
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

        public int BattlerAnimation
        {
            get;
            set;
        }
    }

}
