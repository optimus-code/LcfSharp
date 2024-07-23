using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LcfSharp.Types
{
    public class DbBitArray : IEnumerable<bool>
    {
        private byte[] _storage;

        public DbBitArray( )
        {
        }

        public DbBitArray( int count, bool value = false )
        {
            _storage = new byte[BytesUpFromBits( count )];
            if ( value )
            {
                for ( int i = 0; i < _storage.Length; i++ )
                {
                    _storage[i] = 0xFF;
                }
            }
        }

        public DbBitArray( IEnumerable<bool> values )
        {
            int count = values.Count( );
            _storage = new byte[BytesUpFromBits( count )];
            int i = 0;
            foreach ( var value in values )
            {
                this[i++] = value;
            }
        }

        public DbBitArray( DbBitArray other )
        {
            _storage = new byte[other._storage.Length];
            Array.Copy( other._storage, _storage, _storage.Length );
        }

        public DbBitArray( DbBitArray other, bool copy )
        {
            if ( copy )
            {
                _storage = new byte[other._storage.Length];
                Array.Copy( other._storage, _storage, _storage.Length );
            }
            else
            {
                _storage = other._storage;
                other._storage = null;
            }
        }

        public bool this[int index]
        {
            get
            {
                int byteIndex = index / 8;
                int bitIndex = index % 8;
                return ( _storage[byteIndex] & ( 1 << bitIndex ) ) != 0;
            }
            set
            {
                int byteIndex = index / 8;
                int bitIndex = index % 8;
                if ( value )
                {
                    _storage[byteIndex] |= ( byte ) ( 1 << bitIndex );
                }
                else
                {
                    _storage[byteIndex] &= ( byte ) ~( 1 << bitIndex );
                }
            }
        }

        public bool Empty => Size == 0;

        public int Size => _storage.Length * 8;

        public void SetAll( )
        {
            for ( int i = 0; i < _storage.Length; i++ )
            {
                _storage[i] = 0xFF;
            }
        }

        public void ResetAll( )
        {
            Array.Clear( _storage, 0, _storage.Length );
        }

        public void FlipAll( )
        {
            for ( int i = 0; i < _storage.Length; i++ )
            {
                _storage[i] = ( byte ) ~_storage[i];
            }
        }

        public void Set( int index )
        {
            this[index] = true;
        }

        public void Reset( int index )
        {
            this[index] = false;
        }

        public void Flip( int index )
        {
            this[index] = !this[index];
        }

        private static int BytesUpFromBits( int bits )
        {
            return ( bits + 7 ) / 8;
        }

        public IEnumerator<bool> GetEnumerator( )
        {
            for ( int i = 0; i < Size; i++ )
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator( )
        {
            return GetEnumerator( );
        }

        public override bool Equals( object obj )
        {
            if ( obj is DbBitArray other )
            {
                return _storage.SequenceEqual( other._storage );
            }
            return false;
        }

        public override int GetHashCode( )
        {
            return HashCode.Combine( _storage );
        }

        public static bool operator ==( DbBitArray left, DbBitArray right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( DbBitArray left, DbBitArray right )
        {
            return !Equals( left, right );
        }

        public static bool operator <( DbBitArray left, DbBitArray right )
        {
            return left._storage.Zip( right._storage, ( l, r ) => l.CompareTo( r ) ).Any( c => c < 0 );
        }

        public static bool operator >( DbBitArray left, DbBitArray right )
        {
            return right < left;
        }

        public static bool operator <=( DbBitArray left, DbBitArray right )
        {
            return !( left > right );
        }

        public static bool operator >=( DbBitArray left, DbBitArray right )
        {
            return !( left < right );
        }
    }

}
