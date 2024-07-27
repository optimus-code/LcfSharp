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

namespace LcfSharp.Chunks.Database.Battle
{
    public enum BattleCommandsChunk : int
    {
        /** Integer */
        Placement = 0x02,
        /** Set by the RM2k3 Editor when you enable death handler; but has no effect in RPG_RT. */
        DeathHandlerUnused = 0x04,
        /** Integer */
        Row = 0x06,
        /** Integer */
        BattleType = 0x07,
        /** Unused hidden checkbox Display normal parameters in RPG2003's battle settings tab */
        UnusedDisplayNormalParameters = 0x09,
        /** Array - rpg::BattleCommand */
        Commands = 0x0A,
        /** True if a 2k3 random encounter death handler is active */
        DeathHandler = 0x0F,
        /** Integer */
        DeathEvent = 0x10,
        /** Integer */
        WindowSize = 0x14,
        /** Integer */
        Transparency = 0x18,
        /** Integer */
        DeathTeleport = 0x19,
        /** Integer */
        DeathTeleportID = 0x1A,
        /** Integer */
        DeathTeleportX = 0x1B,
        /** Integer */
        DeathTeleportY = 0x1C,
        /** Integer */
        DeathTeleportFace = 0x1D
    }
}