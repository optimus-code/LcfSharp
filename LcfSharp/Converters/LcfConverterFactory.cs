using LcfSharp.Converters.Types;
using LcfSharp.Exceptions;
using System;
using System.Collections.Generic;

namespace LcfSharp.Converters
{
    public static class LcfConverterFactory
    {
        private static readonly Dictionary<Type, LcfConverter> Converters = new()
        {
            { typeof(string), new LcfStringConverter() },
            { typeof(int), new LcfIntConverter() },
            // Add other default converters
        };

        public static LcfConverter GetConverter(Type type)
        {
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