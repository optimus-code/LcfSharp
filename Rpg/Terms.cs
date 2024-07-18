using LcfSharp.Types;

namespace LcfSharp.Rpg
{
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
    }
}
