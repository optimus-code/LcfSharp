using LcfSharp.IO;
using LcfSharp.Rpg;
using LcfSharp.Rpg.Actors;
using System.Text.Json;
using System.Xml.Serialization;

namespace LcfSharp.Tests
{
    [TestClass]
    public class DatabaseTests
    {

        [TestMethod]
        public void ReadInt()
        {
            // Sample data representing 0x84 0x58 in a memory stream
            byte[] data = { 0x84, 0x58 };
            using (MemoryStream ms = new MemoryStream(data))
            {
                LcfReader lcfReader = new LcfReader(ms);
                int result = lcfReader.ReadVarInt();
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
            Assert.IsTrue(actor1.InitialLevel == 1);
            Assert.IsTrue(actor1.FinalLevel == -1); // Not persisted if default value - i.e -1 is max value
            Assert.IsTrue(actor1.CriticalHit == true);
            Assert.IsTrue(actor1.CriticalHitChance == 30);
            Assert.IsTrue(actor1.InitialEquipment.WeaponID == 18);
            Assert.IsTrue(actor1.InitialEquipment.ArmorID == 54);
            Assert.IsTrue(actor1.InitialEquipment.HelmetID == 0);
            Assert.IsTrue(actor1.InitialEquipment.AccessoryID == 0);

            var actor2 = db.Actors[1];

            Assert.IsTrue(actor2.Name.Value == "Brian");
            Assert.IsTrue(actor2.CharacterName.Value == "Actor1");
            Assert.IsTrue(actor2.InitialLevel == 1);
            Assert.IsTrue(actor2.FinalLevel == -1); // Not persisted if default value - i.e -1 is max value
            Assert.IsTrue(actor2.CriticalHit == true);
            Assert.IsTrue(actor2.CriticalHitChance == 30);
            Assert.IsTrue(actor2.InitialEquipment.WeaponID == 18);
            Assert.IsTrue(actor2.InitialEquipment.ArmorID == 54);
            Assert.IsTrue(actor2.InitialEquipment.HelmetID == 0);
            Assert.IsTrue(actor2.InitialEquipment.AccessoryID == 0);

            Assert.IsTrue(db.Actors[2].Name.Value == "Carol");
            Assert.IsTrue(db.Actors[3].Name.Value == "Daisy");
            Assert.IsTrue(db.Actors[4].Name.Value == "Enryuu");
            Assert.IsTrue(db.Actors[5].Name.Value == "Falcon");
            Assert.IsTrue(db.Actors[6].Name.Value == "Gomez");
            Assert.IsTrue(db.Actors[7].Name.Value == "Helen");

            var item1 = db.Items[0];
            Assert.IsTrue(item1.Name.Value == "Potion");

            var lastItem = db.Items.Last();
            Assert.IsTrue(lastItem.Name.Value == "--------------------");


            var enemy1 = db.Enemies[0];
            Assert.IsTrue(enemy1.Name.Value == "Slime");

            var lastEnemy = db.Enemies.Last();
            Assert.IsTrue(lastEnemy.Name.Value == "Demon God");


            var troop1 = db.Troops[0];
            Assert.IsTrue(troop1.Name.Value == "Slimex2");
            //Assert.IsTrue(troop1.Members.Count == 2);
            //Assert.IsTrue(troop1.Members[0].EnemyID == 1);
            //Assert.IsTrue(troop1.Members[1].EnemyID == 1);
            Assert.IsTrue(troop1.TerrainSet.Count == 10);
            Assert.IsTrue(troop1.TerrainSet[0] == true);
            Assert.IsTrue(troop1.TerrainSet[1] == true);
            Assert.IsTrue(troop1.TerrainSet[2] == true);
            Assert.IsTrue(troop1.TerrainSet[3] == true);
            Assert.IsTrue(troop1.TerrainSet[4] == true);
            Assert.IsTrue(troop1.TerrainSet[5] == true);
            Assert.IsTrue(troop1.TerrainSet[6] == true);
            Assert.IsTrue(troop1.TerrainSet[7] == true);
            Assert.IsTrue(troop1.TerrainSet[8] == false);
            Assert.IsTrue(troop1.TerrainSet[9] == false);

            Assert.IsTrue(db.Troops[1].Name.Value == "Slimex3");

            var lastTroop = db.Troops.Last();
            Assert.IsTrue(lastTroop.Name.Value == "Demon God");

            var system = db.System;
            Assert.IsTrue(system.TitleMusic.Name.Value == "Opening1");
            Assert.IsTrue(system.BattleMusic.Name.Value == "Battle1");
            Assert.IsTrue(system.BattleEndMusic.Name.Value == "BattleEnd1");
            Assert.IsTrue(system.InnMusic.Name.Value == "Inn1");
            Assert.IsTrue(system.BoatMusic.Name.Value == "Ship1");
            Assert.IsTrue(system.ShipMusic.Name.Value == "Ship2");
            Assert.IsTrue(system.AirshipMusic.Name.Value == "Vehicle1");
            Assert.IsTrue(system.GameoverMusic.Name.Value == "Gameover1");

            Assert.IsTrue(db.Terms.Autodestruction.Value == "%S exploded!");
        }

        [TestMethod]
        public void TestRW()
        {
            var db = DatabaseFile.Load("Data\\RPG_RT_rw.ldb");

            Assert.IsNotNull(db);
            Assert.IsTrue(db.Actors[0].Name.Value == "Ryle");
            Assert.IsTrue(db.Actors[1].Name.Value == "Caris");
            Assert.IsTrue(db.Actors[2].Name.Value == "Orubia");
            Assert.IsTrue(db.Actors[3].Name.Value == "Latyss");
            Assert.IsTrue(db.Actors[4].Name.Value == "Hayami");
            Assert.IsTrue(db.Actors[5].Name.Value == "Fina");
        }
           
        [TestMethod]
        public void TestJson()
        {
            var db = DatabaseFile.Load("Data\\RPG_RT.ldb");

            Assert.IsNotNull(db);
            Assert.IsTrue(db.Actors.Count == 8);

            var json = JsonSerializer.Serialize(db);
            File.WriteAllText("C:\\Users\\User\\source\\repos\\LcfSharp\\LcfSharp.Tests\\Data\\rpg_rt.json", json);
        }

        [TestMethod]
        public void TestXml()
        {
            var db = DatabaseFile.Load("Data\\RPG_RT.ldb");

            Assert.IsNotNull(db);
            Assert.IsTrue(db.Actors.Count == 8);

            var serializer = new XmlSerializer(db.GetType());
            using (var stream = File.CreateText("C:\\Users\\User\\source\\repos\\LcfSharp\\LcfSharp.Tests\\Data\\RPG_RT.xml"))
            {
                serializer.Serialize(stream, db);;
            }
        }

        [TestMethod]
        public void IntegrityTest()
        {
            using (var stream = File.OpenRead("Data\\RPG_RT.ldb"))
            using (var reader = new LcfReader(stream))
            {
                var headerLength = reader.ReadVarInt();
                var header = reader.ReadString(headerLength);

                Assert.IsNotNull(header);
                Assert.IsTrue(header.Length == 11);
                Assert.AreEqual(header, "LcfDataBase");

                var inActors = false;

                //var chunk = reader.ReadChunkHeader();
                var actorsCID = reader.ReadVarInt();
                var actorsCL = reader.ReadVarInt();

                Assert.AreEqual(actorsCID, (int)DatabaseChunk.Actors);

                var actorsCount = reader.ReadVarInt();

                Assert.AreEqual(actorsCount, 8);

                var actor1ID = reader.ReadVarInt();

                Assert.AreEqual(actor1ID, 1);

                var actor1NameCID = reader.ReadVarInt();
                var actor1NameCL = reader.ReadVarInt();

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