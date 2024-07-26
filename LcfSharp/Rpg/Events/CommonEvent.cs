﻿using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Classes;
using LcfSharp.Rpg.Shared;
using LcfSharp.Rpg.Skills;
using LcfSharp.IO.Types;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Events
{
    public enum CommonEventChunk : int
    {
        Name = 0x01,
        Trigger = 0x0B,
        SwitchFlag = 0x0C,
        SwitchID = 0x0D,
        EventCommandsSize = 0x15,
        EventCommands = 0x16
    }

    public enum CommonEventTrigger : int
    {
        Automatic = 3,
        Parallel = 4,
        Call = 5
    }

    [LcfChunk<CommonEventChunk>]
    public class CommonEvent
    {
        public static readonly Dictionary<CommonEventTrigger, string> Tags = new Dictionary<CommonEventTrigger, string>
        {
            { CommonEventTrigger.Automatic, "automatic" },
            { CommonEventTrigger.Parallel, "parallel" },
            { CommonEventTrigger.Call, "call" }
        };

        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
		public string Name
        {
            get;
            set;
        }

        [XmlAttribute]
        public CommonEventTrigger Trigger
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool SwitchFlag
        {
            get;
            set;
        }

        [XmlAttribute]
        public int SwitchID
        {
            get;
            set;
        } = 1;

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)CommonEventChunk.EventCommandsSize)]
        public List<EventCommand> EventCommands
        {
            get;
            set;
        } = new List<EventCommand>();
    }
}