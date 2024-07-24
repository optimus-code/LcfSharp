using LcfSharp.IO.Converters;
using System.IO;
using System.Reflection;
using System;
using System.Linq;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Extensions;
using LcfSharp.IO.Converters.Types;

namespace LcfSharp.IO
{
    public class LcfReader
    {
        private readonly BinaryReader _reader;

        public LcfReader(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }

        public T Deserialize<T>() 
            where T : new()
        {
            return (T)Deserialize(typeof(T));
        }

        private object Deserialize(Type type)
        {
            var chunkReader = new LcfChunkConverter(type);
            return chunkReader.Read(_reader, null);
        }
    }
}