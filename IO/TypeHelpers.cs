using System.Runtime.InteropServices;
using System;
using LcfSharp.Rpg.Shared;
using LcfSharp.Rpg.Skills;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Linq;

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

        public static void ReadChunks<TEnum>(LcfReader reader, Func<byte,bool> onReadChunk)
            where TEnum : struct
        {
            var finishedChunks = false;
            var enumValues = ( ( byte[] ) Enum.GetValues(typeof(TEnum)) ).ToHashSet();

            while (!reader.IsEOF && !finishedChunks)
            {
                var chunk = reader.ReadChunkHeader();

                if (enumValues.Contains(chunk.ID))
                {
                    var result = onReadChunk?.Invoke(chunk.ID);

                    if (result.HasValue && !result.Value)
                        reader.Skip(chunk, typeof(TEnum).Name);
                }
                else
                {
                    reader.Skip(chunk, typeof(TEnum).Name);
                }

                if (chunk.ID == enumValues.Last())
                {
                    finishedChunks = true;
                    break;
                }
            }
        }
    }
}
