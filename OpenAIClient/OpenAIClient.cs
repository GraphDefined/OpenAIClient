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
using org.GraphDefined.Vanaheimr.Hermod.HTTP;

#endregion

namespace com.GraphDefined.AI.OpenAI
{

    #region OnGetModelsRequest/-Response

    /// <summary>
    /// A delegate called whenever a GetModels request will be send.
    /// </summary>
    public delegate Task OnGetModelsRequestDelegate(DateTime                                    LogTimestamp,
                                                    DateTime                                    RequestTimestamp,
                                                    OpenAIClient                                Sender,
                                                    String                                      SenderId,
                                                    EventTracking_Id                            EventTrackingId,

                                                    TimeSpan                                    RequestTimeout);

    /// <summary>
    /// A delegate called whenever a response to a GetModels request had been received.
    /// </summary>
    public delegate Task OnGetModelsResponseDelegate(DateTime                                    LogTimestamp,
                                                     DateTime                                    RequestTimestamp,
                                                     OpenAIClient                                Sender,
                                                     String                                      SenderId,
                                                     EventTracking_Id                            EventTrackingId,

                                                     TimeSpan                                    RequestTimeout,
                                                     TimeSpan                                    Duration);

    #endregion

    #region OnGetModelRequest/-Response

    /// <summary>
    /// A delegate called whenever a GetModel request will be send.
    /// </summary>
    public delegate Task OnGetModelRequestDelegate(DateTime                                    LogTimestamp,
                                                   DateTime                                    RequestTimestamp,
                                                   OpenAIClient                                Sender,
                                                   String                                      SenderId,
                                                   EventTracking_Id                            EventTrackingId,

                                                   TimeSpan                                    RequestTimeout);

    /// <summary>
    /// A delegate called whenever a response to a GetModel request had been received.
    /// </summary>
    public delegate Task OnGetModelResponseDelegate(DateTime                                    LogTimestamp,
                                                    DateTime                                    RequestTimestamp,
                                                    OpenAIClient                                Sender,
                                                    String                                      SenderId,
                                                    EventTracking_Id                            EventTrackingId,

                                                    TimeSpan                                    RequestTimeout,
                                                    TimeSpan                                    Duration);

    #endregion


    /// <summary>
    /// OpenAI Client
    /// </summary>
    public class OpenAIClient
    {

        #region Data

        private readonly HTTPBearerAuthentication  apiKeyAuthentication;

        private readonly URL                       remoteURL   = URL.Parse("https://api.openai.com/v1/");

        #endregion

        #region Properties

        /// <summary>
        /// The OpenAI API key.
        /// </summary>
        public APIKey            APIKey            { get; }

        /// <summary>
        /// The optional organization identification.
        /// </summary>
        public Organization_Id?  OrganizationId    { get; }



        public TimeSpan?          RequestTimeout    { get; }

        #endregion

        #region Events

        #region OnGetModelsRequest/-Response

        /// <summary>
        /// An event fired whenever a GetModels request will be send.
        /// </summary>
        public event OnGetModelsRequestDelegate?   OnGetModelsRequest;

        /// <summary>
        /// An event fired whenever a GetModels HTTP request will be send.
        /// </summary>
        public event ClientRequestLogHandler?      OnGetModelsHTTPRequest;

        /// <summary>
        /// An event fired whenever a response to a GetModels HTTP request had been received.
        /// </summary>
        public event ClientResponseLogHandler?     OnGetModelsHTTPResponse;

        /// <summary>
        /// An event fired whenever a response to a GetModels request had been received.
        /// </summary>
        public event OnGetModelsResponseDelegate?  OnGetModelsResponse;

        #endregion

        #region OnGetModelRequest/-Response

        /// <summary>
        /// An event fired whenever a GetModel request will be send.
        /// </summary>
        public event OnGetModelRequestDelegate?   OnGetModelRequest;

        /// <summary>
        /// An event fired whenever a GetModel HTTP request will be send.
        /// </summary>
        public event ClientRequestLogHandler?     OnGetModelHTTPRequest;

        /// <summary>
        /// An event fired whenever a response to a GetModel HTTP request had been received.
        /// </summary>
        public event ClientResponseLogHandler?    OnGetModelHTTPResponse;

        /// <summary>
        /// An event fired whenever a response to a GetModel request had been received.
        /// </summary>
        public event OnGetModelResponseDelegate?  OnGetModelResponse;

        #endregion

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a new OpenAI client.
        /// </summary>
        /// <param name="APIKey">An OpenAI API key.</param>
        /// <param name="OrganizationId">An optional organization identification.</param>
        public OpenAIClient(APIKey            APIKey,
                            Organization_Id?  OrganizationId   = null)
        {

            this.APIKey                = APIKey;
            this.apiKeyAuthentication  = new HTTPBearerAuthentication(APIKey.ToString());
            this.OrganizationId        = OrganizationId;

        }

        #endregion


        #region GetModels   (...)

        /// <summary>
        /// Request all AI language models from the remote API.
        /// </summary>
        /// <param name="Timestamp">The optional timestamp of the request.</param>
        /// <param name="EventTrackingId">An optional event tracking identification for correlating this request with other events.</param>
        /// <param name="RequestTimeout">An optional timeout for this request.</param>
        /// <param name="CancellationToken">An optional token to cancel this request.</param>
        public async Task<OpenAIResponse<IEnumerable<Model>>>

            GetModels(DateTime?          Timestamp           = null,
                      EventTracking_Id?  EventTrackingId     = null,
                      TimeSpan?          RequestTimeout      = null,
                      CancellationToken  CancellationToken   = default)

        {

            #region Send OnGetModelsHTTPRequest event

            var startTime = org.GraphDefined.Vanaheimr.Illias.Timestamp.Now;

            try
            {

                //Counters.GetLocations.IncRequests();

                //if (OnGetLocationsRequest != null)
                //    await Task.WhenAll(OnGetLocationsRequest.GetInvocationList().
                //                       Cast<OnGetLocationsRequestDelegate>().
                //                       Select(e => e(StartTime,
                //                                     Request.Timestamp.Value,
                //                                     this,
                //                                     ClientId,
                //                                     Request.EventTrackingId,

                //                                     Request.PartnerId,
                //                                     Request.OperatorId,
                //                                     Request.ChargingPoolId,
                //                                     Request.StatusEventDate,
                //                                     Request.AvailabilityStatus,
                //                                     Request.TransactionId,
                //                                     Request.AvailabilityStatusUntil,
                //                                     Request.AvailabilityStatusComment,

                //                                     Request.RequestTimeout ?? RequestTimeout.Value))).
                //                       ConfigureAwait(false);

            }
            catch (Exception e)
            {
                DebugX.LogException(e, nameof(OpenAIClient) + "." + nameof(OnGetModelsHTTPRequest));
            }

            #endregion


            OpenAIResponse<IEnumerable<Model>> response;

            try
            {

                #region Upstream HTTP request...

                var httpResponse = await new HTTPSClient(remoteURL,
                                                         //VirtualHostname,
                                                         //Description,
                                                         RemoteCertificateValidator: (a,b,c,d) => true
                                                         //ClientCertificateSelector,
                                                         //ClientCert,
                                                         //TLSProtocol,
                                                         //PreferIPv4,
                                                         //HTTPUserAgent,
                                                         //RequestTimeout,
                                                         //TransmissionRetryDelay,
                                                         //MaxNumberOfRetries,
                                                         //UseHTTPPipelining,
                                                         //HTTPLogger,
                                                         //DNSClient
                                                         ).

                                            Execute(client => client.CreateRequest(HTTPMethod.GET,
                                                                                   remoteURL.Path + "models",
                                                                                   requestbuilder => {
                                                                                       requestbuilder.Authorization = apiKeyAuthentication;
                                                                                       requestbuilder.Accept.Add(HTTPContentType.JSON_UTF8);
                                                                                   }),

                                            RequestLogDelegate:   OnGetModelsHTTPRequest,
                                            ResponseLogDelegate:  OnGetModelsHTTPResponse,
                                            CancellationToken:    CancellationToken,
                                            EventTrackingId:      EventTrackingId,
                                            RequestTimeout:       RequestTimeout ?? this.RequestTimeout).

                                    ConfigureAwait(false);

                #endregion

                response = OpenAIResponse<Model>.ParseJArray(httpResponse,
                                                             Request_Id.Parse("1"),
                                                             json => Model.Parse(json));

            }

            catch (Exception e)
            {
                response = OpenAIResponse<IEnumerable<Model>>.Exception(e);
            }


            #region Send OnGetModelsHTTPResponse event

            var endtime = org.GraphDefined.Vanaheimr.Illias.Timestamp.Now;

            try
            {

                // Update counters
                //if (response.HTTPStatusCode == HTTPStatusCode.OK && response.Content.RequestStatus.Code == 1)
                //    Counters.SetChargingPoolAvailabilityStatus.IncResponses_OK();
                //else
                //    Counters.SetChargingPoolAvailabilityStatus.IncResponses_Error();


                //if (OnGetLocationsResponse != null)
                //    await Task.WhenAll(OnGetLocationsResponse.GetInvocationList().
                //                       Cast<OnGetLocationsResponseDelegate>().
                //                       Select(e => e(Endtime,
                //                                     Request.Timestamp.Value,
                //                                     this,
                //                                     ClientId,
                //                                     Request.EventTrackingId,

                //                                     Request.PartnerId,
                //                                     Request.OperatorId,
                //                                     Request.ChargingPoolId,
                //                                     Request.StatusEventDate,
                //                                     Request.AvailabilityStatus,
                //                                     Request.TransactionId,
                //                                     Request.AvailabilityStatusUntil,
                //                                     Request.AvailabilityStatusComment,

                //                                     Request.RequestTimeout ?? RequestTimeout.Value,
                //                                     result.Content,
                //                                     Endtime - StartTime))).
                //                       ConfigureAwait(false);

            }
            catch (Exception e)
            {
                DebugX.LogException(e, nameof(OpenAIClient) + "." + nameof(OnGetModelsHTTPResponse));
            }

            #endregion

            return response;

        }

        #endregion

        #region GetModel   (...)

        /// <summary>
        /// Request an AI language model from the remote API.
        /// </summary>
        /// <param name="ModelId">An AI language model identification.</param>
        /// 
        /// <param name="Timestamp">The optional timestamp of the request.</param>
        /// <param name="EventTrackingId">An optional event tracking identification for correlating this request with other events.</param>
        /// <param name="RequestTimeout">An optional timeout for this request.</param>
        /// <param name="CancellationToken">An optional token to cancel this request.</param>
        public async Task<OpenAIResponse<Model>>

            GetModel(Model_Id            ModelId,

                     DateTime?           Timestamp           = null,
                     EventTracking_Id?   EventTrackingId     = null,
                     TimeSpan?           RequestTimeout      = null,
                     CancellationToken   CancellationToken   = default)

        {

            #region Send OnGetModelHTTPRequest event

            var startTime = org.GraphDefined.Vanaheimr.Illias.Timestamp.Now;

            try
            {

                //Counters.GetLocations.IncRequests();

                //if (OnGetLocationsRequest != null)
                //    await Task.WhenAll(OnGetLocationsRequest.GetInvocationList().
                //                       Cast<OnGetLocationsRequestDelegate>().
                //                       Select(e => e(StartTime,
                //                                     Request.Timestamp.Value,
                //                                     this,
                //                                     ClientId,
                //                                     Request.EventTrackingId,

                //                                     Request.PartnerId,
                //                                     Request.OperatorId,
                //                                     Request.ChargingPoolId,
                //                                     Request.StatusEventDate,
                //                                     Request.AvailabilityStatus,
                //                                     Request.TransactionId,
                //                                     Request.AvailabilityStatusUntil,
                //                                     Request.AvailabilityStatusComment,

                //                                     Request.RequestTimeout ?? RequestTimeout.Value))).
                //                       ConfigureAwait(false);

            }
            catch (Exception e)
            {
                DebugX.LogException(e, nameof(OpenAIClient) + "." + nameof(OnGetModelHTTPRequest));
            }

            #endregion


            OpenAIResponse<Model> response;

            try
            {

                #region Upstream HTTP request...

                var httpResponse = await new HTTPSClient(remoteURL,
                                                         //VirtualHostname,
                                                         //Description,
                                                         RemoteCertificateValidator: (a,b,c,d) => true
                                                         //ClientCertificateSelector,
                                                         //ClientCert,
                                                         //TLSProtocol,
                                                         //PreferIPv4,
                                                         //HTTPUserAgent,
                                                         //RequestTimeout,
                                                         //TransmissionRetryDelay,
                                                         //MaxNumberOfRetries,
                                                         //UseHTTPPipelining,
                                                         //HTTPLogger,
                                                         //DNSClient
                                                         ).

                                            Execute(client => client.CreateRequest(HTTPMethod.GET,
                                                                                   remoteURL.Path + "models" + ModelId.ToString(),
                                                                                   requestbuilder => {
                                                                                       requestbuilder.Authorization = apiKeyAuthentication;
                                                                                       requestbuilder.Accept.Add(HTTPContentType.JSON_UTF8);
                                                                                   }),

                                            RequestLogDelegate:   OnGetModelHTTPRequest,
                                            ResponseLogDelegate:  OnGetModelHTTPResponse,
                                            CancellationToken:    CancellationToken,
                                            EventTrackingId:      EventTrackingId,
                                            RequestTimeout:       RequestTimeout ?? this.RequestTimeout).

                                    ConfigureAwait(false);

                #endregion

                #region Documentation

                // HTTP/1.1 200 OK
                // Date:                          Sun, 07 May 2023 11:20:50 GMT
                // Content-Type:                  application/json
                // Content-Length:                574
                // Connection:                    keep-alive
                // openai-version:                2020-10-01
                // x-request-id:                  462c18b9b832842d74aa6cb76f23b1f6
                // openai-processing-ms:          29
                // access-control-allow-origin:   *
                // strict-transport-security:     max-age=15724800; includeSubDomains
                // CF-Cache-Status:               DYNAMIC
                // Server:                        cloudflare
                // CF-RAY:                        7c39136ff92e4534-TXL
                // alt-svc:                       h3=":443"; ma=86400, h3-29=":443"; ma=86400
                // 
                // {
                //   "id":         "babbage-similarity",
                //   "object":     "model",
                //   "created":     1651172505,
                //   "owned_by":   "openai-dev",
                //   "permission": [
                //     {
                //       "id":                    "modelperm-mS20lnPqhebTaFPrcCufyg7m",
                //       "object":                "model_permission",
                //       "created":                1669081947,
                //       "allow_create_engine":    false,
                //       "allow_sampling":         true,
                //       "allow_logprobs":         true,
                //       "allow_search_indices":   true,
                //       "allow_view":             true,
                //       "allow_fine_tuning":      false,
                //       "organization":          "*",
                //       "group":                  null,
                //       "is_blocking":            false
                //     }
                //   ],
                //   "root":       "babbage-similarity",
                //   "parent":      null
                // }

                #endregion

                response = OpenAIResponse<Model>.ParseJObject(httpResponse,
                                                              Request_Id.Parse("1"),
                                                              json => Model.Parse(json));

            }

            catch (Exception e)
            {
                response = OpenAIResponse<Model>.Exception(e);
            }


            #region Send OnGetModelHTTPResponse event

            var endtime = org.GraphDefined.Vanaheimr.Illias.Timestamp.Now;

            try
            {

                // Update counters
                //if (response.HTTPStatusCode == HTTPStatusCode.OK && response.Content.RequestStatus.Code == 1)
                //    Counters.SetChargingPoolAvailabilityStatus.IncResponses_OK();
                //else
                //    Counters.SetChargingPoolAvailabilityStatus.IncResponses_Error();


                //if (OnGetLocationsResponse != null)
                //    await Task.WhenAll(OnGetLocationsResponse.GetInvocationList().
                //                       Cast<OnGetLocationsResponseDelegate>().
                //                       Select(e => e(Endtime,
                //                                     Request.Timestamp.Value,
                //                                     this,
                //                                     ClientId,
                //                                     Request.EventTrackingId,

                //                                     Request.PartnerId,
                //                                     Request.OperatorId,
                //                                     Request.ChargingPoolId,
                //                                     Request.StatusEventDate,
                //                                     Request.AvailabilityStatus,
                //                                     Request.TransactionId,
                //                                     Request.AvailabilityStatusUntil,
                //                                     Request.AvailabilityStatusComment,

                //                                     Request.RequestTimeout ?? RequestTimeout.Value,
                //                                     result.Content,
                //                                     Endtime - StartTime))).
                //                       ConfigureAwait(false);

            }
            catch (Exception e)
            {
                DebugX.LogException(e, nameof(OpenAIClient) + "." + nameof(OnGetModelHTTPResponse));
            }

            #endregion

            return response;

        }

        #endregion


    }

}
