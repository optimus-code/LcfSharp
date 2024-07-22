using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LcfSharp.Types
{
    public class DbFlags
    {
        protected bool[] Values
        {
            get;
            set;
        }

        private static Dictionary<Type, List<PropertyInfo>> TypeProperties
        {
            get;
            set;
        } = [];

        public DbFlags()
        {
            CollectProperties(GetType());
        }

        public static TFlags Read<TFlags>(LcfReader reader)
            where TFlags: DbFlags
        {
            var properties = CollectProperties(typeof(TFlags));

            if (properties == null || properties.Count == 0)
                return null;

            var dbFlags = Activator.CreateInstance<TFlags>();
            dbFlags.Values = reader.ReadFlags(properties.Count);

            for (var i = 0; i < properties.Count; i++)
            {
                properties[i].SetValue(dbFlags, dbFlags.Values[i]);
            }
            return dbFlags;
        }

        public static DbFlags Read(LcfReader reader, Type flagsType)
        {
            var properties = CollectProperties(flagsType);

            if (properties == null || properties.Count == 0)
                return null;

            var dbFlags = (DbFlags)Activator.CreateInstance(flagsType);
            dbFlags.Values = reader.ReadFlags(properties.Count);

            for (var i = 0; i < properties.Count; i++)
            {
                properties[i].SetValue(dbFlags, dbFlags.Values[i]);
            }
            return dbFlags;
        }

        public void Write(LcfWriter writer)
        {

        }

        private static List<PropertyInfo> CollectProperties(Type flagsType)
        {
            if (TypeProperties.ContainsKey(flagsType))
                return TypeProperties[flagsType];

            var properties = flagsType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.PropertyType == typeof(bool))
                .ToList();

            if (properties == null || properties.Count == 0)
                return null;

            TypeProperties.Add(flagsType, properties);

            return properties;
        }
    }
}
