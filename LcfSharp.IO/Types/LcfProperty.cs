using LcfSharp.IO.Attributes;
using LcfSharp.IO.Converters;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace LcfSharp.IO.Types
{
    internal class LcfProperty
    {
        static Dictionary<Type, List<LcfProperty>> _propertyCache = [];

        public PropertyInfo Property { get; set; }
        public LcfIDAttribute ID { get; set; }
        public LcfAlwaysPersistAttribute AlwaysPersist { get; set; }
        public LcfSizeAttribute Size { get; set; }
        public LcfVersionAttribute Version { get; set; }

        public bool IsAllowed
        {
            get;
            private set;
        }

        public bool IsGenericListType
        {
            get;
            private set;
        }

        public Type GenericListInnerType
        {
            get;
            private set;
        }

        public bool IsGenericListBasicType
        {
            get;
            private set;
        }

        public LcfProperty(PropertyInfo property)
        {
            Property = property;
            ID = property.GetCustomAttribute<LcfIDAttribute>();
            AlwaysPersist = property.GetCustomAttribute<LcfAlwaysPersistAttribute>();
            Size = property.GetCustomAttribute<LcfSizeAttribute>();
            Version = property.GetCustomAttribute<LcfVersionAttribute>();
            IsAllowed = CheckIsAllowed();
            
            IsGenericListType = property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>);
            
            if (IsGenericListType)
            {
                GenericListInnerType = property.PropertyType.GetGenericArguments()[0];
                IsGenericListBasicType = !GenericListInnerType.IsClass && GenericListInnerType.IsPrimitive;
            }
        }

        private bool CheckIsAllowed()
        {
            return Property != null && Version?.Version == LcfConverterFactory.EngineVersion
                || Version == null && LcfConverterFactory.EngineVersion == LcfEngineVersion.RM2K;
        }

        public static List<LcfProperty> Get(Type type)
        {
            if (!_propertyCache.TryGetValue(type, out var properties))
            {
                properties = new List<LcfProperty>();
                foreach (var p in LcfConverterFactory.GetProperties(type))
                {
                    if (p.GetCustomAttribute<LcfIgnoreAttribute>() == null)
                    {
                        properties.Add(new LcfProperty(p));
                    }
                }
                _propertyCache[type] = properties;
            }
            return properties;
        }
    }
}