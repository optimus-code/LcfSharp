using LcfSharp.Rpg.Events;
using System.Collections.Generic;
using System;
using System.IO;
using LcfSharp.IO.Extensions;

namespace LcfSharp.IO.Converters
{
    public class LcfEventCommandConverter : LcfConverter<EventCommand>
    {
        public override object Read(BinaryReader reader, int? length)
        {
            var instance = new EventCommand();
            instance.Code = (EventCommandCode)reader.ReadVarInt();

            if (instance.Code != EventCommandCode.None)
            {
                instance.Indent = reader.ReadVarInt();
                instance.String = reader.ReadString(reader.ReadVarInt());

                var parametersCount = reader.ReadVarInt();
                instance.Parameters = new List<int>(parametersCount);

                for (var i = 0; i < parametersCount; i++)
                {
                    instance.Parameters.Add(reader.ReadVarInt());
                }
            }

            return instance;
        }

        public override void Write(BinaryWriter writer, object value)
        {
            throw new NotImplementedException();
        }
    }
}