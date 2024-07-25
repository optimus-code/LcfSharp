using LcfSharp.IO.Attributes;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfClassConverter : LcfConverter
    {
        public sealed override Type Type
        {
            get;
            protected set;
        }

        public override bool CanConvert(Type typeToConvert) => typeToConvert == Type;

        public LcfClassConverter(Type classType)
        {
            Type = classType;
        }

        private bool IsAllowed(PropertyInfo property)
        {
            var versionAttribute = property.GetCustomAttribute<LcfVersionAttribute>();

            return (property != null && versionAttribute?.Version == LcfConverterFactory.EngineVersion)
                || (versionAttribute == null && LcfConverterFactory.EngineVersion == LcfEngineVersion.RM2K);

        }

        private void ProcessProperty(BinaryReader reader, object obj, PropertyInfo property)
        {
            var converter = LcfConverterFactory.GetConverter(property.PropertyType);
            if (converter is not null)
            {
                var value = converter.Read(reader, null);
                property.SetValue(obj, value);
            }
            else
            {
                throw new InvalidDataException($"No converter found for type {property.PropertyType}");
            }
        }

        public override object Read(BinaryReader reader, int? length)
        {
            var obj = Activator.CreateInstance(Type);
            var properties = LcfConverterFactory.GetProperties(Type)
                .Where(p => p.GetCustomAttribute<LcfIgnoreAttribute>() == null);
            
            foreach (var property in properties)
            {
                if (reader.BaseStream.Position >= reader.BaseStream.Length)
                    break;

                if (IsAllowed(property))
                    ProcessProperty(reader, obj, property);
            }

            return obj;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            writer.Write((byte)value);
        }
    }
}