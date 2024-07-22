using LcfSharp.IO;
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

    public class Database
    {
        public string LdbHeader
        {
            get;
            set;
        }

        public static bool IsRM2K3
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

        public BattleCommands BattleCommands
        {
            get;
            set;
        }

        public List<Class> Classes
        {
            get;
            set;
        } = new List<Class>();

        public List<BattlerAnimation> BattlerAnimations
        {
            get;
            set;
        } = new List<BattlerAnimation>();

        public Database(LcfReader reader)
        {
            var headerLength = reader.ReadInt();
            var header = reader.ReadString(headerLength);

            if (string.IsNullOrEmpty(header) || header.Length != 11)
                throw new InvalidDataException();

            //if (header != "LcfDataBase")
            //    System.Console.WriteLine("This may not be a correct database format");

            LdbHeader = header;

            TypeHelpers.ReadChunks<DatabaseChunk>(reader, (chunk) =>
            {
                switch ((DatabaseChunk)chunk.ID)
                {
                    case DatabaseChunk.Actors:
                        Actors = new List<Actor>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Actors.Add(new Actor(reader));
                        });
                        return true;

                    case DatabaseChunk.Skills:
                        Skills = new List<Skill>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Skills.Add(new Skill(reader));
                        });
                        return true;

                    case DatabaseChunk.Items:
                        Items = new List<Item>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Items.Add(new Item(reader));
                        });
                        return true;

                    case DatabaseChunk.Enemies:
                        Enemies = new List<Enemy>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Enemies.Add(new Enemy(reader));
                        });
                        return true;

                    case DatabaseChunk.Troops:
                        Troops = new List<Troop>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Troops.Add(new Troop(reader));
                        });
                        return true;

                    case DatabaseChunk.Terrains:
                        Terrains = new List<Terrain>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Terrains.Add(new Terrain(reader));
                        });
                        return true;

                    case DatabaseChunk.Attributes:
                        Attributes = new List<Attribute>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Attributes.Add(new Attribute(reader));
                        });
                        return true;

                    case DatabaseChunk.States:
                        States = new List<State>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            States.Add(new State(reader));
                        });
                        return true;

                    case DatabaseChunk.Animations:
                        Animations = new List<Animation>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Animations.Add(new Animation(reader));
                        });
                        return true;

                    case DatabaseChunk.Chipsets:
                        Chipsets = new List<Chipset>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Chipsets.Add(new Chipset(reader));
                        });
                        return true;

                    case DatabaseChunk.Terms:
                        Terms = new Terms(reader);
                        return true;

                    case DatabaseChunk.System:
                        System = new RpgSystem(reader);
                        return true;

                    case DatabaseChunk.Switches:
                        Switches = new List<Switch>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Switches.Add(new Switch(reader));
                        });
                        return true;

                    case DatabaseChunk.Variables:
                        Variables = new List<Variable>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Variables.Add(new Variable(reader));
                        });
                        return true;

                    case DatabaseChunk.CommonEvents:
                        CommonEvents = new List<CommonEvent>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            CommonEvents.Add(new CommonEvent(reader));
                        });
                        return true;

                    case DatabaseChunk.Version:
                        Version = reader.ReadInt();
                        return true;

                    case DatabaseChunk.BattleCommands:
                        if (!IsRM2K3)
                            return false;
                        BattleCommands = new BattleCommands(reader);
                        return true;

                    case DatabaseChunk.Classes:
                        if (!IsRM2K3)
                            return false;
                        Classes = new List<Class>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Classes.Add(new Class(reader));
                        });
                        return true;

                    case DatabaseChunk.BattlerAnimations:
                        if (!IsRM2K3)
                            return false;
                        BattlerAnimations = new List<BattlerAnimation>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            BattlerAnimations.Add(new BattlerAnimation(reader));
                        });
                        return true;
                }
                return false;
            }, () =>
            {
                return reader.IsEOF;
            });
        }
    }
}