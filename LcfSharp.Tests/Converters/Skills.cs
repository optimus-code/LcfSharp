using LcfSharp.Rpg.Skills;
using LcfSharp.IO.Converters;
using LcfSharp.IO.Extensions;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LcfSharp.Tests.Converters
{
    [TestClass]
    public class Skills
    {
        // Binary data representing the serialized form of the Skill instance
        byte[] data = [0x05, 0x01, 0x0B, 0x24, 0x59, 0x53, 0x74, 0x75, 0x6E, 0x20, 0x43, 0x6C, 0x61, 0x77, 0x02, 0x22, 0x50, 0x61, 0x72, 0x61, 0x6C, 0x79, 0x7A, 0x65, 0x20, 0x31, 0x20, 0x65, 0x6E, 0x65, 0x6D, 0x79, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x70, 0x6F, 0x69, 0x73, 0x6F, 0x6E, 0x20, 0x63, 0x6C, 0x61, 0x77, 0x2E, 0x03, 0x1C, 0x25, 0x53, 0x20, 0x73, 0x6C, 0x61, 0x73, 0x68, 0x65, 0x73, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x24, 0x59, 0x53, 0x74, 0x75, 0x6E, 0x20, 0x43, 0x6C, 0x61, 0x77, 0x21, 0x07, 0x01, 0x03, 0x08, 0x01, 0x00, 0x0C, 0x01, 0x00, 0x0E, 0x01, 0x12, 0x10, 0x08, 0x01, 0x05, 0x28, 0x4F, 0x46, 0x46, 0x29, 0x00, 0x15, 0x01, 0x0A, 0x16, 0x01, 0x00, 0x1F, 0x01, 0x01, 0x29, 0x01, 0x08, 0x2A, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x2C, 0x00, 0x00];

        // Skill instance based on provided JSON
        Skill instance = new Skill
        {
            ID = 5,
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
            StateEffects = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 1 },
            AttributeEffects = [],
            AffectAttrDefence = false,
            BattlerAnimation = -1,
            BattlerAnimationData = []
        };

        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new BinaryReader( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Skill ) );
                var skill = ( Skill ) lcfConverter.Read( reader, null );

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

                CollectionAssert.AreEqual( instance.StateEffects, skill.StateEffects );
                CollectionAssert.AreEqual( instance.AttributeEffects, skill.AttributeEffects );
                Assert.AreEqual( instance.AffectAttrDefence, skill.AffectAttrDefence );
                Assert.AreEqual( instance.BattlerAnimation, skill.BattlerAnimation );
                CollectionAssert.AreEqual( instance.BattlerAnimationData, skill.BattlerAnimationData );
            }
        }

        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new BinaryWriter( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Skill ) );
                lcfConverter.Write( writer, instance, false );

                var buffer = ms.ToArray( );
                int minLength = System.Math.Min( buffer.Length, data.Length );
                int contextBytes = 5; // Number of bytes to show before and after the deviation

                for ( int i = 0; i < minLength; i++ )
                {
                    if ( buffer[i] != data[i] )
                    {
                        // Show surrounding bytes for context
                        int start = System.Math.Max( 0, i - contextBytes );
                        int end = System.Math.Min( minLength - 1, i + contextBytes );

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