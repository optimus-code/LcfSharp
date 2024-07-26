using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Audio;
using LcfSharp.Rpg.Troops;
using LcfSharp.IO.Types;
using System;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Terrains
{
    public enum TerrainChunk : int
    {
        /** String */
        Name = 0x01,
        /** Integer */
        Damage = 0x02,
        /** Integer */
        EncounterRate = 0x03,
        /** String */
        BackgroundName = 0x04,
        /** Flag */
        BoatPass = 0x05,
        /** Flag */
        ShipPass = 0x06,
        /** Flag */
        AirshipPass = 0x07,
        /** Flag */
        AirshipLand = 0x09,
        /** Integer */
        BushDepth = 0x0B,
        /** rpg::Sound - RPG2003 */
        Footstep = 0x0F,
        /** Flag - RPG2003 */
        OnDamageSe = 0x10,
        /** Integer - RPG2003 */
        BackgroundType = 0x11,
        /** String - RPG2003 */
        BackgroundAName = 0x15,
        /** Flag - RPG2003 */
        BackgroundAScrollH = 0x16,
        /** Flag - RPG2003 */
        BackgroundAScrollV = 0x17,
        /** Integer - RPG2003 */
        BackgroundAScrollHSpeed = 0x18,
        /** Integer - RPG2003 */
        BackgroundAScrollVSpeed = 0x19,
        /** Flag - RPG2003 */
        BackgroundB = 0x1E,
        /** String - RPG2003 */
        BackgroundBName = 0x1F,
        /** Flag - RPG2003 */
        BackgroundBScrollH = 0x20,
        /** Flag - RPG2003 */
        BackgroundBScrollV = 0x21,
        /** Integer - RPG2003 */
        BackgroundBScrollHSpeed = 0x22,
        /** Integer - RPG2003 */
        BackgroundBScrollVSpeed = 0x23,
        /** Bitflag - RPG2003 */
        SpecialFlags = 0x28,
        /** Integer - RPG2003 */
        SpecialBackParty = 0x29,
        /** Integer - RPG2003 */
        SpecialBackEnemies = 0x2A,
        /** Integer - RPG2003 */
        SpecialLateralParty = 0x2B,
        /** Integer - RPG2003 */
        SpecialLateralEnemies = 0x2C,
        /** Integer - RPG2003 */
        GridLocation = 0x2D,
        /** Integer - RPG2003 */
        GridTopY = 0x2E,
        /** Integer - RPG2003 */
        GridElongation = 0x2F,
        /** Integer - RPG2003 */
        GridInclination = 0x30
    }

    public enum TerrainBushDepth
    {
        Normal = 0,
        Third = 1,
        Half = 2,
        Full = 3
    }

    public enum TerrainBGAssociation
    {
        Background = 0,
        Frame = 1
    }

    [LcfChunk<TerrainChunk>]
    public class Terrain
    {
        public static readonly Dictionary<TerrainBushDepth, string> BushDepthTags = new Dictionary<TerrainBushDepth, string>
        {
            { TerrainBushDepth.Normal, "normal" },
            { TerrainBushDepth.Third, "third" },
            { TerrainBushDepth.Half, "half" },
            { TerrainBushDepth.Full, "full" }
        };

        public static readonly Dictionary<TerrainBGAssociation, string> TBGAssociationags = new Dictionary<TerrainBGAssociation, string>
        {
            { TerrainBGAssociation.Background, "background" },
            { TerrainBGAssociation.Frame, "frame" }
        };

        [LcfID]
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

        public int Damage
        {
            get;
            set;
        }

        public int EncounterRate
        {
            get;
            set;
        } = 100;

        public string BackgroundName
        {
            get;
            set;
        }

        public bool BoatPass
        {
            get;
            set;
        }

        public bool ShipPass
        {
            get;
            set;
        }

        public bool AirshipPass
        {
            get;
            set;
        } = true;

        public bool AirshipLand
        {
            get;
            set;
        } = true;

        [LcfAlwaysPersistAttribute]
        public TerrainBushDepth BushDepth
        {
            get;
            set;
        }

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersistAttribute]
        public Sound Footstep
        {
            get;
            set;
        }

        public bool OnDamageSe
        {
            get;
            set;
        }

        public int BackgroundType
        {
            get;
            set;
        }

        public string BackgroundAName
        {
            get;
            set;
        }

        public bool BackgroundAScrollH
        {
            get;
            set;
        }

        public bool BackgroundAScrollV
        {
            get;
            set;
        }

        public int BackgroundAScrollHSpeed
        {
            get;
            set;
        }

        public int BackgroundAScrollVSpeed
        {
            get;
            set;
        }

        public bool BackgroundB
        {
            get;
            set;
        }

        public string BackgroundBName
        {
            get;
            set;
        }

        public bool BackgroundBScrollH
        {
            get;
            set;
        }

        public bool BackgroundBScrollV
        {
            get;
            set;
        }

        public int BackgroundBScrollHSpeed
        {
            get;
            set;
        }

        public int BackgroundBScrollVSpeed
        {
            get;
            set;
        }

        public TerrainFlags SpecialFlags
        { 
            get; 
            set; 
        } = new TerrainFlags();

        public int SpecialBackParty
        {
            get;
            set;
        } = 15;

        public int SpecialBackEnemies
        {
            get;
            set;
        } = 10;

        public int SpecialLateralParty
        {
            get;
            set;
        } = 10;

        public int SpecialLateralEnemies
        {
            get;
            set;
        } = 5;

        public int GridLocation
        {
            get;
            set;
        }

        public int GridTopY
        {
            get;
            set;
        } = 120;

        public int GridElongation
        {
            get;
            set;
        } = 392;

        public int GridInclination
        {
            get;
            set;
        } = 16000;
    }
}