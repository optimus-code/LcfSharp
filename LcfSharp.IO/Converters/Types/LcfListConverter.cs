using System;
using System.Collections.Generic;
using System.IO;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfListConverter<T> : LcfConverter<List<T>>
    {
        private readonly LcfConverter _elementConverter;

        public LcfListConverter()
        {
            _elementConverter = LcfConverterFactory.GetConverter(typeof(T));
        }

        public override object Read(BinaryReader reader, int? length)
        {
            var count = length.HasValue ? length.Value : reader.Read7BitEncodedInt();
            var list = new List<object>(count);
            for (var i = 0; i < count; i++)
            {
                list.Add(_elementConverter.Read(reader, null));
            }
            return list;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            var list = (List<object>)value;
            writer.Write7BitEncodedInt(list.Count);
            foreach (var item in list)
            {
                _elementConverter.Write(writer, item);
            }
        }
    }
}