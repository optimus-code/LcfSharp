using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Enemies
{
    public class Enemy
    {
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

        public List<byte> StateRanks
        {
            get;
            set;
        }

        public List<byte> AttributeRanks
        {
            get;
            set;
        }

        public List<EnemyAction> Actions
        {
            get;
            set;
        }

        public int ManiacUnarmedAnimation
        {
            get;
            set;
        }
    }
}