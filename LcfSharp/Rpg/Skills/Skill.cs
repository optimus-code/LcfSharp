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

using System.Collections.Generic;
using LcfSharp.Rpg.Audio;
using LcfSharp.Rpg.Shared;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types;
using LcfSharp.Chunks.Database;

namespace LcfSharp.Rpg.Skills
{
    [LcfChunk<SkillChunk>]
    public class Skill
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        } = 0;

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string UsingMessage1
        {
            get;
            set;
        }

        public string UsingMessage2
        {
            get;
            set;
        }

        public int FailureMessage
        {
            get;
            set;
        } = 0;

        [LcfAlwaysPersist]
        public SkillType SkillType
        {
            get;
            set;
        } = SkillType.Normal;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public SkillSpType SPType
        {
            get;
            set;
        } = SkillSpType.Cost;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int SPPercent
        {
            get;
            set;
        } = 0;

        public int SPCost
        {
            get;
            set;
        } = 0;

        [LcfAlwaysPersist]
        public SkillScope SkillScope
        {
            get;
            set;
        } = SkillScope.Enemy;

        public int SwitchID
        {
            get;
            set;
        } = 1;

        public int AnimationID
        {
            get;
            set;
        } = 1;

        [LcfAlwaysPersist]
        public Sound SoundEffect
        {
            get;
            set;
        }

        public bool OccasionField
        {
            get;
            set;
        } = true;

        public bool OccasionBattle
        {
            get;
            set;
        } = false;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public bool ReverseStateEffect
        {
            get;
            set;
        } = false;

        public int PhysicalRate
        {
            get;
            set;
        } = 0;

        public int MagicalRate
        {
            get;
            set;
        } = 3;

        public int Variance
        {
            get;
            set;
        } = 4;

        public int Power
        {
            get;
            set;
        } = 0;

        public int Hit
        {
            get;
            set;
        } = 100;

        public bool AffectHP
        {
            get;
            set;
        } = false;

        public bool AffectSP
        {
            get;
            set;
        } = false;

        public bool AffectAttack
        {
            get;
            set;
        } = false;

        public bool AffectDefense
        {
            get;
            set;
        } = false;

        public bool AffectSpirit
        {
            get;
            set;
        } = false;

        public bool AffectAgility
        {
            get;
            set;
        } = false;

        public bool AbsorbDamage
        {
            get;
            set;
        } = false;

        public bool IgnoreDefense
        {
            get;
            set;
        } = false;

        [LcfAlwaysPersist]
        [LcfSize(( int ) SkillChunk.StateEffectsSize)]
        public List<bool> StateEffects
        {
            get;
            set;
        }

        [LcfAlwaysPersist]
        [LcfSize(( int ) SkillChunk.AttributeEffectsSize)]
        public List<bool> AttributeEffects
        {
            get;
            set;
        }

        public bool AffectAttrDefence
        {
            get;
            set;
        } = false;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        public int BattlerAnimation
        {
            get;
            set;
        } = -1;

        [LcfVersion(LcfEngineVersion.RM2K3)]
        [LcfAlwaysPersist]
        public List<BattlerAnimationItemSkill> BattlerAnimationData
        {
            get;
            set;
        } = [];
    }
}