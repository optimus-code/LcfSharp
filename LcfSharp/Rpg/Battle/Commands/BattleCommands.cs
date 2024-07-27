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

using LcfSharp.Chunks.Database.Battle;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle.Commands
{
    /// <summary>
    /// Class representing the battle commands settings.
    /// </summary>
    [LcfChunk<BattleCommandsChunk>]
    public class BattleCommands
    {
        /// <summary>
        /// The placement of battle commands. Default is Manual.
        /// </summary>
        public BattleCommandsPlacement Placement
        {
            get;
            set;
        } = BattleCommandsPlacement.Manual;

        /// <summary>
        /// Indicates whether the death handler is unused. Only available in RM2K3. Default is false.
        /// </summary>
        [LcfVersion(LcfEngineVersion.RM2K3)]
        public bool DeathHandlerUnused
        {
            get;
            set;
        } = false;

        /// <summary>
        /// The row shown for battle commands. Default is Front.
        /// </summary>
        public BattleCommandsRowShown Row
        {
            get;
            set;
        } = BattleCommandsRowShown.Front;

        /// <summary>
        /// The battle type for battle commands. Default is Traditional.
        /// </summary>
        public BattleCommandsBattleType BattleType
        {
            get;
            set;
        } = BattleCommandsBattleType.Traditional;

        /// <summary>
        /// Indicates whether normal parameters are displayed. Default is true.
        /// </summary>
        public bool UnusedDisplayNormalParameters
        {
            get;
            set;
        } = true;

        /// <summary>
        /// The list of battle commands.
        /// </summary>
        [LcfAlwaysPersist]
        public List<BattleCommand> Commands
        {
            get;
            set;
        } = [];

        /// <summary>
        /// Indicates whether the death handler is used. Only available in RM2K3. Default is false.
        /// </summary>
        [LcfVersion(LcfEngineVersion.RM2K3)]
        public bool DeathHandler
        {
            get;
            set;
        } = false;

        /// <summary>
        /// The event ID for death handling. Default is 1.
        /// </summary>
        public int DeathEvent
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The window size for battle commands. Default is Large.
        /// </summary>
        public BattleCommandsWindowSize WindowSize
        {
            get;
            set;
        } = BattleCommandsWindowSize.Large;

        /// <summary>
        /// The transparency setting for battle commands. Default is Opaque.
        /// </summary>
        public BattleCommandsTransparency Transparency
        {
            get;
            set;
        } = BattleCommandsTransparency.Opaque;

        /// <summary>
        /// Indicates whether death teleport is enabled. Default is false.
        /// </summary>
        public bool DeathTeleport
        {
            get;
            set;
        } = false;

        /// <summary>
        /// The teleport ID for death handling. Default is 1.
        /// </summary>
        public int DeathTeleportID
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The X-coordinate for death teleport. Default is 0.
        /// </summary>
        public int DeathTeleportX
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The Y-coordinate for death teleport. Default is 0.
        /// </summary>
        public int DeathTeleportY
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The facing direction for death teleport. Default is Retain.
        /// </summary>
        public BattleCommandsFacing DeathTeleportFace
        {
            get;
            set;
        } = BattleCommandsFacing.Retain;
    }
}