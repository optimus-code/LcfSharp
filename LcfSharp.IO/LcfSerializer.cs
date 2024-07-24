using System.IO;
using System.Text;

namespace LcfSharp.IO
{
    public static class LcfSerializer
    {
        static LcfSerializer()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public static T Deserialize<T>(Stream stream, LcfSerializerOptions options = null) 
            where T : new()
        {
            var reader = new LcfReader(stream);
            return reader.Deserialize<T>();
        }

        public static void Serialize<T>(Stream stream, T value, LcfSerializerOptions options = null)
        {
            // Implement serialization logic
        }
    }

}
