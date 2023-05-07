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
    /// Extension methods for organization identifications.
    /// </summary>
    public static class OrganizationIdExtensions
    {

        /// <summary>
        /// Indicates whether this organization identification is null or empty.
        /// </summary>
        /// <param name="OrganizationId">A organization identification.</param>
        public static Boolean IsNullOrEmpty(this Organization_Id? OrganizationId)
            => !OrganizationId.HasValue || OrganizationId.Value.IsNullOrEmpty;

        /// <summary>
        /// Indicates whether this organization identification is NOT null or empty.
        /// </summary>
        /// <param name="OrganizationId">A organization identification.</param>
        public static Boolean IsNotNullOrEmpty(this Organization_Id? OrganizationId)
            => OrganizationId.HasValue && OrganizationId.Value.IsNotNullOrEmpty;

    }


    /// <summary>
    /// The unique identification of a organization.
    /// </summary>
    public readonly struct Organization_Id : IId<Organization_Id>
    {

        #region Data

        /// <summary>
        /// The internal identification.
        /// </summary>
        private readonly String InternalId;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether this organization identification is null or empty.
        /// </summary>
        public Boolean IsNullOrEmpty
            => InternalId.IsNullOrEmpty();

        /// <summary>
        /// Indicates whether this organization identification is NOT null or empty.
        /// </summary>
        public Boolean IsNotNullOrEmpty
            => InternalId.IsNotNullOrEmpty();

        /// <summary>
        /// The length of the organization identification.
        /// </summary>
        public UInt64 Length
            => (UInt64) InternalId.Length;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a new organization identification based on the given text.
        /// </summary>
        /// <param name="Text">The text representation of a organization identification.</param>
        private Organization_Id(String Text)
        {
            this.InternalId = Text;
        }

        #endregion


        #region (static) Parse   (Text)

        /// <summary>
        /// Parse the given text as a organization identification.
        /// </summary>
        /// <param name="Text">A text representation of a organization identification.</param>
        public static Organization_Id Parse(String Text)
        {

            if (TryParse(Text, out var organizationId))
                return organizationId;

            throw new ArgumentException("Invalid text representation of a organization identification: '" + Text + "'!",
                                        nameof(Text));

        }

        #endregion

        #region (static) TryParse(Text)

        /// <summary>
        /// Try to parse the given text as a organization identification.
        /// </summary>
        /// <param name="Text">A text representation of a organization identification.</param>
        public static Organization_Id? TryParse(String Text)
        {

            if (TryParse(Text, out var organizationId))
                return organizationId;

            return null;

        }

        #endregion

        #region (static) TryParse(Text, out OrganizationId)

        /// <summary>
        /// Try to parse the given text as a organization identification.
        /// </summary>
        /// <param name="Text">A text representation of a organization identification.</param>
        /// <param name="OrganizationId">The parsed organization identification.</param>
        public static Boolean TryParse(String Text, out Organization_Id OrganizationId)
        {

            Text = Text.Trim();

            if (Text.IsNotNullOrEmpty())
            {
                try
                {
                    OrganizationId = new Organization_Id(Text);
                    return true;
                }
                catch (Exception)
                { }
            }

            OrganizationId = default;
            return false;

        }

        #endregion

        #region Clone

        /// <summary>
        /// Clone this organization identification.
        /// </summary>
        public Organization_Id Clone

            => new (
                   new String(InternalId?.ToCharArray())
               );

        #endregion


        #region Operator overloading

        #region Operator == (OrganizationId1, OrganizationId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OrganizationId1">A organization identification.</param>
        /// <param name="OrganizationId2">Another organization identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (Organization_Id OrganizationId1,
                                           Organization_Id OrganizationId2)

            => OrganizationId1.Equals(OrganizationId2);

        #endregion

        #region Operator != (OrganizationId1, OrganizationId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OrganizationId1">A organization identification.</param>
        /// <param name="OrganizationId2">Another organization identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (Organization_Id OrganizationId1,
                                           Organization_Id OrganizationId2)

            => !OrganizationId1.Equals(OrganizationId2);

        #endregion

        #region Operator <  (OrganizationId1, OrganizationId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OrganizationId1">A organization identification.</param>
        /// <param name="OrganizationId2">Another organization identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (Organization_Id OrganizationId1,
                                          Organization_Id OrganizationId2)

            => OrganizationId1.CompareTo(OrganizationId2) < 0;

        #endregion

        #region Operator <= (OrganizationId1, OrganizationId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OrganizationId1">A organization identification.</param>
        /// <param name="OrganizationId2">Another organization identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (Organization_Id OrganizationId1,
                                           Organization_Id OrganizationId2)

            => OrganizationId1.CompareTo(OrganizationId2) <= 0;

        #endregion

        #region Operator >  (OrganizationId1, OrganizationId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OrganizationId1">A organization identification.</param>
        /// <param name="OrganizationId2">Another organization identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (Organization_Id OrganizationId1,
                                          Organization_Id OrganizationId2)

            => OrganizationId1.CompareTo(OrganizationId2) > 0;

        #endregion

        #region Operator >= (OrganizationId1, OrganizationId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="OrganizationId1">A organization identification.</param>
        /// <param name="OrganizationId2">Another organization identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (Organization_Id OrganizationId1,
                                           Organization_Id OrganizationId2)

            => OrganizationId1.CompareTo(OrganizationId2) >= 0;

        #endregion

        #endregion

        #region IComparable<OrganizationId> Members

        #region CompareTo(Object)

        /// <summary>
        /// Compares two organization identifications.
        /// </summary>
        /// <param name="Object">A organization identification to compare with.</param>
        public Int32 CompareTo(Object? Object)

            => Object is Organization_Id organizationId
                   ? CompareTo(organizationId)
                   : throw new ArgumentException("The given object is not a organization identification!",
                                                 nameof(Object));

        #endregion

        #region CompareTo(OrganizationId)

        /// <summary>
        /// Compares two organization identifications.
        /// </summary>
        /// <param name="OrganizationId">A organization identification to compare with.</param>
        public Int32 CompareTo(Organization_Id OrganizationId)

            => String.Compare(InternalId,
                              OrganizationId.InternalId,
                              StringComparison.OrdinalIgnoreCase);

        #endregion

        #endregion

        #region IEquatable<OrganizationId> Members

        #region Equals(Object)

        /// <summary>
        /// Compares two organization identifications for equality.
        /// </summary>
        /// <param name="Object">A organization identification to compare with.</param>
        public override Boolean Equals(Object? Object)

            => Object is Organization_Id organizationId &&
                   Equals(organizationId);

        #endregion

        #region Equals(OrganizationId)

        /// <summary>
        /// Compares two organization identifications for equality.
        /// </summary>
        /// <param name="OrganizationId">A organization identification to compare with.</param>
        public Boolean Equals(Organization_Id OrganizationId)

            => String.Equals(InternalId,
                             OrganizationId.InternalId,
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
