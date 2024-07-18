using System.Collections.Generic;
using System;

namespace LcfSharp.Skills
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

        public int ID { get; set; } = 0;
        public int Unknown02 { get; set; } = 0;
        public AnimType Type { get; set; } = AnimType.Weapon;
        public int WeaponAnimationId { get; set; } = 0;
        public Movement MovementType { get; set; } = Movement.None;
        public Afterimage AfterImage { get; set; } = Afterimage.None;
        public int Attacks { get; set; } = 0;
        public bool Ranged { get; set; } = false;
        public int RangedAnimationId { get; set; } = 0;
        public Speed RangedSpeed { get; set; } = Speed.Fast;
        public int BattleAnimationId { get; set; } = 1;
        public int Pose { get; set; } = 3;

        public override bool Equals( object obj )
        {
            return obj is BattlerAnimationItemSkill skill &&
                   Unknown02 == skill.Unknown02 &&
                   Type == skill.Type &&
                   WeaponAnimationId == skill.WeaponAnimationId &&
                   MovementType == skill.MovementType &&
                   AfterImage == skill.AfterImage &&
                   Attacks == skill.Attacks &&
                   Ranged == skill.Ranged &&
                   RangedAnimationId == skill.RangedAnimationId &&
                   RangedSpeed == skill.RangedSpeed &&
                   BattleAnimationId == skill.BattleAnimationId &&
                   Pose == skill.Pose;
        }

        public override int GetHashCode( )
        {
            return HashCode.Combine( Unknown02, Type, WeaponAnimationId, MovementType, AfterImage, Attacks, Ranged, RangedAnimationId, RangedSpeed, BattleAnimationId, Pose );
        }

        public override string ToString( )
        {
            return $"{nameof( Type )}: {Type}, {nameof( MovementType )}: {MovementType}, {nameof( AfterImage )}: {AfterImage}, {nameof( RangedSpeed )}: {RangedSpeed}";
        }

        public static bool operator ==( BattlerAnimationItemSkill left, BattlerAnimationItemSkill right )
        {
            return EqualityComparer<BattlerAnimationItemSkill>.Default.Equals( left, right );
        }

        public static bool operator !=( BattlerAnimationItemSkill left, BattlerAnimationItemSkill right )
        {
            return !( left == right );
        }
    }
}
