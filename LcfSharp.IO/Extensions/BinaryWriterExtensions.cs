using System.IO;
using System.Text;

namespace LcfSharp.IO.Extensions
{
    public static class BinaryWriterExtensions
    {
        /// <summary>
        /// Write an ASCII string with no length prefixed
        /// </summary>
        /// <param name="bw"></param>
        /// <param name="value"></param>
        public static void WriteString(this BinaryWriter bw, string value)
        {
            bw.Write(Encoding.ASCII.GetBytes(value));
        }
    }
}
