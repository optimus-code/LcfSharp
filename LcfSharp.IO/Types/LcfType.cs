using LcfSharp.IO.Attributes;
using LcfSharp.IO.Exceptions;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace LcfSharp.IO.Types
{
    internal class LcfType
    {
        static Dictionary<Type, LcfType> _typeCache = [];

        public List<LcfProperty> Properties
        {
            get;
            private set;
        }

        public Type ChunkEnumType
        {
            get;
            private set;
        }

        public LcfProperty IDProperty
        {
            get;
            set;
        }

        public Dictionary<int, LcfProperty> Chunks
        {
            get;
            private set;
        } = [];

        public Dictionary<int, LcfProperty> SizeChunks
        {
            get;
            private set;
        } = [];

        public LcfType(Type type)
        {
            Properties = LcfProperty.Get(type);

            var chunkAttribute = type.GetCustomAttribute<LcfChunkAttribute>();

            if (chunkAttribute == null)
                throw new LcfException($"Missing LcfChunk attribute on '{type.FullName}.");

            ChunkEnumType = chunkAttribute.ChunkEnumType;
            IDProperty = GetIDProperty();
            MapChunks();
        }

        private void MapChunks()
        {
            foreach (var property in Properties)
            {
                if (Enum.TryParse(ChunkEnumType, property.Property.Name, out var enumValue)
                    && property.IsAllowed)
                {
                    Chunks[(int)enumValue] = property;

                    if (property.Size != null)
                        SizeChunks.Add(property.Size.ChunkID, property);
                }
            }
        }

        private LcfProperty GetIDProperty()
        {
            foreach (var property in Properties)
            {
                if (property.ID != null)
                {
                    return property;
                }
            }
            return null;
        }

        public static LcfType Get(Type type)
        {
            if (!_typeCache.TryGetValue(type, out var lcfType))
            {
                lcfType = new LcfType(type);
                _typeCache[type] = lcfType;
            }
            return lcfType;
        }

        public LcfProperty GetPropertyByChunkID(int chunkID)
        {
            Chunks.TryGetValue(chunkID, out var property);
            return property;
        }
    }
}