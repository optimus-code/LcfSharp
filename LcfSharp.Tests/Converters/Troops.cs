using LcfSharp.IO.Converters;
using LcfSharp.Rpg.Events;
using LcfSharp.Rpg.Troops;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LcfSharp.Tests.Converters
{
    [TestClass]
    public class Troops
    {
        byte[] data = [0x02, 0x01, 0x07, 0x53, 0x6C, 0x69, 0x6D, 0x65, 0x78, 0x33, 0x02, 0x1B, 0x03, 0x01, 0x02, 0x01, 0x60, 0x03, 0x01, 0x68, 0x00, 0x02, 0x02, 0x02, 0x81, 0x20, 0x03, 0x01, 0x74, 0x00, 0x03, 0x02, 0x02, 0x81, 0x60, 0x03, 0x01, 0x68, 0x00, 0x04, 0x01, 0x0A, 0x05, 0x0A, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x00, 0x00, 0x0B, 0x1B, 0x01, 0x01, 0x02, 0x04, 0x01, 0x01, 0x08, 0x00, 0x0B, 0x01, 0x0D, 0x0C, 0x0D, 0xCF, 0x62, 0x00, 0x00, 0x04, 0x00, 0x56, 0x56, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00];

        Troop instance = new( )
        {
            ID = 2,
            Name = "Slimex3",
            Members =
            [
                new( ) { ID = 1, EnemyID = 1, X = 96, Y = 104, Invisible = false },
                new( ) { ID = 2, EnemyID = 1, X = 160, Y = 116, Invisible = false },
                new( ) { ID = 3, EnemyID = 1, X = 224, Y = 104, Invisible = false }
            ],
            AutoAlignment = false,
            TerrainSet = [1, 1, 1, 1, 1, 1, 1, 1, 0, 0],
            AppearRandomly = false,
            Pages =
            [
                new( ) {
                    ID = 1,
                    Condition = new TroopPageCondition
                    {
                        Flags = new TroopPageConditionFlags
                        {
                            SwitchA = false,
                            SwitchB = false,
                            Variable = false,
                            Turn = false,
                            Fatigue = false,
                            EnemyHP = false,
                            ActorHP = false,
                            TurnEnemy = false,
                            TurnActor = false,
                            CommandActor = false
                        },
                        SwitchAID = 1,
                        SwitchBID = 1,
                        VariableID = 1,
                        VariableValue = 0,
                        TurnA = 0,
                        TurnB = 0,
                        FatigueMin = 0,
                        FatigueMax = 100,
                        EnemyID = 0,
                        EnemyHPMin = 0,
                        EnemyHPMax = 100,
                        ActorID = 1,
                        ActorHPMin = 0,
                        ActorHPMax = 100,
                        TurnEnemyID = 0,
                        TurnEnemyA = 0,
                        TurnEnemyB = 0,
                        TurnActorID = 1,
                        TurnActorA = 0,
                        TurnActorB = 0,
                        CommandActorID = 1,
                        CommandID = 1
                    },
                    EventCommands =
                    [
                        new( ) { Code = (EventCommandCode)10210, Indent = 0, String = null, Parameters = [0, 86, 86, 0] },
                        new( ) { Code = 0, Indent = 0, String = null, Parameters = [] }
                    ]
                }
            ]
        };

        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new BinaryReader( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Troop ) );
                var troop = ( Troop ) lcfConverter.Read( reader, null );

                Assert.AreEqual( instance.ID, troop.ID );
                Assert.AreEqual( instance.Name, troop.Name );
                CollectionAssert.AreEqual( instance.Members.Select( m => m.ID ).ToList( ), troop.Members.Select( m => m.ID ).ToList( ) );
                CollectionAssert.AreEqual( instance.Members.Select( m => m.EnemyID ).ToList( ), troop.Members.Select( m => m.EnemyID ).ToList( ) );
                CollectionAssert.AreEqual( instance.Members.Select( m => m.X ).ToList( ), troop.Members.Select( m => m.X ).ToList( ) );
                CollectionAssert.AreEqual( instance.Members.Select( m => m.Y ).ToList( ), troop.Members.Select( m => m.Y ).ToList( ) );
                CollectionAssert.AreEqual( instance.Members.Select( m => m.Invisible ).ToList( ), troop.Members.Select( m => m.Invisible ).ToList( ) );
                Assert.AreEqual( instance.AutoAlignment, troop.AutoAlignment );
                CollectionAssert.AreEqual( instance.TerrainSet, troop.TerrainSet );
                Assert.AreEqual( instance.AppearRandomly, troop.AppearRandomly );

                Assert.AreEqual( instance.Pages.Count, troop.Pages.Count );
                for ( int i = 0; i < instance.Pages.Count; i++ )
                {
                    var expectedPage = instance.Pages[i];
                    var actualPage = troop.Pages[i];

                    Assert.AreEqual( expectedPage.ID, actualPage.ID );
                    Assert.AreEqual( expectedPage.Condition.Flags.SwitchA, actualPage.Condition.Flags.SwitchA );
                    Assert.AreEqual( expectedPage.Condition.Flags.SwitchB, actualPage.Condition.Flags.SwitchB );
                    Assert.AreEqual( expectedPage.Condition.Flags.Variable, actualPage.Condition.Flags.Variable );
                    Assert.AreEqual( expectedPage.Condition.Flags.Turn, actualPage.Condition.Flags.Turn );
                    Assert.AreEqual( expectedPage.Condition.Flags.Fatigue, actualPage.Condition.Flags.Fatigue );
                    Assert.AreEqual( expectedPage.Condition.Flags.EnemyHP, actualPage.Condition.Flags.EnemyHP );
                    Assert.AreEqual( expectedPage.Condition.Flags.ActorHP, actualPage.Condition.Flags.ActorHP );
                    Assert.AreEqual( expectedPage.Condition.Flags.TurnEnemy, actualPage.Condition.Flags.TurnEnemy );
                    Assert.AreEqual( expectedPage.Condition.Flags.TurnActor, actualPage.Condition.Flags.TurnActor );
                    Assert.AreEqual( expectedPage.Condition.Flags.CommandActor, actualPage.Condition.Flags.CommandActor );
                    Assert.AreEqual( expectedPage.Condition.SwitchAID, actualPage.Condition.SwitchAID );
                    Assert.AreEqual( expectedPage.Condition.SwitchBID, actualPage.Condition.SwitchBID );
                    Assert.AreEqual( expectedPage.Condition.VariableID, actualPage.Condition.VariableID );
                    Assert.AreEqual( expectedPage.Condition.VariableValue, actualPage.Condition.VariableValue );
                    Assert.AreEqual( expectedPage.Condition.TurnA, actualPage.Condition.TurnA );
                    Assert.AreEqual( expectedPage.Condition.TurnB, actualPage.Condition.TurnB );
                    Assert.AreEqual( expectedPage.Condition.FatigueMin, actualPage.Condition.FatigueMin );
                    Assert.AreEqual( expectedPage.Condition.FatigueMax, actualPage.Condition.FatigueMax );
                    Assert.AreEqual( expectedPage.Condition.EnemyID, actualPage.Condition.EnemyID );
                    Assert.AreEqual( expectedPage.Condition.EnemyHPMin, actualPage.Condition.EnemyHPMin );
                    Assert.AreEqual( expectedPage.Condition.EnemyHPMax, actualPage.Condition.EnemyHPMax );
                    Assert.AreEqual( expectedPage.Condition.ActorID, actualPage.Condition.ActorID );
                    Assert.AreEqual( expectedPage.Condition.ActorHPMin, actualPage.Condition.ActorHPMin );
                    Assert.AreEqual( expectedPage.Condition.ActorHPMax, actualPage.Condition.ActorHPMax );
                    Assert.AreEqual( expectedPage.Condition.TurnEnemyID, actualPage.Condition.TurnEnemyID );
                    Assert.AreEqual( expectedPage.Condition.TurnEnemyA, actualPage.Condition.TurnEnemyA );
                    Assert.AreEqual( expectedPage.Condition.TurnEnemyB, actualPage.Condition.TurnEnemyB );
                    Assert.AreEqual( expectedPage.Condition.TurnActorID, actualPage.Condition.TurnActorID );
                    Assert.AreEqual( expectedPage.Condition.TurnActorA, actualPage.Condition.TurnActorA );
                    Assert.AreEqual( expectedPage.Condition.TurnActorB, actualPage.Condition.TurnActorB );
                    Assert.AreEqual( expectedPage.Condition.CommandActorID, actualPage.Condition.CommandActorID );
                    Assert.AreEqual( expectedPage.Condition.CommandID, actualPage.Condition.CommandID );

                    for ( int c = 0; c < expectedPage.EventCommands.Count; c++ )
                    {
                        var expectedCommand = expectedPage.EventCommands[c];
                        var actualCommand = actualPage.EventCommands[c];

                        Assert.AreEqual( expectedCommand.Code, actualCommand.Code, $"EventCommand Code mismatch at index {c}." );
                        Assert.AreEqual( expectedCommand.Indent, actualCommand.Indent, $"EventCommand Indent mismatch at index {c}." );
                        Assert.AreEqual( expectedCommand.String, actualCommand.String, $"EventCommand String mismatch at index {c}." );

                        // Compare the Parameters list
                        Assert.AreEqual( expectedCommand.Parameters.Count, actualCommand.Parameters.Count, $"EventCommand Parameters count mismatch at index {c}." );
                        for ( int j = 0; j < expectedCommand.Parameters.Count; j++ )
                        {
                            Assert.AreEqual( expectedCommand.Parameters[j], actualCommand.Parameters[j], $"EventCommand Parameter mismatch at index {c}, parameter {j}." );
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new BinaryWriter( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Troop ) );
                lcfConverter.Write( writer, instance, false );

                var buffer = ms.ToArray( );
                int minLength = Math.Min( buffer.Length, data.Length );
                int contextBytes = 5; // Number of bytes to show before and after the deviation

                for ( int i = 0; i < minLength; i++ )
                {
                    if ( buffer[i] != data[i] )
                    {
                        // Show surrounding bytes for context
                        int start = Math.Max( 0, i - contextBytes );
                        int end = Math.Min( minLength - 1, i + contextBytes + 30 );

                        var bufferSnippet = string.Join( " ", buffer.Skip( start ).Take( end - start + 1 ).Select( b => $"0x{b:X2}" ) );
                        var dataSnippet = string.Join( " ", data.Skip( start ).Take( end - start + 1 ).Select( b => $"0x{b:X2}" ) );

                        Assert.Fail( $"Buffers differ at index {i}. Expected: 0x{data[i]:X2}, Actual: 0x{buffer[i]:X2}\n" +
                                    $"Written:\t{bufferSnippet}\n" +
                                    $"Expected:\t{dataSnippet}" );
                    }
                }

                // If no differences found, check if one buffer is longer than the other
                if ( buffer.Length != data.Length )
                {
                    Assert.Fail( $"Buffers have different lengths. Expected: {data.Length}, Actual: {buffer.Length}" );
                }
            }
        }
    }
}