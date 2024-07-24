using LcfSharp.IO.Attributes;
using LcfSharp.IO.Converters.Types;
using LcfSharp.IO.Exceptions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace LcfSharp.IO.Converters
{
    public static class LcfConverterFactory
    {
        private static readonly Dictionary<Type, LcfConverter> Converters = new()
        {
            { typeof(string), new LcfStringConverter() },
            { typeof(byte), new LcfByteConverter() },
            { typeof(short), new LcfInt16Converter() },
            { typeof(int), new LcfInt32Converter() },
            { typeof(long), new LcfInt64Converter() },
            // Add other default converters
        };

        public static LcfConverter GetConverter(Type type)
        {
            if (type.IsClass && type.GetCustomAttribute<LcfChunkAttribute>() != null)
            {
                return new LcfChunkConverter(type);
            }

            if (Converters.TryGetValue(type, out var converter))
            {
                return converter;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                var elementType = type.GetGenericArguments()[0];
                var listConverterType = typeof(LcfListConverter<>).MakeGenericType(elementType);
                return (LcfConverter)Activator.CreateInstance(listConverterType);
            }

            throw new LcfMissingConverterException(type);
        }
    }
}