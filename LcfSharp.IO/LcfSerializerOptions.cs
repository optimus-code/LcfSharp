using LcfSharp.IO.Converters;
using System.Collections.Generic;

namespace LcfSharp.IO
{
    public class LcfSerializerOptions
    {
        public LcfFormat Format
        {
            get;
            set;
        } = LcfFormat.LDB;

        public bool IgnoreUnknownChunks 
        { 
            get;
            set;
        } = true;

        public List<LcfConverter> Converters
        {
            get;
            set;
        } = [];

        public LcfEngineVersion Version
        {
            get;
            set;
        } = LcfEngineVersion.RM2K;
    }
}
