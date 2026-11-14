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
using LcfSharp.Rpg.States;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests state conversion and serialization.
    /// </summary>
    [TestClass]
    public class States
    {
        // Binary data representing the serialized form of the State instance
        byte[] data = [0x01, 0x08, 0x24, 0x6E, 0x50, 0x4F, 0x49, 0x53, 0x4F, 0x4E, 0x02, 0x01, 0x01, 0x03, 0x01, 0x0D, 0x05, 0x01, 0x00, 0x0B, 0x01, 0x5A, 0x0C, 0x01, 0x46, 0x0D, 0x01, 0x32, 0x33, 0x0E, 0x25, 0x53, 0x20, 0x67, 0x6F, 0x74, 0x20, 0x50, 0x4F, 0x49, 0x53, 0x4F, 0x4E, 0x21, 0x34, 0x0D, 0x25, 0x53, 0x20, 0x69, 0x73, 0x20, 0x50, 0x4F, 0x49, 0x53, 0x4F, 0x4E, 0x21, 0x35, 0x19, 0x25, 0x53, 0x20, 0x24, 0x6E, 0x20, 0x28, 0x50, 0x6F, 0x69, 0x73, 0x6F, 0x6E, 0x65, 0x64, 0x29, 0x20, 0x61, 0x6C, 0x72, 0x65, 0x61, 0x64, 0x79, 0x2E, 0x36, 0x1C, 0x25, 0x53, 0x20, 0x6C, 0x6F, 0x73, 0x74, 0x20, 0x73, 0x6F, 0x6D, 0x65, 0x20, 0x48, 0x50, 0x20, 0x66, 0x72, 0x6F, 0x6D, 0x20, 0x70, 0x6F, 0x69, 0x73, 0x6F, 0x6E, 0x2E, 0x37, 0x10, 0x25, 0x53, 0x20, 0x50, 0x4F, 0x49, 0x53, 0x4F, 0x4E, 0x20, 0x43, 0x55, 0x52, 0x45, 0x44, 0x21, 0x3D, 0x01, 0x05, 0x3E, 0x01, 0x01, 0x3F, 0x01, 0x04, 0x40, 0x01, 0x01, 0x00];

        // State instance based on provided data
        State instance = new( )
        {
            Name = "$nPOISON",
            Type = ( StatePersistence ) 1,
            Color = 13,
            Priority = 50,
            Restriction = 0,
            ARate = 90,
            BRate = 70,
            CRate = 50,
            DRate = 30,
            ERate = 0,
            HoldTurn = 0,
            AutoReleaseProb = 0,
            ReleaseByDamage = 0,
            AffectType = 0,
            AffectAttack = false,
            AffectDefense = false,
            AffectSpirit = false,
            AffectAgility = false,
            ReduceHitRatio = 100,
            AvoidAttacks = false,
            ReflectMagic = false,
            Cursed = false,
            BattlerAnimationID = 100,
            RestrictSkill = false,
            RestrictSkillLevel = 0,
            RestrictMagic = false,
            RestrictMagicLevel = 0,
            HPChangeType = 0,
            SPChangeType = 0,
            MessageActor = "%S got POISON!",
            MessageEnemy = "%S is POISON!",
            MessageAlready = "%S $n (Poisoned) already.",
            MessageAffected = "%S lost some HP from poison.",
            MessageRecovery = "%S POISON CURED!",
            HPChangeMax = 5,
            HPChangeVal = 1,
            HPChangeMapSteps = 4,
            HPChangeMapVal = 1,
            SPChangeMax = 0,
            SPChangeVal = 0,
            SPChangeMapSteps = 0,
            SPChangeMapVal = 0
        };

        /// <summary>
        /// Checks state deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( State ) );
                var state = ( State ) lcfConverter.Read( ref scope );

                Assert.AreEqual( instance.ID, state.ID );
                Assert.AreEqual( instance.Name, state.Name );
                Assert.AreEqual( instance.Type, state.Type );
                Assert.AreEqual( instance.Color, state.Color );
                Assert.AreEqual( instance.Priority, state.Priority );
                Assert.AreEqual( instance.Restriction, state.Restriction );
                Assert.AreEqual( instance.ARate, state.ARate );
                Assert.AreEqual( instance.BRate, state.BRate );
                Assert.AreEqual( instance.CRate, state.CRate );
                Assert.AreEqual( instance.DRate, state.DRate );
                Assert.AreEqual( instance.ERate, state.ERate );
                Assert.AreEqual( instance.HoldTurn, state.HoldTurn );
                Assert.AreEqual( instance.AutoReleaseProb, state.AutoReleaseProb );
                Assert.AreEqual( instance.ReleaseByDamage, state.ReleaseByDamage );
                Assert.AreEqual( instance.AffectType, state.AffectType );
                Assert.AreEqual( instance.AffectAttack, state.AffectAttack );
                Assert.AreEqual( instance.AffectDefense, state.AffectDefense );
                Assert.AreEqual( instance.AffectSpirit, state.AffectSpirit );
                Assert.AreEqual( instance.AffectAgility, state.AffectAgility );
                Assert.AreEqual( instance.ReduceHitRatio, state.ReduceHitRatio );
                Assert.AreEqual( instance.AvoidAttacks, state.AvoidAttacks );
                Assert.AreEqual( instance.ReflectMagic, state.ReflectMagic );
                Assert.AreEqual( instance.Cursed, state.Cursed );
                Assert.AreEqual( instance.BattlerAnimationID, state.BattlerAnimationID );
                Assert.AreEqual( instance.RestrictSkill, state.RestrictSkill );
                Assert.AreEqual( instance.RestrictSkillLevel, state.RestrictSkillLevel );
                Assert.AreEqual( instance.RestrictMagic, state.RestrictMagic );
                Assert.AreEqual( instance.RestrictMagicLevel, state.RestrictMagicLevel );
                Assert.AreEqual( instance.HPChangeType, state.HPChangeType );
                Assert.AreEqual( instance.SPChangeType, state.SPChangeType );
                Assert.AreEqual( instance.MessageActor, state.MessageActor );
                Assert.AreEqual( instance.MessageEnemy, state.MessageEnemy );
                Assert.AreEqual( instance.MessageAlready, state.MessageAlready );
                Assert.AreEqual( instance.MessageAffected, state.MessageAffected );
                Assert.AreEqual( instance.MessageRecovery, state.MessageRecovery );
                Assert.AreEqual( instance.HPChangeMax, state.HPChangeMax );
                Assert.AreEqual( instance.HPChangeVal, state.HPChangeVal );
                Assert.AreEqual( instance.HPChangeMapSteps, state.HPChangeMapSteps );
                Assert.AreEqual( instance.HPChangeMapVal, state.HPChangeMapVal );
                Assert.AreEqual( instance.SPChangeMax, state.SPChangeMax );
                Assert.AreEqual( instance.SPChangeVal, state.SPChangeVal );
                Assert.AreEqual( instance.SPChangeMapSteps, state.SPChangeMapSteps );
                Assert.AreEqual( instance.SPChangeMapVal, state.SPChangeMapVal );
            }
        }

        /// <summary>
        /// Checks state serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( State ) );
                lcfConverter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}