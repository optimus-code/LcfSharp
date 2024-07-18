using LcfSharp.Rpg.Shared;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Items
{
    public enum ItemType
    {
        Normal = 0,
        Weapon = 1,
        Shield = 2,
        Armor = 3,
        Helmet = 4,
        Accessory = 5,
        Medicine = 6,
        Book = 7,
        Material = 8,
        Special = 9,
        Switch = 10
    }

    public enum ItemTrajectory
    {
        Straight = 0,
        Return = 1
    }

    public enum ItemTarget
    {
        Single = 0,
        Center = 1,
        Simultaneous = 2,
        Sequential = 3
    }

    public class Item
    {
        public const string DefaultMessage = "default_message";

        public static readonly Dictionary<ItemType, string> TypeTags = new Dictionary<ItemType, string>
        {
            { ItemType.Normal, "normal" },
            { ItemType.Weapon, "weapon" },
            { ItemType.Shield, "shield" },
            { ItemType.Armor, "armor" },
            { ItemType.Helmet, "helmet" },
            { ItemType.Accessory, "accessory" },
            { ItemType.Medicine, "medicine" },
            { ItemType.Book, "book" },
            { ItemType.Material, "material" },
            { ItemType.Special, "special" },
            { ItemType.Switch, "switch" }
        };

        public static readonly Dictionary<ItemTrajectory, string> TrajectoryTags = new Dictionary<ItemTrajectory, string>
        {
            { ItemTrajectory.Straight, "straight" },
            { ItemTrajectory.Return, "return" }
        };

        public static readonly Dictionary<ItemTarget, string> TargetTags = new Dictionary<ItemTarget, string>
        {
            { ItemTarget.Single, "single" },
            { ItemTarget.Center, "center" },
            { ItemTarget.Simultaneous, "simultaneous" },
            { ItemTarget.Sequential, "sequential" }
        };

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

        public DbString Description
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }

        public int Price
        {
            get;
            set;
        }

        public int Uses
        {
            get;
            set;
        }

        public int AtkPoints1
        {
            get;
            set;
        }

        public int DefPoints1
        {
            get;
            set;
        }

        public int SpiPoints1
        {
            get;
            set;
        }

        public int AgiPoints1
        {
            get;
            set;
        }

        public bool TwoHanded
        {
            get;
            set;
        }

        public int SpCost
        {
            get;
            set;
        }

        public int Hit
        {
            get;
            set;
        }

        public int CriticalHit
        {
            get;
            set;
        }

        public int AnimationID
        {
            get;
            set;
        }

        public bool Preemptive
        {
            get;
            set;
        }

        public bool DualAttack
        {
            get;
            set;
        }

        public bool AttackAll
        {
            get;
            set;
        }

        public bool IgnoreEvasion
        {
            get;
            set;
        }

        public bool PreventCritical
        {
            get;
            set;
        }

        public bool RaiseEvasion
        {
            get;
            set;
        }

        public bool HalfSpCost
        {
            get;
            set;
        }

        public bool NoTerrainDamage
        {
            get;
            set;
        }

        public bool Cursed
        {
            get;
            set;
        }

        public bool EntireParty
        {
            get;
            set;
        }

        public int RecoverHpRate
        {
            get;
            set;
        }

        public int RecoverHp
        {
            get;
            set;
        }

        public int RecoverSpRate
        {
            get;
            set;
        }

        public int RecoverSp
        {
            get;
            set;
        }

        public bool OccasionField1
        {
            get;
            set;
        }

        public bool KoOnly
        {
            get;
            set;
        }

        public int MaxHpPoints
        {
            get;
            set;
        }

        public int MaxSpPoints
        {
            get;
            set;
        }

        public int AtkPoints2
        {
            get;
            set;
        }

        public int DefPoints2
        {
            get;
            set;
        }

        public int SpiPoints2
        {
            get;
            set;
        }

        public int AgiPoints2
        {
            get;
            set;
        }

        public int UsingMessage
        {
            get;
            set;
        }

        public int SkillID
        {
            get;
            set;
        }

        public int SwitchID
        {
            get;
            set;
        }

        public bool OccasionField2
        {
            get;
            set;
        }

        public bool OccasionBattle
        {
            get;
            set;
        }

        public DbBitArray ActorSet
        {
            get;
            set;
        }

        public DbBitArray StateSet
        {
            get;
            set;
        }

        public DbBitArray AttributeSet
        {
            get;
            set;
        }

        public int StateChance
        {
            get;
            set;
        }

        public bool ReverseStateEffect
        {
            get;
            set;
        }

        public int WeaponAnimation
        {
            get;
            set;
        }

        public List<BattlerAnimationItemSkill> AnimationData
        {
            get;
            set;
        }

        public bool UseSkill
        {
            get;
            set;
        }

        public DbBitArray ClassSet
        {
            get;
            set;
        }

        public int RangedTrajectory
        {
            get;
            set;
        }

        public int RangedTarget
        {
            get;
            set;
        }
    }
}
