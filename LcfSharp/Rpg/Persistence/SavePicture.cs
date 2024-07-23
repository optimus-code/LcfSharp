using System.Collections.Generic;

namespace LcfSharp.Rpg.Persistence
{
    public enum SavePictureEffect
    {
        None = 0,
        Rotation = 1,
        Wave = 2,
        ManiacFixedAngle = 3
    }

    public enum SavePictureMapLayer
    {
        None = 0,
        Parallax = 1,
        TilemapBelow = 2,
        EventsBelow = 3,
        EventsSameAsPlayer = 4,
        TilemapAbove = 5,
        EventsAbove = 6,
        Weather = 7,
        Animations = 8,
        Windows = 9,
        Timers = 10
    }

    public enum SavePictureBattleLayer
    {
        None = 0,
        Background = 1,
        BattlersAndAnimations = 2,
        Weather = 3,
        WindowsAndStatus = 4,
        Timers = 5
    }

    public class SavePicture
    {
        public static readonly Dictionary<SavePictureEffect, string> EffectTags = new Dictionary<SavePictureEffect, string>
        {
            { SavePictureEffect.None, "none" },
            { SavePictureEffect.Rotation, "rotation" },
            { SavePictureEffect.Wave, "wave" },
            { SavePictureEffect.ManiacFixedAngle, "maniac_fixed_angle" }
        };

        public static readonly Dictionary<SavePictureMapLayer, string> MapLayerTags = new Dictionary<SavePictureMapLayer, string>
        {
            { SavePictureMapLayer.None, "none" },
            { SavePictureMapLayer.Parallax, "parallax" },
            { SavePictureMapLayer.TilemapBelow, "tilemap_below" },
            { SavePictureMapLayer.EventsBelow, "events_below" },
            { SavePictureMapLayer.EventsSameAsPlayer, "events_same_as_player" },
            { SavePictureMapLayer.TilemapAbove, "tilemap_above" },
            { SavePictureMapLayer.EventsAbove, "events_above" },
            { SavePictureMapLayer.Weather, "weather" },
            { SavePictureMapLayer.Animations, "animations" },
            { SavePictureMapLayer.Windows, "windows" },
            { SavePictureMapLayer.Timers, "timers" }
        };

        public static readonly Dictionary<SavePictureBattleLayer, string> BattleLayerTags = new Dictionary<SavePictureBattleLayer, string>
        {
            { SavePictureBattleLayer.None, "none" },
            { SavePictureBattleLayer.Background, "background" },
            { SavePictureBattleLayer.BattlersAndAnimations, "battlers_and_animations" },
            { SavePictureBattleLayer.Weather, "weather" },
            { SavePictureBattleLayer.WindowsAndStatus, "windows_and_status" },
            { SavePictureBattleLayer.Timers, "timers" }
        };

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public double StartX
        {
            get;
            set;
        }

        public double StartY
        {
            get;
            set;
        }

        public double CurrentX
        {
            get;
            set;
        }

        public double CurrentY
        {
            get;
            set;
        }

        public bool FixedToMap
        {
            get;
            set;
        }

        public double CurrentMagnify
        {
            get;
            set;
        } = 100.0;

        public double CurrentTopTrans
        {
            get;
            set;
        }

        public bool UseTransparentColor
        {
            get;
            set;
        }

        public double CurrentRed
        {
            get;
            set;
        } = 100.0;

        public double CurrentGreen
        {
            get;
            set;
        } = 100.0;

        public double CurrentBlue
        {
            get;
            set;
        } = 100.0;

        public double CurrentSat
        {
            get;
            set;
        } = 100.0;

        public int EffectMode
        {
            get;
            set;
        }

        public double CurrentEffectPower
        {
            get;
            set;
        }

        public double CurrentBotTrans
        {
            get;
            set;
        }

        public int SpritesheetCols
        {
            get;
            set;
        } = 1;

        public int SpritesheetRows
        {
            get;
            set;
        } = 1;

        public int SpritesheetFrame
        {
            get;
            set;
        }

        public int SpritesheetSpeed
        {
            get;
            set;
        }

        public int Frames
        {
            get;
            set;
        }

        public bool SpritesheetPlayOnce
        {
            get;
            set;
        }

        public int MapLayer
        {
            get;
            set;
        } = 7;

        public int BattleLayer
        {
            get;
            set;
        }

        public SavePictureFlags Flags
        {
            get;
            set;
        } = new SavePictureFlags();

        public double FinishX
        {
            get;
            set;
        }

        public double FinishY
        {
            get;
            set;
        }

        public int FinishMagnify
        {
            get;
            set;
        } = 100;

        public int FinishTopTrans
        {
            get;
            set;
        }

        public int FinishBotTrans
        {
            get;
            set;
        }

        public int FinishRed
        {
            get;
            set;
        } = 100;

        public int FinishGreen
        {
            get;
            set;
        } = 100;

        public int FinishBlue
        {
            get;
            set;
        } = 100;

        public int FinishSat
        {
            get;
            set;
        } = 100;

        public int FinishEffectPower
        {
            get;
            set;
        }

        public int TimeLeft
        {
            get;
            set;
        }

        public double CurrentRotation
        {
            get;
            set;
        }

        public int CurrentWaver
        {
            get;
            set;
        }
    }
}