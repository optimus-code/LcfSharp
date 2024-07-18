using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LcfSharp
{
    /// <summary>
    /// Provides methods for writing data to an output stream in a format similar to the Lcf file format.
    /// </summary>
    public class LcfWriter : IDisposable
    {
        private readonly BinaryWriter _writer;
        private long _offset;

        /// <summary>
        /// Initializes a new instance of the <see cref="LcfWriter"/> class with the specified output stream.
        /// </summary>
        /// <param name="stream">The output stream to write data to.</param>
        public LcfWriter( Stream stream )
        {
            _writer = new BinaryWriter( stream );
            _offset = 0;
        }

        public void Write( byte[] buffer, int offset, int count )
        {
            _writer.Write( buffer, offset, count );
            _offset += count;
        }

        public long Tell( ) => _offset;

        public void Dispose( )
        {
            _writer.Dispose( );
        }

        /// <summary>
        /// Writes an integer to the output stream using a variable-length encoding.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        public void Write( int value )
        {
            int temp = value;
            while ( temp > 0x7F )
            {
                byte b = ( byte ) ( temp & 0x7F | 0x80 );
                _writer.Write( b );
                temp >>= 7;
            }
            _writer.Write( ( byte ) temp );
            _offset += sizeof( int );
        }

        /// <summary>
        /// Writes an unsigned 64-bit integer to the output stream using a variable-length encoding.
        /// </summary>
        /// <param name="value">The unsigned 64-bit integer value to write.</param>
        public void Write( ulong value )
        {
            ulong temp = value;
            while ( temp > 0x7F )
            {
                byte b = ( byte ) ( temp & 0x7F | 0x80 );
                _writer.Write( b );
                temp >>= 7;
            }
            _writer.Write( ( byte ) temp );
            _offset += sizeof( ulong );
        }

        /// <summary>
        /// Writes a boolean value to the output stream.
        /// </summary>
        /// <param name="value">The boolean value to write.</param>
        public void Write( bool value ) => Write( value ? 1 : 0 );

        /// <summary>
        /// Writes a signed byte to the output stream.
        /// </summary>
        /// <param name="value">The signed byte value to write.</param>
        public void Write( sbyte value ) => _writer.Write( ( byte ) value );

        /// <summary>
        /// Writes a byte to the output stream.
        /// </summary>
        /// <param name="value">The byte value to write.</param>
        public void Write( byte value ) => _writer.Write( value );

        /// <summary>
        /// Writes a 16-bit signed integer to the output stream.
        /// </summary>
        /// <param name="value">The 16-bit signed integer value to write.</param>
        public void Write( short value )
        {
            byte[] buffer = BitConverter.GetBytes( value );
            Array.Reverse( buffer );
            Write( buffer, 0, sizeof( short ) );
        }

        /// <summary>
        /// Writes a 32-bit unsigned integer to the output stream.
        /// </summary>
        /// <param name="value">The 32-bit unsigned integer value to write.</param>
        public void Write( uint value )
        {
            byte[] buffer = BitConverter.GetBytes( value );
            Array.Reverse( buffer );
            Write( buffer, 0, sizeof( uint ) );
        }

        /// <summary>
        /// Writes a 16-bit unsigned integer to the output stream.
        /// </summary>
        /// <param name="value">The 16-bit unsigned integer value to write.</param>
        public void Write( ushort value )
        {
            byte[] buffer = BitConverter.GetBytes( value );
            Array.Reverse( buffer, 0, sizeof( ushort ) );
            Write( buffer, 0, sizeof( ushort ) );
        }

        /// <summary>
        /// Writes a double-precision floating-point number to the output stream.
        /// </summary>
        /// <param name="value">The double-precision floating-point value to write.</param>
        public void Write( double value )
        {
            byte[] buffer = BitConverter.GetBytes( value );
            Array.Reverse( buffer );
            Write( buffer, 0, sizeof( double ) );
        }

        /// <summary>
        /// Writes a list of boolean values to the output stream.
        /// </summary>
        /// <param name="list">The list of boolean values to write.</param>
        public void Write( List<bool> list )
        {
            foreach ( bool value in list )
            {
                Write( value );
            }
        }

        /// <summary>
        /// Writes a list of bytes to the output stream.
        /// </summary>
        /// <param name="list">The list of bytes to write.</param>
        public void Write( List<byte> list )
        {
            foreach ( byte value in list )
            {
                Write( value );
            }
        }

        /// <summary>
        /// Writes a list of 16-bit signed integers to the output stream.
        /// </summary>
        /// <param name="list">The list of 16-bit signed integers to write.</param>
        public void Write( List<short> list )
        {
            foreach ( short value in list )
            {
                Write( value );
            }
        }

        /// <summary>
        /// Writes a list of 32-bit integers to the output stream.
        /// </summary>
        /// <param name="list">The list of 32-bit integers to write.</param>
        public void Write( List<int> list )
        {
            foreach ( int value in list )
            {
                Write( value );
            }
        }

        /// <summary>
        /// Writes a list of boolean values represented as bits to the output stream.
        /// </summary>
        /// <param name="buffer">The list of boolean values represented as bits to write.</param>
        public void Write( DbBitArray buffer )
        {
            foreach ( bool value in buffer )
            {
                Write( value );
            }
        }

        /// <summary>
        /// Writes a string to the output stream using ASCII encoding.
        /// </summary>
        /// <param name="str">The string to write.</param>
        public void Write( string str )
        {
            byte[] buffer = Encoding.ASCII.GetBytes( str );
            Write( buffer, 0, buffer.Length );
        }

        /// <summary>
        /// Writes a <see cref="DbString"/> to the output stream.
        /// </summary>
        /// <param name="dbString">The <see cref="DbString"/> to write.</param>
        public void Write( DbString dbString )
        {
            Write( dbString.Length );
            Write( dbString.Value );
        }

        /// <summary>
        /// Seeks the position within the output stream according to the specified <see cref="SeekMode"/>.
        /// </summary>
        /// <param name="pos">The new position within the output stream.</param>
        /// <param name="mode">The seek mode, which determines how the position is interpreted.</param>
        public void Seek( long pos, SeekMode mode )
        {
            switch ( mode )
            {
                case SeekMode.FromStart:
                    _writer.BaseStream.Seek( pos, SeekOrigin.Begin );
                    _offset = pos;
                    break;
                case SeekMode.FromCurrent:
                    _writer.BaseStream.Seek( pos, SeekOrigin.Current );
                    _offset += pos;
                    break;
                case SeekMode.FromEnd:
                    _writer.BaseStream.Seek( pos, SeekOrigin.End );
                    _offset = _writer.BaseStream.Length - pos;
                    break;
                default:
                    throw new ArgumentException( "Invalid SeekMode." );
            }
        }

        /// <summary>
        /// Sets an error message for reporting purposes.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to format.</param>
        public void SetError( string format, params object[] args )
        {
            string str = string.Format( format, args );
            Console.WriteLine( str );
        }
    }
}
