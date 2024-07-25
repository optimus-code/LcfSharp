using LcfSharp.IO.Attributes;
using LcfSharp.IO.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfListCollectionConverter : LcfConverter
    {
        public sealed override Type Type
        {
            get;
            protected set;
        }

        public override bool CanConvert(Type typeToConvert) => typeToConvert == Type;

        public LcfListCollectionConverter(Type classType)
        {
            Type = classType;
        }

        public override object Read(BinaryReader reader, int? length)
        {
            if (!length.HasValue || length.Value == 0)
                throw new LcfException("No length specified for LcfListCollection converter!.");

            var properties = LcfConverterFactory.GetProperties(Type)
                .Where(p => p.GetCustomAttribute<LcfIgnoreAttribute>() == null &&
                p.PropertyType.IsGenericType &&
                p.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                .ToArray();

            var listCount = properties.Length;

            if (listCount == 0)
                throw new LcfException("No list properties found in type marked as an LcfListCollection");

            var elementType = properties.First().PropertyType.GetGenericArguments()[0];
            var listConverterType = typeof(LcfListConverter<>).MakeGenericType(elementType);
            var converter = (LcfConverter)Activator.CreateInstance(listConverterType);

            // The lists in the class all are the same size, divided by the amount of individual lists
            var listItemCount = length.Value / Marshal.SizeOf(elementType) / listCount;

            if (listItemCount <= 0)
                throw new LcfException("Invalid list item count in LcfListCollection.");

            var obj = Activator.CreateInstance(Type);
            foreach (var property in properties )
            {
                

                var list = (IList)converter.Read(reader, listItemCount);
                property.SetValue(obj, list);
            }
            return obj;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            throw new NotImplementedException();
        }
    }
}