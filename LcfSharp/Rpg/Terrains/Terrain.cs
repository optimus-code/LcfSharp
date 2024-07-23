using LcfSharp.IO;
using LcfSharp.Rpg.Audio;
using LcfSharp.Rpg.Troops;
using LcfSharp.Types;
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

        public TerrainBushDepth BushDepth
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

        public Terrain(LcfReader reader)
        {
            TypeHelpers.ReadChunks<TerrainChunk>(reader, (chunk) =>
            {
                switch ((TerrainChunk)chunk.ID)
                {
                    case TerrainChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;

                    case TerrainChunk.Damage:
                        Damage = reader.ReadInt();
                        return true;

                    case TerrainChunk.EncounterRate:
                        EncounterRate = reader.ReadInt();
                        return true;

                    case TerrainChunk.BackgroundName:
                        BackgroundName = reader.ReadDbString(chunk.Length);
                        return true;

                    case TerrainChunk.BoatPass:
                        BoatPass = reader.ReadBool();
                        return true;

                    case TerrainChunk.ShipPass:
                        ShipPass = reader.ReadBool();
                        return true;

                    case TerrainChunk.AirshipPass:
                        AirshipPass = reader.ReadBool();
                        return true;

                    case TerrainChunk.AirshipLand:
                        AirshipLand = reader.ReadBool();
                        return true;

                    case TerrainChunk.BushDepth:
                        BushDepth = (TerrainBushDepth)reader.ReadInt();
                        return true;

                    case TerrainChunk.Footstep:
                        if (!Database.IsRM2K3)
                            return false;
                        Footstep = new Sound(reader);
                        return true;

                    case TerrainChunk.OnDamageSe:
                        if (!Database.IsRM2K3)
                            return false;
                        OnDamageSe = reader.ReadBool();
                        return true;

                    case TerrainChunk.BackgroundType:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundType = reader.ReadInt();
                        return true;

                    case TerrainChunk.BackgroundAName:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundAName = reader.ReadDbString(chunk.Length);
                        return true;

                    case TerrainChunk.BackgroundAScrollH:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundAScrollH = reader.ReadBool();
                        return true;

                    case TerrainChunk.BackgroundAScrollV:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundAScrollV = reader.ReadBool();
                        return true;

                    case TerrainChunk.BackgroundAScrollHSpeed:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundAScrollHSpeed = reader.ReadInt();
                        return true;

                    case TerrainChunk.BackgroundAScrollVSpeed:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundAScrollVSpeed = reader.ReadInt();
                        return true;

                    case TerrainChunk.BackgroundB:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundB = reader.ReadBool();
                        return true;

                    case TerrainChunk.BackgroundBName:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundBName = reader.ReadDbString(chunk.Length);
                        return true;

                    case TerrainChunk.BackgroundBScrollH:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundBScrollH = reader.ReadBool();
                        return true;

                    case TerrainChunk.BackgroundBScrollV:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundBScrollV = reader.ReadBool();
                        return true;

                    case TerrainChunk.BackgroundBScrollHSpeed:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundBScrollHSpeed = reader.ReadInt();
                        return true;

                    case TerrainChunk.BackgroundBScrollVSpeed:
                        if (!Database.IsRM2K3)
                            return false;
                        BackgroundBScrollVSpeed = reader.ReadInt();
                        return true;

                    case TerrainChunk.SpecialFlags:
                        if (!Database.IsRM2K3)
                            return false;
                        SpecialFlags = DbFlags.Read<TerrainFlags>(reader);
                        return SpecialFlags != null;

                    case TerrainChunk.SpecialBackParty:
                        if (!Database.IsRM2K3)
                            return false;
                        SpecialBackParty = reader.ReadInt();
                        return true;

                    case TerrainChunk.SpecialBackEnemies:
                        if (!Database.IsRM2K3)
                            return false;
                        SpecialBackEnemies = reader.ReadInt();
                        return true;

                    case TerrainChunk.SpecialLateralParty:
                        if (!Database.IsRM2K3)
                            return false;
                        SpecialLateralParty = reader.ReadInt();
                        return true;

                    case TerrainChunk.SpecialLateralEnemies:
                        if (!Database.IsRM2K3)
                            return false;
                        SpecialLateralEnemies = reader.ReadInt();
                        return true;

                    case TerrainChunk.GridLocation:
                        if (!Database.IsRM2K3)
                            return false;
                        GridLocation = reader.ReadInt();
                        return true;

                    case TerrainChunk.GridTopY:
                        if (!Database.IsRM2K3)
                            return false;
                        GridTopY = reader.ReadInt();
                        return true;

                    case TerrainChunk.GridElongation:
                        if (!Database.IsRM2K3)
                            return false;
                        GridElongation = reader.ReadInt();
                        return true;

                    case TerrainChunk.GridInclination:
                        if (!Database.IsRM2K3)
                            return false;
                        GridInclination = reader.ReadInt();
                        return true;
                }
                return false;
            });
        }
    }
}