using LcfSharp.IO.Attributes;
using LcfSharp.IO.Converters.Types;
using LcfSharp.IO.Exceptions;
using LcfSharp.IO.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LcfSharp.IO.Converters
{
    public static class LcfConverterFactory
    {
        public static LcfEngineVersion EngineVersion
        {
            get;
            set;
        }

        private static readonly Dictionary<Type, LcfConverter> Converters = new()
        {
            { typeof(string), new LcfStringConverter() },
            { typeof(byte), new LcfByteConverter() },
            { typeof(bool), new LcfBooleanConverter() },
            { typeof(short), new LcfInt16Converter() },
            { typeof(int), new LcfInt32Converter() },
            { typeof(long), new LcfInt64Converter() },
            { typeof(BitArray), new LcfBitArrayConverter() }
        };

        private static Dictionary<Type, List<PropertyInfo>> Cache
        {
            get;
            set;
        } = [];

        private static Dictionary<Type, LcfConverter> CustomConverters
        {
            get;
            set;
        } = [];

        private static Dictionary<Type, LcfConverter> DynamicConverters
        {
            get;
            set;
        } = [];

        public static List<PropertyInfo> GetProperties(Type type)
        {
            if (Cache.TryGetValue(type, out var properties))
                return properties;

            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToList();
        }

        public static void RegisterConverter(LcfConverter converter)
        {
            if (converter == null)
                throw new LcfException("Cannot add a NULL converter!");

            if (CustomConverters.ContainsKey(converter.Type))
                return;

            CustomConverters.Add(converter.Type, converter);
        }

        public static LcfConverter GetConverter(Type type)
        {
            if (DynamicConverters.TryGetValue(type, out var dynamicConverter))
                return DynamicConverters[type];

            var isBasicConverter = false;
            LcfConverter resultantConverter = null;

            if (type.IsEnum)
            {
                resultantConverter = new LcfEnumConverter(type);
            }
            else if (type.IsAssignableTo(typeof(IDbFlags)))
            {
                resultantConverter = new LcfDbFlagsConverter(type);
            }
            else if (type.IsClass && type.GetCustomAttribute<LcfListCollectionAttribute>() != null)
            {
                resultantConverter = new LcfListCollectionConverter(type);
            }
            else if (type.IsClass && type.GetCustomAttribute<LcfChunkAttribute>() != null)
            {
                resultantConverter = new LcfChunkConverter(type);
            }
            else if (CustomConverters.TryGetValue(type, out var customConverter))
            {
                resultantConverter = customConverter;
                isBasicConverter = true;
            }
            else if (Converters.TryGetValue(type, out var converter))
            {
                resultantConverter = converter;
                isBasicConverter = true;
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                var elementType = type.GetGenericArguments()[0];
                var listConverterType = typeof(LcfListConverter<>).MakeGenericType(elementType);
                resultantConverter = (LcfConverter)Activator.CreateInstance(listConverterType);
            }
            else if (type.IsClass)
            {
                resultantConverter = new LcfClassConverter(type);
            }

            if (resultantConverter == null)
                throw new LcfMissingConverterException(type);

            // Cache the result
            if (!isBasicConverter)
                DynamicConverters.Add(type, resultantConverter);

            return resultantConverter;
        }
    }
}