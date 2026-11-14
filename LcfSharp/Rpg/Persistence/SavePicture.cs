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

using LcfSharp.Chunks.Persistence;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types.Generic;
using LcfSharp.IO.Types;

namespace LcfSharp.Rpg.Persistence
{
    /// <summary>
    /// Represents Picture data in an LSD save file.
    /// </summary>
    [LcfChunk<SavePictureChunk>]
    public class SavePicture : IIndexedItem
    {
        [LcfID]
        public int ID
        {
            get;
            set;
        }

        public LcfString Name
        {
            get;
            set;
        }

        public double StartX
        {
            get;
            set;
        }

        public double StartY
        {
            get;
            set;
        }

        public double CurrentX
        {
            get;
            set;
        }

        public double CurrentY
        {
            get;
            set;
        }

        public bool FixedToMap
        {
            get;
            set;
        }

        public double CurrentMagnify
        {
            get;
            set;
        } = 100.0;

        public double CurrentTopTrans
        {
            get;
            set;
        }

        public bool UseTransparentColor
        {
            get;
            set;
        }

        public double CurrentRed
        {
            get;
            set;
        } = 100.0;

        public double CurrentGreen
        {
            get;
            set;
        } = 100.0;

        public double CurrentBlue
        {
            get;
            set;
        } = 100.0;

        public double CurrentSat
        {
            get;
            set;
        } = 100.0;

        public int EffectMode
        {
            get;
            set;
        }

        public double CurrentEffectPower
        {
            get;
            set;
        }

        public double CurrentBotTrans
        {
            get;
            set;
        }

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int SpritesheetCols
        {
            get;
            set;
        } = 1;

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int SpritesheetRows
        {
            get;
            set;
        } = 1;

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int SpritesheetFrame
        {
            get;
            set;
        }

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int SpritesheetSpeed
        {
            get;
            set;
        }

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public int Frames
        {
            get;
            set;
        }

        [LcfVersion( LcfEngineVersion.RM2K3 )]
        public bool SpritesheetPlayOnce
        {
            get;
            set;
        }

        public int MapLayer
        {
            get;
            set;
        } = 7;

        public int BattleLayer
        {
            get;
            set;
        }

        public SavePictureFlags Flags
        {
            get;
            set;
        } = new SavePictureFlags();

        public double FinishX
        {
            get;
            set;
        }

        public double FinishY
        {
            get;
            set;
        }

        public int FinishMagnify
        {
            get;
            set;
        } = 100;

        public int FinishTopTrans
        {
            get;
            set;
        }

        public int FinishBotTrans
        {
            get;
            set;
        }

        public int FinishRed
        {
            get;
            set;
        } = 100;

        public int FinishGreen
        {
            get;
            set;
        } = 100;

        public int FinishBlue
        {
            get;
            set;
        } = 100;

        public int FinishSat
        {
            get;
            set;
        } = 100;

        public int FinishEffectPower
        {
            get;
            set;
        }

        public int TimeLeft
        {
            get;
            set;
        }

        public double CurrentRotation
        {
            get;
            set;
        }

        public int CurrentWaver
        {
            get;
            set;
        }
    }
}