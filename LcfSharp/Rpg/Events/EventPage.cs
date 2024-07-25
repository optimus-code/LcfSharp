using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Events
{
    public enum EventPageDirection
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    public enum EventPageFrame
    {
        Left = 0,
        Middle = 1,
        Right = 2,
        Middle2 = 3
    }

    public enum EventPageMoveType
    {
        Stationary = 0,
        Random = 1,
        Vertical = 2,
        Horizontal = 3,
        Toward = 4,
        Away = 5,
        Custom = 6
    }

    public enum EventPageTrigger
    {
        Action = 0,
        Touched = 1,
        Collision = 2,
        AutoStart = 3,
        Parallel = 4
    }

    public enum EventPageLayers
    {
        Below = 0,
        Same = 1,
        Above = 2
    }

    public enum EventPageAnimType
    {
        NonContinuous = 0,
        Continuous = 1,
        FixedNonContinuous = 2,
        FixedContinuous = 3,
        FixedGraphic = 4,
        Spin = 5,
        StepFrameFix = 6
    }

    public enum EventPageMoveSpeed
    {
        Eighth = 1,
        Quarter = 2,
        Half = 3,
        Normal = 4,
        Double = 5,
        Fourfold = 6
    }

    public enum EventPageManiacEventInfo
    {
        Action = 0,
        Touched = 1,
        Collision = 2,
        AutoStart = 3,
        Parallel = 4,
        Called = 5,
        BattleStart = 6,
        BattleParallel = 7,
        MapEvent = 16,
        CommonEvent = 32,
        BattleEvent = 64
    }

    public class EventPage
    {
        public static readonly Dictionary<EventPageDirection, string> DirectionTags = new Dictionary<EventPageDirection, string>
        {
            { EventPageDirection.Up, "up" },
            { EventPageDirection.Right, "right" },
            { EventPageDirection.Down, "down" },
            { EventPageDirection.Left, "left" }
        };

        public static readonly Dictionary<EventPageFrame, string> FrameTags = new Dictionary<EventPageFrame, string>
        {
            { EventPageFrame.Left, "left" },
            { EventPageFrame.Middle, "middle" },
            { EventPageFrame.Right, "right" },
            { EventPageFrame.Middle2, "middle2" }
        };

        public static readonly Dictionary<EventPageMoveType, string> MoveTypeTags = new Dictionary<EventPageMoveType, string>
        {
            { EventPageMoveType.Stationary, "stationary" },
            { EventPageMoveType.Random, "random" },
            { EventPageMoveType.Vertical, "vertical" },
            { EventPageMoveType.Horizontal, "horizontal" },
            { EventPageMoveType.Toward, "toward" },
            { EventPageMoveType.Away, "away" },
            { EventPageMoveType.Custom, "custom" }
        };

        public static readonly Dictionary<EventPageTrigger, string> TriggerTags = new Dictionary<EventPageTrigger, string>
        {
            { EventPageTrigger.Action, "action" },
            { EventPageTrigger.Touched, "touched" },
            { EventPageTrigger.Collision, "collision" },
            { EventPageTrigger.AutoStart, "auto_start" },
            { EventPageTrigger.Parallel, "parallel" }
        };


        public static readonly Dictionary<EventPageLayers, string> LayersTags = new Dictionary<EventPageLayers, string>
        {
            { EventPageLayers.Below, "below" },
            { EventPageLayers.Same, "same" },
            { EventPageLayers.Above, "above" }
        };

        public static readonly Dictionary<EventPageAnimType, string> AnimTypeTags = new Dictionary<EventPageAnimType, string>
        {
            { EventPageAnimType.NonContinuous, "non_continuous" },
            { EventPageAnimType.Continuous, "continuous" },
            { EventPageAnimType.FixedNonContinuous, "fixed_non_continuous" },
            { EventPageAnimType.FixedContinuous, "fixed_continuous" },
            { EventPageAnimType.FixedGraphic, "fixed_graphic" },
            { EventPageAnimType.Spin, "spin" },
            { EventPageAnimType.StepFrameFix, "step_frame_fix" }
        };

        public static readonly Dictionary<EventPageMoveSpeed, string> MoveSpeedTags = new Dictionary<EventPageMoveSpeed, string>
        {
            { EventPageMoveSpeed.Eighth, "eighth" },
            { EventPageMoveSpeed.Quarter, "quarter" },
            { EventPageMoveSpeed.Half, "half" },
            { EventPageMoveSpeed.Normal, "normal" },
            { EventPageMoveSpeed.Double, "double" },
            { EventPageMoveSpeed.Fourfold, "fourfold" }
        };

        public static readonly Dictionary<EventPageManiacEventInfo, string> ManiacEventInfoTags = new Dictionary<EventPageManiacEventInfo, string>
        {
            { EventPageManiacEventInfo.Action, "action" },
            { EventPageManiacEventInfo.Touched, "touched" },
            { EventPageManiacEventInfo.Collision, "collision" },
            { EventPageManiacEventInfo.AutoStart, "auto_start" },
            { EventPageManiacEventInfo.Parallel, "parallel" },
            { EventPageManiacEventInfo.Called, "called" },
            { EventPageManiacEventInfo.BattleStart, "battle_start" },
            { EventPageManiacEventInfo.BattleParallel, "battle_parallel" },
            { EventPageManiacEventInfo.MapEvent, "map_event" },
            { EventPageManiacEventInfo.CommonEvent, "common_event" },
            { EventPageManiacEventInfo.BattleEvent, "battle_event" }
        };

        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        }

        public EventPageCondition Condition
        {
            get;
            set;
        }

        public DbString CharacterName
        {
            get;
            set;
        }

        [XmlAttribute]
        public int CharacterIndex
        {
            get;
            set;
        }

        [XmlAttribute]
        public int CharacterDirection
        {
            get;
            set;
        } = 2;

        [XmlAttribute]
        public int CharacterPattern
        {
            get;
            set;
        } = 1;

        [XmlAttribute]
        public bool Translucent
        {
            get;
            set;
        }

        [XmlAttribute]
        public int MoveType
        {
            get;
            set;
        } = 1;

        [XmlAttribute]
        public int MoveFrequency
        {
            get;
            set;
        } = 3;

        [XmlAttribute]
        public int Trigger
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Layer
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool OverlapForbidden
        {
            get;
            set;
        }

        [XmlAttribute]
        public int AnimationType
        {
            get;
            set;
        }

        [XmlAttribute]
        public int MoveSpeed
        {
            get;
            set;
        } = 3;

        public MoveRoute MoveRoute
        {
            get;
            set;
        }

        public List<EventCommand> EventCommands
        {
            get;
            set;
        } = new List<EventCommand>();
    }
}
