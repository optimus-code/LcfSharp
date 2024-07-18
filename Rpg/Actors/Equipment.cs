using System;

namespace LcfSharp.Rpg.Actors
{
    public class Equipment
    {
        public short WeaponID
        {
            get;
            set;
        } = 0;

        public short ShieldID
        {
            get;
            set;
        } = 0;

        public short ArmorID
        {
            get;
            set;
        } = 0;

        public short HelmetID
        {
            get;
            set;
        } = 0;

        public short AccessoryID
        {
            get;
            set;
        } = 0;

        public static bool operator ==(Equipment left, Equipment right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.WeaponID == right.WeaponID &&
                   left.ShieldID == right.ShieldID &&
                   left.ArmorID == right.ArmorID &&
                   left.HelmetID == right.HelmetID &&
                   left.AccessoryID == right.AccessoryID;
        }

        public static bool operator !=(Equipment left, Equipment right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is Equipment other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(WeaponID, ShieldID, ArmorID, HelmetID, AccessoryID);
        }

        public override string ToString()
        {
            return $"WeaponID: {WeaponID}, ShieldID: {ShieldID}, ArmorID: {ArmorID}, HelmetID: {HelmetID}, AccessoryID: {AccessoryID}";
        }
    }
}
