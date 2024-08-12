using LcfSharp.Rpg.States;
using LcfSharp.IO.Converters;
using LcfSharp.IO.Extensions;
using System.IO;
using System.Linq;
using System;

namespace LcfSharp.Tests.Converters
{
    [TestClass]
    public class States
    {
        // Binary data representing the serialized form of the State instance
        byte[] data = [0x02, 0x01, 0x08, 0x24, 0x6E, 0x50, 0x4F, 0x49, 0x53, 0x4F, 0x4E, 0x02, 0x01, 0x01, 0x03, 0x01, 0x0D, 0x05, 0x01, 0x00, 0x0B, 0x01, 0x5A, 0x0C, 0x01, 0x46, 0x0D, 0x01, 0x32, 0x33, 0x0E, 0x25, 0x53, 0x20, 0x67, 0x6F, 0x74, 0x20, 0x50, 0x4F, 0x49, 0x53, 0x4F, 0x4E, 0x21, 0x34, 0x0D, 0x25, 0x53, 0x20, 0x69, 0x73, 0x20, 0x50, 0x4F, 0x49, 0x53, 0x4F, 0x4E, 0x21, 0x35, 0x19, 0x25, 0x53, 0x20, 0x24, 0x6E, 0x20, 0x28, 0x50, 0x6F, 0x69, 0x73, 0x6F, 0x6E, 0x65, 0x64, 0x29, 0x20, 0x61, 0x6C, 0x72, 0x65, 0x61, 0x64, 0x79, 0x2E, 0x36, 0x1C, 0x25, 0x53, 0x20, 0x6C, 0x6F, 0x73, 0x74, 0x20, 0x73, 0x6F, 0x6D, 0x65, 0x20, 0x48, 0x50, 0x20, 0x66, 0x72, 0x6F, 0x6D, 0x20, 0x70, 0x6F, 0x69, 0x73, 0x6F, 0x6E, 0x2E, 0x37, 0x10, 0x25, 0x53, 0x20, 0x50, 0x4F, 0x49, 0x53, 0x4F, 0x4E, 0x20, 0x43, 0x55, 0x52, 0x45, 0x44, 0x21, 0x3D, 0x01, 0x05, 0x3E, 0x01, 0x01, 0x3F, 0x01, 0x04, 0x40, 0x01, 0x01, 0x00];

        // State instance based on provided data
        State instance = new( )
        {
            ID = 2,
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

        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new BinaryReader( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( State ) );
                var state = ( State ) lcfConverter.Read( reader, null );

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

        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new BinaryWriter( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( State ) );
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