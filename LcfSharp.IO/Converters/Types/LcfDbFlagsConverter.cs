using LcfSharp.IO.Types;
using LcfSharp.IO.Exceptions;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace LcfSharp.IO.Converters.Types
{
    public class LcfDbFlagsConverter : LcfConverter
    {
        public sealed override Type Type
        {
            get;
            protected set;
        }
        
        private List<PropertyInfo> Properties
        {
            get;
            set;
        }

        public override bool CanConvert(Type typeToConvert) => typeToConvert == Type;

        public LcfDbFlagsConverter(Type type)
        {
            Type = type;

            if (!Type.IsAssignableTo(typeof(IDbFlags)))
                throw new LcfException("Invalid DbFlags type, does not inherit from IDbFlags.");

            Properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.PropertyType == typeof(bool))
                .ToList();

            if (Properties == null || Properties.Count == 0)
                throw new LcfException("DbFlags type has no Boolen properties.");
        }

        public override object Read(BinaryReader reader, int? length)
        {
            var instance = Activator.CreateInstance(Type);
            var size = length.HasValue ? length.Value : Properties.Count;
            var byteCount = (size + 7) / 8;
            var flagIndex = 0;

            for (var byteIndex = 0; byteIndex < byteCount; byteIndex++)
            {
                var byteValue = reader.ReadByte();

                for (var bitIndex = 0; bitIndex < 8 && flagIndex < size; bitIndex++)
                {
                    var flagValue = (byteValue & (1 << bitIndex)) != 0;
                    Properties[flagIndex].SetValue(instance, flagValue);
                    flagIndex++;
                }
            }

            return instance;
        }

        public override void Write(BinaryWriter writer, object value)
        {
        }
    }
}