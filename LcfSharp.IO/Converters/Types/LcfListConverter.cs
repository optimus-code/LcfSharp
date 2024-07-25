using LcfSharp.IO.Attributes;
using LcfSharp.IO.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfListConverter<T> : LcfConverter<List<T>>
    {
        private readonly LcfConverter _elementConverter;
        private readonly bool _hasIDAttribute;
        private readonly bool _noIndex;

        public LcfListConverter()
        {
            _elementConverter = LcfConverterFactory.GetConverter(typeof(T));
            _hasIDAttribute = LcfConverterFactory.GetProperties(_elementConverter.Type)
                .Count(p => p.GetCustomAttribute<LcfIDAttribute>() != null) > 0;
            _noIndex = typeof(T).GetCustomAttribute<LcfNoIndexAttribute>() != null;
        }

        public override object Read(BinaryReader reader, int? length)
        {
            // When there's no index we have to just keep reading until we've hit length
            if (_noIndex && length.HasValue)
            {
                var startPosition = reader.BaseStream.Position;

                var list = new List<T>();
                while (reader.BaseStream.Position < (startPosition + length.Value))
                {
                    list.Add((T)_elementConverter.Read(reader, null));
                }
                return list;
            }
            else
            {
                var count = !_hasIDAttribute && length.HasValue ? length.Value : reader.ReadVarInt();
                var list = new List<T>(count);
                for (var i = 0; i < count; i++)
                {
                    list.Add((T)_elementConverter.Read(reader, null));
                }
                return list;
            }
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