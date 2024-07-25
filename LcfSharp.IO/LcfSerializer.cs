using LcfSharp.IO.Converters;
using LcfSharp.IO.Exceptions;
using System.IO;
using System.Linq;
using System.Text;

namespace LcfSharp.IO
{
    public static class LcfSerializer
    {
        private static readonly LcfSerializerOptions _defaultOptions = new();

        static LcfSerializer()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        private static string ReadHeader(LcfReader reader, LcfSerializerOptions options)
        {
            switch (options.Format)
            {
                case LcfFormat.LDB:
                    var headerLength = reader.ReadVarInt();
                    var header = reader.ReadString(headerLength);

                    if (string.IsNullOrEmpty(header)
                        || header.Length != 11
                        || header != "LcfDataBase")
                    {
                        throw new LcfInvalidHeaderException("LcfDatabase", header ?? "NULL");
                    }
                    return header;
            }

            return null;
        }

        public static T Deserialize<T>(Stream stream, LcfSerializerOptions options = null) 
            where T : ILcfRootChunk
        {
            var currentOptions = options ?? _defaultOptions;

            if (currentOptions.Converters.Any())
            {
                foreach (var converter in currentOptions.Converters)
                {
                    LcfConverterFactory.RegisterConverter(converter);
                }
            }

            LcfConverterFactory.EngineVersion = options.Version;

            using (var reader = new LcfReader(stream))
            {
                var header = ReadHeader(reader, currentOptions);

                var instance = reader.Deserialize<T>();

                if (instance != null)
                    instance.Header = header;

                return instance;
            }
        }

        public static void Serialize<T>(Stream stream, T value, LcfSerializerOptions options = null)
        {
            // Implement serialization logic
        }
    }

}
