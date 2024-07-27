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
using LcfSharp.IO.Converters;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace LcfSharp.IO.Types
{
    /// <summary>
    /// Represents a property in an LCF (RPG Maker 2000 format) type, including metadata and attributes.
    /// </summary>
    internal class LcfProperty
    {
        /// <summary>
        /// Cache for storing properties of different types.
        /// </summary>
        static Dictionary<Type, List<LcfProperty>> _propertyCache = [];

        /// <summary>
        /// Gets the <see cref="PropertyInfo"/> associated with this LcfProperty.
        /// </summary>
        public PropertyInfo Property
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="LcfIDAttribute"/> of the property, if any.
        /// </summary>
        public LcfIDAttribute ID
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="LcfAlwaysPersistAttribute"/> of the property, if any.
        /// </summary>
        public LcfAlwaysPersistAttribute AlwaysPersist
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="LcfSizeAttribute"/> of the property, if any.
        /// </summary>
        public LcfSizeAttribute Size
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="LcfVersionAttribute"/> of the property, if any.
        /// </summary>
        public LcfVersionAttribute Version
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the property is allowed based on the version attribute and engine version.
        /// </summary>
        public bool IsAllowed
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the property is a generic list type.
        /// </summary>
        public bool IsGenericListType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the inner type of the generic list if the property is a generic list type.
        /// </summary>
        public Type GenericListInnerType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the inner type of the generic list is a basic type (primitive or not a class).
        /// </summary>
        public bool IsGenericListBasicType
        {
            get;
            private set;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="LcfProperty"/> class for the specified property.
        /// </summary>
        /// <param name="property">The property to create an <see cref="LcfProperty"/> for.</param>
        public LcfProperty( PropertyInfo property )
        {
            Property = property;
            ID = property.GetCustomAttribute<LcfIDAttribute>( );
            AlwaysPersist = property.GetCustomAttribute<LcfAlwaysPersistAttribute>( );
            Size = property.GetCustomAttribute<LcfSizeAttribute>( );
            Version = property.GetCustomAttribute<LcfVersionAttribute>( );
            IsAllowed = CheckIsAllowed( );

            IsGenericListType = property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition( ) == typeof( List<> );

            if ( IsGenericListType )
            {
                GenericListInnerType = property.PropertyType.GetGenericArguments( )[0];
                IsGenericListBasicType = !GenericListInnerType.IsClass && GenericListInnerType.IsPrimitive;
            }
        }

        /// <summary>
        /// Checks whether the property is allowed based on the version attribute and engine version.
        /// </summary>
        /// <returns><c>true</c> if the property is allowed; otherwise, <c>false</c>.</returns>
        private bool CheckIsAllowed( )
        {
            return Property != null && Version?.Version == LcfConverterFactory.EngineVersion
                || Version == null && LcfConverterFactory.EngineVersion == LcfEngineVersion.RM2K;
        }

        /// <summary>
        /// Gets a list of <see cref="LcfProperty"/> objects for the specified type.
        /// </summary>
        /// <param name="type">The type to get properties for.</param>
        /// <returns>A list of <see cref="LcfProperty"/> objects for the specified type.</returns>
        public static List<LcfProperty> Get( Type type )
        {
            if ( !_propertyCache.TryGetValue( type, out var properties ) )
            {
                properties = [];
                foreach ( var p in LcfConverterFactory.GetProperties( type ) )
                {
                    if ( p.GetCustomAttribute<LcfIgnoreAttribute>( ) == null )
                    {
                        properties.Add( new LcfProperty( p ) );
                    }
                }
                _propertyCache[type] = properties;
            }
            return properties;
        }
    }
}