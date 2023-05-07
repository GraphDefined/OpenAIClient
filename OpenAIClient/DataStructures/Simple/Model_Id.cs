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
    /// Extension methods for model identifications.
    /// </summary>
    public static class ModelIdExtensions
    {

        /// <summary>
        /// Indicates whether this model identification is null or empty.
        /// </summary>
        /// <param name="ModelId">A model identification.</param>
        public static Boolean IsNullOrEmpty(this Model_Id? ModelId)
            => !ModelId.HasValue || ModelId.Value.IsNullOrEmpty;

        /// <summary>
        /// Indicates whether this model identification is NOT null or empty.
        /// </summary>
        /// <param name="ModelId">A model identification.</param>
        public static Boolean IsNotNullOrEmpty(this Model_Id? ModelId)
            => ModelId.HasValue && ModelId.Value.IsNotNullOrEmpty;

    }


    /// <summary>
    /// The unique identification of a model.
    /// </summary>
    public readonly struct Model_Id : IId<Model_Id>
    {

        #region Data

        /// <summary>
        /// The internal identification.
        /// </summary>
        private readonly String InternalId;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether this model identification is null or empty.
        /// </summary>
        public Boolean IsNullOrEmpty
            => InternalId.IsNullOrEmpty();

        /// <summary>
        /// Indicates whether this model identification is NOT null or empty.
        /// </summary>
        public Boolean IsNotNullOrEmpty
            => InternalId.IsNotNullOrEmpty();

        /// <summary>
        /// The length of the model identification.
        /// </summary>
        public UInt64 Length
            => (UInt64) InternalId.Length;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a new model identification based on the given text.
        /// </summary>
        /// <param name="Text">The text representation of a model identification.</param>
        private Model_Id(String Text)
        {
            this.InternalId = Text;
        }

        #endregion


        #region (static) Parse   (Text)

        /// <summary>
        /// Parse the given text as a model identification.
        /// </summary>
        /// <param name="Text">A text representation of a model identification.</param>
        public static Model_Id Parse(String Text)
        {

            if (TryParse(Text, out var modelId))
                return modelId;

            throw new ArgumentException("Invalid text representation of a model identification: '" + Text + "'!",
                                        nameof(Text));

        }

        #endregion

        #region (static) TryParse(Text)

        /// <summary>
        /// Try to parse the given text as a model identification.
        /// </summary>
        /// <param name="Text">A text representation of a model identification.</param>
        public static Model_Id? TryParse(String Text)
        {

            if (TryParse(Text, out var modelId))
                return modelId;

            return null;

        }

        #endregion

        #region (static) TryParse(Text, out ModelId)

        /// <summary>
        /// Try to parse the given text as a model identification.
        /// </summary>
        /// <param name="Text">A text representation of a model identification.</param>
        /// <param name="ModelId">The parsed model identification.</param>
        public static Boolean TryParse(String Text, out Model_Id ModelId)
        {

            Text = Text.Trim();

            if (Text.IsNotNullOrEmpty())
            {
                try
                {
                    ModelId = new Model_Id(Text);
                    return true;
                }
                catch (Exception)
                { }
            }

            ModelId = default;
            return false;

        }

        #endregion

        #region Clone

        /// <summary>
        /// Clone this model identification.
        /// </summary>
        public Model_Id Clone

            => new (
                   new String(InternalId?.ToCharArray())
               );

        #endregion


        #region Operator overloading

        #region Operator == (ModelId1, ModelId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ModelId1">A model identification.</param>
        /// <param name="ModelId2">Another model identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (Model_Id ModelId1,
                                           Model_Id ModelId2)

            => ModelId1.Equals(ModelId2);

        #endregion

        #region Operator != (ModelId1, ModelId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ModelId1">A model identification.</param>
        /// <param name="ModelId2">Another model identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (Model_Id ModelId1,
                                           Model_Id ModelId2)

            => !ModelId1.Equals(ModelId2);

        #endregion

        #region Operator <  (ModelId1, ModelId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ModelId1">A model identification.</param>
        /// <param name="ModelId2">Another model identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (Model_Id ModelId1,
                                          Model_Id ModelId2)

            => ModelId1.CompareTo(ModelId2) < 0;

        #endregion

        #region Operator <= (ModelId1, ModelId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ModelId1">A model identification.</param>
        /// <param name="ModelId2">Another model identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (Model_Id ModelId1,
                                           Model_Id ModelId2)

            => ModelId1.CompareTo(ModelId2) <= 0;

        #endregion

        #region Operator >  (ModelId1, ModelId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ModelId1">A model identification.</param>
        /// <param name="ModelId2">Another model identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (Model_Id ModelId1,
                                          Model_Id ModelId2)

            => ModelId1.CompareTo(ModelId2) > 0;

        #endregion

        #region Operator >= (ModelId1, ModelId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="ModelId1">A model identification.</param>
        /// <param name="ModelId2">Another model identification.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (Model_Id ModelId1,
                                           Model_Id ModelId2)

            => ModelId1.CompareTo(ModelId2) >= 0;

        #endregion

        #endregion

        #region IComparable<ModelId> Members

        #region CompareTo(Object)

        /// <summary>
        /// Compares two model identifications.
        /// </summary>
        /// <param name="Object">A model identification to compare with.</param>
        public Int32 CompareTo(Object? Object)

            => Object is Model_Id modelId
                   ? CompareTo(modelId)
                   : throw new ArgumentException("The given object is not a model identification!",
                                                 nameof(Object));

        #endregion

        #region CompareTo(ModelId)

        /// <summary>
        /// Compares two model identifications.
        /// </summary>
        /// <param name="ModelId">A model identification to compare with.</param>
        public Int32 CompareTo(Model_Id ModelId)

            => String.Compare(InternalId,
                              ModelId.InternalId,
                              StringComparison.OrdinalIgnoreCase);

        #endregion

        #endregion

        #region IEquatable<ModelId> Members

        #region Equals(Object)

        /// <summary>
        /// Compares two model identifications for equality.
        /// </summary>
        /// <param name="Object">A model identification to compare with.</param>
        public override Boolean Equals(Object? Object)

            => Object is Model_Id modelId &&
                   Equals(modelId);

        #endregion

        #region Equals(ModelId)

        /// <summary>
        /// Compares two model identifications for equality.
        /// </summary>
        /// <param name="ModelId">A model identification to compare with.</param>
        public Boolean Equals(Model_Id ModelId)

            => String.Equals(InternalId,
                             ModelId.InternalId,
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
