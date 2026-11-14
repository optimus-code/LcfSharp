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
using LcfSharp.Rpg.Items;
using System.IO;

namespace LcfSharp.Tests.Converters
{
    /// <summary>
    /// Tests item conversion and serialization.
    /// </summary>
    [TestClass]
    public class Items
    {
        // Binary data representing the serialized form of the Item instance
        byte[] data = [0x01, 0x08, 0x24, 0x64, 0x50, 0x6F, 0x74, 0x69, 0x6F, 0x6E, 0x02, 0x31, 0x52, 0x65, 0x63, 0x6F, 0x76, 0x65, 0x72, 0x73, 0x20, 0x35, 0x30, 0x25, 0x20, 0x6F, 0x66, 0x20, 0x24, 0x6B, 0x48, 0x50, 0x2C, 0x20, 0x61, 0x6C, 0x73, 0x6F, 0x20, 0x61, 0x76, 0x61, 0x69, 0x6C, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x74, 0x6F, 0x20, 0x63, 0x68, 0x69, 0x6C, 0x64, 0x72, 0x65, 0x6E, 0x21, 0x03, 0x01, 0x06, 0x05, 0x01, 0x28, 0x0F, 0x01, 0x00, 0x1F, 0x01, 0x00, 0x20, 0x01, 0x32, 0x21, 0x01, 0x0A, 0x33, 0x01, 0x00, 0x3E, 0x00, 0x40, 0x00, 0x42, 0x00, 0x00];

        // Item instance based on provided JSON
        Item instance = new Item
        {
            Name = "$dPotion",
            Description = "Recovers 50% of $kHP, also available to children!",
            Type = ( ItemType ) 6,
            Price = 40,
            Uses = 1,
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
            OccasionField2 = true,
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

        /// <summary>
        /// Checks item deserialization.
        /// </summary>
        [TestMethod]
        public void Read( )
        {
            using ( var ms = new MemoryStream( data ) )
            {
                var reader = new LcfReader( ms );
                var scope = reader.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Item ) );
                var item = ( Item ) lcfConverter.Read( ref scope );

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
                TestHelpers.AssertBuffer( instance.ActorSet.ToArray( ), item.ActorSet.ToArray( ) );
                TestHelpers.AssertBuffer( instance.StateSet.ToArray( ), item.StateSet.ToArray( ) );
                TestHelpers.AssertBuffer( instance.AttributeSet.ToArray( ), item.AttributeSet.ToArray( ) );
                Assert.AreEqual( instance.StateChance, item.StateChance );
                Assert.AreEqual( instance.ReverseStateEffect, item.ReverseStateEffect );
                Assert.AreEqual( instance.WeaponAnimation, item.WeaponAnimation );
                Assert.AreSequenceEqual( instance.AnimationData, item.AnimationData );
                Assert.AreEqual( instance.UseSkill, item.UseSkill );
                Assert.AreSequenceEqual( instance.ClassSet, item.ClassSet );
                Assert.AreEqual( instance.RangedTrajectory, item.RangedTrajectory );
                Assert.AreEqual( instance.RangedTarget, item.RangedTarget );
            }
        }

        /// <summary>
        /// Checks item serialization.
        /// </summary>
        [TestMethod]
        public void Write( )
        {
            using ( var ms = new MemoryStream( ) )
            {
                var writer = new LcfWriter( ms );
                var scope = writer.CreateRootScope( );

                var lcfConverter = LcfConverterFactory.GetConverter( typeof( Item ) );
                lcfConverter.Write( ref scope, instance );
                writer.Commit( ref scope );

                TestHelpers.AssertBuffer( data, ms.ToArray( ) );
            }
        }
    }
}
