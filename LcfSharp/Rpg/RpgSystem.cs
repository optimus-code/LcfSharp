using LcfSharp.IO;
using LcfSharp.IO.Attributes;
using LcfSharp.Rpg.Audio;
using LcfSharp.IO.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg
{
    public enum SystemChunk : int
    {
        /** Integer - RPG2003 */
        LdbID = 0x0A,
        /** String */
        BoatName = 0x0B,
        /** String */
        ShipName = 0x0C,
        /** String */
        AirshipName = 0x0D,
        /** Integer */
        BoatIndex = 0x0E,
        /** Integer */
        ShipIndex = 0x0F,
        /** Integer */
        AirshipIndex = 0x10,
        /** String */
        TitleName = 0x11,
        /** String */
        GameoverName = 0x12,
        /** String */
        SystemName = 0x13,
        /** String - RPG2003 */
        System2Name = 0x14,
        /** Integer */
        PartySize = 0x15,
        /** Array - Short */
        Party = 0x16,
        /** Integer - RPG2003 */
        MenuCommandsSize = 0x1A,
        /** Array - Short - RPG2003 */
        MenuCommands = 0x1B,
        /** rpg::Music */
        TitleMusic = 0x1F,
        /** rpg::Music */
        BattleMusic = 0x20,
        /** rpg::Music */
        BattleEndMusic = 0x21,
        /** rpg::Music */
        InnMusic = 0x22,
        /** rpg::Music */
        BoatMusic = 0x23,
        /** rpg::Music */
        ShipMusic = 0x24,
        /** rpg::Music */
        AirshipMusic = 0x25,
        /** rpg::Music */
        GameoverMusic = 0x26,
        /** rpg::Sound */
        CursorSe = 0x29,
        /** rpg::Sound */
        DecisionSe = 0x2A,
        /** rpg::Sound */
        CancelSe = 0x2B,
        /** rpg::Sound */
        BuzzerSe = 0x2C,
        /** rpg::Sound */
        BattleSe = 0x2D,
        /** rpg::Sound */
        EscapeSe = 0x2E,
        /** rpg::Sound */
        EnemyAttackSe = 0x2F,
        /** rpg::Sound */
        EnemyDamagedSe = 0x30,
        /** rpg::Sound */
        ActorDamagedSe = 0x31,
        /** rpg::Sound */
        DodgeSe = 0x32,
        /** rpg::Sound */
        EnemyDeathSe = 0x33,
        /** rpg::Sound */
        ItemSe = 0x34,
        /** Integer */
        TransitionOut = 0x3D,
        /** Integer */
        TransitionIn = 0x3E,
        /** Integer */
        BattleStartFadeOut = 0x3F,
        /** Integer */
        BattleStartFadeIn = 0x40,
        /** Integer */
        BattleEndFadeOut = 0x41,
        /** Integer */
        BattleEndFadeIn = 0x42,
        /** Integer */
        MessageStretch = 0x47,
        /** Integer */
        FontID = 0x48,
        /** Integer */
        SelectedCondition = 0x51,
        /** Integer */
        SelectedHero = 0x52,
        /** String */
        BattleTestBackground = 0x54,
        /** Array - rpg::TestBattler */
        BattleTestData = 0x55,
        /** Integer */
        SaveCount = 0x5B,
        /** Integer */
        BattleTestTerrain = 0x5E,
        /** Integer */
        BattleTestFormation = 0x5F,
        /** Integer */
        BattleTestCondition = 0x60,
        /** Integer RPG2003 - Whether equipment usage is by Actor or by Class. This is a global setting in RM2k3! */
        EquipmentSetting = 0x61,
        /** Integer RPG2003 (EDITOR ONLY) - Double click on Terrain in Troops changes this setting and 0x54. Affects only the RM2k3 editor. */
        BattletestAltTerrain = 0x62,
        /** Flag - RPG2003 */
        ShowFrame = 0x63,
        /** String - RPG2003 */
        FrameName = 0x64,
        /** Flag - RPG2003 */
        InvertAnimations = 0x65,
        /** When false the title is skipped and the game starts directly. In TestPlay mode skips directly to the Load scene. Added in RPG Maker 2003 v1.11 */
        ShowTitle = 0x6F
    }

    public enum SystemFadeOut
    {
        Default = 0,
        FadeOut = 1,
        RemoveBlocks = 2,
        WipeDownward = 3,
        WipeUpward = 4,
        VenetianBlinds = 5,
        VerticalBlinds = 6,
        HorizontalBlinds = 7,
        RecedingSquare = 8,
        ExpandingSquare = 9,
        ScreenMovesUp = 10,
        ScreenMovesDown = 11,
        ScreenMovesLeft = 12,
        ScreenMovesRight = 13,
        VerticalDiv = 14,
        HorizontalDiv = 15,
        Quadrasection = 16,
        ZoomIn = 17,
        Mosaic = 18,
        WaverScreen = 19,
        Instantaneous = 20,
        None = 21
    }

    public enum SystemFadeIn
    {
        Default = 0,
        FadeIn = 1,
        ReconstituteBlocks = 2,
        UnwipeDownward = 3,
        UnwipeUpward = 4,
        VenetianBlinds = 5,
        VerticalBlinds = 6,
        HorizontalBlinds = 7,
        RecedingSquare = 8,
        ExpandingSquare = 9,
        ScreenMovesDown = 10,
        ScreenMovesUp = 11,
        ScreenMovesRight = 12,
        ScreenMovesLeft = 13,
        VerticalUnify = 14,
        HorizontalUnify = 15,
        UnifyQuadrants = 16,
        ZoomOut = 17,
        Mosaic = 18,
        WaverScreen = 19,
        Instantaneous = 20,
        None = 21
    }

    public enum SystemStretch
    {
        Stretch = 0,
        Tiled = 1
    }

    public enum SystemFont
    {
        Gothic = 0,
        Mincho = 1
    }

    public enum SystemBattleFormation
    {
        Terrain = 0,
        Loose = 1,
        Tight = 2
    }

    public enum SystemBattleCondition
    {
        None = 0,
        Initiative = 1,
        Back = 2,
        Surround = 3,
        Pincers = 4
    }

    public enum SystemEquipmentSetting
    {
        Actor = 0,
        Class = 1
    }

    [LcfChunk<SystemChunk>]
    public class RpgSystem
    {
        public static readonly Dictionary<SystemFadeOut, string> FadeOutTags = new Dictionary<SystemFadeOut, string>
        {
            { SystemFadeOut.Default, "default" },
            { SystemFadeOut.FadeOut, "fade_out" },
            { SystemFadeOut.RemoveBlocks, "remove_blocks" },
            { SystemFadeOut.WipeDownward, "wipe_downward" },
            { SystemFadeOut.WipeUpward, "wipe_upward" },
            { SystemFadeOut.VenetianBlinds, "venetian_blinds" },
            { SystemFadeOut.VerticalBlinds, "vertical_blinds" },
            { SystemFadeOut.HorizontalBlinds, "horizontal_blinds" },
            { SystemFadeOut.RecedingSquare, "receding_square" },
            { SystemFadeOut.ExpandingSquare, "expanding_square" },
            { SystemFadeOut.ScreenMovesUp, "screen_moves_up" },
            { SystemFadeOut.ScreenMovesDown, "screen_moves_down" },
            { SystemFadeOut.ScreenMovesLeft, "screen_moves_left" },
            { SystemFadeOut.ScreenMovesRight, "screen_moves_right" },
            { SystemFadeOut.VerticalDiv, "vertical_div" },
            { SystemFadeOut.HorizontalDiv, "horizontal_div" },
            { SystemFadeOut.Quadrasection, "quadrasection" },
            { SystemFadeOut.ZoomIn, "zoom_in" },
            { SystemFadeOut.Mosaic, "mosaic" },
            { SystemFadeOut.WaverScreen, "waver_screen" },
            { SystemFadeOut.Instantaneous, "instantaneous" },
            { SystemFadeOut.None, "none" }
        };

        public static readonly Dictionary<SystemFadeIn, string> FadeInTags = new Dictionary<SystemFadeIn, string>
        {
            { SystemFadeIn.Default, "default" },
            { SystemFadeIn.FadeIn, "fade_in" },
            { SystemFadeIn.ReconstituteBlocks, "reconstitute_blocks" },
            { SystemFadeIn.UnwipeDownward, "unwipe_downward" },
            { SystemFadeIn.UnwipeUpward, "unwipe_upward" },
            { SystemFadeIn.VenetianBlinds, "venetian_blinds" },
            { SystemFadeIn.VerticalBlinds, "vertical_blinds" },
            { SystemFadeIn.HorizontalBlinds, "horizontal_blinds" },
            { SystemFadeIn.RecedingSquare, "receding_square" },
            { SystemFadeIn.ExpandingSquare, "expanding_square" },
            { SystemFadeIn.ScreenMovesDown, "screen_moves_down" },
            { SystemFadeIn.ScreenMovesUp, "screen_moves_up" },
            { SystemFadeIn.ScreenMovesRight, "screen_moves_right" },
            { SystemFadeIn.ScreenMovesLeft, "screen_moves_left" },
            { SystemFadeIn.VerticalUnify, "vertical_unify" },
            { SystemFadeIn.HorizontalUnify, "horizontal_unify" },
            { SystemFadeIn.UnifyQuadrants, "unify_quadrants" },
            { SystemFadeIn.ZoomOut, "zoom_out" },
            { SystemFadeIn.Mosaic, "mosaic" },
            { SystemFadeIn.WaverScreen, "waver_screen" },
            { SystemFadeIn.Instantaneous, "instantaneous" },
            { SystemFadeIn.None, "none" }
        };

        public static readonly Dictionary<SystemStretch, string> StretchTags = new Dictionary<SystemStretch, string>
        {
            { SystemStretch.Stretch, "stretch" },
            { SystemStretch.Tiled, "tiled" }
        };

        public static readonly Dictionary<SystemFont, string> FontTags = new Dictionary<SystemFont, string>
        {
            { SystemFont.Gothic, "gothic" },
            { SystemFont.Mincho, "mincho" }
        };

        public static readonly Dictionary<SystemBattleFormation, string> BattleFormationTags = new Dictionary<SystemBattleFormation, string>
        {
            { SystemBattleFormation.Terrain, "terrain" },
            { SystemBattleFormation.Loose, "loose" },
            { SystemBattleFormation.Tight, "tight" }
        };

        public static readonly Dictionary<SystemBattleCondition, string> BattleConditionTags = new Dictionary<SystemBattleCondition, string>
        {
            { SystemBattleCondition.None, "none" },
            { SystemBattleCondition.Initiative, "initiative" },
            { SystemBattleCondition.Back, "back" },
            { SystemBattleCondition.Surround, "surround" },
            { SystemBattleCondition.Pincers, "pincers" }
        };

        public static readonly Dictionary<SystemEquipmentSetting, string> EquipmentSettingTags = new Dictionary<SystemEquipmentSetting, string>
        {
            { SystemEquipmentSetting.Actor, "actor" },
            { SystemEquipmentSetting.Class, "class" }
        };

        public int LdbID
        {
            get;
            set;
        }

        public DbString BoatName
        {
            get;
            set;
        }

        public DbString ShipName
        {
            get;
            set;
        }

        public DbString AirshipName
        {
            get;
            set;
        }

        public int BoatIndex
        {
            get;
            set;
        }

        public int ShipIndex
        {
            get;
            set;
        }

        public int AirshipIndex
        {
            get;
            set;
        }

        public DbString TitleName
        {
            get;
            set;
        }

        public DbString GameoverName
        {
            get;
            set;
        }

        public DbString SystemName
        {
            get;
            set;
        }

        public DbString System2Name
        {
            get;
            set;
        }

        public List<short> Party
        {
            get;
            set;
        } = new List<short> { 1 };

        [LcfAlwaysPersistAttribute]
        public List<short> MenuCommands
        {
            get;
            set;
        } = new List<short> { 1 };

        public Music TitleMusic
        {
            get;
            set;
        }

        public Music BattleMusic
        {
            get;
            set;
        }

        public Music BattleEndMusic
        {
            get;
            set;
        }

        public Music InnMusic
        {
            get;
            set;
        }

        public Music BoatMusic
        {
            get;
            set;
        }

        public Music ShipMusic
        {
            get;
            set;
        }

        public Music AirshipMusic
        {
            get;
            set;
        }

        public Music GameoverMusic
        {
            get;
            set;
        }

        public Sound CursorSe
        {
            get;
            set;
        }

        public Sound DecisionSe
        {
            get;
            set;
        }

        public Sound CancelSe
        {
            get;
            set;
        }

        public Sound BuzzerSe
        {
            get;
            set;
        }

        public Sound BattleSe
        {
            get;
            set;
        }

        public Sound EscapeSe
        {
            get;
            set;
        }

        public Sound EnemyAttackSe
        {
            get;
            set;
        }

        public Sound EnemyDamagedSe
        {
            get;
            set;
        }

        public Sound ActorDamagedSe
        {
            get;
            set;
        }

        public Sound DodgeSe
        {
            get;
            set;
        }

        public Sound EnemyDeathSe
        {
            get;
            set;
        }

        public Sound ItemSe
        {
            get;
            set;
        }

        public SystemFadeOut TransitionOut
        {
            get;
            set;
        }

        public SystemFadeIn TransitionIn
        {
            get;
            set;
        }

        public SystemFadeOut BattleStartFadeOut
        {
            get;
            set;
        }

        public SystemFadeIn BattleStartFadeIn
        {
            get;
            set;
        }

        public SystemFadeOut BattleEndFadeOut
        {
            get;
            set;
        }

        public SystemFadeIn BattleEndFadeIn
        {
            get;
            set;
        }

        public SystemStretch MessageStretch
        {
            get;
            set;
        }

        public SystemFont FontID
        {
            get;
            set;
        }

        public SystemBattleCondition SelectedCondition
        {
            get;
            set;
        }

        public int SelectedHero
        {
            get;
            set;
        }

        public DbString BattleTestBackground
        {
            get;
            set;
        }

        public List<TestBattler> BattleTestData
        {
            get;
            set;
        }

        public int SaveCount
        {
            get;
            set;
        }

        public int BattleTestTerrain
        {
            get;
            set;
        }

        public SystemBattleFormation BattleTestFormation
        {
            get;
            set;
        }

        public SystemBattleCondition BattleTestCondition
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public SystemEquipmentSetting EquipmentSetting
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public int BattleTestAltTerrain
        {
            get;
            set;
        } = -1;

        [LcfAlwaysPersistAttribute]
        public bool ShowFrame
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public DbString FrameName
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public bool InvertAnimations
        {
            get;
            set;
        }

        [LcfAlwaysPersistAttribute]
        public bool ShowTitle
        {
            get;
            set;
        } = true;
    }
}