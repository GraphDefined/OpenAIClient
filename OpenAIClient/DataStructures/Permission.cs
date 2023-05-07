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

#endregion

namespace com.GraphDefined.AI.OpenAI
{

    /// <summary>
    /// The permissions for using an AI language model.
    /// </summary>
    public class Permission
    {

        #region Properties

        /// <summary>
        /// Permission Id (not to be confused with ModelId)
        /// </summary>
        //[JsonProperty("id")]
        public String    Id                     { get; }

        /// <summary>
        /// Object type, should always be 'model_permission'
        /// </summary>
        //[JsonProperty("object")]
        public String    Object                 { get; }

        /// The time when the permission was created
        //[JsonProperty("created")]
        public DateTime  Created                { get; }
            //=> DateTimeOffset.FromUnixTimeSeconds(CreatedUnixTime).DateTime;

        /// <summary>
        /// Can the model be created?
        /// </summary>
        //[JsonProperty("allow_create_engine")]
        public Boolean   AllowCreateEngine      { get; }

        /// <summary>
        /// Does the model support temperature sampling?
        /// https://beta.openai.com/docs/api-reference/completions/create#completions/create-temperature
        /// </summary>
        //[JsonProperty("allow_sampling")]
        public Boolean   AllowSampling          { get; }

        /// <summary>
        /// Does the model support logprobs?
        /// https://beta.openai.com/docs/api-reference/completions/create#completions/create-logprobs
        /// </summary>
        //[JsonProperty("allow_logprobs")]
        public Boolean   AllowLogProbs          { get; }

        /// <summary>
        /// Does the model support search indices?
        /// </summary>
        //[JsonProperty("allow_search_indices")]
        public Boolean   AllowSearchIndices     { get; }

        //[JsonProperty("allow_view")]
        public Boolean   AllowView              { get; }

        /// <summary>
        /// Does the model allow fine tuning?
        /// https://beta.openai.com/docs/api-reference/fine-tunes
        /// </summary>
        //[JsonProperty("allow_fine_tuning")]
        public Boolean   AllowFineTuning        { get; }

        /// <summary>
        /// Is the model only allowed for a particular organization? May not be implemented yet.
        /// </summary>
        //[JsonProperty("organization")]
        public String    Organization           { get; }

        /// <summary>
        /// Is the model part of a group? Seems not implemented yet. Always null.
        /// </summary>
        //[JsonProperty("group")]
        public String    Group                  { get; }

        //[JsonProperty("is_blocking")]
        public Boolean   IsBlocking             { get; }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create new permissions for using an AI language model.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Object"></param>
        /// <param name="Created"></param>
        /// <param name="AllowCreateEngine"></param>
        /// <param name="AllowSampling"></param>
        /// <param name="AllowLogProbs"></param>
        /// <param name="AllowSearchIndices"></param>
        /// <param name="AllowView"></param>
        /// <param name="AllowFineTuning"></param>
        /// <param name="Organization"></param>
        /// <param name="Group"></param>
        /// <param name="IsBlocking"></param>
        public Permission(String    Id,
                          String    Object,
                          DateTime  Created,
                          Boolean   AllowCreateEngine,
                          Boolean   AllowSampling,
                          Boolean   AllowLogProbs,
                          Boolean   AllowSearchIndices,
                          Boolean   AllowView,
                          Boolean   AllowFineTuning,
                          String    Organization,
                          String    Group,
                          Boolean   IsBlocking)
        {

            this.Id                  = Id;
            this.Object              = Object;
            this.Created             = Created;
            this.AllowCreateEngine   = AllowCreateEngine;
            this.AllowSampling       = AllowSampling;
            this.AllowLogProbs       = AllowLogProbs;
            this.AllowSearchIndices  = AllowSearchIndices;
            this.AllowView           = AllowView;
            this.AllowFineTuning     = AllowFineTuning;
            this.Organization        = Organization;
            this.Group               = Group;
            this.IsBlocking          = IsBlocking;

        }

        #endregion



    }

}
