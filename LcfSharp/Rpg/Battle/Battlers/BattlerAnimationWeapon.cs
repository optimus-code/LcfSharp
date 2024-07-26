using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Battle.Battlers
{
    public enum BattlerAnimationWeaponChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        WeaponName = 0x02,
        /** Integer */
        WeaponIndex = 0x03
    }

    [LcfChunk<BattlerAnimationWeaponChunk>]
    public class BattlerAnimationWeapon
    {
        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        } = 0;

        public string Name
        {
            get;
            set;
        }

        public string WeaponName
        {
            get;
            set;
        }

        [XmlAttribute]
        public int WeaponIndex
        {
            get;
            set;
        } = 0;
    }
}