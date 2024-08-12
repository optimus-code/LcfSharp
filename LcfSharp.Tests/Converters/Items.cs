using LcfSharp.IO.Converters;
using LcfSharp.Rpg.Items;

namespace LcfSharp.Tests.Converters
{
    [TestClass]
    public class Items
    {
        // Binary data representing the serialized form of the Item instance
        byte[] data = new byte[] { 0x02, 0x01, 0x08, 0x24, 0x64, 0x50, 0x6F, 0x74, 0x69, 0x6F, 0x6E, 0x02, 0x31, 0x52, 0x65, 0x63, 0x6F, 0x76, 0x65, 0x72, 0x73, 0x20, 0x35, 0x30, 0x25, 0x20, 0x6F, 0x66, 0x20, 0x24, 0x6B, 0x48, 0x50, 0x2C, 0x20, 0x61, 0x6C, 0x73, 0x6F, 0x20, 0x61, 0x76, 0x61, 0x69, 0x6C, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x74, 0x6F, 0x20, 0x63, 0x68, 0x69, 0x6C, 0x64, 0x72, 0x65, 0x6E, 0x21, 0x03, 0x01, 0x06, 0x05, 0x01, 0x28, 0x0F, 0x01, 0x00, 0x1F, 0x01, 0x00, 0x20, 0x01, 0x32, 0x21, 0x01, 0x0A, 0x33, 0x01, 0x00, 0x3E, 0x00, 0x40, 0x00, 0x42, 0x00, 0x00 };

        // Item instance based on provided JSON
        Item instance = new Item
        {
            ID = 2,
            Name = "$dPotion",
            Description = "Recovers 50% of $kHP, also available to children!",
            Type = ( ItemType ) 6,
            Price = 40,
            Uses = 0,
            AtkPoints1 = 0,
            DefPoints1 = 0,
            SpiPoints1 = 0,
            AgiPoints1 = 0,
            TwoHanded = false,
            SPCost = 0,
            Hit = 0,
            CriticalHit = 0,
            AnimationID = 0,
            Preemptive = false,
            DualAttack = false,
            AttackAll = false,
            IgnoreEvasion = false,
            PreventCritical = false,
            RaiseEvasion = false,
            HalfSPCost = false,
            NoTerrainDamage = false,
            Cursed = false,
            EntireParty = false,
            RecoverHPRate = 50,
            RecoverHP = 10,
            RecoverSPRate = 0,
            RecoverSP = 0,
            OccasionField1 = false,
            KOOnly = false,
            MaxHPPoints = 0,
            MaxSPPoints = 0,
            AtkPoints2 = 0,
            DefPoints2 = 0,
            SpiPoints2 = 0,
            AgiPoints2 = 0,
            UsingMessage = 0,
            SkillID = 0,
            SwitchID = 0,
            OccasionField2 = false,
            OccasionBattle = false,
            ActorSet = [],
            StateSet = [],
            AttributeSet = [],
            StateChance = 0,
            ReverseStateEffect = false,
            WeaponAnimation = 0,
            AnimationData = null,
            UseSkill = false,
            ClassSet = null,
            RangedTrajectory = 0,
            RangedTarget = 0
        };

        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new BinaryReader( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Item ) );
                var item = ( Item ) lcfConverter.Read( reader, null );

                Assert.AreEqual( instance.ID, item.ID );
                Assert.AreEqual( instance.Name, item.Name );
                Assert.AreEqual( instance.Description, item.Description );
                Assert.AreEqual( instance.Type, item.Type );
                Assert.AreEqual( instance.Price, item.Price );
                Assert.AreEqual( instance.Uses, item.Uses );
                Assert.AreEqual( instance.AtkPoints1, item.AtkPoints1 );
                Assert.AreEqual( instance.DefPoints1, item.DefPoints1 );
                Assert.AreEqual( instance.SpiPoints1, item.SpiPoints1 );
                Assert.AreEqual( instance.AgiPoints1, item.AgiPoints1 );
                Assert.AreEqual( instance.TwoHanded, item.TwoHanded );
                Assert.AreEqual( instance.SPCost, item.SPCost );
                Assert.AreEqual( instance.Hit, item.Hit );
                Assert.AreEqual( instance.CriticalHit, item.CriticalHit );
                Assert.AreEqual( instance.AnimationID, item.AnimationID );
                Assert.AreEqual( instance.Preemptive, item.Preemptive );
                Assert.AreEqual( instance.DualAttack, item.DualAttack );
                Assert.AreEqual( instance.AttackAll, item.AttackAll );
                Assert.AreEqual( instance.IgnoreEvasion, item.IgnoreEvasion );
                Assert.AreEqual( instance.PreventCritical, item.PreventCritical );
                Assert.AreEqual( instance.RaiseEvasion, item.RaiseEvasion );
                Assert.AreEqual( instance.HalfSPCost, item.HalfSPCost );
                Assert.AreEqual( instance.NoTerrainDamage, item.NoTerrainDamage );
                Assert.AreEqual( instance.Cursed, item.Cursed );
                Assert.AreEqual( instance.EntireParty, item.EntireParty );
                Assert.AreEqual( instance.RecoverHPRate, item.RecoverHPRate );
                Assert.AreEqual( instance.RecoverHP, item.RecoverHP );
                Assert.AreEqual( instance.RecoverSPRate, item.RecoverSPRate );
                Assert.AreEqual( instance.RecoverSP, item.RecoverSP );
                Assert.AreEqual( instance.OccasionField1, item.OccasionField1 );
                Assert.AreEqual( instance.KOOnly, item.KOOnly );
                Assert.AreEqual( instance.MaxHPPoints, item.MaxHPPoints );
                Assert.AreEqual( instance.MaxSPPoints, item.MaxSPPoints );
                Assert.AreEqual( instance.AtkPoints2, item.AtkPoints2 );
                Assert.AreEqual( instance.DefPoints2, item.DefPoints2 );
                Assert.AreEqual( instance.SpiPoints2, item.SpiPoints2 );
                Assert.AreEqual( instance.AgiPoints2, item.AgiPoints2 );
                Assert.AreEqual( instance.UsingMessage, item.UsingMessage );
                Assert.AreEqual( instance.SkillID, item.SkillID );
                Assert.AreEqual( instance.SwitchID, item.SwitchID );
                Assert.AreEqual( instance.OccasionField2, item.OccasionField2 );
                Assert.AreEqual( instance.OccasionBattle, item.OccasionBattle );
                CollectionAssert.AreEqual( instance.ActorSet, item.ActorSet );
                CollectionAssert.AreEqual( instance.StateSet, item.StateSet );
                CollectionAssert.AreEqual( instance.AttributeSet, item.AttributeSet );
                Assert.AreEqual( instance.StateChance, item.StateChance );
                Assert.AreEqual( instance.ReverseStateEffect, item.ReverseStateEffect );
                Assert.AreEqual( instance.WeaponAnimation, item.WeaponAnimation );
                Assert.AreEqual( instance.AnimationData, item.AnimationData );
                Assert.AreEqual( instance.UseSkill, item.UseSkill );
                Assert.AreEqual( instance.ClassSet, item.ClassSet );
                Assert.AreEqual( instance.RangedTrajectory, item.RangedTrajectory );
                Assert.AreEqual( instance.RangedTarget, item.RangedTarget );
            }
        }

        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new BinaryWriter( ms );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Item ) );
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
