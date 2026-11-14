/// <copyright>
/// 
/// LcfSharp Copyright (c) 2024 optimus-code
/// (A "loose" .NET port of liblcf)
/// Licensed under the MIT License.
/// 
/// Copyright (c) 2014-2023 liblcf authors
/// Licensed under the MIT License.
/// 
/// Permission is hereby granted, free of charge, to any person obtaining
/// a copy of this software and associated documentation files (the
/// "Software"), to deal in the Software without restriction, including
/// without limitation the rights to use, copy, modify, merge, publish,
/// distribute, sublicense, and/or sell copies of the Software, and to
/// permit persons to whom the Software is furnished to do so, subject to
/// the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included
/// in all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
/// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
/// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
/// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
/// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
/// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
/// </copyright>

using LcfSharp.IO.Attributes;
using LcfSharp.IO.Types.Generic;
using System;
using System.Linq;

namespace LcfSharp.Rpg.Shared
{
    /// <summary>
    /// Class representing a collection of parameters for a character.
    /// </summary>
    [LcfListCollection]
    public class Parameters : IEquatable<Parameters>
    {
        /// <summary>
        /// List of maximum HP (Health Points) values.
        /// </summary>
        public LcfPackedList<short> MaxHP
        {
            get;
            set;
        } = [];

        /// <summary>
        /// List of maximum SP (Spirit Points) values.
        /// </summary>
        public LcfPackedList<short> MaxSP
        {
            get;
            set;
        } = [];

        /// <summary>
        /// List of attack values.
        /// </summary>
        public LcfPackedList<short> Attack
        {
            get;
            set;
        } = [];

        /// <summary>
        /// List of defense values.
        /// </summary>
        public LcfPackedList<short> Defense
        {
            get;
            set;
        } = [];

        /// <summary>
        /// List of spirit values.
        /// </summary>
        public LcfPackedList<short> Spirit
        {
            get;
            set;
        } = [];

        /// <summary>
        /// List of agility values.
        /// </summary>
        public LcfPackedList<short> Agility
        {
            get;
            set;
        } = [];

        /// <summary>
        /// Compares the parameter values with another collection.
        /// </summary>
        /// <param name="other">The collection to compare.</param>
        /// <returns>Whether all parameter values are equal.</returns>
        public bool Equals( Parameters other )
        {
            if ( ReferenceEquals( this, other ) )
                return true;

            if ( other is null || GetType( ) != other.GetType( ) )
                return false;

            return ListsEqual( MaxHP, other.MaxHP ) &&
                   ListsEqual( MaxSP, other.MaxSP ) &&
                   ListsEqual( Attack, other.Attack ) &&
                   ListsEqual( Defense, other.Defense ) &&
                   ListsEqual( Spirit, other.Spirit ) &&
                   ListsEqual( Agility, other.Agility );
        }

        /// <summary>
        /// Compares the parameter values with another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Whether the parameter values are equal.</returns>
        public override bool Equals( object obj ) => Equals( obj as Parameters );

        /// <summary>
        /// Gets a hash code based on the parameter values.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode( )
        {
            var hash = new HashCode( );
            hash.Add( GetType( ) );
            AddListHash( ref hash, MaxHP );
            AddListHash( ref hash, MaxSP );
            AddListHash( ref hash, Attack );
            AddListHash( ref hash, Defense );
            AddListHash( ref hash, Spirit );
            AddListHash( ref hash, Agility );
            return hash.ToHashCode( );
        }

        /// <summary>
        /// Compares two parameter lists by value.
        /// </summary>
        /// <param name="left">The first list.</param>
        /// <param name="right">The second list.</param>
        /// <returns>Whether the lists contain the same values.</returns>
        private static bool ListsEqual( LcfPackedList<short> left, LcfPackedList<short> right )
        {
            return ReferenceEquals( left, right ) ||
                ( left != null && right != null && left.SequenceEqual( right ) );
        }

        /// <summary>
        /// Adds a list's values to the hash code.
        /// </summary>
        /// <param name="hash">The hash code accumulator.</param>
        /// <param name="list">The list to hash.</param>
        private static void AddListHash( ref HashCode hash, LcfPackedList<short> list )
        {
            if ( list == null )
            {
                hash.Add( -1 );
                return;
            }

            hash.Add( list.Count );

            foreach ( var item in list )
                hash.Add( item );
        }

    }
}