using LcfSharp.IO;
using LcfSharp.Rpg.Classes;
using LcfSharp.Rpg.Shared;
using LcfSharp.Rpg.Skills;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Events
{
    public enum CommonEventChunk : byte
    {
        Name = 0x01,
        Trigger = 0x0B,
        SwitchFlag = 0x0C,
        SwitchId = 0x0D,
        EventCommandsSize = 0x15,
        EventCommands = 0x16
    }

    public enum CommonEventTrigger : int
    {
        Automatic = 3,
        Parallel = 4,
        Call = 5
    }

    public class CommonEvent
    {
        public static readonly Dictionary<CommonEventTrigger, string> Tags = new Dictionary<CommonEventTrigger, string>
        {
            { CommonEventTrigger.Automatic, "automatic" },
            { CommonEventTrigger.Parallel, "parallel" },
            { CommonEventTrigger.Call, "call" }
        };

        public int ID
        {
            get;
            set;
        }

        public DbString Name
        {
            get;
            set;
        }

        public CommonEventTrigger Trigger
        {
            get;
            set;
        }

        public bool SwitchFlag
        {
            get;
            set;
        }

        public int SwitchID
        {
            get;
            set;
        } = 1;

        public List<EventCommand> EventCommands
        {
            get;
            set;
        } = new List<EventCommand>();

        public CommonEvent(LcfReader reader)
        {
            int eventCommandsCount = 0;

            TypeHelpers.ReadChunks<CommonEventChunk>(reader, (chunkID) =>
            {
                switch ((CommonEventChunk)chunkID)
                {
                    case CommonEventChunk.Name:
                        Name = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case CommonEventChunk.Trigger:
                        Trigger = (CommonEventTrigger)reader.ReadInt();
                        return true;

                    case CommonEventChunk.SwitchFlag:
                        SwitchFlag = reader.ReadBool();
                        return true;

                    case CommonEventChunk.SwitchId:
                        SwitchID = reader.ReadInt();
                        return true;

                    case CommonEventChunk.EventCommandsSize:
                        eventCommandsCount = reader.ReadInt();
                        return true;

                    case CommonEventChunk.EventCommands:
                        if (eventCommandsCount > 0)
                        { 
                            for (int i = 0; i < eventCommandsCount; i++)
                            {
                                EventCommands.Add(new EventCommand(reader));
                            }
                            return true;
                        }
                        break;
                }
                return false;
            });
        }
    }
}
