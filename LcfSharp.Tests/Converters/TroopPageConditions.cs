using LcfSharp.Rpg.Troops;
using LcfSharp.IO.Converters;
using LcfSharp.IO.Extensions;
using System.IO;
using System.Linq;
using System;

namespace LcfSharp.Tests.Converters
{
    [TestClass]
    public class TroopPageConditions
    {
        // Binary data representing the serialized form of the TroopPageCondition instance
        byte[] data = [0x01, 0x01, 0x08, 0x00];

        // TroopPageCondition instance based on provided data
        TroopPageCondition instance = new TroopPageCondition
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
        };

        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new BinaryReader( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopPageCondition ) );
                var condition = ( TroopPageCondition ) lcfConverter.Read( reader, null );

                // Compare Flags
                Assert.AreEqual( instance.Flags.SwitchA, condition.Flags.SwitchA );
                Assert.AreEqual( instance.Flags.SwitchB, condition.Flags.SwitchB );
                Assert.AreEqual( instance.Flags.Variable, condition.Flags.Variable );
                Assert.AreEqual( instance.Flags.Turn, condition.Flags.Turn );
                Assert.AreEqual( instance.Flags.Fatigue, condition.Flags.Fatigue );
                Assert.AreEqual( instance.Flags.EnemyHP, condition.Flags.EnemyHP );
                Assert.AreEqual( instance.Flags.ActorHP, condition.Flags.ActorHP );
                Assert.AreEqual( instance.Flags.TurnEnemy, condition.Flags.TurnEnemy );
                Assert.AreEqual( instance.Flags.TurnActor, condition.Flags.TurnActor );
                Assert.AreEqual( instance.Flags.CommandActor, condition.Flags.CommandActor );

                // Compare other properties
                Assert.AreEqual( instance.SwitchAID, condition.SwitchAID );
                Assert.AreEqual( instance.SwitchBID, condition.SwitchBID );
                Assert.AreEqual( instance.VariableID, condition.VariableID );
                Assert.AreEqual( instance.VariableValue, condition.VariableValue );
                Assert.AreEqual( instance.TurnA, condition.TurnA );
                Assert.AreEqual( instance.TurnB, condition.TurnB );
                Assert.AreEqual( instance.FatigueMin, condition.FatigueMin );
                Assert.AreEqual( instance.FatigueMax, condition.FatigueMax );
                Assert.AreEqual( instance.EnemyID, condition.EnemyID );
                Assert.AreEqual( instance.EnemyHPMin, condition.EnemyHPMin );
                Assert.AreEqual( instance.EnemyHPMax, condition.EnemyHPMax );
                Assert.AreEqual( instance.ActorID, condition.ActorID );
                Assert.AreEqual( instance.ActorHPMin, condition.ActorHPMin );
                Assert.AreEqual( instance.ActorHPMax, condition.ActorHPMax );
                Assert.AreEqual( instance.TurnEnemyID, condition.TurnEnemyID );
                Assert.AreEqual( instance.TurnEnemyA, condition.TurnEnemyA );
                Assert.AreEqual( instance.TurnEnemyB, condition.TurnEnemyB );
                Assert.AreEqual( instance.TurnActorID, condition.TurnActorID );
                Assert.AreEqual( instance.TurnActorA, condition.TurnActorA );
                Assert.AreEqual( instance.TurnActorB, condition.TurnActorB );
                Assert.AreEqual( instance.CommandActorID, condition.CommandActorID );
                Assert.AreEqual( instance.CommandID, condition.CommandID );
            }
        }

        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new BinaryWriter( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopPageCondition ) );
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
