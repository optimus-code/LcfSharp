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

namespace LcfSharp.Rpg.Battle
{
    public enum BattleCommandsPlacement : int
    {
        Manual = 0,
        Automatic = 1
    }

    public enum BattleCommandsRowShown : int
    {
        Front = 0,
        Back = 1
    }

    public enum BattleCommandsBattleType : int
    {
        Traditional = 0,
        Alternative = 1,
        Gauge = 2
    }

    public enum BattleCommandsWindowSize : int
    {
        Large = 0,
        Small = 1
    }

    public enum BattleCommandsTransparency : int
    {
        Opaque = 0,
        Transparent = 1
    }

    public enum BattleCommandsFacing : int
    {
        Retain = 0,
        Up = 1,
        Right = 2,
        Down = 3,
        Left = 4
    }

    [LcfChunk<BattleCommandsChunk>]
    public class BattleCommands
    {
        public BattleCommandsPlacement Placement
        {
            get;
            set;
        } = 0;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public bool DeathHandlerUnused
        {
            get;
            set;
        } = false;

        public BattleCommandsRowShown Row
        {
            get;
            set;
        } = 0;

        public BattleCommandsBattleType BattleType
        {
            get;
            set;
        } = 0;

        public bool UnusedDisplayNormalParameters
        {
            get;
            set;
        } = true;

        [LcfAlwaysPersist]
        public List<BattleCommand> Commands
        {
            get;
            set;
        } = [];

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public bool DeathHandler
        {
            get;
            set;
        } = false;

        public int DeathEvent
        {
            get;
            set;
        } = 1;

        public BattleCommandsWindowSize WindowSize
        {
            get;
            set;
        } = 0;

        public BattleCommandsTransparency Transparency
        {
            get;
            set;
        } = 0;

        public bool DeathTeleport
        {
            get;
            set;
        } = false;

        public int DeathTeleportID
        {
            get;
            set;
        } = 1;

        public int DeathTeleportX
        {
            get;
            set;
        } = 0;

        public int DeathTeleportY
        {
            get;
            set;
        } = 0;

        public BattleCommandsFacing DeathTeleportFace
        {
            get;
            set;
        } = 0;
    }
}