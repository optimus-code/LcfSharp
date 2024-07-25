using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Actors;
using LcfSharp.Rpg.Animations;
using LcfSharp.Rpg.Attributes;
using LcfSharp.Rpg.Battle;
using LcfSharp.Rpg.Battle.Battlers;
using LcfSharp.Rpg.Chipsets;
using LcfSharp.Rpg.Classes;
using LcfSharp.Rpg.Enemies;
using LcfSharp.Rpg.Events;
using LcfSharp.Rpg.Items;
using LcfSharp.Rpg.Skills;
using LcfSharp.Rpg.States;
using LcfSharp.Rpg.Terrains;
using LcfSharp.Rpg.Troops;
using System.Collections.Generic;
using System.IO;

namespace LcfSharp.Rpg
{
    public enum DatabaseChunk : int
    {
        /** rpg::Actor */
        Actors = 0x0B,
        /** rpg::Skill */
        Skills = 0x0C,
        /** rpg::Item */
        Items = 0x0D,
        /** rpg::Enemy */
        Enemies = 0x0E,
        /** rpg::Troop */
        Troops = 0x0F,
        /** rpg::Terrain */
        Terrains = 0x10,
        /** rpg::Attribute */
        Attributes = 0x11,
        /** rpg::State */
        States = 0x12,
        /** rpg::Animation */
        Animations = 0x13,
        /** rpg::Chipset */
        Chipsets = 0x14,
        /** rpg::Terms */
        Terms = 0x15,
        /** rpg::System */
        System = 0x16,
        /** rpg::Switches */
        Switches = 0x17,
        /** rpg::Variables */
        Variables = 0x18,
        /** rpg::CommonEvent */
        CommonEvents = 0x19,
        /** Indicates version of database. When 1 the database was converted to RPG Maker 2000 v1.61 */
        Version = 0x1A,
        /** Duplicated? - Not used - RPG2003 */
        CommonEventD2 = 0x1B,
        /** Duplicated? - Not used - RPG2003 */
        CommonEventD3 = 0x1C,
        /** rpg::BattleCommand - RPG2003 */
        BattleCommands = 0x1D,
        /** rpg::Class - RPG2003 */
        Classes = 0x1E,
        /** Duplicated? - Not used - RPG2003 */
        ClassD1 = 0x1F,
        /** rpg::BattlerAnimation - RPG2003 */
        BattlerAnimations = 0x20
    }

    [LcfChunk<DatabaseChunk>]
    public class Database : ILcfRootChunk
    {
        [LcfIgnore]
        public string Header
        {
            get;
            set;
        }

        public List<Actor> Actors
        {
            get;
            set;
        } = new List<Actor>();

        public List<Skill> Skills
        {
            get;
            set;
        } = new List<Skill>();

        public List<Item> Items
        {
            get;
            set;
        } = new List<Item>();

        public List<Enemy> Enemies
        {
            get;
            set;
        } = new List<Enemy>();

        public List<Troop> Troops
        {
            get;
            set;
        } = new List<Troop>();

        public List<Terrain> Terrains
        {
            get;
            set;
        } = new List<Terrain>();

        public List<Attribute> Attributes
        {
            get;
            set;
        } = new List<Attribute>();

        public List<State> States
        {
            get;
            set;
        } = new List<State>();

        public List<Animation> Animations
        {
            get;
            set;
        } = new List<Animation>();

        public List<Chipset> Chipsets
        {
            get;
            set;
        } = new List<Chipset>();

        public Terms Terms
        {
            get;
            set;
        }

        public RpgSystem System
        {
            get;
            set;
        }

        public List<Switch> Switches
        {
            get;
            set;
        } = new List<Switch>();

        public List<Variable> Variables
        {
            get;
            set;
        } = new List<Variable>();

        public List<CommonEvent> CommonEvents
        {
            get;
            set;
        } = new List<CommonEvent>();

        public int Version
        {
            get;
            set;
        } = 0;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
        public BattleCommands BattleCommands
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
        public List<Class> Classes
        {
            get;
            set;
        } = new List<Class>();

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
        public List<BattlerAnimation> BattlerAnimations
        {
            get;
            set;
        } = new List<BattlerAnimation>();
    }
}