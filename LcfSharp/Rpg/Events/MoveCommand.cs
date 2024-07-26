using LcfSharp.IO.Types;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LcfSharp.Rpg.Events
{
    public class MoveCommand
    {
        public static readonly Dictionary<MoveCommandCode, string> CodeTags = new Dictionary<MoveCommandCode, string>
        {
            { MoveCommandCode.MoveUp, "move_up" },
            { MoveCommandCode.MoveRight, "move_right" },
            { MoveCommandCode.MoveDown, "move_down" },
            { MoveCommandCode.MoveLeft, "move_left" },
            { MoveCommandCode.MoveUpright, "move_upright" },
            { MoveCommandCode.MoveDownright, "move_downright" },
            { MoveCommandCode.MoveDownleft, "move_downleft" },
            { MoveCommandCode.MoveUpleft, "move_upleft" },
            { MoveCommandCode.MoveRandom, "move_random" },
            { MoveCommandCode.MoveTowardsHero, "move_towards_hero" },
            { MoveCommandCode.MoveAwayFromHero, "move_away_from_hero" },
            { MoveCommandCode.MoveForward, "move_forward" },
            { MoveCommandCode.FaceUp, "face_up" },
            { MoveCommandCode.FaceRight, "face_right" },
            { MoveCommandCode.FaceDown, "face_down" },
            { MoveCommandCode.FaceLeft, "face_left" },
            { MoveCommandCode.Turn90DegreeRight, "turn_90_degree_right" },
            { MoveCommandCode.Turn90DegreeLeft, "turn_90_degree_left" },
            { MoveCommandCode.Turn180Degree, "turn_180_degree" },
            { MoveCommandCode.Turn90DegreeRandom, "turn_90_degree_random" },
            { MoveCommandCode.FaceRandomDirection, "face_random_direction" },
            { MoveCommandCode.FaceHero, "face_hero" },
            { MoveCommandCode.FaceAwayFromHero, "face_away_from_hero" },
            { MoveCommandCode.Wait, "wait" },
            { MoveCommandCode.BeginJump, "begin_jump" },
            { MoveCommandCode.EndJump, "end_jump" },
            { MoveCommandCode.LockFacing, "lock_facing" },
            { MoveCommandCode.UnlockFacing, "unlock_facing" },
            { MoveCommandCode.IncreaseMovementSpeed, "increase_movement_speed" },
            { MoveCommandCode.DecreaseMovementSpeed, "decrease_movement_speed" },
            { MoveCommandCode.IncreaseMovementFrequence, "increase_movement_frequence" },
            { MoveCommandCode.DecreaseMovementFrequence, "decrease_movement_frequence" },
            { MoveCommandCode.SwitchOn, "switch_on" },
            { MoveCommandCode.SwitchOff, "switch_off" },
            { MoveCommandCode.ChangeGraphic, "change_graphic" },
            { MoveCommandCode.PlaySoundEffect, "play_sound_effect" },
            { MoveCommandCode.WalkEverywhereOn, "walk_everywhere_on" },
            { MoveCommandCode.WalkEverywhereOff, "walk_everywhere_off" },
            { MoveCommandCode.StopAnimation, "stop_animation" },
            { MoveCommandCode.StartAnimation, "start_animation" },
            { MoveCommandCode.IncreaseTransp, "increase_transp" },
            { MoveCommandCode.DecreaseTransp, "decrease_transp" }
        };

        [XmlAttribute]
        public int CommandID
        {
            get;
            set;
        }

        public string ParameterString
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ParameterA
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ParameterB
        {
            get;
            set;
        }

        [XmlAttribute]
        public int ParameterC
        {
            get;
            set;
        }
    }
}
