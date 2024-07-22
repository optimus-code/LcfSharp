using LcfSharp.IO;
using LcfSharp.Rpg.Troops;
using LcfSharp.Types;

namespace LcfSharp.Rpg
{
    public enum TermsChunk : int
    {
        /** String */
        Encounter = 0x01,
        /** String */
        SpecialCombat = 0x02,
        /** String */
        EscapeSuccess = 0x03,
        /** String */
        EscapeFailure = 0x04,
        /** String */
        Victory = 0x05,
        /** String */
        Defeat = 0x06,
        /** String */
        ExpReceived = 0x07,
        /** String */
        GoldReceivedA = 0x08,
        /** String */
        GoldReceivedB = 0x09,
        /** String */
        ItemReceived = 0x0A,
        /** String */
        Attacking = 0x0B,
        /** String */
        EnemyCritical = 0x0C,
        /** String */
        ActorCritical = 0x0D,
        /** String */
        Defending = 0x0E,
        /** String */
        Observing = 0x0F,
        /** String */
        Focus = 0x10,
        /** String */
        Autodestruction = 0x11,
        /** String */
        EnemyEscape = 0x12,
        /** String */
        EnemyTransform = 0x13,
        /** String */
        EnemyDamaged = 0x14,
        /** String */
        EnemyUndamaged = 0x15,
        /** String */
        ActorDamaged = 0x16,
        /** String */
        ActorUndamaged = 0x17,
        /** String */
        SkillFailureA = 0x18,
        /** String */
        SkillFailureB = 0x19,
        /** String */
        SkillFailureC = 0x1A,
        /** String */
        Dodge = 0x1B,
        /** String */
        UseItem = 0x1C,
        /** String */
        HpRecovery = 0x1D,
        /** String */
        ParameterIncrease = 0x1E,
        /** String */
        ParameterDecrease = 0x1F,
        /** String */
        EnemyHpAbsorbed = 0x20,
        /** String */
        ActorHpAbsorbed = 0x21,
        /** String */
        ResistanceIncrease = 0x22,
        /** String */
        ResistanceDecrease = 0x23,
        /** String */
        LevelUp = 0x24,
        /** String */
        SkillLearned = 0x25,
        /** String */
        BattleStart = 0x26,
        /** String */
        Miss = 0x27,
        /** String */
        ShopGreeting1 = 0x29,
        /** String */
        ShopRegreeting1 = 0x2A,
        /** String */
        ShopBuy1 = 0x2B,
        /** String */
        ShopSell1 = 0x2C,
        /** String */
        ShopLeave1 = 0x2D,
        /** String */
        ShopBuySelect1 = 0x2E,
        /** String */
        ShopBuyNumber1 = 0x2F,
        /** String */
        ShopPurchased1 = 0x30,
        /** String */
        ShopSellSelect1 = 0x31,
        /** String */
        ShopSellNumber1 = 0x32,
        /** String */
        ShopSold1 = 0x33,
        /** String */
        ShopGreeting2 = 0x36,
        /** String */
        ShopRegreeting2 = 0x37,
        /** String */
        ShopBuy2 = 0x38,
        /** String */
        ShopSell2 = 0x39,
        /** String */
        ShopLeave2 = 0x3A,
        /** String */
        ShopBuySelect2 = 0x3B,
        /** String */
        ShopBuyNumber2 = 0x3C,
        /** String */
        ShopPurchased2 = 0x3D,
        /** String */
        ShopSellSelect2 = 0x3E,
        /** String */
        ShopSellNumber2 = 0x3F,
        /** String */
        ShopSold2 = 0x40,
        /** String */
        ShopGreeting3 = 0x43,
        /** String */
        ShopRegreeting3 = 0x44,
        /** String */
        ShopBuy3 = 0x45,
        /** String */
        ShopSell3 = 0x46,
        /** String */
        ShopLeave3 = 0x47,
        /** String */
        ShopBuySelect3 = 0x48,
        /** String */
        ShopBuyNumber3 = 0x49,
        /** String */
        ShopPurchased3 = 0x4A,
        /** String */
        ShopSellSelect3 = 0x4B,
        /** String */
        ShopSellNumber3 = 0x4C,
        /** String */
        ShopSold3 = 0x4D,
        /** String */
        InnAGreeting1 = 0x50,
        /** String */
        InnAGreeting2 = 0x51,
        /** String */
        InnAGreeting3 = 0x52,
        /** String */
        InnAAccept = 0x53,
        /** String */
        InnACancel = 0x54,
        /** String */
        InnBGreeting1 = 0x55,
        /** String */
        InnBGreeting2 = 0x56,
        /** String */
        InnBGreeting3 = 0x57,
        /** String */
        InnBAccept = 0x58,
        /** String */
        InnBCancel = 0x59,
        /** String */
        PossessedItems = 0x5C,
        /** String */
        EquippedItems = 0x5D,
        /** String */
        Gold = 0x5F,
        /** String */
        BattleFight = 0x65,
        /** String */
        BattleAuto = 0x66,
        /** String */
        BattleEscape = 0x67,
        /** String */
        CommandAttack = 0x68,
        /** String */
        CommandDefend = 0x69,
        /** String */
        CommandItem = 0x6A,
        /** String */
        CommandSkill = 0x6B,
        /** String */
        MenuEquipment = 0x6C,
        /** String */
        MenuSave = 0x6E,
        /** String */
        MenuQuit = 0x70,
        /** String */
        NewGame = 0x72,
        /** String */
        LoadGame = 0x73,
        /** String */
        ExitGame = 0x75,
        /** String */
        Status = 0x76,
        /** String */
        Row = 0x77,
        /** String */
        Order = 0x78,
        /** String */
        WaitOn = 0x79,
        /** String */
        WaitOff = 0x7A,
        /** String */
        Level = 0x7B,
        /** String */
        HealthPoints = 0x7C,
        /** String */
        SpiritPoints = 0x7D,
        /** String */
        NormalStatus = 0x7E,
        /** String - char x 2? */
        ExpShort = 0x7F,
        /** String - char x 2? */
        LvlShort = 0x80,
        /** String - char x 2? */
        HpShort = 0x81,
        /** String - char x 2? */
        SpShort = 0x82,
        /** String */
        SpCost = 0x83,
        /** String */
        Attack = 0x84,
        /** String */
        Defense = 0x85,
        /** String */
        Spirit = 0x86,
        /** String */
        Agility = 0x87,
        /** String */
        Weapon = 0x88,
        /** String */
        Shield = 0x89,
        /** String */
        Armor = 0x8A,
        /** String */
        Helmet = 0x8B,
        /** String */
        Accessory = 0x8C,
        /** String */
        SaveGameMessage = 0x92,
        /** String */
        LoadGameMessage = 0x93,
        /** String */
        File = 0x94,
        /** String */
        ExitGameMessage = 0x97,
        /** String */
        Yes = 0x98,
        /** String */
        No = 0x99
    }

    public class Terms
    {
        // Sentinel name used to denote that the default hardcoded term should be used.
        public const string DefaultTerm = "default_term";

        public static string TermOrDefault(DbString dbTerm, string defaultTerm)
        {
            return dbTerm.ToString() ?? defaultTerm;
        }

        public DbString Encounter
        {
            get;
            set;
        }

        public DbString SpecialCombat
        {
            get;
            set;
        }

        public DbString EscapeSuccess
        {
            get;
            set;
        }

        public DbString EscapeFailure
        {
            get;
            set;
        }

        public DbString Victory
        {
            get;
            set;
        }

        public DbString Defeat
        {
            get;
            set;
        }

        public DbString ExpReceived
        {
            get;
            set;
        }

        public DbString GoldReceivedA
        {
            get;
            set;
        }

        public DbString GoldReceivedB
        {
            get;
            set;
        }

        public DbString ItemReceived
        {
            get;
            set;
        }

        public DbString Attacking
        {
            get;
            set;
        }

        public DbString EnemyCritical
        {
            get;
            set;
        }

        public DbString ActorCritical
        {
            get;
            set;
        }

        public DbString Defending
        {
            get;
            set;
        }

        public DbString Observing
        {
            get;
            set;
        }

        public DbString Focus
        {
            get;
            set;
        }

        public DbString Autodestruction
        {
            get;
            set;
        }

        public DbString EnemyEscape
        {
            get;
            set;
        }

        public DbString EnemyTransform
        {
            get;
            set;
        }

        public DbString EnemyDamaged
        {
            get;
            set;
        }

        public DbString EnemyUndamaged
        {
            get;
            set;
        }

        public DbString ActorDamaged
        {
            get;
            set;
        }

        public DbString ActorUndamaged
        {
            get;
            set;
        }

        public DbString SkillFailureA
        {
            get;
            set;
        }

        public DbString SkillFailureB
        {
            get;
            set;
        }

        public DbString SkillFailureC
        {
            get;
            set;
        }

        public DbString Dodge
        {
            get;
            set;
        }

        public DbString UseItem
        {
            get;
            set;
        }

        public DbString HpRecovery
        {
            get;
            set;
        }

        public DbString ParameterIncrease
        {
            get;
            set;
        }

        public DbString ParameterDecrease
        {
            get;
            set;
        }

        public DbString EnemyHpAbsorbed
        {
            get;
            set;
        }

        public DbString ActorHpAbsorbed
        {
            get;
            set;
        }

        public DbString ResistanceIncrease
        {
            get;
            set;
        }

        public DbString ResistanceDecrease
        {
            get;
            set;
        }

        public DbString LevelUp
        {
            get;
            set;
        }

        public DbString SkillLearned
        {
            get;
            set;
        }

        public DbString BattleStart
        {
            get;
            set;
        }

        public DbString Miss
        {
            get;
            set;
        }

        public DbString ShopGreeting1
        {
            get;
            set;
        }

        public DbString ShopRegreeting1
        {
            get;
            set;
        }

        public DbString ShopBuy1
        {
            get;
            set;
        }

        public DbString ShopSell1
        {
            get;
            set;
        }

        public DbString ShopLeave1
        {
            get;
            set;
        }

        public DbString ShopBuySelect1
        {
            get;
            set;
        }

        public DbString ShopBuyNumber1
        {
            get;
            set;
        }

        public DbString ShopPurchased1
        {
            get;
            set;
        }

        public DbString ShopSellSelect1
        {
            get;
            set;
        }

        public DbString ShopSellNumber1
        {
            get;
            set;
        }

        public DbString ShopSold1
        {
            get;
            set;
        }

        public DbString ShopGreeting2
        {
            get;
            set;
        }

        public DbString ShopRegreeting2
        {
            get;
            set;
        }

        public DbString ShopBuy2
        {
            get;
            set;
        }

        public DbString ShopSell2
        {
            get;
            set;
        }

        public DbString ShopLeave2
        {
            get;
            set;
        }

        public DbString ShopBuySelect2
        {
            get;
            set;
        }

        public DbString ShopBuyNumber2
        {
            get;
            set;
        }

        public DbString ShopPurchased2
        {
            get;
            set;
        }

        public DbString ShopSellSelect2
        {
            get;
            set;
        }

        public DbString ShopSellNumber2
        {
            get;
            set;
        }

        public DbString ShopSold2
        {
            get;
            set;
        }

        public DbString ShopGreeting3
        {
            get;
            set;
        }

        public DbString ShopRegreeting3
        {
            get;
            set;
        }

        public DbString ShopBuy3
        {
            get;
            set;
        }

        public DbString ShopSell3
        {
            get;
            set;
        }

        public DbString ShopLeave3
        {
            get;
            set;
        }

        public DbString ShopBuySelect3
        {
            get;
            set;
        }

        public DbString ShopBuyNumber3
        {
            get;
            set;
        }

        public DbString ShopPurchased3
        {
            get;
            set;
        }

        public DbString ShopSellSelect3
        {
            get;
            set;
        }

        public DbString ShopSellNumber3
        {
            get;
            set;
        }

        public DbString ShopSold3
        {
            get;
            set;
        }

        public DbString InnAGreeting1
        {
            get;
            set;
        }

        public DbString InnAGreeting2
        {
            get;
            set;
        }

        public DbString InnAGreeting3
        {
            get;
            set;
        }

        public DbString InnAAccept
        {
            get;
            set;
        }

        public DbString InnACancel
        {
            get;
            set;
        }

        public DbString InnBGreeting1
        {
            get;
            set;
        }

        public DbString InnBGreeting2
        {
            get;
            set;
        }

        public DbString InnBGreeting3
        {
            get;
            set;
        }

        public DbString InnBAccept
        {
            get;
            set;
        }

        public DbString InnBCancel
        {
            get;
            set;
        }

        public DbString PossessedItems
        {
            get;
            set;
        }

        public DbString EquippedItems
        {
            get;
            set;
        }

        public DbString Gold
        {
            get;
            set;
        }

        public DbString BattleFight
        {
            get;
            set;
        }

        public DbString BattleAuto
        {
            get;
            set;
        }

        public DbString BattleEscape
        {
            get;
            set;
        }

        public DbString CommandAttack
        {
            get;
            set;
        }

        public DbString CommandDefend
        {
            get;
            set;
        }

        public DbString CommandItem
        {
            get;
            set;
        }

        public DbString CommandSkill
        {
            get;
            set;
        }

        public DbString MenuEquipment
        {
            get;
            set;
        }

        public DbString MenuSave
        {
            get;
            set;
        }

        public DbString MenuQuit
        {
            get;
            set;
        }

        public DbString NewGame
        {
            get;
            set;
        }

        public DbString LoadGame
        {
            get;
            set;
        }

        public DbString ExitGame
        {
            get;
            set;
        }

        public DbString Status
        {
            get;
            set;
        }

        public DbString Row
        {
            get;
            set;
        }

        public DbString Order
        {
            get;
            set;
        }

        public DbString WaitOn
        {
            get;
            set;
        }

        public DbString WaitOff
        {
            get;
            set;
        }

        public DbString Level
        {
            get;
            set;
        }

        public DbString HealthPoints
        {
            get;
            set;
        }

        public DbString SpiritPoints
        {
            get;
            set;
        }

        public DbString NormalStatus
        {
            get;
            set;
        }

        public DbString ExpShort
        {
            get;
            set;
        }

        public DbString LvlShort
        {
            get;
            set;
        }

        public DbString HpShort
        {
            get;
            set;
        }

        public DbString SpShort
        {
            get;
            set;
        }

        public DbString SpCost
        {
            get;
            set;
        }

        public DbString Attack
        {
            get;
            set;
        }

        public DbString Defense
        {
            get;
            set;
        }

        public DbString Spirit
        {
            get;
            set;
        }

        public DbString Agility
        {
            get;
            set;
        }

        public DbString Weapon
        {
            get;
            set;
        }

        public DbString Shield
        {
            get;
            set;
        }

        public DbString Armor
        {
            get;
            set;
        }

        public DbString Helmet
        {
            get;
            set;
        }

        public DbString Accessory
        {
            get;
            set;
        }

        public DbString SaveGameMessage
        {
            get;
            set;
        }

        public DbString LoadGameMessage
        {
            get;
            set;
        }

        public DbString File
        {
            get;
            set;
        }

        public DbString ExitGameMessage
        {
            get;
            set;
        }

        public DbString Yes
        {
            get;
            set;
        }

        public DbString No
        {
            get;
            set;
        }

        public Terms(LcfReader reader)
        {
            TypeHelpers.ReadChunks<TermsChunk>(reader, (chunk) =>
            {
                switch ((TermsChunk)chunk.ID)
                {
                    case TermsChunk.Encounter:
                        Encounter = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.SpecialCombat:
                        SpecialCombat = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.EscapeSuccess:
                        EscapeSuccess = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.EscapeFailure:
                        EscapeFailure = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Victory:
                        Victory = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Defeat:
                        Defeat = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ExpReceived:
                        ExpReceived = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.GoldReceivedA:
                        GoldReceivedA = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.GoldReceivedB:
                        GoldReceivedB = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ItemReceived:
                        ItemReceived = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Attacking:
                        Attacking = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.EnemyCritical:
                        EnemyCritical = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ActorCritical:
                        ActorCritical = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Defending:
                        Defending = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Observing:
                        Observing = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Focus:
                        Focus = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Autodestruction:
                        Autodestruction = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.EnemyEscape:
                        EnemyEscape = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.EnemyTransform:
                        EnemyTransform = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.EnemyDamaged:
                        EnemyDamaged = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.EnemyUndamaged:
                        EnemyUndamaged = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ActorDamaged:
                        ActorDamaged = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ActorUndamaged:
                        ActorUndamaged = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.SkillFailureA:
                        SkillFailureA = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.SkillFailureB:
                        SkillFailureB = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.SkillFailureC:
                        SkillFailureC = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Dodge:
                        Dodge = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.UseItem:
                        UseItem = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.HpRecovery:
                        HpRecovery = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ParameterIncrease:
                        ParameterIncrease = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ParameterDecrease:
                        ParameterDecrease = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.EnemyHpAbsorbed:
                        EnemyHpAbsorbed = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ActorHpAbsorbed:
                        ActorHpAbsorbed = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ResistanceIncrease:
                        ResistanceIncrease = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ResistanceDecrease:
                        ResistanceDecrease = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.LevelUp:
                        LevelUp = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.SkillLearned:
                        SkillLearned = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.BattleStart:
                        BattleStart = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Miss:
                        Miss = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopGreeting1:
                        ShopGreeting1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopRegreeting1:
                        ShopRegreeting1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopBuy1:
                        ShopBuy1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSell1:
                        ShopSell1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopLeave1:
                        ShopLeave1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopBuySelect1:
                        ShopBuySelect1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopBuyNumber1:
                        ShopBuyNumber1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopPurchased1:
                        ShopPurchased1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSellSelect1:
                        ShopSellSelect1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSellNumber1:
                        ShopSellNumber1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSold1:
                        ShopSold1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopGreeting2:
                        ShopGreeting2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopRegreeting2:
                        ShopRegreeting2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopBuy2:
                        ShopBuy2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSell2:
                        ShopSell2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopLeave2:
                        ShopLeave2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopBuySelect2:
                        ShopBuySelect2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopBuyNumber2:
                        ShopBuyNumber2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopPurchased2:
                        ShopPurchased2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSellSelect2:
                        ShopSellSelect2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSellNumber2:
                        ShopSellNumber2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSold2:
                        ShopSold2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopGreeting3:
                        ShopGreeting3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopRegreeting3:
                        ShopRegreeting3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopBuy3:
                        ShopBuy3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSell3:
                        ShopSell3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopLeave3:
                        ShopLeave3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopBuySelect3:
                        ShopBuySelect3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopBuyNumber3:
                        ShopBuyNumber3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopPurchased3:
                        ShopPurchased3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSellSelect3:
                        ShopSellSelect3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSellNumber3:
                        ShopSellNumber3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ShopSold3:
                        ShopSold3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.InnAGreeting1:
                        InnAGreeting1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.InnAGreeting2:
                        InnAGreeting2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.InnAGreeting3:
                        InnAGreeting3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.InnAAccept:
                        InnAAccept = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.InnACancel:
                        InnACancel = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.InnBGreeting1:
                        InnBGreeting1 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.InnBGreeting2:
                        InnBGreeting2 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.InnBGreeting3:
                        InnBGreeting3 = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.InnBAccept:
                        InnBAccept = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.InnBCancel:
                        InnBCancel = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.PossessedItems:
                        PossessedItems = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.EquippedItems:
                        EquippedItems = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Gold:
                        Gold = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.BattleFight:
                        BattleFight = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.BattleAuto:
                        BattleAuto = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.BattleEscape:
                        BattleEscape = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.CommandAttack:
                        CommandAttack = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.CommandDefend:
                        CommandDefend = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.CommandItem:
                        CommandItem = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.CommandSkill:
                        CommandSkill = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.MenuEquipment:
                        MenuEquipment = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.MenuSave:
                        MenuSave = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.MenuQuit:
                        MenuQuit = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.NewGame:
                        NewGame = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.LoadGame:
                        LoadGame = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ExitGame:
                        ExitGame = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Status:
                        Status = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Row:
                        Row = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Order:
                        Order = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.WaitOn:
                        WaitOn = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.WaitOff:
                        WaitOff = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Level:
                        Level = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.HealthPoints:
                        HealthPoints = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.SpiritPoints:
                        SpiritPoints = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.NormalStatus:
                        NormalStatus = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ExpShort:
                        ExpShort = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.LvlShort:
                        LvlShort = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.HpShort:
                        HpShort = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.SpShort:
                        SpShort = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.SpCost:
                        SpCost = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Attack:
                        Attack = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Defense:
                        Defense = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Spirit:
                        Spirit = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Agility:
                        Agility = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Weapon:
                        Weapon = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Shield:
                        Shield = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Armor:
                        Armor = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Helmet:
                        Helmet = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Accessory:
                        Accessory = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.SaveGameMessage:
                        SaveGameMessage = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.LoadGameMessage:
                        LoadGameMessage = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.File:
                        File = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.ExitGameMessage:
                        ExitGameMessage = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.Yes:
                        Yes = reader.ReadDbString(chunk.Length);
                        return true;

                    case TermsChunk.No:
                        No = reader.ReadDbString(chunk.Length);
                        return true;
                }
                return false;
            });
        }
    }
}