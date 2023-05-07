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
    /// Extension methods for owner identifications.
    /// </summary>
    public static class OwnerIdExtensions
    {

        /// <summary>
        /// Indicates whether this owner identification is null or empty.
        /// </summary>
        /// <param name="OwnerId">An owner identification.</param>
        public static Boolean IsNullOrEmpty(this Owner_Id? OwnerId)
            => !OwnerId.HasValue || OwnerId.Value.IsNullOrEmpty;

        /// <summary>
        /// Indicates whether this owner identification is NOT null or empty.
        /// </summary>
        /// <param name="OwnerId">An owner identification.</param>
        public static Boolean IsNotNullOrEmpty(this Owner_Id? OwnerId)
            => OwnerId.HasValue && OwnerId.Value.IsNotNullOrEmpty;

    }


    /// <summary>
    /// The unique identification of an owner.
    /// </summary>
    public readonly struct Owner_Id : IId<Owner_Id>
    {

        #region Data

        /// <summary>
        /// The internal identification.
        /// </summary>
        private readonly String InternalId;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether this owner identification is null or empty.
        /// </summary>
        public Boolean IsNullOrEmpty
            => InternalId.IsNullOrEmpty();

        /// <summary>
        /// Indicates whether this owner identification is NOT null or empty.
        /// </summary>
        public Boolean IsNotNullOrEmpty
            => InternalId.IsNotNullOrEmpty();

        /// <summary>
        /// The length of the owner identification.
        /// </summary>
        public UInt64 Length
            => (UInt64) InternalId.Length;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a new owner identification based on the given text.
        /// </summary>
        /// <param name="Text">The text representation of an owner identification.</param>
        private Owner_Id(String Text)
        {
            this.InternalId = Text;
        }

        #endregion


        #region (static) Parse   (Text)

        /// <summary>
        /// Parse the given text as an owner identification.
        /// </summary>
        /// <param name="Text">A text representation of an owner identification.</param>
        public static Owner_Id Parse(String Text)
        {

            if (TryParse(Text, out var ownerId))
                return ownerId;

            throw new ArgumentException("Invalid text representation of an owner identification: '" + Text + "'!",
                                        nameof(Text));

        }

        #endregion

        #region (static) TryParse(Text)

        /// <summary>
        /// Try to parse the given text as an owner identification.
        /// </summary>
        /// <param name="Text">A text representation of an owner identification.</param>
        public static Owner_Id? TryParse(String Text)
        {

            if (TryParse(Text, out var ownerId))
                return ownerId;

            return null;

        }

        #endregion

        #region (static) TryParse(Text, out OwnerId)

        /// <summary>
        /// Try to parse the given text as an owner identification.
        /// </summary>
        /// <param name="Text">A text representation of an owner identification.</param>
        /// <param name="OwnerId">The parsed owner identification.</param>
        public static Boolean TryParse(String Text, out Owner_Id OwnerId)
        {

            Text = Text.Trim();

            if (Text.IsNotNullOrEmpty())
            {
                try
                {
                    OwnerId = new Owner_Id(Text);
                    return true;
                }
                catch (Exception)
                { }
            }

            OwnerId = default;
            return false;

        }

        #endregion

        #region Clone

        /// <summary>
        /// Clone this owner identification.
        /// </summary>
        public Owner_Id Clone

            => new (
                   new String(InternalId?.ToCharArray())
               );

        #endregion


        #region Operator overloading

        #region Operator == (OwnerId1, OwnerId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OwnerId1">An owner identification.</param>
        /// <param name="OwnerId2">Another owner identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (Owner_Id OwnerId1,
                                           Owner_Id OwnerId2)

            => OwnerId1.Equals(OwnerId2);

        #endregion

        #region Operator != (OwnerId1, OwnerId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OwnerId1">An owner identification.</param>
        /// <param name="OwnerId2">Another owner identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (Owner_Id OwnerId1,
                                           Owner_Id OwnerId2)

            => !OwnerId1.Equals(OwnerId2);

        #endregion

        #region Operator <  (OwnerId1, OwnerId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OwnerId1">An owner identification.</param>
        /// <param name="OwnerId2">Another owner identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (Owner_Id OwnerId1,
                                          Owner_Id OwnerId2)

            => OwnerId1.CompareTo(OwnerId2) < 0;

        #endregion

        #region Operator <= (OwnerId1, OwnerId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OwnerId1">An owner identification.</param>
        /// <param name="OwnerId2">Another owner identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (Owner_Id OwnerId1,
                                           Owner_Id OwnerId2)

            => OwnerId1.CompareTo(OwnerId2) <= 0;

        #endregion

        #region Operator >  (OwnerId1, OwnerId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OwnerId1">An owner identification.</param>
        /// <param name="OwnerId2">Another owner identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (Owner_Id OwnerId1,
                                          Owner_Id OwnerId2)

            => OwnerId1.CompareTo(OwnerId2) > 0;

        #endregion

        #region Operator >= (OwnerId1, OwnerId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OwnerId1">An owner identification.</param>
        /// <param name="OwnerId2">Another owner identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (Owner_Id OwnerId1,
                                           Owner_Id OwnerId2)

            => OwnerId1.CompareTo(OwnerId2) >= 0;

        #endregion

        #endregion

        #region IComparable<OwnerId> Members

        #region CompareTo(Object)

        /// <summary>
        /// Compares two owner identifications.
        /// </summary>
        /// <param name="Object">An owner identification to compare with.</param>
        public Int32 CompareTo(Object? Object)

            => Object is Owner_Id ownerId
                   ? CompareTo(ownerId)
                   : throw new ArgumentException("The given object is not an owner identification!",
                                                 nameof(Object));

        #endregion

        #region CompareTo(OwnerId)

        /// <summary>
        /// Compares two owner identifications.
        /// </summary>
        /// <param name="OwnerId">An owner identification to compare with.</param>
        public Int32 CompareTo(Owner_Id OwnerId)

            => String.Compare(InternalId,
                              OwnerId.InternalId,
                              StringComparison.OrdinalIgnoreCase);

        #endregion

        #endregion

        #region IEquatable<OwnerId> Members

        #region Equals(Object)

        /// <summary>
        /// Compares two owner identifications for equality.
        /// </summary>
        /// <param name="Object">An owner identification to compare with.</param>
        public override Boolean Equals(Object? Object)

            => Object is Owner_Id ownerId &&
                   Equals(ownerId);

        #endregion

        #region Equals(OwnerId)

        /// <summary>
        /// Compares two owner identifications for equality.
        /// </summary>
        /// <param name="OwnerId">An owner identification to compare with.</param>
        public Boolean Equals(Owner_Id OwnerId)

            => String.Equals(InternalId,
                             OwnerId.InternalId,
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
