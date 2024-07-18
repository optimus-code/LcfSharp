using LcfSharp.Rpg.Audio;
using LcfSharp.Types;
using System;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Terrains
{
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

        public DbString BackgroundName
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

        public int BushDepth
        {
            get;
            set;
        }

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

        public DbString BackgroundAName
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

        public DbString BackgroundBName
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

        public TerrainFlags SpecialFlags { get; set; } = new TerrainFlags();

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
