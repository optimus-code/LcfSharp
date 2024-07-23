using System.Runtime.InteropServices;
using System;
using LcfSharp.Rpg.Shared;
using LcfSharp.Rpg.Skills;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Linq;
using System.Collections.Generic;

namespace LcfSharp.IO
{
    public static class TypeHelpers
    {
        public static void ReadLcf<T>(ref T refValue, LcfReader stream, uint length, Action onRead)
        {
            int dif = 0;

            var classSize = Marshal.SizeOf<T>();

            // FIXME: Bug #174
            if (length != classSize)
            {
                dif = (int)(length - classSize);
                Console.WriteLine($"Reading Primitive of incorrect size {length} (expected {classSize}) at {stream.Tell():X}");
            }

            onRead?.Invoke();

            if (dif != 0)
            {
                // Fix incorrect read pointer position
                Console.WriteLine($"Invalid {typeof(T).Name} at {stream.Tell():X}");
                stream.Seek(dif, SeekMode.FromCurrent);
            }
        }

        public static void ReadChunks<TEnum>(LcfReader reader, Func<Chunk,bool> onReadChunk, Chunk? parentChunk = null )
            where TEnum : struct
        {
            var finishedChunks = false;
            var enumValues = ( ( int[] ) Enum.GetValues(typeof(TEnum)) ).ToHashSet();
            var startPosition = reader.Offset;

            while (!reader.IsEOF && !finishedChunks)
            {
                var chunk = reader.ReadChunkHeader();

                if (enumValues.Contains(chunk.ID))
                {
                    var result = onReadChunk?.Invoke(chunk);

                    if (result.HasValue && !result.Value || !result.HasValue)
                        reader.Skip(chunk, typeof(TEnum).Name);
                }
                else
                {
                    reader.Skip(chunk, typeof(TEnum).Name);
                }

                if (parentChunk.HasValue && reader.Offset >= startPosition + parentChunk.Value.Length)
                {
                    finishedChunks = true;
                    break;
                }
            }
        }

        public static void ReadChunkList(LcfReader reader, int length, Action onReadItem, bool readID = true)
        {
            var count = reader.ReadInt();

            for ( var i = 0; i < count; i++)
            {
                if (readID)
                {
                    var id = reader.ReadInt();
                }
                onReadItem?.Invoke();
            }
        }

        public static List<byte> ReadChunkByteList(LcfReader reader, int length)
        {
            var results = new List<byte>((int)length);
            ReadChunkList(reader, length, () =>
            {
                results.Add(reader.ReadByte());
            });
            return results;
        }

        public static List<short> ReadChunkShortList(LcfReader reader, int length)
        {
            var results = new List<short>((int)(length / Marshal.SizeOf<short>()));
            ReadChunkList(reader, length, () =>
            {
                results.Add(reader.ReadShort());
            });
            return results;
        }

        public static List<int> ReadChunkIntList(LcfReader reader, int length)
        {
            var results = new List<int>();
            ReadChunkList(reader, length, () =>
            {
                results.Add(reader.ReadInt());
            });
            return results;
        }
    }
}
