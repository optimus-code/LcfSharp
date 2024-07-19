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
    public class Database
    {
        public string LdbHeader
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
            while (!reader.IsEOF)
            {
                int fieldIndex = reader.ReadInt();
                int fieldLength = reader.ReadInt();

                switch (fieldIndex)
                {
                    case 0x01: // name
                        Actors.Add(ReadActor(reader, fieldLength));
                        break;
                    case 0x02: // title
                        Skills.Add(ReadSkill(reader, fieldLength));
                        break;
                    case 0x03: // character_name
                        Items.Add(ReadItem(reader, fieldLength));
                        break;
                    // Add other cases here...
                    default:
                        reader.BaseStream.Seek(fieldLength, SeekOrigin.Current);
                        break;
                }
            }
        }

    }
}
