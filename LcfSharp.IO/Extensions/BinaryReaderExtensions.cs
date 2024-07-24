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
    }
}
