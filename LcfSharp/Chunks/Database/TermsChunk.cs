/// <copyright>
/// 
/// LcfSharp Copyright (c) 2024 optimus-code
/// (A "loose" .NET port of liblcf)
/// Licensed under the MIT License.
/// 
/// Copyright (c) 2014-2023 liblcf authors
/// Licensed under the MIT License.
/// 
/// Permission is hereby granted, free of charge, to any person obtaining
/// a copy of this software and associated documentation files (the
/// "Software"), to deal in the Software without restriction, including
/// without limitation the rights to use, copy, modify, merge, publish,
/// distribute, sublicense, and/or sell copies of the Software, and to
/// permit persons to whom the Software is furnished to do so, subject to
/// the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included
/// in all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
/// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
/// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
/// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
/// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
/// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
/// </copyright>

namespace LcfSharp.Chunks.Database
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
}
