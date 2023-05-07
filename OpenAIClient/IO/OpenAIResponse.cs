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

    public class OpenAIResponse
    {

        #region Properties

        public OpenAIRequest?   Request                   { get; }

        public String           StatusMessage             { get; }

        public String?          AdditionalInformation     { get; }
        public DateTime         Timestamp                 { get; }

        public HTTPResponse?    HTTPResponse              { get; }
        public Request_Id?      RequestId                 { get; }

        #endregion

        #region Constructor(s)

        public OpenAIResponse(OpenAIRequest  Request,

                              String         StatusMessage,
                              String?        AdditionalInformation   = null,
                              DateTime?      Timestamp               = null,

                              HTTPResponse?  HTTPResponse            = null,
                              Request_Id?    RequestId               = null)

        {

            this.Request                = Request;

            this.StatusMessage          = StatusMessage;
            this.AdditionalInformation  = AdditionalInformation;
            this.Timestamp              = Timestamp ?? org.GraphDefined.Vanaheimr.Illias.Timestamp.Now;

            this.HTTPResponse           = HTTPResponse;
            this.RequestId              = RequestId;

        }

        public OpenAIResponse(String         StatusMessage,
                              String?        AdditionalInformation   = null,
                              DateTime?      Timestamp               = null,

                              HTTPResponse?  HTTPResponse            = null,
                              Request_Id?    RequestId               = null)

        {

            this.Request                = null;

            this.StatusMessage          = StatusMessage;
            this.AdditionalInformation  = AdditionalInformation;
            this.Timestamp              = Timestamp ?? org.GraphDefined.Vanaheimr.Illias.Timestamp.Now;

            this.HTTPResponse           = HTTPResponse;
            this.RequestId              = RequestId;

        }

        #endregion


        public static OpenAIResponse Error(String         StatusMessage,
                                           String?        AdditionalInformation   = null,
                                           DateTime?      Timestamp               = null,

                                           HTTPResponse?  HTTPResponse            = null,
                                           Request_Id?    RequestId               = null)

            => new(StatusMessage,
                   AdditionalInformation,
                   Timestamp,

                   HTTPResponse,
                   RequestId);


        public static OpenAIResponse Exception(Exception      Exception,
                                               DateTime?      Timestamp      = null,

                                               HTTPResponse?  HTTPResponse   = null,
                                               Request_Id?    RequestId      = null)

            => new(Exception.Message,
                   Exception.StackTrace,
                   Timestamp,

                   HTTPResponse,
                   RequestId);


    }

    public class OpenAIResponse<TResponse> : OpenAIResponse

        where TResponse : class

    {

        #region Properties

        public TResponse?  Data    { get; }

        #endregion

        #region Constructor(s)

        public OpenAIResponse(TResponse?     Data,

                              String         StatusMessage,
                              String?        AdditionalInformation   = null,
                              DateTime?      Timestamp               = null,

                              HTTPResponse?  HTTPResponse            = null,
                              Request_Id?    RequestId               = null)

            : base(StatusMessage,
                   AdditionalInformation,
                   Timestamp,

                   HTTPResponse,
                   RequestId)

        {

            this.Data  = Data;

        }

        public OpenAIResponse(String         StatusMessage,
                              String?        AdditionalInformation   = null,
                              DateTime?      Timestamp               = null,

                              HTTPResponse?  HTTPResponse            = null,
                              Request_Id?    RequestId               = null)

            : this(null,
                   StatusMessage,
                   AdditionalInformation,
                   Timestamp,

                   HTTPResponse,
                   RequestId)

        { }

        #endregion


        public new static OpenAIResponse<TResponse> Error(String         StatusMessage,
                                                          String?        AdditionalInformation   = null,
                                                          DateTime?      Timestamp               = null,

                                                          HTTPResponse?  HTTPResponse            = null,
                                                          Request_Id?    RequestId               = null)

            => new(StatusMessage,
                   AdditionalInformation,
                   Timestamp,

                   HTTPResponse,
                   RequestId);


        public new static OpenAIResponse<TResponse> Exception(Exception      Exception,
                                                              DateTime?      Timestamp      = null,

                                                              HTTPResponse?  HTTPResponse   = null,
                                                              Request_Id?    RequestId      = null)

            => new(Exception.Message,
                   Exception.StackTrace,
                   Timestamp,

                   HTTPResponse,
                   RequestId);


        // {
        //   "error": {
        //     "message": "Invalid URL (GET /v1/model/babbage-similarity)",
        //     "type": "invalid_request_error",
        //     "param": null,
        //     "code": null
        //   }
        // }


        public static OpenAIResponse<IEnumerable<TResponse>> ParseJArray<TElements>(HTTPResponse              Response,
                                                                                    Request_Id                RequestId,
                                                                                    Func<JObject, TElements>  Parser)
        {

            OpenAIResponse<IEnumerable<TResponse>>? result = default;

            try
            {

                var remoteRequestId = Response.TryParseHeaderField<Request_Id>("x-request-id", Request_Id.TryParse) ?? RequestId;

                if (Response.HTTPBody?.Length > 0)
                {

                    var json           = JObject.Parse(Response.HTTPBodyAsUTF8String);

                    #region Documentation

                    // {
                    //   "object": "list",
                    //   "data": [
                    //      ...
                    //   ]
                    // }

                    #endregion

                    var statusMessage  = json["status_message"]?.Value<String>();
                    var timestamp      = json["timestamp"]?.     Value<DateTime>();
                    if (timestamp.HasValue && timestamp.Value.Kind != DateTimeKind.Utc)
                        timestamp      = timestamp.Value.ToUniversalTime();

                    if (Response.HTTPStatusCode == HTTPStatusCode.OK ||
                        Response.HTTPStatusCode == HTTPStatusCode.Created)
                    {

                        var items          = new List<TResponse>();
                        var exceptions     = new List<String>();

                        if (json["data"] is JArray JSONArray)
                        {
                            foreach (var item in JSONArray)
                            {
                                try
                                {
                                    items.Add((TResponse) (Object) Parser(item as JObject));
                                }
                                catch (Exception e)
                                {
                                    exceptions.Add(e.Message);
                                }
                            }
                        }

                        result = new OpenAIResponse<IEnumerable<TResponse>>(items,
                                                                            statusMessage ?? String.Empty,
                                                                            exceptions.Any() ? exceptions.AggregateWith(Environment.NewLine) : null,
                                                                            timestamp ?? org.GraphDefined.Vanaheimr.Illias.Timestamp.Now,

                                                                            Response,
                                                                            remoteRequestId);

                    }

                    else
                        result = new OpenAIResponse<IEnumerable<TResponse>>(Array.Empty<TResponse>(),
                                                                          statusMessage ?? String.Empty,
                                                                          Response.EntirePDU,
                                                                          timestamp ?? org.GraphDefined.Vanaheimr.Illias.Timestamp.Now,

                                                                          Response,
                                                                          remoteRequestId);

                }

                else
                    result = new OpenAIResponse<IEnumerable<TResponse>>(Array.Empty<TResponse>(),
                                                                      Response.HTTPStatusCode.Code + " - " + Response.HTTPStatusCode.Description,
                                                                      Response.EntirePDU,
                                                                      Response.Timestamp,

                                                                      Response,
                                                                      remoteRequestId);

            }
            catch (Exception e)
            {

                result = new OpenAIResponse<IEnumerable<TResponse>>(Array.Empty<TResponse>(),
                                                                    e.Message,
                                                                    e.StackTrace,
                                                                    org.GraphDefined.Vanaheimr.Illias.Timestamp.Now,
                                                                    Response,
                                                                    RequestId);

            }

            return result;

        }


        public static OpenAIResponse<TResponse> ParseJObject(HTTPResponse              Response,
                                                             Request_Id                RequestId,
                                                             Func<JObject, TResponse>  Parser)
        {

            OpenAIResponse<TResponse>? result = default;

            try
            {

                var remoteRequestId = Response.TryParseHeaderField<Request_Id>("x-request-id", Request_Id.TryParse) ?? RequestId;

                if (Response.HTTPBody?.Length > 0)
                {

                    var json           = JObject.Parse(Response.HTTPBodyAsUTF8String);

                    var timestamp      = json["timestamp"]?.     Value<DateTime>();
                    if (timestamp.HasValue && timestamp.Value.Kind != DateTimeKind.Utc)
                        timestamp      = timestamp.Value.ToUniversalTime();

                    if (Response.HTTPStatusCode == HTTPStatusCode.OK ||
                        Response.HTTPStatusCode == HTTPStatusCode.Created)
                    {

                        result = new OpenAIResponse<TResponse>(Parser(json),
                                                               String.Empty,
                                                               null,
                                                               timestamp,

                                                               Response,
                                                               remoteRequestId);

                    }

                    else
                        result = new OpenAIResponse<TResponse>(String.Empty,
                                                               Response.EntirePDU,
                                                               timestamp,

                                                               Response,
                                                               remoteRequestId);

                }

                else
                    result = new OpenAIResponse<TResponse>(Response.HTTPStatusCode.Code + " - " + Response.HTTPStatusCode.Description,
                                                           Response.EntirePDU,
                                                           Response.Timestamp,

                                                           Response,
                                                           remoteRequestId);

            }
            catch (Exception e)
            {

                result = new OpenAIResponse<TResponse>(e.Message,
                                                       e.StackTrace);

            }

            result ??= new OpenAIResponse<TResponse>(String.Empty);

            return result;

        }




        // HTTP/1.1 200 OK
        // Date:                          Sun, 07 May 2023 09:11:05 GMT
        // Content-Type:                  application/json
        // Content-Length:                43017
        // Connection:                    keep-alive
        // openai-version:                2020-10-01
        // x-request-id:                  4a29caed7f6e95d825cbcb4639cbf80c
        // openai-processing-ms:          77
        // access-control-allow-origin:   *
        // strict-transport-security:     max-age=15724800; includeSubDomains
        // CF-Cache-Status:               DYNAMIC
        // Server:                        cloudflare
        // CF-RAY:                        7c385563ec2f727e-HAM
        // alt-svc:                       h3=":443"; ma=86400, h3-29=":443"; ma=86400


    }

}
