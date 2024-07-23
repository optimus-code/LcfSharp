using LcfSharp.IO;
using LcfSharp.Rpg;
using LcfSharp.Rpg.Actors;

namespace LcfSharp.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void TestReadShort()
        {
            // Sample data in little-endian format for various test cases
            byte[] data1 = { 0x88, 0x13 }; // Should represent 5000
            byte[] data2 = { 0xFF, 0x7F }; // Should represent 32767 (max positive value for int16)
            byte[] data3 = { 0x00, 0x80 }; // Should represent -32768 (min negative value for int16)
            byte[] data4 = { 0x00, 0x00 }; // Should represent 0

            using (MemoryStream ms = new MemoryStream(data1))
            {
                LcfReader lcfReader = new LcfReader(ms);
                short result = lcfReader.ReadShort();
                Assert.AreEqual(5000, result);
            }

            using (MemoryStream ms = new MemoryStream(data2))
            {
                LcfReader lcfReader = new LcfReader(ms);
                short result = lcfReader.ReadShort();
                Assert.AreEqual(32767, result);
            }

            using (MemoryStream ms = new MemoryStream(data3))
            {
                LcfReader lcfReader = new LcfReader(ms);
                short result = lcfReader.ReadShort();
                Assert.AreEqual(-32768, result);
            }

            using (MemoryStream ms = new MemoryStream(data4))
            {
                LcfReader lcfReader = new LcfReader(ms);
                short result = lcfReader.ReadShort();
                Assert.AreEqual(0, result);
            }
        }

        [TestMethod]
        public void ReadInt()
        {
            // Sample data representing 0x84 0x58 in a memory stream
            byte[] data = { 0x84, 0x58 };
            using (MemoryStream ms = new MemoryStream(data))
            {
                LcfReader lcfReader = new LcfReader(ms);
                int result = lcfReader.ReadInt();
                Assert.IsTrue(result == 600);
            }
        }

        [TestMethod]
        public void TestRead()
        {
            var db = DatabaseFile.Load("Data\\RPG_RT.ldb");

            Assert.IsNotNull(db);
            Assert.IsTrue(db.Actors.Count == 8);

            var actor1 = db.Actors[0];

            Assert.IsTrue(actor1.Name.Value == "Alex");
            Assert.IsTrue(actor1.CharacterName.Value == "Actor1");


            Assert.IsTrue(db.Actors[1].Name.Value == "Brian");
            Assert.IsTrue(db.Actors[2].Name.Value == "Carol");
            Assert.IsTrue(db.Actors[3].Name.Value == "Daisy");
            Assert.IsTrue(db.Actors[4].Name.Value == "Enryuu");
            Assert.IsTrue(db.Actors[5].Name.Value == "Falcon");
            Assert.IsTrue(db.Actors[6].Name.Value == "Gomez");
            Assert.IsTrue(db.Actors[7].Name.Value == "Helen");
        }

        [TestMethod]
        public void IntegrityTest()
        {
            using (var stream = File.OpenRead("Data\\RPG_RT.ldb"))
            using (var reader = new LcfReader(stream))
            {
                var headerLength = reader.ReadInt();
                var header = reader.ReadString(headerLength);

                Assert.IsNotNull(header);
                Assert.IsTrue(header.Length == 11);
                Assert.AreEqual(header, "LcfDataBase");

                var inActors = false;

                //var chunk = reader.ReadChunkHeader();
                var startOffset = reader.Offset;
                var actorsCID = reader.ReadInt();
                var actorsCL = reader.ReadInt();

                Assert.AreEqual(actorsCID, (int)DatabaseChunk.Actors);

                var actorsCount = reader.ReadInt();

                Assert.AreEqual(actorsCount, 8);

                var actor1ID = reader.ReadInt();

                Assert.AreEqual(actor1ID, 1);

                var actor1NameCID = reader.ReadInt();
                var actor1NameCL = reader.ReadInt();

                Assert.AreEqual(actor1NameCID, (byte)ActorChunk.Name);

                var actorName = reader.ReadDbString(actor1NameCL);

                Assert.AreEqual(actorName.Value, "Alex");
                //Console.WriteLine($"Chunk: {chunk.ID} Length: {chunk.Length}");

                //reader.Seek(chunkLength, SeekMode.FromCurrent);
                //if (!inActors)
                //{

                //    switch (chunk.ID)
                //    {
                //        case (int)DatabaseChunk.Actors: // Actors
                //            inActors = true;
                //            break;

                //        default:
                //            reader.Seek(chunk.Length, SeekMode.FromCurrent);
                //            break;
                //    }
                //}
                //else
                //{
                //    switch (chunk.ID)
                //    {
                //        case (int)ActorChunk.Name: // Actors
                //            inActors = true;
                //            break;

                //        default:
                //            reader.Seek(chunk.Length, SeekMode.FromCurrent);
                //            break;
                //    }
                //}

                //Assert.AreEqual(chunk.ID, (int)DatabaseChunk.Actors);

                //var nameLength = reader.ReadInt();
                //Assert.IsTrue(chunk.Length == 4);

            }
        }
    }
}