/// <copyright>
/// 
/// LcfSharp Copyright (c) 2024 optimus-code
/// (A "loose" .NET port of liblcf)
/// Licensed under the MIT License.
/// 
/// Copyright (c) 2014-2023 liblcf authors
/// Licensed under the MIT License.
/// 
/// Permission is hereby granted, free of charge, to any person obtaining
/// a copy of this software and associated documentation files (the
/// "Software"), to deal in the Software without restriction, including
/// without limitation the rights to use, copy, modify, merge, publish,
/// distribute, sublicense, and/or sell copies of the Software, and to
/// permit persons to whom the Software is furnished to do so, subject to
/// the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included
/// in all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
/// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
/// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
/// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
/// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
/// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
/// </copyright>

using LcfSharp.Chunks.Database;
using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg.States
{
    /// <summary>
    /// Class representing a state in the game.
    /// </summary>
    [LcfChunk<StateChunk>]
    public class State
    {
        /// <summary>
        /// The constant ID for the death state.
        /// </summary>
        public const int DeathID = 1;

        /// <summary>
        /// The unique identifier for the state.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the state.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The persistence type of the state.
        /// </summary>
        [LcfAlwaysPersist]
        public StatePersistence Type
        {
            get;
            set;
        }

        /// <summary>
        /// The color of the state. Default is 6.
        /// </summary>
        public int Color
        {
            get;
            set;
        } = 6;

        /// <summary>
        /// The priority of the state. Default is 50.
        /// </summary>
        public int Priority
        {
            get;
            set;
        } = 50;

        /// <summary>
        /// The restriction of the state.
        /// </summary>
        [LcfAlwaysPersist]
        public StateRestriction Restriction
        {
            get;
            set;
        }

        /// <summary>
        /// The A-rate of the state. Default is 100.
        /// </summary>
        public int ARate
        {
            get;
            set;
        } = 100;

        /// <summary>
        /// The B-rate of the state. Default is 80.
        /// </summary>
        public int BRate
        {
            get;
            set;
        } = 80;

        /// <summary>
        /// The C-rate of the state. Default is 60.
        /// </summary>
        public int CRate
        {
            get;
            set;
        } = 60;

        /// <summary>
        /// The D-rate of the state. Default is 30.
        /// </summary>
        public int DRate
        {
            get;
            set;
        } = 30;

        /// <summary>
        /// The E-rate of the state.
        /// </summary>
        public int ERate
        {
            get;
            set;
        }

        /// <summary>
        /// The number of turns the state is held.
        /// </summary>
        public int HoldTurn
        {
            get;
            set;
        }

        /// <summary>
        /// The probability of the state being automatically released.
        /// </summary>
        public int AutoReleaseProb
        {
            get;
            set;
        }

        /// <summary>
        /// The probability of the state being released by damage.
        /// </summary>
        public int ReleaseByDamage
        {
            get;
            set;
        }

        /// <summary>
        /// The type of effect the state has.
        /// </summary>
        public StateAffectType AffectType
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the state affects attack.
        /// </summary>
        public bool AffectAttack
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the state affects defense.
        /// </summary>
        public bool AffectDefense
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the state affects spirit.
        /// </summary>
        public bool AffectSpirit
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the state affects agility.
        /// </summary>
        public bool AffectAgility
        {
            get;
            set;
        }

        /// <summary>
        /// The reduction in hit ratio caused by the state. Default is 100.
        /// </summary>
        public int ReduceHitRatio
        {
            get;
            set;
        } = 100;

        /// <summary>
        /// Indicates whether the state causes the character to avoid attacks.
        /// </summary>
        public bool AvoidAttacks
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the state reflects magic.
        /// </summary>
        public bool ReflectMagic
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the state is cursed.
        /// </summary>
        public bool Cursed
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the battler animation associated with the state. Default is 100.
        /// </summary>
        public int BattlerAnimationID
        {
            get;
            set;
        } = 100;

        /// <summary>
        /// Indicates whether the state restricts skill usage.
        /// </summary>
        public bool RestrictSkill
        {
            get;
            set;
        }

        /// <summary>
        /// The skill level restricted by the state.
        /// </summary>
        public int RestrictSkillLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the state restricts magic usage.
        /// </summary>
        public bool RestrictMagic
        {
            get;
            set;
        }

        /// <summary>
        /// The magic level restricted by the state.
        /// </summary>
        public int RestrictMagicLevel
        {
            get;
            set;
        }

        /// <summary>
        /// The type of HP change caused by the state.
        /// </summary>
        public StateChangeType HPChangeType
        {
            get;
            set;
        }

        /// <summary>
        /// The type of SP change caused by the state.
        /// </summary>
        public StateChangeType SPChangeType
        {
            get;
            set;
        }

        /// <summary>
        /// The message shown when the state affects an actor.
        /// </summary>
        public string MessageActor
        {
            get;
            set;
        }

        /// <summary>
        /// The message shown when the state affects an enemy.
        /// </summary>
        public string MessageEnemy
        {
            get;
            set;
        }

        /// <summary>
        /// The message shown when the state is already present.
        /// </summary>
        public string MessageAlready
        {
            get;
            set;
        }

        /// <summary>
        /// The message shown when the state affects a character.
        /// </summary>
        public string MessageAffected
        {
            get;
            set;
        }

        /// <summary>
        /// The message shown when the state is recovered.
        /// </summary>
        public string MessageRecovery
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum HP change caused by the state.
        /// </summary>
        public int HPChangeMax
        {
            get;
            set;
        }

        /// <summary>
        /// The HP change value caused by the state.
        /// </summary>
        public int HPChangeVal
        {
            get;
            set;
        }

        /// <summary>
        /// The number of map steps required to change HP.
        /// </summary>
        public int HPChangeMapSteps
        {
            get;
            set;
        }

        /// <summary>
        /// The HP change value per map step.
        /// </summary>
        public int HPChangeMapVal
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum SP change caused by the state.
        /// </summary>
        public int SPChangeMax
        {
            get;
            set;
        }

        /// <summary>
        /// The SP change value caused by the state.
        /// </summary>
        public int SPChangeVal
        {
            get;
            set;
        }

        /// <summary>
        /// The number of map steps required to change SP.
        /// </summary>
        public int SPChangeMapSteps
        {
            get;
            set;
        }

        /// <summary>
        /// The SP change value per map step.
        /// </summary>
        public int SPChangeMapVal
        {
            get;
            set;
        }
    }
}