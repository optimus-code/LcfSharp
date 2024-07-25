using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Events;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Troops
{
    public enum TroopPageChunk : int
    {
        Condition = 0x02,
        EventCommandsSize = 0x0B,
        EventCommands = 0x0C
    }

    [LcfChunk<TroopPageChunk>]
    public class TroopPage
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public TroopPageCondition Condition
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        [LcfSize((int)TroopPageChunk.EventCommandsSize)]
        public List<EventCommand> EventCommands
        {
            get;
            set;
        } = [];
    }
}
