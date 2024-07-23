using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using LcfSharp.Types;
using System.Collections.Generic;

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
        AnimationId = 0x14,
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
        HalfSpCost = 0x1B,
        /** Flag */
        NoTerrainDamage = 0x1C,
        /** Flag - RPG2003 */
        Cursed = 0x1D,
        /** Flag */
        EntireParty = 0x1F,
        /** Integer */
        RecoverHpRate = 0x20,
        /** Integer */
        RecoverHp = 0x21,
        /** Integer */
        RecoverSpRate = 0x22,
        /** Integer */
        RecoverSp = 0x23,
        /** Flag */
        OccasionField1 = 0x25,
        /** Flag */
        KoOnly = 0x26,
        /** Integer */
        MaxHpPoints = 0x29,
        /** Integer */
        MaxSpPoints = 0x2A,
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
        SkillId = 0x35,
        /** Integer */
        SwitchId = 0x37,
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

        public ItemType Type
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

        public Item(LcfReader reader)
        {
            int actorSetSize = 0;
            int stateSetSize = 0;
            int attributeSetSize = 0;
            int classSetSize = 0;

            TypeHelpers.ReadChunks<ItemChunk>(reader, (chunk) =>
            {
                switch ((ItemChunk)chunk.ID)
                {
                    case ItemChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;

                    case ItemChunk.Description:
                        Description = reader.ReadDbString(chunk.Length);
                        return true;

                    case ItemChunk.Type:
                        Type = (ItemType)reader.ReadInt();
                        return true;

                    case ItemChunk.Price:
                        Price = reader.ReadInt();
                        return true;

                    case ItemChunk.Uses:
                        Uses = reader.ReadInt();
                        return true;

                    case ItemChunk.AtkPoints1:
                        AtkPoints1 = reader.ReadInt();
                        return true;

                    case ItemChunk.DefPoints1:
                        DefPoints1 = reader.ReadInt();
                        return true;

                    case ItemChunk.SpiPoints1:
                        SpiPoints1 = reader.ReadInt();
                        return true;

                    case ItemChunk.AgiPoints1:
                        AgiPoints1 = reader.ReadInt();
                        return true;

                    case ItemChunk.TwoHanded:
                        TwoHanded = reader.ReadBool();
                        return true;

                    case ItemChunk.SpCost:
                        SpCost = reader.ReadInt();
                        return true;

                    case ItemChunk.Hit:
                        Hit = reader.ReadInt();
                        return true;

                    case ItemChunk.CriticalHit:
                        CriticalHit = reader.ReadInt();
                        return true;

                    case ItemChunk.AnimationId:
                        AnimationID = reader.ReadInt();
                        return true;

                    case ItemChunk.Preemptive:
                        Preemptive = reader.ReadBool();
                        return true;

                    case ItemChunk.DualAttack:
                        DualAttack = reader.ReadBool();
                        return true;

                    case ItemChunk.AttackAll:
                        AttackAll = reader.ReadBool();
                        return true;

                    case ItemChunk.IgnoreEvasion:
                        IgnoreEvasion = reader.ReadBool();
                        return true;

                    case ItemChunk.PreventCritical:
                        PreventCritical = reader.ReadBool();
                        return true;

                    case ItemChunk.RaiseEvasion:
                        RaiseEvasion = reader.ReadBool();
                        return true;

                    case ItemChunk.HalfSpCost:
                        HalfSpCost = reader.ReadBool();
                        return true;

                    case ItemChunk.NoTerrainDamage:
                        NoTerrainDamage = reader.ReadBool();
                        return true;

                    case ItemChunk.Cursed:
                        if (!Database.IsRM2K3)
                            return false;
                        Cursed = reader.ReadBool();
                        return true;

                    case ItemChunk.EntireParty:
                        EntireParty = reader.ReadBool();
                        return true;

                    case ItemChunk.RecoverHpRate:
                        RecoverHpRate = reader.ReadInt();
                        return true;

                    case ItemChunk.RecoverHp:
                        RecoverHp = reader.ReadInt();
                        return true;

                    case ItemChunk.RecoverSpRate:
                        RecoverSpRate = reader.ReadInt();
                        return true;

                    case ItemChunk.RecoverSp:
                        RecoverSp = reader.ReadInt();
                        return true;

                    case ItemChunk.OccasionField1:
                        OccasionField1 = reader.ReadBool();
                        return true;

                    case ItemChunk.KoOnly:
                        KoOnly = reader.ReadBool();
                        return true;

                    case ItemChunk.MaxHpPoints:
                        MaxHpPoints = reader.ReadInt();
                        return true;

                    case ItemChunk.MaxSpPoints:
                        MaxSpPoints = reader.ReadInt();
                        return true;

                    case ItemChunk.AtkPoints2:
                        AtkPoints2 = reader.ReadInt();
                        return true;

                    case ItemChunk.DefPoints2:
                        DefPoints2 = reader.ReadInt();
                        return true;

                    case ItemChunk.SpiPoints2:
                        SpiPoints2 = reader.ReadInt();
                        return true;

                    case ItemChunk.AgiPoints2:
                        AgiPoints2 = reader.ReadInt();
                        return true;

                    case ItemChunk.UsingMessage:
                        UsingMessage = reader.ReadInt();
                        return true;

                    case ItemChunk.SkillId:
                        SkillID = reader.ReadInt();
                        return true;

                    case ItemChunk.SwitchId:
                        SwitchID = reader.ReadInt();
                        return true;

                    case ItemChunk.OccasionField2:
                        OccasionField2 = reader.ReadBool();
                        return true;

                    case ItemChunk.OccasionBattle:
                        OccasionBattle = reader.ReadBool();
                        return true;

                    case ItemChunk.ActorSetSize:
                        actorSetSize = reader.ReadInt();
                        return true;

                    case ItemChunk.ActorSet:
                        if (actorSetSize > 0)
                        { 
                            ActorSet = reader.ReadBitArray(actorSetSize);
                            return true;
                        }
                        break;

                    case ItemChunk.StateSetSize:
                        stateSetSize = reader.ReadInt();
                        return true;

                    case ItemChunk.StateSet:
                        if (stateSetSize > 0)
                        {
                            StateSet = reader.ReadBitArray(stateSetSize);
                            return true;
                        }
                        break;

                    case ItemChunk.AttributeSetSize:
                        attributeSetSize = reader.ReadInt();
                        return true;

                    case ItemChunk.AttributeSet:
                        if (attributeSetSize > 0)
                        {
                            AttributeSet = reader.ReadBitArray(attributeSetSize);
                            return true;
                        }
                        break;

                    case ItemChunk.StateChance:
                        StateChance = reader.ReadInt();
                        return true;

                    case ItemChunk.ReverseStateEffect:
                        ReverseStateEffect = reader.ReadBool();
                        return true;

                    case ItemChunk.WeaponAnimation:
                        if (!Database.IsRM2K3)
                            return false;
                        WeaponAnimation = reader.ReadInt();
                        return true;

                    case ItemChunk.AnimationData:
                        if (!Database.IsRM2K3)
                            return false;
                        AnimationData = new List<BattlerAnimationItemSkill>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            AnimationData.Add(new BattlerAnimationItemSkill(reader));
                        });
                        return true;

                    case ItemChunk.UseSkill:
                        if (!Database.IsRM2K3)
                            return false;
                        UseSkill = reader.ReadBool();
                        return true;

                    case ItemChunk.ClassSetSize:
                        if (!Database.IsRM2K3)
                            return false;
                        classSetSize = reader.ReadInt();
                        return true;

                    case ItemChunk.ClassSet:
                        if (!Database.IsRM2K3)
                            return false;
                        if (classSetSize > 0)
                        {
                            ClassSet = reader.ReadBitArray(classSetSize);
                            return true;
                        }
                        break;

                    case ItemChunk.RangedTrajectory:
                        RangedTrajectory = (ItemTrajectory)reader.ReadInt();
                        return true;

                    case ItemChunk.RangedTarget:
                        RangedTarget = (ItemTarget)reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}