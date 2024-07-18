namespace LcfSharp.Rpg.Shared
{
    public class BattlerAnimationItemSkill
    {
        public enum Speed
        {
            Fast = 0,
            Medium = 1,
            Slow = 2
        }

        public enum AnimType
        {
            Weapon = 0,
            Battle = 1
        }

        public enum Movement
        {
            None = 0,
            Step = 1,
            Jump = 2,
            Move = 3
        }

        public enum Afterimage
        {
            None = 0,
            Add = 1
        }

        public int ID
        {
            get;
            set;
        }

        public int Unknown02
        {
            get;
            set;
        }

        public AnimType Type
        {
            get;
            set;
        }

        public int WeaponAnimationID
        {
            get;
            set;
        }

        public Movement MovementType
        {
            get;
            set;
        }

        public Afterimage AfterImage
        {
            get;
            set;
        }

        public int Attacks
        {
            get;
            set;
        }

        public bool Ranged
        {
            get;
            set;
        }

        public int RangedAnimationID
        {
            get;
            set;
        }

        public Speed RangedSpeed
        {
            get;
            set;
        }

        public int BattleAnimationID
        {
            get;
            set;
        }

        public int Pose
        {
            get;
            set;
        }
    }
}