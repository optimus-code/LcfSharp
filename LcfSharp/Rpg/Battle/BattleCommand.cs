using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Battle
{
    public enum BattleCommandChunk : int
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

    [LcfChunk<BattleCommandChunk>]
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

        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        } = 0;

        [LcfAlwaysPersistAttribute]
        public string Name
        {
            get;
            set;
        }

        [XmlAttribute]
        public BattleCommandType Type
        {
            get;
            set;
        } = BattleCommandType.Attack;
    }
}