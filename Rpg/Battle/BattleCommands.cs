using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle
{
    public enum BattleCommandsPlacement
    {
        Manual = 0,
        Automatic = 1
    }

    public enum BattleCommandsRowShown
    {
        Front = 0,
        Back = 1
    }

    public enum BattleCommandsBattleType
    {
        Traditional = 0,
        Alternative = 1,
        Gauge = 2
    }

    public enum BattleCommandsWindowSize
    {
        Large = 0,
        Small = 1
    }

    public enum BattleCommandsTransparency
    {
        Opaque = 0,
        Transparent = 1
    }

    public enum BattleCommandsFacing
    {
        Retain = 0,
        Up = 1,
        Right = 2,
        Down = 3,
        Left = 4
    }

    public class BattleCommands
    {
        public static readonly Dictionary<BattleCommandsPlacement, string> PlacementTags = new Dictionary<BattleCommandsPlacement, string>
        {
            { BattleCommandsPlacement.Manual, "manual" },
            { BattleCommandsPlacement.Automatic, "automatic" }
        };

        public static readonly Dictionary<BattleCommandsRowShown, string> RowShownTags = new Dictionary<BattleCommandsRowShown, string>
        {
            { BattleCommandsRowShown.Front, "front" },
            { BattleCommandsRowShown.Back, "back" }
        };

        public static readonly Dictionary<BattleCommandsBattleType, string> BattleTypeTags = new Dictionary<BattleCommandsBattleType, string>
        {
            { BattleCommandsBattleType.Traditional, "traditional" },
            { BattleCommandsBattleType.Alternative, "alternative" },
            { BattleCommandsBattleType.Gauge, "gauge" }
        };

        public static readonly Dictionary<BattleCommandsWindowSize, string> WindowSizeTags = new Dictionary<BattleCommandsWindowSize, string>
        {
            { BattleCommandsWindowSize.Large, "large" },
            { BattleCommandsWindowSize.Small, "small" }
        };

        public static readonly Dictionary<BattleCommandsTransparency, string> TransparencyTags = new Dictionary<BattleCommandsTransparency, string>
        {
            { BattleCommandsTransparency.Opaque, "opaque" },
            { BattleCommandsTransparency.Transparent, "transparent" }
        };

        public static readonly Dictionary<BattleCommandsFacing, string> FacingTags = new Dictionary<BattleCommandsFacing, string>
        {
            { BattleCommandsFacing.Retain, "retain" },
            { BattleCommandsFacing.Up, "up" },
            { BattleCommandsFacing.Right, "right" },
            { BattleCommandsFacing.Down, "down" },
            { BattleCommandsFacing.Left, "left" }
        };

        public int Placement
        {
            get;
            set;
        } = 0;

        public bool DeathHandlerUnused
        {
            get;
            set;
        } = false;

        public int Row
        {
            get;
            set;
        } = 0;

        public int BattleType
        {
            get;
            set;
        } = 0;

        public bool UnusedDisplayNormalParameters
        {
            get;
            set;
        } = true;

        public List<BattleCommand> Commands
        {
            get;
            set;
        } = new List<BattleCommand>();

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

        public int WindowSize
        {
            get;
            set;
        } = 0;

        public int Transparency
        {
            get;
            set;
        } = 0;

        public bool DeathTeleport
        {
            get;
            set;
        } = false;

        public int DeathTeleportId
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

        public int DeathTeleportFace
        {
            get;
            set;
        } = 0;
    }
}
