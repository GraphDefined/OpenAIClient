/*
 * Copyright (c) 2023 GraphDefined GmbH <achim.friedland@graphdefined.com>
 * This file is part of OpenAI Client
 *
 * Licensed under the Affero GPL license, Version 3.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.gnu.org/licenses/agpl.html
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using org.GraphDefined.Vanaheimr.Illias;

#endregion

namespace com.GraphDefined.AI.OpenAI
{

    /// <summary>
    /// Extension methods for object types.
    /// </summary>
    public static class ObjectTypeExtensions
    {

        /// <summary>
        /// Indicates whether this object type is null or empty.
        /// </summary>
        /// <param name="ObjectType">A object type.</param>
        public static Boolean IsNullOrEmpty(this Object_Type? ObjectType)
            => !ObjectType.HasValue || ObjectType.Value.IsNullOrEmpty;

        /// <summary>
        /// Indicates whether this object type is NOT null or empty.
        /// </summary>
        /// <param name="ObjectType">A object type.</param>
        public static Boolean IsNotNullOrEmpty(this Object_Type? ObjectType)
            => ObjectType.HasValue && ObjectType.Value.IsNotNullOrEmpty;

    }


    /// <summary>
    /// The unique identification of an object type.
    /// </summary>
    public readonly struct Object_Type : IId<Object_Type>
    {

        #region Data

        /// <summary>
        /// The internal identification.
        /// </summary>
        private readonly String InternalId;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether this object type is null or empty.
        /// </summary>
        public Boolean IsNullOrEmpty
            => InternalId.IsNullOrEmpty();

        /// <summary>
        /// Indicates whether this object type is NOT null or empty.
        /// </summary>
        public Boolean IsNotNullOrEmpty
            => InternalId.IsNotNullOrEmpty();

        /// <summary>
        /// The length of the object type.
        /// </summary>
        public UInt64 Length
            => (UInt64) InternalId.Length;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a new object type based on the given text.
        /// </summary>
        /// <param name="Text">The text representation of an object type.</param>
        private Object_Type(String Text)
        {
            this.InternalId = Text;
        }

        #endregion


        #region (static) Parse   (Text)

        /// <summary>
        /// Parse the given text as an object type.
        /// </summary>
        /// <param name="Text">A text representation of an object type.</param>
        public static Object_Type Parse(String Text)
        {

            if (TryParse(Text, out var objectType))
                return objectType;

            throw new ArgumentException("Invalid text representation of an object type: '" + Text + "'!",
                                        nameof(Text));

        }

        #endregion

        #region (static) TryParse(Text)

        /// <summary>
        /// Try to parse the given text as an object type.
        /// </summary>
        /// <param name="Text">A text representation of an object type.</param>
        public static Object_Type? TryParse(String Text)
        {

            if (TryParse(Text, out var objectType))
                return objectType;

            return null;

        }

        #endregion

        #region (static) TryParse(Text, out ObjectType)

        /// <summary>
        /// Try to parse the given text as an object type.
        /// </summary>
        /// <param name="Text">A text representation of an object type.</param>
        /// <param name="ObjectType">The parsed object type.</param>
        public static Boolean TryParse(String Text, out Object_Type ObjectType)
        {

            Text = Text.Trim();

            if (Text.IsNotNullOrEmpty())
            {
                try
                {
                    ObjectType = new Object_Type(Text);
                    return true;
                }
                catch (Exception)
                { }
            }

            ObjectType = default;
            return false;

        }

        #endregion

        #region Clone

        /// <summary>
        /// Clone this object type.
        /// </summary>
        public Object_Type Clone

            => new (
                   new String(InternalId?.ToCharArray())
               );

        #endregion


        #region Operator overloading

        #region Operator == (ObjectType1, ObjectType2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ObjectType1">A object type.</param>
        /// <param name="ObjectType2">Another object type.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (Object_Type ObjectType1,
                                           Object_Type ObjectType2)

            => ObjectType1.Equals(ObjectType2);

        #endregion

        #region Operator != (ObjectType1, ObjectType2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ObjectType1">A object type.</param>
        /// <param name="ObjectType2">Another object type.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (Object_Type ObjectType1,
                                           Object_Type ObjectType2)

            => !ObjectType1.Equals(ObjectType2);

        #endregion

        #region Operator <  (ObjectType1, ObjectType2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ObjectType1">A object type.</param>
        /// <param name="ObjectType2">Another object type.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (Object_Type ObjectType1,
                                          Object_Type ObjectType2)

            => ObjectType1.CompareTo(ObjectType2) < 0;

        #endregion

        #region Operator <= (ObjectType1, ObjectType2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ObjectType1">A object type.</param>
        /// <param name="ObjectType2">Another object type.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (Object_Type ObjectType1,
                                           Object_Type ObjectType2)

            => ObjectType1.CompareTo(ObjectType2) <= 0;

        #endregion

        #region Operator >  (ObjectType1, ObjectType2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ObjectType1">A object type.</param>
        /// <param name="ObjectType2">Another object type.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (Object_Type ObjectType1,
                                          Object_Type ObjectType2)

            => ObjectType1.CompareTo(ObjectType2) > 0;

        #endregion

        #region Operator >= (ObjectType1, ObjectType2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ObjectType1">A object type.</param>
        /// <param name="ObjectType2">Another object type.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (Object_Type ObjectType1,
                                           Object_Type ObjectType2)

            => ObjectType1.CompareTo(ObjectType2) >= 0;

        #endregion

        #endregion

        #region IComparable<ObjectType> Members

        #region CompareTo(Object)

        /// <summary>
        /// Compares two object types.
        /// </summary>
        /// <param name="Object">A object type to compare with.</param>
        public Int32 CompareTo(Object? Object)

            => Object is Object_Type objectType
                   ? CompareTo(objectType)
                   : throw new ArgumentException("The given object is not an object type!",
                                                 nameof(Object));

        #endregion

        #region CompareTo(ObjectType)

        /// <summary>
        /// Compares two object types.
        /// </summary>
        /// <param name="ObjectType">A object type to compare with.</param>
        public Int32 CompareTo(Object_Type ObjectType)

            => String.Compare(InternalId,
                              ObjectType.InternalId,
                              StringComparison.OrdinalIgnoreCase);

        #endregion

        #endregion

        #region IEquatable<ObjectType> Members

        #region Equals(Object)

        /// <summary>
        /// Compares two object types for equality.
        /// </summary>
        /// <param name="Object">A object type to compare with.</param>
        public override Boolean Equals(Object? Object)

            => Object is Object_Type objectType &&
                   Equals(objectType);

        #endregion

        #region Equals(ObjectType)

        /// <summary>
        /// Compares two object types for equality.
        /// </summary>
        /// <param name="ObjectType">A object type to compare with.</param>
        public Boolean Equals(Object_Type ObjectType)

            => String.Equals(InternalId,
                             ObjectType.InternalId,
                             StringComparison.OrdinalIgnoreCase);

        #endregion

        #endregion

        #region GetHashCode()

        /// <summary>
        /// Return the hash code of this object.
        /// </summary>
        /// <returns>The hash code of this object.</returns>
        public override Int32 GetHashCode()

            => InternalId?.ToLower().GetHashCode() ?? 0;

        #endregion

        #region (override) ToString()

        /// <summary>
        /// Return a text representation of this object.
        /// </summary>
        public override String ToString()

            => InternalId ?? "";

        #endregion

    }

}
