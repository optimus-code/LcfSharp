using LcfSharp.IO;

namespace LcfSharp.Rpg
{
    public enum TestBattlerChunk : int
    {
        /** Integer */
        ActorId = 0x01,
        /** Integer */
        Level = 0x02,
        /** Integer */
        WeaponId = 0x0B,
        /** Integer */
        ShieldId = 0x0C,
        /** Integer */
        ArmorId = 0x0D,
        /** Integer */
        HelmetId = 0x0E,
        /** Integer */
        AccessoryId = 0x0F
    }

    public class TestBattler
    {
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

        public TestBattler(LcfReader reader)
        {
            TypeHelpers.ReadChunks<TestBattlerChunk>(reader, (chunk) =>
            {
                switch ((TestBattlerChunk)chunk.ID)
                {
                    case TestBattlerChunk.ActorId:
                        ActorID = reader.ReadInt();
                        return true;

                    case TestBattlerChunk.Level:
                        Level = reader.ReadInt();
                        return true;

                    case TestBattlerChunk.WeaponId:
                        WeaponID = reader.ReadInt();
                        return true;

                    case TestBattlerChunk.ShieldId:
                        ShieldID = reader.ReadInt();
                        return true;

                    case TestBattlerChunk.ArmorId:
                        ArmorID = reader.ReadInt();
                        return true;

                    case TestBattlerChunk.HelmetId:
                        HelmetID = reader.ReadInt();
                        return true;

                    case TestBattlerChunk.AccessoryId:
                        AccessoryID = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}