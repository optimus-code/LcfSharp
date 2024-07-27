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

namespace LcfSharp.Rpg.Events
{
    public enum MoveCommandCode
    {
        MoveUp = 0,
        MoveRight = 1,
        MoveDown = 2,
        MoveLeft = 3,
        MoveUpright = 4,
        MoveDownright = 5,
        MoveDownleft = 6,
        MoveUpleft = 7,
        MoveRandom = 8,
        MoveTowardsHero = 9,
        MoveAwayFromHero = 10,
        MoveForward = 11,
        FaceUp = 12,
        FaceRight = 13,
        FaceDown = 14,
        FaceLeft = 15,
        Turn90DegreeRight = 16,
        Turn90DegreeLeft = 17,
        Turn180Degree = 18,
        Turn90DegreeRandom = 19,
        FaceRandomDirection = 20,
        FaceHero = 21,
        FaceAwayFromHero = 22,
        Wait = 23,
        BeginJump = 24,
        EndJump = 25,
        LockFacing = 26,
        UnlockFacing = 27,
        IncreaseMovementSpeed = 28,
        DecreaseMovementSpeed = 29,
        IncreaseMovementFrequence = 30,
        DecreaseMovementFrequence = 31,
        SwitchOn = 32,
        SwitchOff = 33,
        ChangeGraphic = 34,
        PlaySoundEffect = 35,
        WalkEverywhereOn = 36,
        WalkEverywhereOff = 37,
        StopAnimation = 38,
        StartAnimation = 39,
        IncreaseTransp = 40,
        DecreaseTransp = 41
    }
}
