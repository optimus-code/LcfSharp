using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle
{
    public enum BattleCommandsChunk : byte
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
        DeathTeleportId = 0x1A,
        /** Integer */
        DeathTeleportX = 0x1B,
        /** Integer */
        DeathTeleportY = 0x1C,
        /** Integer */
        DeathTeleportFace = 0x1D
    }

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

        public BattleCommandsPlacement Placement
        {
            get;
            set;
        } = 0;

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

        public BattleCommandsFacing DeathTeleportFace
        {
            get;
            set;
        } = 0;

        public BattleCommands(LcfReader reader)
        {
            TypeHelpers.ReadChunks<BattleCommandsChunk>(reader, (chunkID) =>
            {
                switch ((BattleCommandsChunk)chunkID)
                {
                    case BattleCommandsChunk.Placement:
                        Placement = (BattleCommandsPlacement)reader.ReadInt();
                        return true;

                    case BattleCommandsChunk.DeathHandlerUnused:
                        DeathHandlerUnused = reader.ReadBool();
                        return true;

                    case BattleCommandsChunk.Row:
                        Row = (BattleCommandsRowShown)reader.ReadInt();
                        return true;

                    case BattleCommandsChunk.BattleType:
                        BattleType = (BattleCommandsBattleType)reader.ReadInt();
                        return true;

                    case BattleCommandsChunk.UnusedDisplayNormalParameters:
                        UnusedDisplayNormalParameters = reader.ReadBool();
                        return true;

                    case BattleCommandsChunk.Commands:
                        // Read the list of BattleCommand objects
                        int commandCount = reader.ReadInt();
                        for (int i = 0; i < commandCount; i++)
                        {
                            Commands.Add(new BattleCommand(reader));
                        }
                        return true;

                    case BattleCommandsChunk.DeathHandler:
                        DeathHandler = reader.ReadBool();
                        return true;

                    case BattleCommandsChunk.DeathEvent:
                        DeathEvent = reader.ReadInt();
                        return true;

                    case BattleCommandsChunk.WindowSize:
                        WindowSize = (BattleCommandsWindowSize)reader.ReadInt();
                        return true;

                    case BattleCommandsChunk.Transparency:
                        Transparency = (BattleCommandsTransparency)reader.ReadInt();
                        return true;

                    case BattleCommandsChunk.DeathTeleport:
                        DeathTeleport = reader.ReadBool();
                        return true;
                    case BattleCommandsChunk.DeathTeleportId:
                        DeathTeleportId = reader.ReadInt();
                        return true;

                    case BattleCommandsChunk.DeathTeleportX:
                        DeathTeleportX = reader.ReadInt();
                        return true;

                    case BattleCommandsChunk.DeathTeleportY:
                        DeathTeleportY = reader.ReadInt();
                        return true;

                    case BattleCommandsChunk.DeathTeleportFace:
                        DeathTeleportFace = (BattleCommandsFacing)reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}
