using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Troops;
using LcfSharp.IO.Types;

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

    [LcfChunk<TermsChunk>]
    public class Terms
    {
		[LcfAlwaysPersistAttribute]
		public string Encounter
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string SpecialCombat
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string EscapeSuccess
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string EscapeFailure
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Victory
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Defeat
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ExpReceived
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string GoldReceivedA
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string GoldReceivedB
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ItemReceived
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Attacking
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string EnemyCritical
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ActorCritical
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Defending
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Observing
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Focus
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Autodestruction
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string EnemyEscape
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string EnemyTransform
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string EnemyDamaged
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string EnemyUndamaged
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ActorDamaged
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ActorUndamaged
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string SkillFailureA
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string SkillFailureB
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string SkillFailureC
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Dodge
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string UseItem
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string HpRecovery
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ParameterIncrease
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ParameterDecrease
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string EnemyHpAbsorbed
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ActorHpAbsorbed
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ResistanceIncrease
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ResistanceDecrease
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string LevelUp
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string SkillLearned
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
		[LcfAlwaysPersistAttribute]
		public string BattleStart
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
		public string Miss
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopGreeting1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopRegreeting1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopBuy1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSell1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopLeave1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopBuySelect1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopBuyNumber1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopPurchased1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSellSelect1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSellNumber1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSold1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopGreeting2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopRegreeting2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopBuy2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSell2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopLeave2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopBuySelect2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopBuyNumber2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopPurchased2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSellSelect2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSellNumber2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSold2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopGreeting3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopRegreeting3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopBuy3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSell3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopLeave3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopBuySelect3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopBuyNumber3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopPurchased3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSellSelect3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSellNumber3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ShopSold3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string InnAGreeting1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string InnAGreeting2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string InnAGreeting3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string InnAAccept
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string InnACancel
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string InnBGreeting1
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string InnBGreeting2
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string InnBGreeting3
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string InnBAccept
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string InnBCancel
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string PossessedItems
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string EquippedItems
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Gold
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string BattleFight
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string BattleAuto
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string BattleEscape
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string CommandAttack
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string CommandDefend
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string CommandItem
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string CommandSkill
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string MenuEquipment
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string MenuSave
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string MenuQuit
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string NewGame
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string LoadGame
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ExitGame
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
		public string Status
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
		public string Row
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
		public string Order
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
		public string WaitOn
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
		public string WaitOff
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Level
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string HealthPoints
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string SpiritPoints
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string NormalStatus
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ExpShort
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string LvlShort
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string HpShort
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string SpShort
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string SpCost
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Attack
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Defense
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Spirit
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Agility
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Weapon
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Shield
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Armor
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Helmet
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Accessory
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string SaveGameMessage
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string LoadGameMessage
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string File
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string ExitGameMessage
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string Yes
        {
            get;
            set;
        }

		[LcfAlwaysPersistAttribute]
		public string No
        {
            get;
            set;
        }
    }
}