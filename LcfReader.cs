using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LcfSharp
{
    /// <summary>
    /// Provides methods for reading data from a stream in Little Chunk Format (LCF).
    /// </summary>
    public class LcfReader : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether the underlying stream can be read.
        /// </summary>
        public bool IsOK => _reader.BaseStream.CanRead;

        /// <summary>
        /// Gets a value indicating whether the end of the stream has been reached.
        /// </summary>
        public bool IsEOF => _offset >= _reader.BaseStream.Length;

        /// <summary>
        /// Gets the current position within the stream.
        /// </summary>
        /// <returns>The current position within the stream.</returns>
        public long Tell( ) => _offset;

        /// <summary>
        /// Peeks at the next available character in the underlying stream.
        /// </summary>
        /// <returns>The next available character, or -1 if the end of the stream is reached.</returns>
        public int Peek( ) => _reader.PeekChar( );

        private readonly BinaryReader _reader;
        private long _offset;

        /// <summary>
        /// Initializes a new instance of the <see cref="LcfReader"/> class with a given stream.
        /// </summary>
        /// <param name="stream">The stream to read data from.</param>
        public LcfReader( Stream stream )
        {
            _reader = new BinaryReader( stream );
            _offset = 0;
        }

        /// <summary>
        /// Releases the resources used by the <see cref="LcfReader"/> object.
        /// </summary>
        public void Dispose( )
        {
            _reader.Dispose( );
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream into a buffer and advances the position.
        /// </summary>
        /// <param name="buffer">The buffer to read data into.</param>
        /// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin reading.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        public int Read( byte[] buffer, int offset, int count )
        {
            int bytesRead = _reader.Read( buffer, offset, count );
            _offset += bytesRead;

            if ( bytesRead < count )
            {
                throw new EndOfStreamException( "Reached the end of the stream." );
            }

            return bytesRead;
        }

        /// <summary>
        /// Reads a Boolean value from the stream.
        /// </summary>
        /// <returns>true if the value read is greater than 0; otherwise, false.</returns>
        public bool ReadBool( ) => ReadInt( ) > 0;

        /// <summary>
        /// Reads a signed byte from the stream.
        /// </summary>
        /// <returns>The signed byte read from the stream.</returns>
        public sbyte ReadSByte( ) => ( sbyte ) _reader.ReadByte( );

        /// <summary>
        /// Reads an unsigned byte from the stream.
        /// </summary>
        /// <returns>The unsigned byte read from the stream.</returns>
        public byte ReadByte( ) => _reader.ReadByte( );

        /// <summary>
        /// Reads a 16-bit signed integer from the stream.
        /// </summary>
        /// <returns>The 16-bit signed integer read from the stream.</returns>
        public short ReadShort( )
        {
            byte[] buffer = new byte[sizeof( short )];
            Read( buffer, 0, sizeof( short ) );
            Array.Reverse( buffer );
            return BitConverter.ToInt16( buffer, 0 );
        }

        /// <summary>
        /// Reads a 32-bit unsigned integer from the stream.
        /// </summary>
        /// <returns>The 32-bit unsigned integer read from the stream.</returns>
        public uint ReadUInt( )
        {
            byte[] buffer = new byte[sizeof( uint )];
            Read( buffer, 0, sizeof( uint ) );
            Array.Reverse( buffer );
            return BitConverter.ToUInt32( buffer, 0 );
        }

        /// <summary>
        /// Reads a compressed signed integer from the stream.
        /// </summary>
        /// <returns>The compressed signed integer read from the stream.</returns>
        public int ReadInt( )
        {
            int value = 0;
            int shift = 0;

            while ( true )
            {
                byte b = ReadByte( );

                value |= ( b & 0x7F ) << shift;
                shift += 7;

                if ( ( b & 0x80 ) == 0 )
                {
                    break;
                }

                if ( shift > 28 )
                {
                    throw new InvalidDataException( "Invalid compressed integer." );
                }
            }

            return value;
        }

        /// <summary>
        /// Reads a 16-bit unsigned integer from the underlying stream.
        /// </summary>
        /// <returns>The 16-bit unsigned integer read from the stream.</returns>
        public ushort ReadUInt16( )
        {
            byte[] buffer = new byte[sizeof( ushort )];
            Read( buffer, 0, sizeof( ushort ) );
            Array.Reverse( buffer ); // Ensure little-endian to big-endian conversion
            return BitConverter.ToUInt16( buffer, 0 );
        }

        /// <summary>
        /// Reads a compressed unsigned long from the stream.
        /// </summary>
        /// <returns>The compressed unsigned long read from the stream.</returns>
        public ulong ReadUInt64( )
        {
            ulong value = 0;
            int shift = 0;

            while ( true )
            {
                byte b = ReadByte( );

                value |= ( ulong ) ( b & 0x7F ) << shift;
                shift += 7;

                if ( ( b & 0x80 ) == 0 )
                {
                    break;
                }

                if ( shift > 63 )
                {
                    throw new InvalidDataException( "Invalid compressed integer." );
                }
            }

            return value;
        }

        /// <summary>
        /// Reads a double-precision floating-point number from the stream.
        /// </summary>
        /// <returns>The double-precision floating-point number read from the stream.</returns>
        public double ReadDouble( )
        {
            byte[] buffer = new byte[sizeof( double )];
            Read( buffer, 0, sizeof( double ) );
            Array.Reverse( buffer );
            return BitConverter.ToDouble( buffer, 0 );
        }

        /// <summary>
        /// Reads a list of Boolean values from the stream.
        /// </summary>
        /// <param name="size">The number of Boolean values to read.</param>
        /// <returns>A list of Boolean values.</returns>
        public List<bool> ReadBoolList( int size )
        {
            List<bool> buffer = new List<bool>( );

            for ( int i = 0; i < size; i++ )
            {
                byte val = ReadByte( );
                buffer.Add( val > 0 );
            }

            return buffer;
        }

        /// <summary>
        /// Reads a list of bytes from the stream.
        /// </summary>
        /// <param name="size">The number of bytes to read.</param>
        /// <returns>A list of bytes.</returns>
        public List<byte> ReadByteList( int size )
        {
            List<byte> buffer = new List<byte>( );

            for ( int i = 0; i < size; i++ )
            {
                byte val = ReadByte( );
                buffer.Add( val );
            }

            return buffer;
        }

        /// <summary>
        /// Reads a string from the stream using ASCII encoding.
        /// </summary>
        /// <param name="size">The number of bytes to read for the string.</param>
        /// <returns>The string read from the stream.</returns>
        public string ReadString( int size )
        {
            byte[] buffer = new byte[size];
            Read( buffer, 0, size );
            string str = Encoding.ASCII.GetString( buffer, 0, size );
            return str;
        }

        /// <summary>
        /// Reads a DbString from the stream.
        /// </summary>
        /// <param name="size">The number of bytes to read for the DBString.</param>
        /// <returns>The DbString read from the stream.</returns>
        public DbString ReadDbString( int size )
        {
            string tmp = ReadString( size );
            return new DbString( tmp );
        }

        /// <summary>
        /// Seeks the position within the stream based on the specified mode.
        /// </summary>
        /// <param name="pos">The position to seek to.</param>
        /// <param name="mode">The seek mode.</param>
        public void Seek( long pos, SeekMode mode )
        {
            switch ( mode )
            {
                case SeekMode.FromStart:
                    _reader.BaseStream.Seek( pos, SeekOrigin.Begin );
                    _offset = pos;
                    break;
                case SeekMode.FromCurrent:
                    _reader.BaseStream.Seek( pos, SeekOrigin.Current );
                    _offset += pos;
                    break;
                case SeekMode.FromEnd:
                    _reader.BaseStream.Seek( pos, SeekOrigin.End );
                    _offset = _reader.BaseStream.Length - pos;
                    break;
                default:
                    throw new ArgumentException( "Invalid SeekMode." );
            }
        }

        /// <summary>
        /// Skips reading the specified chunk of data from the stream.
        /// </summary>
        /// <param name="chunkInfo">Information about the chunk to skip.</param>
        /// <param name="where">A description of where the skip operation occurred.</param>
        public void Skip( Chunk chunkInfo, string where )
        {
            Console.WriteLine( $"Skipped Chunk {chunkInfo.ID:X2} ({chunkInfo.Length} byte) in lcf at {Tell( ):X8} ({where})" );

            for ( uint i = 0; i < chunkInfo.Length; i++ )
            {
                byte byteVal = ReadByte( );
                Console.Write( $"{byteVal:X2} " );
                if ( ( i + 1 ) % 16 == 0 )
                {
                    Console.WriteLine( );
                }
            }

            Console.WriteLine( );
        }

        /// <summary>
        /// Sets an error message for debugging purposes.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to format.</param>
        public void SetError( string format, params object[] args )
        {
            string str = string.Format( format, args );
            Console.WriteLine( str );
        }
    }

    /// <summary>
    /// Specifies the seek mode when seeking within a <see cref="LcfReader"/> stream.
    /// </summary>
    public enum SeekMode
    {
        /// <summary>
        /// Seek from the start of the stream.
        /// </summary>
        FromStart,

        /// <summary>
        /// Seek from the current position in the stream.
        /// </summary>
        FromCurrent,

        /// <summary>
        /// Seek from the end of the stream.
        /// </summary>
        FromEnd
    }

    /// <summary>
    /// Represents a chunk of data with an ID and length.
    /// </summary>
    public struct Chunk
    {
        /// <summary>
        /// Gets or sets the ID of the chunk.
        /// </summary>
        public byte ID { get; set; }

        /// <summary>
        /// Gets or sets the length of the chunk in bytes.
        /// </summary>
        public uint Length { get; set; }
    }
}