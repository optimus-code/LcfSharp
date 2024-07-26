using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Xml.Serialization;

namespace LcfSharp.Rpg
{
    public enum VariableChunk : int
    {
        /** String */
        Name = 0x01
    }

    [LcfChunk<VariableChunk>]
    public class Variable
    {
        [LcfID]
        [XmlAttribute]
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}