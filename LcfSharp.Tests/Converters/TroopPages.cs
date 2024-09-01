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
    public class TroopPages
    {
        // Binary data representing the serialized form of the TroopPage instance
        byte[] data = [0x01, 0x02, 0x04, 0x01, 0x01, 0x08, 0x00, 0x0B, 0x01, 0x0D, 0x0C, 0x0D, 0xCF, 0x62, 0x00, 0x00, 0x04, 0x00, 0x56, 0x56, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00];

        // TroopPage instance based on provided data
        TroopPage instance = new TroopPage
        {
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
            EventCommands = new List<EventCommand>
            {
                new EventCommand { Code = ( EventCommandCode ) 10210, Indent = 0, String = null, Parameters = new List<int> { 0, 86, 86, 0 } },
                new EventCommand { Code = 0, Indent = 0, String = null, Parameters = new List<int>() },
                new EventCommand { Code = 0, Indent = 0, String = null, Parameters = new List<int>() },
                new EventCommand { Code = 0, Indent = 0, String = null, Parameters = new List<int>() },
                new EventCommand { Code = 0, Indent = 0, String = null, Parameters = new List<int>() }
            }
        };

        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new BinaryReader( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopPage ) );
                var troopPage = ( TroopPage ) lcfConverter.Read( reader, null );

                Assert.AreEqual( instance.ID, troopPage.ID );

                // Compare Condition
                Assert.AreEqual( instance.Condition.Flags.SwitchA, troopPage.Condition.Flags.SwitchA );
                Assert.AreEqual( instance.Condition.Flags.SwitchB, troopPage.Condition.Flags.SwitchB );
                Assert.AreEqual( instance.Condition.Flags.Variable, troopPage.Condition.Flags.Variable );
                Assert.AreEqual( instance.Condition.Flags.Turn, troopPage.Condition.Flags.Turn );
                Assert.AreEqual( instance.Condition.Flags.Fatigue, troopPage.Condition.Flags.Fatigue );
                Assert.AreEqual( instance.Condition.Flags.EnemyHP, troopPage.Condition.Flags.EnemyHP );
                Assert.AreEqual( instance.Condition.Flags.ActorHP, troopPage.Condition.Flags.ActorHP );
                Assert.AreEqual( instance.Condition.Flags.TurnEnemy, troopPage.Condition.Flags.TurnEnemy );
                Assert.AreEqual( instance.Condition.Flags.TurnActor, troopPage.Condition.Flags.TurnActor );
                Assert.AreEqual( instance.Condition.Flags.CommandActor, troopPage.Condition.Flags.CommandActor );

                Assert.AreEqual( instance.Condition.SwitchAID, troopPage.Condition.SwitchAID );
                Assert.AreEqual( instance.Condition.SwitchBID, troopPage.Condition.SwitchBID );
                Assert.AreEqual( instance.Condition.VariableID, troopPage.Condition.VariableID );
                Assert.AreEqual( instance.Condition.VariableValue, troopPage.Condition.VariableValue );
                Assert.AreEqual( instance.Condition.TurnA, troopPage.Condition.TurnA );
                Assert.AreEqual( instance.Condition.TurnB, troopPage.Condition.TurnB );
                Assert.AreEqual( instance.Condition.FatigueMin, troopPage.Condition.FatigueMin );
                Assert.AreEqual( instance.Condition.FatigueMax, troopPage.Condition.FatigueMax );
                Assert.AreEqual( instance.Condition.EnemyID, troopPage.Condition.EnemyID );
                Assert.AreEqual( instance.Condition.EnemyHPMin, troopPage.Condition.EnemyHPMin );
                Assert.AreEqual( instance.Condition.EnemyHPMax, troopPage.Condition.EnemyHPMax );
                Assert.AreEqual( instance.Condition.ActorID, troopPage.Condition.ActorID );
                Assert.AreEqual( instance.Condition.ActorHPMin, troopPage.Condition.ActorHPMin );
                Assert.AreEqual( instance.Condition.ActorHPMax, troopPage.Condition.ActorHPMax );
                Assert.AreEqual( instance.Condition.TurnEnemyID, troopPage.Condition.TurnEnemyID );
                Assert.AreEqual( instance.Condition.TurnEnemyA, troopPage.Condition.TurnEnemyA );
                Assert.AreEqual( instance.Condition.TurnEnemyB, troopPage.Condition.TurnEnemyB );
                Assert.AreEqual( instance.Condition.TurnActorID, troopPage.Condition.TurnActorID );
                Assert.AreEqual( instance.Condition.TurnActorA, troopPage.Condition.TurnActorA );
                Assert.AreEqual( instance.Condition.TurnActorB, troopPage.Condition.TurnActorB );
                Assert.AreEqual( instance.Condition.CommandActorID, troopPage.Condition.CommandActorID );
                Assert.AreEqual( instance.Condition.CommandID, troopPage.Condition.CommandID );

                // Compare EventCommands
                Assert.AreEqual( instance.EventCommands.Count, troopPage.EventCommands.Count );
                for ( int i = 0; i < instance.EventCommands.Count; i++ )
                {
                    var expectedCommand = instance.EventCommands[i];
                    var actualCommand = troopPage.EventCommands[i];

                    Assert.AreEqual( expectedCommand.Code, actualCommand.Code, $"EventCommand Code mismatch at index {i}." );
                    Assert.AreEqual( expectedCommand.Indent, actualCommand.Indent, $"EventCommand Indent mismatch at index {i}." );
                    Assert.AreEqual( expectedCommand.String, actualCommand.String, $"EventCommand String mismatch at index {i}." );

                    // Compare the Parameters list
                    Assert.AreEqual( expectedCommand.Parameters.Count, actualCommand.Parameters.Count, $"EventCommand Parameters count mismatch at index {i}." );
                    for ( int j = 0; j < expectedCommand.Parameters.Count; j++ )
                    {
                        Assert.AreEqual( expectedCommand.Parameters[j], actualCommand.Parameters[j], $"EventCommand Parameter mismatch at index {i}, parameter {j}." );
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

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopPage ) );
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
                        int end = Math.Min( minLength - 1, i + contextBytes );

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