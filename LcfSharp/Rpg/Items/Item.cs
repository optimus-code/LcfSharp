using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Shared;
using LcfSharp.IO.Types;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Items
{
    public enum ItemChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        Description = 0x02,
        /** Integer */
        Type = 0x03,
        /** Integer */
        Price = 0x05,
        /** Integer */
        Uses = 0x06,
        /** Integer */
        AtkPoints1 = 0x0B,
        /** Integer */
        DefPoints1 = 0x0C,
        /** Integer */
        SpiPoints1 = 0x0D,
        /** Integer */
        AgiPoints1 = 0x0E,
        /** Flag */
        TwoHanded = 0x0F,
        /** Integer */
        SpCost = 0x10,
        /** Integer */
        Hit = 0x11,
        /** Integer */
        CriticalHit = 0x12,
        /** Integer */
        AnimationID = 0x14,
        /** Flag */
        Preemptive = 0x15,
        /** Flag */
        DualAttack = 0x16,
        /** Flag */
        AttackAll = 0x17,
        /** Flag */
        IgnoreEvasion = 0x18,
        /** Flag */
        PreventCritical = 0x19,
        /** Flag */
        RaiseEvasion = 0x1A,
        /** Flag */
        HalfSPCost = 0x1B,
        /** Flag */
        NoTerrainDamage = 0x1C,
        /** Flag - RPG2003 */
        Cursed = 0x1D,
        /** Flag */
        EntireParty = 0x1F,
        /** Integer */
        RecoverHPRate = 0x20,
        /** Integer */
        RecoverHP = 0x21,
        /** Integer */
        RecoverSPRate = 0x22,
        /** Integer */
        RecoverSP = 0x23,
        /** Flag */
        OccasionField1 = 0x25,
        /** Flag */
        KOOnly = 0x26,
        /** Integer */
        MaxHPPoints = 0x29,
        /** Integer */
        MaxSPPoints = 0x2A,
        /** Integer */
        AtkPoints2 = 0x2B,
        /** Integer */
        DefPoints2 = 0x2C,
        /** Integer */
        SpiPoints2 = 0x2D,
        /** Integer */
        AgiPoints2 = 0x2E,
        /** Integer */
        UsingMessage = 0x33,
        /** Integer */
        SkillID = 0x35,
        /** Integer */
        SwitchID = 0x37,
        /** Flag */
        OccasionField2 = 0x39,
        /** Flag */
        OccasionBattle = 0x3A,
        /** Integer */
        ActorSetSize = 0x3D,
        /** Array - Flag */
        ActorSet = 0x3E,
        /** Integer */
        StateSetSize = 0x3F,
        /** Array - Flag */
        StateSet = 0x40,
        /** Integer */
        AttributeSetSize = 0x41,
        /** Array - Flag */
        AttributeSet = 0x42,
        /** Integer */
        StateChance = 0x43,
        /** Flag */
        ReverseStateEffect = 0x44,
        /** Integer - RPG2003 */
        WeaponAnimation = 0x45,
        /** Array - RPG2003 */
        AnimationData = 0x46,
        /** Flag - RPG2003 */
        UseSkill = 0x47,
        /** Integer - RPG2003 */
        ClassSetSize = 0x48,
        /** Array - Flag - RPG2003 */
        ClassSet = 0x49,
        /** Integer */
        RangedTrajectory = 0x4B,
        /** Integer */
        RangedTarget = 0x4C
    }

    public enum ItemType : int
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

    public enum ItemTrajectory : int
    {
        Straight = 0,
        Return = 1
    }

    public enum ItemTarget : int
    {
        Single = 0,
        Center = 1,
        Simultaneous = 2,
        Sequential = 3
    }

    [LcfChunk<ItemChunk>]
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

        [LcfID]
        [XmlAttribute]
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

        [LcfAlwaysPersistAttribute]
        [XmlAttribute]
        public ItemType Type
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Price
        {
            get;
            set;
        }

        [XmlAttribute]
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

        [LcfAlwaysPersistAttribute]
        public bool TwoHanded
        {
            get;
            set;
        }

        public int SPCost
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

        public bool HalfSPCost
        {
            get;
            set;
        }

        public bool NoTerrainDamage
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public bool Cursed
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public bool EntireParty
        {
            get;
            set;
        }

        public int RecoverHPRate
        {
            get;
            set;
        }

        public int RecoverHP
        {
            get;
            set;
        }

        public int RecoverSPRate
        {
            get;
            set;
        }

        public int RecoverSP
        {
            get;
            set;
        }

        public bool OccasionField1
        {
            get;
            set;
        }

        public bool KOOnly
        {
            get;
            set;
        }

        public int MaxHPPoints
        {
            get;
            set;
        }

        public int MaxSPPoints
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

        [LcfAlwaysPersistAttribute]
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

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)ItemChunk.ActorSetSize)]
        public List<bool> ActorSet
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)ItemChunk.StateSetSize)]
        public List<bool> StateSet
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)ItemChunk.AttributeSetSize)]
        public List<bool> AttributeSet
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

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int WeaponAnimation
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
        public List<BattlerAnimationItemSkill> AnimationData
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public bool UseSkill
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
        [LcfSize((int)ItemChunk.ClassSetSize)]
        public List<bool> ClassSet
        {
            get;
            set;
        }

        public ItemTrajectory RangedTrajectory
        {
            get;
            set;
        }

        public ItemTarget RangedTarget
        {
            get;
            set;
        }
    }
}