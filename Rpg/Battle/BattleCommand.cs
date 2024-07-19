using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle
{
    public enum BattleCommandChunk : byte
    {
        /** String */
        Name = 0x01,
        /** Integer */
        Type = 0x02
    }

    public enum BattleCommandType : int
    {
        Attack = 0,
        Skill = 1,
        Subskill = 2,
        Defense = 3,
        Item = 4,
        Escape = 5,
        Special = 6
    }

    public class BattleCommand
    {
        public static readonly Dictionary<BattleCommandType, string> TypeTags = new Dictionary<BattleCommandType, string>
        {
            { BattleCommandType.Attack, "attack" },
            { BattleCommandType.Skill, "skill" },
            { BattleCommandType.Subskill, "subskill" },
            { BattleCommandType.Defense, "defense" },
            { BattleCommandType.Item, "item" },
            { BattleCommandType.Escape, "escape" },
            { BattleCommandType.Special, "special" }
        };

        public int ID
        {
            get;
            set;
        } = 0;

        public DbString Name
        {
            get;
            set;
        }

        public BattleCommandType Type
        {
            get;
            set;
        } = BattleCommandType.Attack;

        public BattleCommand(LcfReader reader)
        {
            TypeHelpers.ReadChunks<BattleCommandChunk>(reader, (chunkID) =>
            {
                switch ((BattleCommandChunk)chunkID)
                {
                    case BattleCommandChunk.Name:
                        Name = reader.ReadDbString(reader.ReadInt());
                        return true;

                    case BattleCommandChunk.Type:
                        Type = (BattleCommandType)reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}
