using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Actors;
using LcfSharp.Rpg.Shared;
using LcfSharp.IO.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Enemies
{
    public enum EnemyChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        BattlerName = 0x02,
        /** Integer */
        BattlerHue = 0x03,
        /** Integer */
        MaxHP = 0x04,
        /** Integer */
        MaxSP = 0x05,
        /** Integer */
        Attack = 0x06,
        /** Integer */
        Defense = 0x07,
        /** Integer */
        Spirit = 0x08,
        /** Integer */
        Agility = 0x09,
        /** Flag */
        Transparent = 0x0A,
        /** Integer */
        Exp = 0x0B,
        /** Integer */
        Gold = 0x0C,
        /** Integer */
        DropID = 0x0D,
        /** Integer */
        DropProb = 0x0E,
        /** Flag */
        CriticalHit = 0x15,
        /** Integer */
        CriticalHitChance = 0x16,
        /** Flag */
        Miss = 0x1A,
        /** Flag */
        Levitate = 0x1C,
        /** Integer */
        StateRanksSize = 0x1F,
        /** Array - Short */
        StateRanks = 0x20,
        /** Integer */
        AttributeRanksSize = 0x21,
        /** Array - Short */
        AttributeRanks = 0x22,
        /** Array - rpg::EnemyAction */
        Actions = 0x2A
    }

    [LcfChunk<EnemyChunk>]
    public class Enemy
    {
        [LcfID]
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

        public DbString BattlerName
        {
            get;
            set;
        }

        public int BattlerHue
        {
            get;
            set;
        }

        public int MaxHP
        {
            get;
            set;
        }

        public int MaxSP
        {
            get;
            set;
        }

        public int Attack
        {
            get;
            set;
        }

        public int Defense
        {
            get;
            set;
        }

        public int Spirit
        {
            get;
            set;
        }

        public int Agility
        {
            get;
            set;
        }

        public bool Transparent
        {
            get;
            set;
        }

        public int Exp
        {
            get;
            set;
        }

        public int Gold
        {
            get;
            set;
        }

        public int DropID
        {
            get;
            set;
        }

        public int DropProb
        {
            get;
            set;
        }

        public bool CriticalHit
        {
            get;
            set;
        }

        public int CriticalHitChance
        {
            get;
            set;
        }

        public bool Miss
        {
            get;
            set;
        }

        public bool Levitate
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)EnemyChunk.StateRanksSize)]
        public List<byte> StateRanks
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)EnemyChunk.AttributeRanksSize)]
        public List<byte> AttributeRanks
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public List<EnemyAction> Actions
        {
            get;
            set;
        }
    }
}