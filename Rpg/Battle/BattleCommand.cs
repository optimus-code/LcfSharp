using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Battle
{
    public enum BattleCommandType
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

        public int Type
        {
            get;
            set;
        } = 0;
    }
}
