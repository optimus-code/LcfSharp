using LcfSharp.IO;
using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg
{
    public enum TestBattlerChunk : int
    {
        /** Integer */
        ActorID = 0x01,
        /** Integer */
        Level = 0x02,
        /** Integer */
        WeaponID = 0x0B,
        /** Integer */
        ShieldID = 0x0C,
        /** Integer */
        ArmorID = 0x0D,
        /** Integer */
        HelmetID = 0x0E,
        /** Integer */
        AccessoryID = 0x0F
    }

    [LcfChunk<TestBattlerChunk>]
    public class TestBattler
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        } = 0;

        public int ActorID
        {
            get;
            set;
        } = 1;

        public int Level
        {
            get;
            set;
        } = 1;

        public int WeaponID
        {
            get;
            set;
        } = 0;

        public int ShieldID
        {
            get;
            set;
        } = 0;

        public int ArmorID
        {
            get;
            set;
        } = 0;

        public int HelmetID
        {
            get;
            set;
        } = 0;

        public int AccessoryID
        {
            get;
            set;
        } = 0;
    }
}