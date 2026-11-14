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
using LcfSharp.Rpg.Skills;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests skill conversion and serialization.
    /// </summary>
    [TestClass]
    public class Skills
    {
        // Binary data representing the serialized form of the Skill instance
        byte[] data = [0x01, 0x0B, 0x24, 0x59, 0x53, 0x74, 0x75, 0x6E, 0x20, 0x43, 0x6C, 0x61, 0x77, 0x02, 0x22, 0x50, 0x61, 0x72, 0x61, 0x6C, 0x79, 0x7A, 0x65, 0x20, 0x31, 0x20, 0x65, 0x6E, 0x65, 0x6D, 0x79, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x70, 0x6F, 0x69, 0x73, 0x6F, 0x6E, 0x20, 0x63, 0x6C, 0x61, 0x77, 0x2E, 0x03, 0x1C, 0x25, 0x53, 0x20, 0x73, 0x6C, 0x61, 0x73, 0x68, 0x65, 0x73, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x24, 0x59, 0x53, 0x74, 0x75, 0x6E, 0x20, 0x43, 0x6C, 0x61, 0x77, 0x21, 0x07, 0x01, 0x03, 0x08, 0x01, 0x00, 0x0C, 0x01, 0x00, 0x0E, 0x01, 0x12, 0x10, 0x08, 0x01, 0x05, 0x28, 0x4F, 0x46, 0x46, 0x29, 0x00, 0x15, 0x01, 0x0A, 0x16, 0x01, 0x00, 0x1F, 0x01, 0x01, 0x29, 0x01, 0x08, 0x2A, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x2C, 0x00, 0x00];

        // Skill instance based on provided JSON
        Skill instance = new Skill
        {
            Name = "$YStun Claw",
            Description = "Paralyze 1 enemy with poison claw.",
            UsingMessage1 = "%S slashes with $YStun Claw!",
            UsingMessage2 = null,
            FailureMessage = 3,
            SkillType = 0,
            SPType = 0,
            SPPercent = 0,
            SPCost = 0,
            SkillScope = 0,
            SwitchID = 1,
            AnimationID = 18,
            SoundEffect = new Rpg.Audio.Sound
            {
                Name = "(OFF)",
                Volume = 100,
                Tempo = 100,
                Balance = 50
            },
            OccasionField = true,
            OccasionBattle = false,
            ReverseStateEffect = false,
            PhysicalRate = 10,
            MagicalRate = 0,
            Variance = 4,
            Power = 0,
            Hit = 100,
            AffectHP = true,
            AffectSP = false,
            AffectAttack = false,
            AffectDefense = false,
            AffectSpirit = false,
            AffectAgility = false,
            AbsorbDamage = false,
            IgnoreDefense = false,
            StateEffects = [0, 0, 0, 0, 0, 0, 0, 1],
            AttributeEffects = [],
            AffectAttrDefence = false,
            BattlerAnimation = -1,
            BattlerAnimationData = []
        };

        /// <summary>
        /// Checks skill deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Skill ) );
                var skill = ( Skill ) lcfConverter.Read( ref scope );

                Assert.AreEqual( instance.ID, skill.ID );
                Assert.AreEqual( instance.Name, skill.Name );
                Assert.AreEqual( instance.Description, skill.Description );
                Assert.AreEqual( instance.UsingMessage1, skill.UsingMessage1 );
                Assert.AreEqual( instance.UsingMessage2, skill.UsingMessage2 );
                Assert.AreEqual( instance.FailureMessage, skill.FailureMessage );
                Assert.AreEqual( instance.SkillType, skill.SkillType );
                Assert.AreEqual( instance.SPType, skill.SPType );
                Assert.AreEqual( instance.SPPercent, skill.SPPercent );
                Assert.AreEqual( instance.SPCost, skill.SPCost );
                Assert.AreEqual( instance.SkillScope, skill.SkillScope );
                Assert.AreEqual( instance.SwitchID, skill.SwitchID );
                Assert.AreEqual( instance.AnimationID, skill.AnimationID );

                Assert.AreEqual( instance.SoundEffect.Name, skill.SoundEffect.Name );
                Assert.AreEqual( instance.SoundEffect.Volume, skill.SoundEffect.Volume );
                Assert.AreEqual( instance.SoundEffect.Tempo, skill.SoundEffect.Tempo );
                Assert.AreEqual( instance.SoundEffect.Balance, skill.SoundEffect.Balance );

                Assert.AreEqual( instance.OccasionField, skill.OccasionField );
                Assert.AreEqual( instance.OccasionBattle, skill.OccasionBattle );
                Assert.AreEqual( instance.ReverseStateEffect, skill.ReverseStateEffect );
                Assert.AreEqual( instance.PhysicalRate, skill.PhysicalRate );
                Assert.AreEqual( instance.MagicalRate, skill.MagicalRate );
                Assert.AreEqual( instance.Variance, skill.Variance );
                Assert.AreEqual( instance.Power, skill.Power );
                Assert.AreEqual( instance.Hit, skill.Hit );
                Assert.AreEqual( instance.AffectHP, skill.AffectHP );
                Assert.AreEqual( instance.AffectSP, skill.AffectSP );
                Assert.AreEqual( instance.AffectAttack, skill.AffectAttack );
                Assert.AreEqual( instance.AffectDefense, skill.AffectDefense );
                Assert.AreEqual( instance.AffectSpirit, skill.AffectSpirit );
                Assert.AreEqual( instance.AffectAgility, skill.AffectAgility );
                Assert.AreEqual( instance.AbsorbDamage, skill.AbsorbDamage );
                Assert.AreEqual( instance.IgnoreDefense, skill.IgnoreDefense );

                TestHelpers.AssertBuffer( instance.StateEffects.ToArray( ), skill.StateEffects.ToArray( ) );
                TestHelpers.AssertBuffer( instance.AttributeEffects.ToArray( ), skill.AttributeEffects.ToArray( ) );
                Assert.AreEqual( instance.AffectAttrDefence, skill.AffectAttrDefence );
                Assert.AreEqual( instance.BattlerAnimation, skill.BattlerAnimation );
                CollectionAssert.AreEqual( instance.BattlerAnimationData, skill.BattlerAnimationData );
            }
        }

        /// <summary>
        /// Checks skill serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Skill ) );
                lcfConverter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}