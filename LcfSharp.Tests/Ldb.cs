/// <copyright>
/// 
/// LcfSharp Copyright (c) 2024 optimus-code
/// (A "loose" .NET port of liblcf)
/// Licensed under the MIT License.
/// 
/// Copyright (c) 2014-2023 liblcf authors
/// Licensed under the MIT License.
/// 
/// Permission is hereby granted, free of charge, to any person obtaining
/// a copy of this software and associated documentation files (the
/// "Software"), to deal in the Software without restriction, including
/// without limitation the rights to use, copy, modify, merge, publish,
/// distribute, sublicense, and/or sell copies of the Software, and to
/// permit persons to whom the Software is furnished to do so, subject to
/// the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included
/// in all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
/// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
/// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
/// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
/// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
/// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
/// </copyright>

using LcfSharp.IO;
using LcfSharp.IO.Types;
using System.IO;
using System.Linq;

namespace LcfSharp.Tests
{
    /// <summary>
    /// Tests LDB conversion and serialization.
    /// </summary>
    [TestClass]
    public class Ldb
    {
        /// <summary>
        /// Checks ldb deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            var db = LdbFile.Load( Path.Combine( "Data", "RPG_RT.ldb" ) );

            Assert.IsNotNull( db );
            Assert.AreEqual( 8, db.Actors.Count );
            Assert.AreEqual( 128, db.Skills.Count );
            Assert.AreEqual( 84, db.Items.Count );
            Assert.AreEqual( 45, db.Enemies.Count );
            Assert.AreEqual( 80, db.Troops.Count );
            Assert.AreEqual( 10, db.Terrains.Count );
            Assert.AreEqual( 17, db.Attributes.Count );
            Assert.AreEqual( 10, db.States.Count );
            Assert.AreEqual( 131, db.Animations.Count );
            Assert.AreEqual( 5, db.Chipsets.Count );
            Assert.AreEqual( 100, db.Switches.Count );
            Assert.AreEqual( 100, db.Variables.Count );
            Assert.AreEqual( 10, db.CommonEvents.Count );
            Assert.AreEqual( 1, db.Version );

            Assert.AreEqual( "Grassland", ( string ) db.Terrains[0].Name );
            Assert.AreEqual( "Sword", ( string ) db.Attributes[0].Name );
            Assert.AreEqual( "Dead", ( string ) db.States[0].Name );
            Assert.AreEqual( "Hit A", ( string ) db.Animations[0].Name );
            Assert.AreEqual( "Basic", ( string ) db.Chipsets[0].Name );

            Assert.AreEqual( "Alex", ( string ) db.Actors[0].Name );
            Assert.AreEqual( "Brian", ( string ) db.Actors[1].Name );

            foreach ( var actor in db.Actors.Take( 2 ) )
            {
                Assert.AreEqual( "Actor1", ( string ) actor.CharacterName );
                Assert.AreEqual( 1, actor.InitialLevel );
                Assert.AreEqual( -1, actor.FinalLevel ); // Not persisted if default value - i.e -1 is max value
                Assert.IsTrue( actor.CriticalHit );
                Assert.AreEqual( 30, actor.CriticalHitChance );
                Assert.AreEqual( 18, actor.InitialEquipment.WeaponID );
                Assert.AreEqual( 54, actor.InitialEquipment.ArmorID );
                Assert.AreEqual( 0, actor.InitialEquipment.HelmetID );
                Assert.AreEqual( 0, actor.InitialEquipment.AccessoryID );
            }

            Assert.AreEqual( "Carol", ( string ) db.Actors[2].Name );
            Assert.AreEqual( "Daisy", ( string ) db.Actors[3].Name );
            Assert.AreEqual( "Enryuu", ( string ) db.Actors[4].Name );
            Assert.AreEqual( "Falcon", ( string ) db.Actors[5].Name );
            Assert.AreEqual( "Gomez", ( string ) db.Actors[6].Name );
            Assert.AreEqual( "Helen", ( string ) db.Actors[7].Name );

            var item1 = db.Items[0];
            Assert.AreEqual( "Potion", ( string ) item1.Name );

            var lastItem = db.Items.Last( );
            Assert.AreEqual( "--------------------", ( string ) lastItem.Name );


            var enemy1 = db.Enemies[0];
            Assert.AreEqual( "Slime", ( string ) enemy1.Name );

            var lastEnemy = db.Enemies.Last( );
            Assert.AreEqual( "Demon God", ( string ) lastEnemy.Name );


            var troop1 = db.Troops[0];
            Assert.AreEqual( "Slimex2", ( string ) troop1.Name );
            Assert.AreEqual( 2, troop1.Members.Count );
            Assert.AreEqual( 1, troop1.Members[0].EnemyID );
            Assert.AreEqual( 1, troop1.Members[1].EnemyID );
            TestHelpers.AssertBuffer( new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 }, troop1.TerrainSet.ToArray( ) );

            Assert.AreEqual( "Slimex3", ( string ) db.Troops[1].Name );

            var lastTroop = db.Troops.Last( );
            Assert.AreEqual( "Demon God", ( string ) lastTroop.Name );

            var system = db.System;
            Assert.AreEqual( "Opening1", ( string ) system.TitleMusic.Name );
            Assert.AreEqual( "Battle1", ( string ) system.BattleMusic.Name );
            Assert.AreEqual( "BattleEnd1", ( string ) system.BattleEndMusic.Name );
            Assert.AreEqual( "Inn1", ( string ) system.InnMusic.Name );
            Assert.AreEqual( "Ship1", ( string ) system.BoatMusic.Name );
            Assert.AreEqual( "Ship2", ( string ) system.ShipMusic.Name );
            Assert.AreEqual( "Vehicle1", ( string ) system.AirshipMusic.Name );
            Assert.AreEqual( "Gameover1", ( string ) system.GameoverMusic.Name );

            Assert.AreEqual( "%S exploded!", ( string ) db.Terms.Autodestruction );
        }

        /// <summary>
        /// Checks the custom ldb deserialization.
        /// </summary>
        [TestMethod]
        public void ReadCustom( )
        {
            var db = LdbFile.Load( Path.Combine( "Data", "RPG_RT_rw.ldb" ) );

            Assert.IsNotNull( db );
            Assert.AreEqual( 14, db.Actors.Count );
            Assert.AreEqual( 380, db.Skills.Count );
            Assert.AreEqual( 530, db.Items.Count );
            Assert.AreEqual( 107, db.Enemies.Count );
            Assert.AreEqual( 107, db.Troops.Count );
            Assert.AreEqual( 11, db.Terrains.Count );
            Assert.AreEqual( 22, db.Attributes.Count );
            Assert.AreEqual( 17, db.States.Count );
            Assert.AreEqual( 320, db.Animations.Count );
            Assert.AreEqual( 80, db.Chipsets.Count );
            Assert.AreEqual( 500, db.Switches.Count );
            Assert.AreEqual( 120, db.Variables.Count );
            Assert.AreEqual( 65, db.CommonEvents.Count );
            Assert.AreEqual( 1, db.Version );

            Assert.AreEqual( "Grass", ( string ) db.Terrains[0].Name );
            Assert.AreEqual( "Thrust", ( string ) db.Attributes[0].Name );
            Assert.AreEqual( "$oDEAD", ( string ) db.States[0].Name );
            Assert.AreEqual( "Multiple Hits", ( string ) db.Animations[0].Name );
            Assert.AreEqual( "Name Input Control", ( string ) db.CommonEvents[0].Name );

            Assert.AreEqual( "Ryle", ( string ) db.Actors[0].Name );
            Assert.AreEqual( "Caris", ( string ) db.Actors[1].Name );
            Assert.AreEqual( 14, db.Actors[1].Skills.Count );
            Assert.AreEqual( "Orubia", ( string ) db.Actors[2].Name );
            Assert.AreEqual( "Latyss", ( string ) db.Actors[3].Name );
            Assert.AreEqual( "Hayami", ( string ) db.Actors[4].Name );
            Assert.AreEqual( "Fina", ( string ) db.Actors[5].Name );

            Assert.AreEqual( "$YStun Claw", ( string ) db.Skills[4].Name );
            Assert.AreEqual( 8, db.Skills[4].StateEffects.Count );
            Assert.AreEqual( ( byte ) 1, db.Skills[4].StateEffects.Last( ) );
        }

        /// <summary>
        /// Checks that ldb fixtures round-trip without byte changes.
        /// </summary>
        /// <param name="file">The fixture file name.</param>
        [TestMethod]
        [DataRow( "RPG_RT.ldb" )]
        [DataRow( "RPG_RT_rw.ldb" )]
        public void RoundTrip( string file )
        {
            var sourceBuffer = File.ReadAllBytes( Path.Combine( "Data", file ) );
            var source = LdbFile.Load( Path.Combine( "Data", file ) );
            byte[] buffer;

            using ( var ms = new MemoryStream( ) )
            {
                LcfSerialiser.Serialise( ms, source, new LcfSerialiserOptions { Format = LcfFormat.LDB } );
                buffer = ms.ToArray( );
            }

            LdbFile result;
            using ( var ms = new MemoryStream( buffer ) )
            {
                result = LcfSerialiser.Deserialise<LdbFile>( ms, new LcfSerialiserOptions { Format = LcfFormat.LDB } );
            }
            Assert.AreEqual( source.Version, result.Version );
            Assert.AreEqual( source.Actors.Count, result.Actors.Count );
            Assert.AreEqual( source.Skills.Count, result.Skills.Count );
            Assert.AreEqual( source.Items.Count, result.Items.Count );
            Assert.AreEqual( source.Enemies.Count, result.Enemies.Count );
            Assert.AreEqual( source.Troops.Count, result.Troops.Count );
            Assert.AreEqual( source.Terrains.Count, result.Terrains.Count );
            Assert.AreEqual( source.Attributes.Count, result.Attributes.Count );
            Assert.AreEqual( source.States.Count, result.States.Count );
            Assert.AreEqual( source.Animations.Count, result.Animations.Count );
            Assert.AreEqual( source.Chipsets.Count, result.Chipsets.Count );
            Assert.AreEqual( source.Switches.Count, result.Switches.Count );
            Assert.AreEqual( source.Variables.Count, result.Variables.Count );
            Assert.AreEqual( source.CommonEvents.Count, result.CommonEvents.Count );

            for ( int i = 0; i < source.Actors.Count; i++ )
            {
                var expected = source.Actors[i];
                var actual = result.Actors[i];
                Assert.AreEqual( expected.ID, actual.ID, $"Actor {i}" );
                Assert.AreEqual( expected.Name, actual.Name, $"Actor {i}" );
                Assert.AreEqual( expected.InitialLevel, actual.InitialLevel, $"Actor {i}" );
                Assert.AreEqual( expected.FinalLevel, actual.FinalLevel, $"Actor {i}" );
                Assert.AreEqual( expected.Skills.Count, actual.Skills.Count, $"Actor {i}" );
                CollectionAssert.AreEqual( expected.Parameters.MaxHP, actual.Parameters.MaxHP, $"Actor {i}" );
                CollectionAssert.AreEqual( expected.Parameters.MaxSP, actual.Parameters.MaxSP, $"Actor {i}" );
                CollectionAssert.AreEqual( expected.Parameters.Attack, actual.Parameters.Attack, $"Actor {i}" );
                CollectionAssert.AreEqual( expected.Parameters.Defense, actual.Parameters.Defense, $"Actor {i}" );
                CollectionAssert.AreEqual( expected.Parameters.Spirit, actual.Parameters.Spirit, $"Actor {i}" );
                CollectionAssert.AreEqual( expected.Parameters.Agility, actual.Parameters.Agility, $"Actor {i}" );
                TestHelpers.AssertBuffer( expected.StateRanks.ToArray( ), actual.StateRanks.ToArray( ) );
                TestHelpers.AssertBuffer( expected.AttributeRanks.ToArray( ), actual.AttributeRanks.ToArray( ) );
            }

            for ( int i = 0; i < source.Skills.Count; i++ )
            {
                Assert.AreEqual( source.Skills[i].ID, result.Skills[i].ID, $"Skill {i}" );
                Assert.AreEqual( source.Skills[i].Name, result.Skills[i].Name, $"Skill {i}" );
            }

            for ( int i = 0; i < source.Items.Count; i++ )
            {
                Assert.AreEqual( source.Items[i].ID, result.Items[i].ID, $"Item {i}" );
                Assert.AreEqual( source.Items[i].Name, result.Items[i].Name, $"Item {i}" );
                Assert.AreEqual( source.Items[i].Price, result.Items[i].Price, $"Item {i}" );
            }

            for ( int i = 0; i < source.Enemies.Count; i++ )
            {
                var expected = source.Enemies[i];
                var actual = result.Enemies[i];
                Assert.AreEqual( expected.ID, actual.ID, $"Enemy {i}" );
                Assert.AreEqual( expected.Name, actual.Name, $"Enemy {i}" );
                Assert.AreEqual( expected.MaxHP, actual.MaxHP, $"Enemy {i}" );
                Assert.AreEqual( expected.Actions.Count, actual.Actions.Count, $"Enemy {i}" );
                TestHelpers.AssertBuffer( expected.StateRanks.ToArray( ), actual.StateRanks.ToArray( ) );
                TestHelpers.AssertBuffer( expected.AttributeRanks.ToArray( ), actual.AttributeRanks.ToArray( ) );
            }

            for ( int i = 0; i < source.Troops.Count; i++ )
            {
                var expected = source.Troops[i];
                var actual = result.Troops[i];
                Assert.AreEqual( expected.ID, actual.ID, $"Troop {i}" );
                Assert.AreEqual( expected.Name, actual.Name, $"Troop {i}" );
                Assert.AreEqual( expected.Members.Count, actual.Members.Count, $"Troop {i}" );
                Assert.AreEqual( expected.Pages.Count, actual.Pages.Count, $"Troop {i}" );
                TestHelpers.AssertBuffer( expected.TerrainSet.ToArray( ), actual.TerrainSet.ToArray( ) );
                for ( int p = 0; p < expected.Pages.Count; p++ )
                {
                    Assert.AreEqual( expected.Pages[p].EventCommands.Count,
                        actual.Pages[p].EventCommands.Count, $"Troop {i}, page {p}" );
                }
            }

            for ( int i = 0; i < source.Terrains.Count; i++ )
            {
                Assert.AreEqual( source.Terrains[i].Name, result.Terrains[i].Name, $"Terrain {i}" );
                Assert.AreEqual( source.Terrains[i].EncounterRate, result.Terrains[i].EncounterRate, $"Terrain {i}" );
            }

            for ( int i = 0; i < source.Attributes.Count; i++ )
                Assert.AreEqual( source.Attributes[i].Name, result.Attributes[i].Name, $"Attribute {i}" );

            for ( int i = 0; i < source.States.Count; i++ )
                Assert.AreEqual( source.States[i].Name, result.States[i].Name, $"State {i}" );

            for ( int i = 0; i < source.Animations.Count; i++ )
            {
                var expected = source.Animations[i];
                var actual = result.Animations[i];
                Assert.AreEqual( expected.Name, actual.Name, $"Animation {i}" );
                Assert.AreEqual( expected.Timings.Count, actual.Timings.Count, $"Animation {i}" );
                Assert.AreEqual( expected.Frames.Count, actual.Frames.Count, $"Animation {i}" );
            }

            for ( int i = 0; i < source.Chipsets.Count; i++ )
            {
                Assert.AreEqual( source.Chipsets[i].Name, result.Chipsets[i].Name, $"Chipset {i}" );
                CollectionAssert.AreEqual( source.Chipsets[i].TerrainData, result.Chipsets[i].TerrainData, $"Chipset {i}" );
                TestHelpers.AssertBuffer( source.Chipsets[i].PassableDataLower.ToArray( ), result.Chipsets[i].PassableDataLower.ToArray( ) );
                TestHelpers.AssertBuffer( source.Chipsets[i].PassableDataUpper.ToArray( ), result.Chipsets[i].PassableDataUpper.ToArray( ) );
            }

            for ( int i = 0; i < source.Switches.Count; i++ )
                Assert.AreEqual( source.Switches[i].Name, result.Switches[i].Name, $"Switch {i}" );

            for ( int i = 0; i < source.Variables.Count; i++ )
                Assert.AreEqual( source.Variables[i].Name, result.Variables[i].Name, $"Variable {i}" );

            for ( int i = 0; i < source.CommonEvents.Count; i++ )
            {
                Assert.AreEqual( source.CommonEvents[i].Name, result.CommonEvents[i].Name, $"Common event {i}" );
                Assert.AreEqual( source.CommonEvents[i].Trigger, result.CommonEvents[i].Trigger, $"Common event {i}" );
                Assert.AreEqual( source.CommonEvents[i].EventCommands.Count,
                    result.CommonEvents[i].EventCommands.Count, $"Common event {i}" );
            }

            Assert.AreEqual( source.System.TitleMusic.Name, result.System.TitleMusic.Name );
            Assert.AreEqual( source.System.BattleMusic.Name, result.System.BattleMusic.Name );
            Assert.AreEqual( source.Terms.Encounter, result.Terms.Encounter );
            Assert.AreEqual( source.Terms.Autodestruction, result.Terms.Autodestruction );

            TestHelpers.AssertBuffer( sourceBuffer, buffer );
        }
    }
}
