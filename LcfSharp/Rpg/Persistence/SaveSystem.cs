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

using LcfSharp.Chunks.Persistence;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types.Generic;
using LcfSharp.IO.Types;
using LcfSharp.Rpg.Audio;

namespace LcfSharp.Rpg.Persistence
{
    /// <summary>
    /// Represents System data in an LSD save file.
    /// </summary>
    [LcfChunk<SaveSystemChunk>]
    public class SaveSystem
    {
        [LcfAlwaysPersist]
        public int Scene
        {
            get;
            set;
        }

        public int FrameCount
        {
            get;
            set;
        }

        public LcfString GraphicsName
        {
            get;
            set;
        }

        public int MessageStretch
        {
            get;
            set;
        }

        public int FontID
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        [LcfSize( ( int ) SaveSystemChunk.SwitchesSize )]
        public LcfPackedList<bool> Switches
        {
            get;
            set;
        } = [];

        [LcfAlwaysPersist]
        [LcfSize( ( int ) SaveSystemChunk.VariablesSize )]
        public LcfPackedList<LcfFixedInt32> Variables
        {
            get;
            set;
        } = [];

        public int MessageTransparent
        {
            get;
            set;
        }

        public int MessagePosition
        {
            get;
            set;
        } = 2;

        public int MessagePreventOverlap
        {
            get;
            set;
        } = 1;

        public int MessageContinueEvents
        {
            get;
            set;
        }

        public LcfString FaceName
        {
            get;
            set;
        }

        public int FaceID
        {
            get;
            set;
        }

        public bool FaceRight
        {
            get;
            set;
        }

        public bool FaceFlip
        {
            get;
            set;
        }

        public bool EventMessageActive
        {
            get;
            set;
        }

        public bool MusicStopping
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        public Music TitleMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        [LcfAlwaysPersist]
        public Music BattleMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        [LcfAlwaysPersist]
        public Music BattleEndMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        [LcfAlwaysPersist]
        public Music InnMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        [LcfAlwaysPersist]
        public Music CurrentMusic
        {
            get;
            set;
        } = new Music( );

        [LcfAlwaysPersist]
        public Music BeforeVehicleMusic
        {
            get;
            set;
        } = new Music( );

        [LcfAlwaysPersist]
        public Music BeforeBattleMusic
        {
            get;
            set;
        } = new Music( );

        [LcfAlwaysPersist]
        public Music StoredMusic
        {
            get;
            set;
        } = new Music( );

        [LcfAlwaysPersist]
        public Music BoatMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        [LcfAlwaysPersist]
        public Music ShipMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        [LcfAlwaysPersist]
        public Music AirshipMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        [LcfAlwaysPersist]
        public Music GameoverMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        [LcfAlwaysPersist]
        public Sound CursorSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound DecisionSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound CancelSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound BuzzerSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound BattleSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound EscapeSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound EnemyAttackSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound EnemyDamagedSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound ActorDamagedSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound DodgeSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound EnemyDeathSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public Sound ItemSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        [LcfAlwaysPersist]
        public sbyte TransitionOut
        {
            get;
            set;
        } = -1;

        [LcfAlwaysPersist]
        public sbyte TransitionIn
        {
            get;
            set;
        } = -1;

        [LcfAlwaysPersist]
        public sbyte BattleStartFadeout
        {
            get;
            set;
        } = -1;

        [LcfAlwaysPersist]
        public sbyte BattleStartFadein
        {
            get;
            set;
        } = -1;

        [LcfAlwaysPersist]
        public sbyte BattleEndFadeout
        {
            get;
            set;
        } = -1;

        [LcfAlwaysPersist]
        public sbyte BattleEndFadein
        {
            get;
            set;
        } = -1;

        public bool TeleportAllowed
        {
            get;
            set;
        } = true;

        public bool EscapeAllowed
        {
            get;
            set;
        } = true;

        public bool SaveAllowed
        {
            get;
            set;
        } = true;

        public bool MenuAllowed
        {
            get;
            set;
        } = true;

        public LcfString Background
        {
            get;
            set;
        }

        public int SaveCount
        {
            get;
            set;
        }

        public int SaveSlot
        {
            get;
            set;
        } = 1;

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int AtbMode
        {
            get;
            set;
        }
    }
}