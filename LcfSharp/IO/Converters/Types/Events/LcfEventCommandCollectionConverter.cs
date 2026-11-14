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

using LcfSharp.IO.Scopes;
using LcfSharp.Rpg.Events;

namespace LcfSharp.IO.Converters.Types.Events
{
    /// <summary>
    /// Converts Event Command collections.
    /// </summary>
    public class LcfEventCommandCollectionConverter : LcfConverter<EventCommandCollection>
    {
        private static LcfConverter _elementConverter;
        private static readonly byte[] _terminator = [0x0, 0x0, 0x0, 0x0];

        /// <summary>
        /// Reads an EventCommand collection.
        /// </summary>
        /// <param name="scope">The read scope.</param>
        /// <returns>The collection value.</returns>
        public override object Read( ref LcfReadScope scope )
        {
            if ( _elementConverter == null )
                _elementConverter = LcfConverterFactory.GetConverter( typeof( EventCommand ) );

            var list = new EventCommandCollection();

            while ( !scope.IsFinished )
            {
                // If we encounter a zero-byte we've reached the event command terminator
                if ( scope.PeekByte( ) == 0 )
                    break;

                list.Add( ( EventCommand ) _elementConverter.Read( ref scope ) );
            }

            return list;
        }

        /// <summary>
        /// Writes an EventCommand collection.
        /// </summary>
        /// <param name="scope">The write scope.</param>
        /// <param name="value">The collection to write.</param>
        public override void Write( ref LcfWriteScope scope, object value )
        {
            if ( _elementConverter == null )
                _elementConverter = LcfConverterFactory.GetConverter( typeof( EventCommand ) );

            var list = ( EventCommandCollection ) value;

            for ( var i = 0; i < list.Count; i++ )
            {
                _elementConverter.Write( ref scope, list[i] );
            }

            // EventCommand collections are terminated by four zero-bytes.
            scope.WriteBytes( _terminator );
        }
    }
}