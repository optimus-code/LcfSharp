﻿using LcfSharp.IO;
using LcfSharp.IO.Extensions;
using System.Text;

namespace LcfSharp.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void ReadInt( )
        {
            byte[] data = { 0x84, 0x58 };
            using ( MemoryStream ms = new MemoryStream( data ) )
            {
                LcfReader lcfReader = new LcfReader( ms );
                var result = lcfReader.ReadVarInt32( );
                Assert.IsTrue( result == 600 );
            }
        }

        [TestMethod]
        public void ReadString( )
        {
            Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );

            // Byte arrays for SHIFT-JIS and ASCII encoded strings
            byte[] shiftJisData = { 0x82, 0xA0, 0x82, 0xA2, 0x82, 0xA4, 0x82, 0xA6, 0x82, 0xA8 }; // "あいうえお" in SHIFT-JIS
            byte[] asciiData = { 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello" in ASCII

            // Read and decode SHIFT-JIS string
            using ( var shiftJisMs = new MemoryStream( shiftJisData ) )
            {
                var shiftJisReader = new BinaryReader( shiftJisMs );
                var shiftJisString = shiftJisReader.ReadString( shiftJisData.Length );
                Assert.AreEqual( "あいうえお", shiftJisString );
            }

            // Read and decode ASCII string
            using ( var asciiMs = new MemoryStream( asciiData ) )
            {
                var asciiReader = new BinaryReader( asciiMs );
                var asciiString = asciiReader.ReadString( asciiData.Length );
                Assert.AreEqual( "Hello", asciiString );
            }
        }


        [TestMethod]
        public void TestLdb( )
        {
            var db = LdbFile.Load( Path.Combine( "Data", "RPG_RT.ldb" ) );

            Assert.IsNotNull( db );
            Assert.IsTrue( db.Actors.Count == 8 );

            var actor1 = db.Actors[0];

            Assert.IsTrue( actor1.Name == "Alex" );
            Assert.IsTrue( actor1.CharacterName == "Actor1" );
            Assert.IsTrue( actor1.InitialLevel == 1 );
            Assert.IsTrue( actor1.FinalLevel == -1 ); // Not persisted if default value - i.e -1 is max value
            Assert.IsTrue( actor1.CriticalHit == true );
            Assert.IsTrue( actor1.CriticalHitChance == 30 );
            Assert.IsTrue( actor1.InitialEquipment.WeaponID == 18 );
            Assert.IsTrue( actor1.InitialEquipment.ArmorID == 54 );
            Assert.IsTrue( actor1.InitialEquipment.HelmetID == 0 );
            Assert.IsTrue( actor1.InitialEquipment.AccessoryID == 0 );

            var actor2 = db.Actors[1];

            Assert.IsTrue( actor2.Name == "Brian" );
            Assert.IsTrue( actor2.CharacterName == "Actor1" );
            Assert.IsTrue( actor2.InitialLevel == 1 );
            Assert.IsTrue( actor2.FinalLevel == -1 ); // Not persisted if default value - i.e -1 is max value
            Assert.IsTrue( actor2.CriticalHit == true );
            Assert.IsTrue( actor2.CriticalHitChance == 30 );
            Assert.IsTrue( actor2.InitialEquipment.WeaponID == 18 );
            Assert.IsTrue( actor2.InitialEquipment.ArmorID == 54 );
            Assert.IsTrue( actor2.InitialEquipment.HelmetID == 0 );
            Assert.IsTrue( actor2.InitialEquipment.AccessoryID == 0 );

            Assert.IsTrue( db.Actors[2].Name == "Carol" );
            Assert.IsTrue( db.Actors[3].Name == "Daisy" );
            Assert.IsTrue( db.Actors[4].Name == "Enryuu" );
            Assert.IsTrue( db.Actors[5].Name == "Falcon" );
            Assert.IsTrue( db.Actors[6].Name == "Gomez" );
            Assert.IsTrue( db.Actors[7].Name == "Helen" );

            var item1 = db.Items[0];
            Assert.IsTrue( item1.Name == "Potion" );

            var lastItem = db.Items.Last( );
            Assert.IsTrue( lastItem.Name == "--------------------" );


            var enemy1 = db.Enemies[0];
            Assert.IsTrue( enemy1.Name == "Slime" );

            var lastEnemy = db.Enemies.Last( );
            Assert.IsTrue( lastEnemy.Name == "Demon God" );


            var troop1 = db.Troops[0];
            Assert.IsTrue( troop1.Name == "Slimex2" );
            Assert.IsTrue( troop1.Members.Count == 2 );
            Assert.IsTrue( troop1.Members[0].EnemyID == 1 );
            Assert.IsTrue( troop1.Members[1].EnemyID == 1 );
            Assert.IsTrue( troop1.TerrainSet.Count == 10 );
            Assert.IsTrue( troop1.TerrainSet[0] == true );
            Assert.IsTrue( troop1.TerrainSet[1] == true );
            Assert.IsTrue( troop1.TerrainSet[2] == true );
            Assert.IsTrue( troop1.TerrainSet[3] == true );
            Assert.IsTrue( troop1.TerrainSet[4] == true );
            Assert.IsTrue( troop1.TerrainSet[5] == true );
            Assert.IsTrue( troop1.TerrainSet[6] == true );
            Assert.IsTrue( troop1.TerrainSet[7] == true );
            Assert.IsTrue( troop1.TerrainSet[8] == false );
            Assert.IsTrue( troop1.TerrainSet[9] == false );

            Assert.IsTrue( db.Troops[1].Name == "Slimex3" );

            var lastTroop = db.Troops.Last( );
            Assert.IsTrue( lastTroop.Name == "Demon God" );

            var system = db.System;
            Assert.IsTrue( system.TitleMusic.Name == "Opening1" );
            Assert.IsTrue( system.BattleMusic.Name == "Battle1" );
            Assert.IsTrue( system.BattleEndMusic.Name == "BattleEnd1" );
            Assert.IsTrue( system.InnMusic.Name == "Inn1" );
            Assert.IsTrue( system.BoatMusic.Name == "Ship1" );
            Assert.IsTrue( system.ShipMusic.Name == "Ship2" );
            Assert.IsTrue( system.AirshipMusic.Name == "Vehicle1" );
            Assert.IsTrue( system.GameoverMusic.Name == "Gameover1" );

            Assert.IsTrue( db.Terms.Autodestruction == "%S exploded!" );
        }

        [TestMethod]
        public void TestLdbRW( )
        {
            var db = LdbFile.Load( Path.Combine( "Data", "RPG_RT_rw.ldb" ) );

            Assert.IsNotNull( db );
            Assert.IsTrue( db.Actors[0].Name == "Ryle" );
            Assert.IsTrue( db.Actors[1].Name == "Caris" );
            Assert.IsTrue( db.Actors[2].Name == "Orubia" );
            Assert.IsTrue( db.Actors[3].Name == "Latyss" );
            Assert.IsTrue( db.Actors[4].Name == "Hayami" );
            Assert.IsTrue( db.Actors[5].Name == "Fina" );
        }

        [TestMethod]
        public void TestLMT( )
        {
            var mapTree = LmtFile.Load( Path.Combine( "Data", "RPG_RT.lmt" ) );

            Assert.IsNotNull( mapTree );

            Assert.IsTrue( mapTree.Maps[0].Name == "Romancing Walker" );
            Assert.IsTrue( mapTree.Maps[1].Name == "Main MAP" );
        }

        [TestMethod]
        public void TestLMU( )
        {
            var map = LmuFile.Load( Path.Combine( "Data", "Map0001.lmu" ) );

            Assert.IsNotNull( map );

            Assert.IsTrue( map.Width == 100 );
            Assert.IsTrue( map.Height == 135 );
        }
    }
}