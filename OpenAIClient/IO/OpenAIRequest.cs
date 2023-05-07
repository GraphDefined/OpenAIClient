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

using Newtonsoft.Json.Linq;

using org.GraphDefined.Vanaheimr.Illias;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;

#endregion

namespace com.GraphDefined.AI.OpenAI
{

    public class OpenAIRequest
    {

        #region Properties

        public OpenAIClient       OpenAIClient        { get; }

        public HTTPRequest        HTTPRequest         { get; }

        #endregion


        protected OpenAIRequest(HTTPRequest   Request,
                                OpenAIClient  OpenAIClient)
        {

            this.HTTPRequest   = Request ?? throw new ArgumentNullException(nameof(HTTPRequest), "The given HTTP request must not be null!");
            this.OpenAIClient  = OpenAIClient;

        }


    }

    public class OpenAIRequest<T>
    {


    }

}
