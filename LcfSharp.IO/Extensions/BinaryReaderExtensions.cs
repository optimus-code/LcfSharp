using LcfSharp.IO.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LcfSharp.IO.Extensions
{
    public static class BinaryReaderExtensions
    {
        /// <summary>
        /// Read an ASCII string with no length prefixed
        /// </summary>
        /// <param name="br"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ReadString(this BinaryReader br, int length)
        {
            return Encoding.ASCII.GetString(br.ReadBytes(length));
        }

        /// <summary>
        /// Read a variable encoding string with no length prefixed
        /// </summary>
        /// <param name="br"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static DbString ReadDbString(this BinaryReader br, int length)
        {
            return Encoding.ASCII.GetString(br.ReadBytes(length));
        }

        /// <summary>
        /// Reads a list of short values from the stream.
        /// </summary>
        /// <param name="br"></param>
        /// <param name="size">The number of short values to read.</param>
        /// <returns>A list of short values.</returns>
        public static List<short> ReadInt16List(this BinaryReader br, int size)
        {
            if (size == 0)
                return new List<short>();

            var buffer = new List<short>();

            for (var i = 0; i < size; i++)
                buffer.Add(br.ReadInt16());

            return buffer;
        }

        /// <summary>
        /// Read a 7-bit variable-length encoded integer
        /// </summary>
        /// <remarks>(Output differs slightly to built-in .NET one due to the OR
        /// that occurs before. Hence needing this version for RM2K compatibility.</remarks>
        /// <param name="br"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static int ReadVarInt(this BinaryReader br)
        {
            int result = 0;
            int loops = 0;

            while (true)
            {
                byte byteReadJustNow = br.ReadByte();
                result <<= 7;
                result |= byteReadJustNow & 0x7F;

                if ((byteReadJustNow & 0x80) == 0)
                {
                    break;
                }

                if (loops > 5)
                {
                    throw new FormatException("Bad 7-bit encoded integer.");
                }

                loops++;
            }

            return loops > 5 ? 0 : result;
        }

        public static byte? PeekByte(this BinaryReader br)
        {
            var stream = br.BaseStream;

            if (stream.Position >= stream.Length)
                return null;

            if (!stream.CanSeek)
                return null;

            long origPos = stream.Position;
            var value = br.ReadByte();
            stream.Position = origPos;
            return value;
        }
    }
}
