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
using LcfSharp.IO.Converters;
using LcfSharp.Rpg.Events;
using LcfSharp.Rpg.Troops;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests troop page conversion and serialization.
    /// </summary>
    [TestClass]
    public class TroopPages
    {
        // Binary data representing the serialized form of the TroopPage instance
        byte[] data = [0x02, 0x04, 0x01, 0x01, 0x08, 0x00, 0x0B, 0x01, 0x0D, 0x0C, 0x0D, 0xCF, 0x62, 0x00, 0x00, 0x04, 0x00, 0x56, 0x56, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00];

        // TroopPage instance based on provided data
        TroopPage instance = new TroopPage
        {
            Condition = new TroopPageCondition
            {
                Flags = new TroopPageConditionFlags
                {
                    SwitchA = false,
                    SwitchB = false,
                    Variable = false,
                    Turn = true,
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
                new EventCommand { Code = ( EventCommandCode ) 10210, Indent = 0, String = null, Parameters = [0, 86, 86, 0] }
            ]
        };

        /// <summary>
        /// Checks trooppage deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopPage ) );
                var troopPage = ( TroopPage ) lcfConverter.Read( ref scope );

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

        /// <summary>
        /// Checks trooppage serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopPage ) );
                lcfConverter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );                
            }
        }
    }
}