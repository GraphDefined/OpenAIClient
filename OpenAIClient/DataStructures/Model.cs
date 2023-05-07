/*
 * Copyright (c) 2022-2023 GraphDefined GmbH <achim.friedland@graphdefined.com>
 * This file is part of OpenAI Tests
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

using Newtonsoft.Json.Linq;

using org.GraphDefined.Vanaheimr.Illias;
using Telegram.Bot.Helpers;

#endregion

namespace com.GraphDefined.AI.OpenAI
{

    /// <summary>
    /// An AI model.
    /// https://platform.openai.com/docs/api-reference/models
    /// </summary>
    public class Model : IHasId<Model_Id>,
                         IEquatable<Model>,
                         IComparable<Model>,
                         IComparable
    {

        #region Propertis

        /// <summary>
        /// The unique identification of the AI model.
        /// </summary>
        [Mandatory]
        public Model_Id     Id            { get; }

        /// <summary>
        /// The object type.
        /// </summary>
        [Mandatory]
        public Object_Type  ObjectType    { get; }

        /// <summary>
        /// The creation timestamp of the AI model.
        /// </summary>
        [Mandatory]
        public DateTime     Created       { get; }

        /// <summary>
        /// The owner identification of the AI model.
        /// </summary>
        [Mandatory]
        public Owner_Id     OwnedBy       { get; }

        /// <summary>
        /// The optional unique identification of the root AI model.
        /// </summary>
        [Optional]
        public Model_Id?    Root          { get; }

        /// <summary>
        /// The optional unique identification of the parent AI model.
        /// </summary>
        [Optional]
        public Model_Id?    Parent        { get; }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a new AI model.
        /// </summary>
        /// <param name="Id">An unique identification of the AI model.</param>
        /// <param name="ObjectType">An object type.</param>
        /// <param name="Created">An creation timestamp of the AI model.</param>
        /// <param name="OwnedBy">An owner identification of the AI model.</param>
        /// <param name="Root">An optional unique identification of a root AI model.</param>
        /// <param name="Parent">An optional unique identification of a parent AI model.</param>
        public Model(Model_Id     Id,
                     Object_Type  ObjectType,
                     DateTime     Created,
                     Owner_Id     OwnedBy,
                     Model_Id?    Root,
                     Model_Id?    Parent)
        {

            this.Id          = Id;
            this.ObjectType  = ObjectType;
            this.Created     = Created;
            this.OwnedBy     = OwnedBy;
            this.Root        = Root;
            this.Parent      = Parent;

            unchecked
            {

                hashCode = Id.                 GetHashCode()       * 13 ^
                           ObjectType.         GetHashCode()       * 11 ^
                           Created.ToIso8601().GetHashCode()       *  7 ^
                           OwnedBy.            GetHashCode()       *  5 ^
                          (Root?.              GetHashCode() ?? 0) *  3 ^
                           Parent?.            GetHashCode() ?? 0;

            }

        }

        #endregion


        #region Documentation

        // {
        //     "id":        "text-curie:001",
        //     "object":    "model",
        //     "created":    1641955047,
        //     "owned_by":  "system",
        //     "permission": [
        //       {
        //         "id":                    "snapperm-BI9TAT6SCj43JRsUb9CYadsz",
        //         "object":                "model_permission",
        //         "created":                1641955123,
        //         "allow_create_engine":    false,
        //         "allow_sampling":         true,
        //         "allow_logprobs":         true,
        //         "allow_search_indices":   false,
        //         "allow_view":             true,
        //         "allow_fine_tuning":      false,
        //         "organization":          "*",
        //         "group":                  null,
        //         "is_blocking":            false
        //       }
        //     ],
        //     "root":      "text-curie:001",
        //     "parent":     null
        // }

        #endregion

        #region (static) Parse   (JSON, CustomModelParser = null)

        /// <summary>
        /// Parse the given JSON representation of a model.
        /// </summary>
        /// <param name="JSON">The JSON to parse.</param>
        /// <param name="CustomModelParser">A delegate to parse custom model JSON objects.</param>
        public static Model Parse(JObject                              JSON,
                                  CustomJObjectParserDelegate<Model>?  CustomModelParser   = null)
        {

            if (TryParse(JSON,
                         out var model,
                         out var errorResponse,
                         CustomModelParser))
            {
                return model!;
            }

            throw new ArgumentException("The given JSON representation of a model is invalid: " + errorResponse,
                                        nameof(JSON));

        }

        #endregion

        #region (static) TryParse(JSON, out Model, out ErrorResponse, ModelIdURL = null, CustomModelParser = null)

        // Note: The following is needed to satisfy pattern matching delegates! Do not refactor it!

        /// <summary>
        /// Try to parse the given JSON representation of a model.
        /// </summary>
        /// <param name="JSON">The JSON to parse.</param>
        /// <param name="Model">The parsed model.</param>
        /// <param name="ErrorResponse">An optional error response.</param>
        public static Boolean TryParse(JObject      JSON,
                                       out Model?   Model,
                                       out String?  ErrorResponse)

            => TryParse(JSON,
                        out Model,
                        out ErrorResponse,
                        null);


        /// <summary>
        /// Try to parse the given JSON representation of a model.
        /// </summary>
        /// <param name="JSON">The JSON to parse.</param>
        /// <param name="Model">The parsed model.</param>
        /// <param name="ErrorResponse">An optional error response.</param>
        /// <param name="CustomModelParser">A delegate to parse custom model JSON objects.</param>
        public static Boolean TryParse(JObject                              JSON,
                                       out Model?                           Model,
                                       out String?                          ErrorResponse,
                                       CustomJObjectParserDelegate<Model>?  CustomModelParser   = null)
        {

            try
            {

                Model = default;

                if (JSON?.HasValues != true)
                {
                    ErrorResponse = "The given JSON object must not be null or empty!";
                    return false;
                }

                #region Parse Id         [mandatory]

                if (!JSON.ParseMandatory("id",
                                         "model identification",
                                         Model_Id.TryParse,
                                         out Model_Id ModelId,
                                         out ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region Parse Object     [mandatory]

                if (!JSON.ParseMandatory("object",
                                         "object",
                                         Object_Type.TryParse,
                                         out Object_Type ObjectType,
                                         out ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region Parse Created    [mandatory]

                if (!JSON.ParseMandatory("created",
                                         "model creation timestamp",
                                         out Int64 unixTimestamp,
                                         out ErrorResponse))
                {
                    return false;
                }

                var Created = unixTimestamp.FromUnixTimestamp();

                #endregion

                #region OwnedBy          [mandatory]

                if (!JSON.ParseMandatory("owned_by",
                                         "owner identification",
                                         Owner_Id.TryParse,
                                         out Owner_Id OwnedBy,
                                         out ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region Parse Root       [optional]

                if (JSON.ParseOptional("root",
                                       "root model identification",
                                       Model_Id.TryParse,
                                       out Model_Id? Root,
                                       out ErrorResponse))
                {
                    if (ErrorResponse is not null)
                        return false;
                }

                #endregion

                #region Parse Parent     [optional]

                if (JSON.ParseOptional("parent",
                                       "parent model identification",
                                       Model_Id.TryParse,
                                       out Model_Id? Parent,
                                       out ErrorResponse))
                {
                    if (ErrorResponse is not null)
                        return false;
                }

                #endregion


                Model = new Model(ModelId,
                                  ObjectType,
                                  Created,
                                  OwnedBy,
                                  Root,
                                  Parent);

                if (CustomModelParser is not null)
                    Model = CustomModelParser(JSON,
                                              Model);

                return true;

            }
            catch (Exception e)
            {
                Model          = default;
                ErrorResponse  = "The given JSON representation of a model is invalid: " + e.Message;
                return false;
            }

        }

        #endregion

        #region ToJSON(CustomModelSerializer = null, ...)

        /// <summary>
        /// Return a JSON representation of this object.
        /// </summary>
        /// <param name="CustomModelSerializer">A delegate to serialize custom AI model JSON objects.</param>
        public JObject ToJSON(CustomJObjectSerializerDelegate<Model>? CustomModelSerializer = null)
        {

            var json = JSONObject.Create(

                                 new JProperty("id",         Id.        ToString()),
                                 new JProperty("object",     ObjectType.ToString()),
                                 new JProperty("created",    Created.   ToUnixTimestamp()),
                                 new JProperty("owned_by",   OwnedBy.   ToString()),

                           Root.HasValue
                               ? new JProperty("root",       Root.      ToString())
                               : null,

                           Parent.HasValue
                               ? new JProperty("parent",     Parent.    ToString())
                               : null

                       );

            return CustomModelSerializer is not null
                       ? CustomModelSerializer(this, json)
                       : json;

        }

        #endregion

        #region Clone()

        /// <summary>
        /// Clone this object.
        /// </summary>
        public Model Clone()

            => new (Id,
                    ObjectType,
                    Created,
                    OwnedBy,
                    Root,
                    Parent);

        #endregion


        #region Operator overloading

        #region Operator == (Model1, Model2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="Model1">A model.</param>
        /// <param name="Model2">Another model.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (Model Model1,
                                           Model Model2)
        {

            if (Object.ReferenceEquals(Model1, Model2))
                return true;

            if (Model1 is null || Model2 is null)
                return false;

            return Model1.Equals(Model2);

        }

        #endregion

        #region Operator != (Model1, Model2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="Model1">A model.</param>
        /// <param name="Model2">Another model.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (Model Model1,
                                           Model Model2)

            => !(Model1 == Model2);

        #endregion

        #region Operator <  (Model1, Model2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="Model1">A model.</param>
        /// <param name="Model2">Another model.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (Model Model1,
                                          Model Model2)

            => Model1 is null
                   ? throw new ArgumentNullException(nameof(Model1), "The given model must not be null!")
                   : Model1.CompareTo(Model2) < 0;

        #endregion

        #region Operator <= (Model1, Model2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="Model1">A model.</param>
        /// <param name="Model2">Another model.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (Model Model1,
                                           Model Model2)

            => !(Model1 > Model2);

        #endregion

        #region Operator >  (Model1, Model2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="Model1">A model.</param>
        /// <param name="Model2">Another model.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (Model Model1,
                                          Model Model2)

            => Model1 is null
                   ? throw new ArgumentNullException(nameof(Model1), "The given model must not be null!")
                   : Model1.CompareTo(Model2) > 0;

        #endregion

        #region Operator >= (Model1, Model2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="Model1">A model.</param>
        /// <param name="Model2">Another model.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (Model Model1,
                                           Model Model2)

            => !(Model1 < Model2);

        #endregion

        #endregion

        #region IComparable<Model> Members

        #region CompareTo(Object)

        /// <summary>
        /// Compares two models.
        /// </summary>
        /// <param name="Object">A model to compare with.</param>
        public Int32 CompareTo(Object? Object)

            => Object is Model model
                   ? CompareTo(model)
                   : throw new ArgumentException("The given object is not a model!",
                                                 nameof(Object));

        #endregion

        #region CompareTo(Model)

        /// <summary>
        /// Compares two models.
        /// </summary>
        /// <param name="Model">A model to compare with.</param>
        public Int32 CompareTo(Model? Model)
        {

            if (Model is null)
                throw new ArgumentNullException(nameof(Model), "The given model must not be null!");

            var c = Id.                 CompareTo(Model.Id);

            if (c == 0)
                c = ObjectType.         CompareTo(Model.ObjectType);

            if (c == 0)
                c = Created.ToIso8601().CompareTo(Model.Created.ToIso8601());

            if (c == 0)
                c = OwnedBy.            CompareTo(Model.OwnedBy);

            if (c == 0 && Root.  HasValue && Model.Root.  HasValue)
                c = Root.  Value.       CompareTo(Model.Root.  Value);

            if (c == 0 && Parent.HasValue && Model.Parent.HasValue)
                c = Parent.Value.       CompareTo(Model.Parent.Value);

            return c;

        }

        #endregion

        #endregion

        #region IEquatable<Model> Members

        #region Equals(Object)

        /// <summary>
        /// Compares two models for equality.
        /// </summary>
        /// <param name="Object">A model to compare with.</param>
        public override Boolean Equals(Object? Object)

            => Object is Model model &&
                   Equals(model);

        #endregion

        #region Equals(Model)

        /// <summary>
        /// Compares two models for equality.
        /// </summary>
        /// <param name="Model">A model to compare with.</param>
        public Boolean Equals(Model? Model)

            => Model is not null &&

               Id.                 Equals(Model.Id)                  &&
               ObjectType.         Equals(Model.ObjectType)          &&
               Created.ToIso8601().Equals(Model.Created.ToIso8601()) &&
               OwnedBy.            Equals(Model.OwnedBy)             &&

            ((!Root.  HasValue && !Model.Root.  HasValue) ||
              (Root.  HasValue &&  Model.Root.  HasValue && Root.  Value.Equals(Model.Root.  Value))) &&

            ((!Parent.HasValue && !Model.Parent.HasValue) ||
              (Parent.HasValue &&  Model.Parent.HasValue && Parent.Value.Equals(Model.Parent.Value)));

        #endregion

        #endregion

        #region GetHashCode()

        private readonly Int32 hashCode;

        /// <summary>
        /// Get the hashcode of this object.
        /// </summary>
        public override Int32 GetHashCode()
            => hashCode;

        #endregion

        #region (override) ToString()

        /// <summary>
        /// Get a text representation of this object.
        /// </summary>
        public override String ToString()

            => $"{Id} - {Created.ToIso8601()}";

        #endregion

    }

}
