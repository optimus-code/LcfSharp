using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Audio
{
    public enum SoundChunk : int
    {
        /** String */
        Name = 0x01,
        /** Integer */
        Volume = 0x03,
        /** Integer */
        Tempo = 0x04,
        /** Integer */
        Balance = 0x05
    }

    [LcfChunk<SoundChunk>]
    public class Sound
    {
        [LcfAlwaysPersistAttribute]
        public string Name
        {
            get;
            set;
        } = "(OFF)";

        [XmlAttribute]
        public int Volume
        {
            get;
            set;
        } = 100;

        [XmlAttribute]
        public int Tempo
        {
            get;
            set;
        } = 100;

        [XmlAttribute]
        public int Balance
        {
            get;
            set;
        } = 50;
    }
}