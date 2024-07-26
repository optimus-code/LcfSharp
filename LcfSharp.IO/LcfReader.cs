using LcfSharp.IO.Converters;
using System.IO;
using System.Reflection;
using System;
using System.Linq;
using LcfSharp.IO.Attributes;
using LcfSharp.IO.Extensions;
using LcfSharp.IO.Converters.Types;
using LcfSharp.IO.Types;

namespace LcfSharp.IO
{
    public class LcfReader : IDisposable
    {
        public long Position
        {
            get
            {
                return _reader.BaseStream.Position;
            }
        }

        private readonly BinaryReader _reader;

        public LcfReader(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }

        public T Deserialize<T>() 
            where T : ILcfRootChunk
        {
            return (T)Deserialize(typeof(T));
        }

        private ILcfRootChunk Deserialize(Type type)
        {
            var chunkReader = new LcfChunkConverter(type);
            return (ILcfRootChunk)chunkReader.Read(_reader, null);
        }

        public int ReadVarInt()
        {
            return _reader.ReadVarInt();
        }

        public string ReadString(int length)
        {
            return _reader.ReadString(length);
        }

        public void Dispose()
        {
            _reader?.Dispose();
        }
    }
}