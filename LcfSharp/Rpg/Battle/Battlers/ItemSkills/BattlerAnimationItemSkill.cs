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

using LcfSharp.Chunks.Database.Battle;
using LcfSharp.IO.Attributes;

namespace LcfSharp.Rpg.Battle.Battlers.ItemSkills
{
    /// <summary>
    /// Class representing the battler animation for item skills.
    /// </summary>
    [LcfChunk<BattlerAnimationItemSkillChunk>]
    public class BattlerAnimationItemSkill
    {
        /// <summary>
        /// The unique identifier for the battler animation item skill.
        /// </summary>
        [LcfID]
        public int ID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// An unknown property.
        /// </summary>
        public int Unknown02
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The animation type of the battler animation item skill.
        /// </summary>
        public BattlerAnimationItemSkillAnimType Type
        {
            get;
            set;
        } = BattlerAnimationItemSkillAnimType.Weapon;

        /// <summary>
        /// The ID of the weapon animation.
        /// </summary>
        public int WeaponAnimationID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The movement type of the battler animation item skill.
        /// </summary>
        public BattlerAnimationItemSkillMovement Movement
        {
            get;
            set;
        } = BattlerAnimationItemSkillMovement.None;

        /// <summary>
        /// The afterimage type of the battler animation item skill.
        /// </summary>
        public BattlerAnimationItemSkillAfterimage AfterImage
        {
            get;
            set;
        } = BattlerAnimationItemSkillAfterimage.None;

        /// <summary>
        /// The number of attacks.
        /// </summary>
        public int Attacks
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Indicates whether the skill is ranged.
        /// </summary>
        public bool Ranged
        {
            get;
            set;
        } = false;

        /// <summary>
        /// The ID of the ranged animation.
        /// </summary>
        public int RangedAnimationID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The speed of the ranged animation.
        /// </summary>
        public BattlerAnimationItemSkillSpeed RangedSpeed
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// The ID of the battle animation.
        /// </summary>
        public int BattleAnimationID
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// The pose of the battler animation.
        /// </summary>
        public BattlerAnimationPoses Pose
        {
            get;
            set;
        } = BattlerAnimationPoses.Skill;
    }
}