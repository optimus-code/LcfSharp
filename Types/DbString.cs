using System.Text;

namespace LcfSharp.Types
{
    /// <summary>
    /// Represents a string with a 16-bit length field, typically used for reading and writing strings in legacy file formats.
    /// </summary>
    public class DbString
    {
        private ushort _length;
        private string _value;

        /// <summary>
        /// Gets or sets the length of the string.
        /// </summary>
        public ushort Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        /// <summary>
        /// Gets or sets the string value.
        /// </summary>
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbString"/> class with default values.
        /// </summary>
        public DbString( )
        {
            _length = 0;
            _value = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbString"/> class with the specified string value.
        /// </summary>
        /// <param name="value">The string value to set.</param>
        public DbString( string value )
        {
            _length = ( ushort ) value.Length;
            _value = value;
        }

        /// <summary>
        /// Reads the DbString from a <see cref="LcfReader"/>.
        /// </summary>
        /// <param name="reader">The LcfReader to read from.</param>
        public void Read( LcfReader reader )
        {
            _length = reader.ReadUInt16( );
            byte[] buffer = new byte[_length];
            reader.Read( buffer, 0, _length );
            _value = Encoding.UTF8.GetString( buffer );
        }

        /// <summary>
        /// Writes the DbString to a <see cref="LcfWriter"/>.
        /// </summary>
        /// <param name="writer">The LcfWriter to write to.</param>
        public void Write( LcfWriter writer )
        {
            writer.Write( _length );
            byte[] buffer = Encoding.UTF8.GetBytes( _value );
            writer.Write( buffer, 0, _length );
        }
    }
}
