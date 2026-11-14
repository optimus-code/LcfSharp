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
using LcfSharp.Rpg.Troops;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests troop page condition conversion and serialization.
    /// </summary>
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
        };

        /// <summary>
        /// Checks trooppagecondition deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopPageCondition ) );
                var condition = ( TroopPageCondition ) lcfConverter.Read( ref scope );

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

        /// <summary>
        /// Checks trooppagecondition serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( TroopPageCondition ) );
                lcfConverter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}
