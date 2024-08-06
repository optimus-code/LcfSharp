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

using LcfSharp.Chunks.Database;
using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Converters;
using LcfSharp.IO.Types;
using LcfSharp.Rpg;
using LcfSharp.Rpg.Actors;
using LcfSharp.Rpg.Animations;
using LcfSharp.Rpg.Attributes;
using LcfSharp.Rpg.Battle.Battlers;
using LcfSharp.Rpg.Battle.Commands;
using LcfSharp.Rpg.Chipsets;
using LcfSharp.Rpg.Classes;
using LcfSharp.Rpg.Core;
using LcfSharp.Rpg.Enemies;
using LcfSharp.Rpg.Events;
using LcfSharp.Rpg.GameSystems;
using LcfSharp.Rpg.Items;
using LcfSharp.Rpg.Skills;
using LcfSharp.Rpg.States;
using LcfSharp.Rpg.Terrains;
using LcfSharp.Rpg.Troops;
using System.Collections.Generic;
using System.IO;

namespace LcfSharp
{
    /// <summary>
    /// Class representing the RPG Maker database containing various game data.
    /// </summary>
    [LcfChunk<DatabaseChunk>]
    public class LdbFile : ILcfRootChunk
    {
        /// <summary>
        /// The header of the database.
        /// </summary>
        [LcfIgnore]
        public string Header
        {
            get;
            set;
        }

        /// <summary>
        /// The list of actors in the database.
        /// </summary>
        public List<Actor> Actors
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of skills in the database.
        /// </summary>
        public List<Skill> Skills
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of items in the database.
        /// </summary>
        public List<Item> Items
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of enemies in the database.
        /// </summary>
        public List<Enemy> Enemies
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of troops in the database.
        /// </summary>
        public List<Troop> Troops
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of terrains in the database.
        /// </summary>
        public List<Terrain> Terrains
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of attributes in the database.
        /// </summary>
        public List<Attribute> Attributes
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of states in the database.
        /// </summary>
        public List<State> States
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of animations in the database.
        /// </summary>
        public List<Animation> Animations
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of chipsets in the database.
        /// </summary>
        public List<Chipset> Chipsets
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The terms used in the game.
        /// </summary>
        public Terms Terms
        {
            get;
            set;
        }

        /// <summary>
        /// The system settings of the game.
        /// </summary>
        public GameSystem System
        {
            get;
            set;
        }

        /// <summary>
        /// The list of switches in the database.
        /// </summary>
        public List<Switch> Switches
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of variables in the database.
        /// </summary>
        public List<Variable> Variables
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of common events in the database.
        /// </summary>
        public List<CommonEvent> CommonEvents
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The version of the database.
        /// </summary>
        public int Version
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The battle commands settings for RPG Maker 2003.
        /// </summary>
        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public BattleCommands BattleCommands
        {
            get;
            set;
        }

        /// <summary>
        /// The list of classes in the database for RPG Maker 2003.
        /// </summary>
        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public List<Class> Classes
        {
            get;
            set;
        } = [];

        /// <summary>
        /// The list of battler animations in the database for RPG Maker 2003.
        /// </summary>
        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public List<BattlerAnimation> BattlerAnimations
        {
            get;
            set;
        } = [];

        /// <summary>
        /// Loads the database from the specified file path.
        /// </summary>
        /// <param name="path">The file path of the map tree.</param>
        /// <returns>The loaded Map Tree object.</returns>
        public static LdbFile Load(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return LcfSerialiser.Deserialise<LdbFile>(stream);
            }
        }
    }
}