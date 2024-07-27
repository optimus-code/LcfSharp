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

using LcfSharp.Rpg.Audio;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Persistence
{
    public enum SaveSystemScene
    {
        Map = 0,
        Menu = 1,
        Battle = 2,
        Shop = 3,
        Name = 4,
        File = 5,
        Title = 6,
        GameOver = 7,
        Debug = 8
    }

    public enum SaveSystemAtbMode
    {
        AtbActive = 0,
        AtbWait = 1
    }

    public class SaveSystem
    {
        public static readonly Dictionary<SaveSystemScene, string> SceneTags = new Dictionary<SaveSystemScene, string>
        {
            { SaveSystemScene.Map, "map" },
            { SaveSystemScene.Menu, "menu" },
            { SaveSystemScene.Battle, "battle" },
            { SaveSystemScene.Shop, "shop" },
            { SaveSystemScene.Name, "name" },
            { SaveSystemScene.File, "file" },
            { SaveSystemScene.Title, "title" },
            { SaveSystemScene.GameOver, "game_over" },
            { SaveSystemScene.Debug, "debug" }
        };

        public static readonly Dictionary<SaveSystemAtbMode, string> AtbModeTags = new Dictionary<SaveSystemAtbMode, string>
        {
            { SaveSystemAtbMode.AtbActive, "atb_active" },
            { SaveSystemAtbMode.AtbWait, "atb_wait" }
        };

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

        public string GraphicsName
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

        public List<bool> Switches
        {
            get;
            set;
        } = [];

        public List<int> Variables
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

        public string FaceName
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

        public Music TitleMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        public Music BattleMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        public Music BattleEndMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        public Music InnMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        public Music CurrentMusic
        {
            get;
            set;
        }

        public Music BeforeVehicleMusic
        {
            get;
            set;
        }

        public Music BeforeBattleMusic
        {
            get;
            set;
        }

        public Music StoredMusic
        {
            get;
            set;
        }

        public Music BoatMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        public Music ShipMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        public Music AirshipMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        public Music GameoverMusic
        {
            get;
            set;
        } = new Music { Name = "" };

        public Sound CursorSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound DecisionSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound CancelSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound BuzzerSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound BattleSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound EscapeSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound EnemyAttackSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound EnemyDamagedSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound ActorDamagedSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound DodgeSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound EnemyDeathSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public Sound ItemSE
        {
            get;
            set;
        } = new Sound { Name = "" };

        public sbyte TransitionOut
        {
            get;
            set;
        } = -1;

        public sbyte TransitionIn
        {
            get;
            set;
        } = -1;

        public sbyte BattleStartFadeout
        {
            get;
            set;
        } = -1;

        public sbyte BattleStartFadein
        {
            get;
            set;
        } = -1;

        public sbyte BattleEndFadeout
        {
            get;
            set;
        } = -1;

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

        public string Background
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

        public int AtbMode
        {
            get;
            set;
        }

        public List<string> ManiacStrings
        {
            get;
            set;
        } = [];

        public int ManiacFrameskip
        {
            get;
            set;
        }

        public int ManiacPictureLimit
        {
            get;
            set;
        }

        public List<byte> ManiacOptions
        {
            get;
            set;
        } = [];

        public List<byte> ManiacJoypadBindings
        {
            get;
            set;
        } = [];
    }
}
