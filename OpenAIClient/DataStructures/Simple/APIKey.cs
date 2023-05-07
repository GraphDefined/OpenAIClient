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
    /// Extension methods for API keys.
    /// </summary>
    public static class APIKeyExtensions
    {

        /// <summary>
        /// Indicates whether this API key is null or empty.
        /// </summary>
        /// <param name="APIKey">An API key.</param>
        public static Boolean IsNullOrEmpty(this APIKey? APIKey)
            => !APIKey.HasValue || APIKey.Value.IsNullOrEmpty;

        /// <summary>
        /// Indicates whether this API key is NOT null or empty.
        /// </summary>
        /// <param name="APIKey">An API key.</param>
        public static Boolean IsNotNullOrEmpty(this APIKey? APIKey)
            => APIKey.HasValue && APIKey.Value.IsNotNullOrEmpty;

    }


    /// <summary>
    /// The unique identification of an API key.
    /// </summary>
    public readonly struct APIKey : IId<APIKey>
    {

        #region Data

        /// <summary>
        /// The internal identification.
        /// </summary>
        private readonly String InternalId;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether this API key is null or empty.
        /// </summary>
        public Boolean IsNullOrEmpty
            => InternalId.IsNullOrEmpty();

        /// <summary>
        /// Indicates whether this API key is NOT null or empty.
        /// </summary>
        public Boolean IsNotNullOrEmpty
            => InternalId.IsNotNullOrEmpty();

        /// <summary>
        /// The length of the API key.
        /// </summary>
        public UInt64 Length
            => (UInt64) InternalId.Length;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a new API key based on the given text.
        /// </summary>
        /// <param name="Text">The text representation of an API key.</param>
        private APIKey(String Text)
        {
            this.InternalId = Text;
        }

        #endregion


        #region (static) Parse   (Text)

        /// <summary>
        /// Parse the given text as an API key.
        /// </summary>
        /// <param name="Text">A text representation of an API key.</param>
        public static APIKey Parse(String Text)
        {

            if (TryParse(Text, out var apiKey))
                return apiKey;

            throw new ArgumentException("Invalid text representation of an API key: '" + Text + "'!",
                                        nameof(Text));

        }

        #endregion

        #region (static) TryParse(Text)

        /// <summary>
        /// Try to parse the given text as an API key.
        /// </summary>
        /// <param name="Text">A text representation of an API key.</param>
        public static APIKey? TryParse(String Text)
        {

            if (TryParse(Text, out var apiKey))
                return apiKey;

            return null;

        }

        #endregion

        #region (static) TryParse(Text, out APIKey)

        /// <summary>
        /// Try to parse the given text as an API key.
        /// </summary>
        /// <param name="Text">A text representation of an API key.</param>
        /// <param name="APIKey">The parsed API key.</param>
        public static Boolean TryParse(String Text, out APIKey APIKey)
        {

            Text = Text.Trim();

            if (Text.IsNotNullOrEmpty())
            {
                try
                {
                    APIKey = new APIKey(Text);
                    return true;
                }
                catch (Exception)
                { }
            }

            APIKey = default;
            return false;

        }

        #endregion

        #region Clone

        /// <summary>
        /// Clone this API key.
        /// </summary>
        public APIKey Clone

            => new (
                   new String(InternalId?.ToCharArray())
               );

        #endregion


        #region Operator overloading

        #region Operator == (APIKey1, APIKey2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="APIKey1">An API key.</param>
        /// <param name="APIKey2">Another API key.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (APIKey APIKey1,
                                           APIKey APIKey2)

            => APIKey1.Equals(APIKey2);

        #endregion

        #region Operator != (APIKey1, APIKey2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="APIKey1">An API key.</param>
        /// <param name="APIKey2">Another API key.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (APIKey APIKey1,
                                           APIKey APIKey2)

            => !APIKey1.Equals(APIKey2);

        #endregion

        #region Operator <  (APIKey1, APIKey2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="APIKey1">An API key.</param>
        /// <param name="APIKey2">Another API key.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (APIKey APIKey1,
                                          APIKey APIKey2)

            => APIKey1.CompareTo(APIKey2) < 0;

        #endregion

        #region Operator <= (APIKey1, APIKey2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="APIKey1">An API key.</param>
        /// <param name="APIKey2">Another API key.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (APIKey APIKey1,
                                           APIKey APIKey2)

            => APIKey1.CompareTo(APIKey2) <= 0;

        #endregion

        #region Operator >  (APIKey1, APIKey2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="APIKey1">An API key.</param>
        /// <param name="APIKey2">Another API key.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (APIKey APIKey1,
                                          APIKey APIKey2)

            => APIKey1.CompareTo(APIKey2) > 0;

        #endregion

        #region Operator >= (APIKey1, APIKey2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="APIKey1">An API key.</param>
        /// <param name="APIKey2">Another API key.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (APIKey APIKey1,
                                           APIKey APIKey2)

            => APIKey1.CompareTo(APIKey2) >= 0;

        #endregion

        #endregion

        #region IComparable<APIKey> Members

        #region CompareTo(Object)

        /// <summary>
        /// Compares two API keys.
        /// </summary>
        /// <param name="Object">An API key to compare with.</param>
        public Int32 CompareTo(Object? Object)

            => Object is APIKey apiKey
                   ? CompareTo(apiKey)
                   : throw new ArgumentException("The given object is not an API key!",
                                                 nameof(Object));

        #endregion

        #region CompareTo(APIKey)

        /// <summary>
        /// Compares two API keys.
        /// </summary>
        /// <param name="APIKey">An API key to compare with.</param>
        public Int32 CompareTo(APIKey APIKey)

            => String.Compare(InternalId,
                              APIKey.InternalId,
                              StringComparison.OrdinalIgnoreCase);

        #endregion

        #endregion

        #region IEquatable<APIKey> Members

        #region Equals(Object)

        /// <summary>
        /// Compares two API keys for equality.
        /// </summary>
        /// <param name="Object">An API key to compare with.</param>
        public override Boolean Equals(Object? Object)

            => Object is APIKey apiKey &&
                   Equals(apiKey);

        #endregion

        #region Equals(APIKey)

        /// <summary>
        /// Compares two API keys for equality.
        /// </summary>
        /// <param name="APIKey">An API key to compare with.</param>
        public Boolean Equals(APIKey APIKey)

            => String.Equals(InternalId,
                             APIKey.InternalId,
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
