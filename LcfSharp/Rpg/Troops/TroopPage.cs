using LcfSharp.IO;
using LcfSharp.Rpg.Events;
using LcfSharp.Rpg.Shared;
using LcfSharp.Rpg.Skills;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Troops
{
    public enum TroopPageChunk : int
    {
        Condition = 0x02,
        EventCommandsSize = 0x0B,
        EventCommands = 0x0C
    }

    public class TroopPage
    {
        public int ID
        {
            get;
            set;
        }

        public TroopPageCondition Condition
        {
            get;
            set;
        }

        public List<EventCommand> EventCommands
        {
            get;
            set;
        } = [];

        public TroopPage(LcfReader reader)
        {
            int eventCommandsCount = 0;

            TypeHelpers.ReadChunks<TroopPageChunk>(reader, (chunk) =>
            {
                switch ((TroopPageChunk)chunk.ID)
                {
                    case TroopPageChunk.Condition:
                        Condition = new TroopPageCondition(reader);
                        return true;

                    case TroopPageChunk.EventCommandsSize:
                        eventCommandsCount = reader.ReadInt();
                        return true;

                    case TroopPageChunk.EventCommands:
                        if (eventCommandsCount > 0)
                        {
                            for (var i = 0; i < eventCommandsCount; i++)
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
