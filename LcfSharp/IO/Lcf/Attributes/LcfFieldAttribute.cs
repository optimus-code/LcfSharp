using System;

namespace LcfSharp.IO.Lcf.Attributes
{
    public abstract class LcfFieldAttributeBase : Attribute
    {
        public abstract Type ChunkEnumType { get; protected set; }
        public abstract int ChunkID { get; protected set; }
        public abstract int? SizeChunkID { get; protected set; }
        public abstract bool IsRM2K3 { get; protected set; }
        public abstract bool NoDefaultWrite { get; protected set; }
    }

    /// <summary>
    /// Attribute to mark properties with LcfField metadata.
    /// </summary>
    /// <typeparam name="TChunkEnum">Type of the chunk ID enum.</typeparam>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class LcfFieldAttribute<TChunkEnum> : LcfFieldAttributeBase
        where TChunkEnum : Enum
    {
        /// <summary>
        /// Gets the chunk enum type.
        /// </summary>
        public override Type ChunkEnumType
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the chunk ID.
        /// </summary>
        public override int ChunkID
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the size chunk ID.
        /// </summary>
        public override int? SizeChunkID
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets a value indicating whether the property is for RM2K3.
        /// </summary>
        public override bool IsRM2K3
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets a value indicating whether the property should not be written by default.
        /// </summary>
        public override bool NoDefaultWrite
        {
            get;
            protected set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LcfFieldAttribute{TChunkEnum}"/> class.
        /// </summary>
        /// <param name="chunkID">The chunk ID.</param>
        /// <param name="isRM2K3">Whether the property is for RM2K3.</param>
        /// <param name="noDefaultWrite">Whether the property should not be written when it is default value.</param>
        public LcfFieldAttribute(TChunkEnum chunkID,
            bool isRM2K3 = false, bool noDefaultWrite = false)
        {
            ChunkEnumType = typeof(TChunkEnum);
            ChunkID = (int)Convert.ChangeType(chunkID, typeof(int));
            SizeChunkID = null;
            IsRM2K3 = isRM2K3;
            NoDefaultWrite = noDefaultWrite;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LcfFieldAttribute{TChunkEnum}"/> class.
        /// </summary>
        /// <param name="chunkID">The chunk ID.</param>
        /// <param name="sizeChunkID">The size chunk ID this is dependant on for a value.</param>
        /// <param name="isRM2K3">Whether the property is for RM2K3.</param>
        /// <param name="noDefaultWrite">Whether the property should not be written when it is default value.</param>
        public LcfFieldAttribute(TChunkEnum chunkID, TChunkEnum sizeChunkID,
            bool isRM2K3 = false, bool noDefaultWrite = false)
        {
            ChunkEnumType = typeof(TChunkEnum);
            ChunkID = (int)Convert.ChangeType(chunkID, typeof(int));
            SizeChunkID = (int)Convert.ChangeType(chunkID, typeof(int));
            IsRM2K3 = isRM2K3;
            NoDefaultWrite = noDefaultWrite;
        }
    }
}