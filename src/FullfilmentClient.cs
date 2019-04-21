using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using SaaSFulfillmentClient.Models;

namespace SaaSFulfillment
{
    public class FullfilmentClient : IFulfillmentClient
    {
        private const string BaseUrl = "https://marketplaceapi.microsoft.com/api/saas";
        private const string DefaultApiVersion = "2018-08-31";
        private const string DefaultApiVersionParameterName = "api-version";
        private readonly string apiVersion;
        private readonly string baseUri;
        private readonly HttpMessageHandler httpMessageHandler;
        private readonly ILogger logger;

        public FullfilmentClient(ILogger logger) : this(BaseUrl, DefaultApiVersion, null, logger)
        {
        }

        public FullfilmentClient(string baseUri, string apiVersion, ILogger logger) : this(baseUri, apiVersion, null, logger)
        {
        }

        public FullfilmentClient(HttpMessageHandler httpMessageHandler, ILogger logger) : this(BaseUrl, DefaultApiVersion, httpMessageHandler, logger)
        {
        }

        public FullfilmentClient(string baseUri, string apiVersion, HttpMessageHandler httpMessageHandler, ILogger logger)
        {
            this.baseUri = baseUri;
            this.apiVersion = apiVersion;
            this.logger = logger;
            this.httpMessageHandler = httpMessageHandler;
        }

        public async Task<FullfilmentRequestResult> ActivateSubscriptionAsync(string subscriptionId, ActivatedSubscription subscriptionDetails, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken)
        {
            var requestUrl = FluentUriBuilder
                .Start(this.baseUri)
                .AddPath("subscriptions")
                .AddPath(subscriptionId)
                .AddPath("activate")
                .AddQuery(DefaultApiVersionParameterName, this.apiVersion)
                .Uri;

            requestId = requestId == default ? Guid.NewGuid() : requestId;
            correlationId = correlationId == default ? Guid.NewGuid() : correlationId;

            var response = await this.SendRequestAndReturnResult(
                HttpMethod.Post,
                requestUrl,
                requestId,
                correlationId,
                bearerToken,
                null,
                JsonConvert.SerializeObject(subscriptionDetails),
                cancellationToken);

            return await FullfilmentRequestResult.ParseAsync<FullfilmentRequestResult>(response);
        }

        public async Task<FullfilmentRequestResult> DeleteSubscriptionAsync(string subscriptionId, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken)
        {
            var requestUrl = FluentUriBuilder
                .Start(this.baseUri)
                .AddPath("subscriptions")
                .AddPath(subscriptionId)
                .AddQuery(DefaultApiVersionParameterName, this.apiVersion)
                .Uri;

            requestId = requestId == default ? Guid.NewGuid() : requestId;
            correlationId = correlationId == default ? Guid.NewGuid() : correlationId;

            var response = await this.SendRequestAndReturnResult(
                HttpMethod.Delete,
                requestUrl,
                requestId,
                correlationId,
                bearerToken,
                null,
                "",
                cancellationToken);

            return await FullfilmentRequestResult.ParseAsync<FullfilmentRequestResult>(response);
        }

        public async Task<SubscriptionOperation> GetSubscriptionOperationAsync(string subscriptionId, string operationId, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken)
        {
            var requestUrl = FluentUriBuilder
            .Start(this.baseUri)
            .AddPath("subscriptions")
            .AddPath(subscriptionId)
            .AddPath("operations")
            .AddPath(operationId)
            .AddQuery(DefaultApiVersionParameterName, this.apiVersion)
            .Uri;

            requestId = requestId == default ? Guid.NewGuid() : requestId;
            correlationId = correlationId == default ? Guid.NewGuid() : correlationId;

            var response = await this.SendRequestAndReturnResult(
                HttpMethod.Get,
                requestUrl,
                requestId,
                correlationId,
                bearerToken,
                null,
                "",
                cancellationToken);

            return await FullfilmentRequestResult.ParseAsync<SubscriptionOperation>(response);
        }

        public async Task<IEnumerable<SubscriptionOperation>> GetSubscriptionOperationsAsync(string subscriptionId, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken)
        {
            var requestUrl = FluentUriBuilder
            .Start(this.baseUri)
            .AddPath("subscriptions")
            .AddPath(subscriptionId)
            .AddPath("operations")
            .AddQuery(DefaultApiVersionParameterName, this.apiVersion)
            .Uri;

            requestId = requestId == default ? Guid.NewGuid() : requestId;
            correlationId = correlationId == default ? Guid.NewGuid() : correlationId;

            var response = await this.SendRequestAndReturnResult(HttpMethod.Get,
                requestUrl,
                requestId,
                correlationId,
                bearerToken,
                null,
                "",
                cancellationToken);

            return await FullfilmentRequestResult.ParseMultipleAsync<SubscriptionOperation>(response);
        }

        public async Task<IEnumerable<SubscriptionOperation>> GetOperationsAsync(Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken)
        {
            var requestUrl = FluentUriBuilder
            .Start(this.baseUri)
            .AddPath("operations")
            .AddQuery(DefaultApiVersionParameterName, this.apiVersion)
            .Uri;

            requestId = requestId == default ? Guid.NewGuid() : requestId;
            correlationId = correlationId == default ? Guid.NewGuid() : correlationId;

            var response = await this.SendRequestAndReturnResult(HttpMethod.Get,
                requestUrl,
                requestId,
                correlationId,
                bearerToken,
                null,
                "",
                cancellationToken);

            return await FullfilmentRequestResult.ParseMultipleAsync<SubscriptionOperation>(response);
        }

        public async Task<Subscription> GetSubscriptionAsync(string subscriptionId, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken)
        {
            var requestUrl = FluentUriBuilder
            .Start(this.baseUri)
            .AddPath("subscriptions")
            .AddPath(subscriptionId)
            .AddQuery(DefaultApiVersionParameterName, this.apiVersion)
            .Uri;

            requestId = requestId == default ? Guid.NewGuid() : requestId;
            correlationId = correlationId == default ? Guid.NewGuid() : correlationId;

            var response = await this.SendRequestAndReturnResult(HttpMethod.Get,
                requestUrl,
                requestId,
                correlationId,
                bearerToken,
                null,
                "",
                cancellationToken);

            return await FullfilmentRequestResult.ParseAsync<Subscription>(response);
        }

        public async Task<SubscriptionPlans> GetSubscriptionPlansAsync(string subscriptionId, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken)
        {
            var requestUrl = FluentUriBuilder
                .Start(this.baseUri)
                .AddPath("subscriptions")
                .AddPath(subscriptionId)
                .AddPath("listAvailablePlans")
                .AddQuery(DefaultApiVersionParameterName, this.apiVersion)
                .Uri;

            requestId = requestId == default ? Guid.NewGuid() : requestId;
            correlationId = correlationId == default ? Guid.NewGuid() : correlationId;

            var response = await this.SendRequestAndReturnResult(HttpMethod.Get,
                requestUrl,
                requestId,
                correlationId,
                bearerToken,
                null,
                "",
                cancellationToken);

            return await FullfilmentRequestResult.ParseAsync<SubscriptionPlans>(response);
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync(
            Guid requestId,
            Guid correlationId,
            string bearerToken, CancellationToken cancellationToken)
        {
            var requestUrl = FluentUriBuilder
                .Start(this.baseUri)
                .AddPath("subscriptions")
                .AddQuery(DefaultApiVersionParameterName, this.apiVersion)
                .Uri;

            requestId = requestId == default ? Guid.NewGuid() : requestId;
            correlationId = correlationId == default ? Guid.NewGuid() : correlationId;

            var response = await this.SendRequestAndReturnResult(HttpMethod.Get,
                requestUrl,
                requestId,
                correlationId,
                bearerToken,
                null,
                "",
                cancellationToken);

            return await FullfilmentRequestResult.ParseMultipleAsync<Subscription>(response);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="marketplaceToken">
        /// Token query parameter in the URL when the user is redirected to the SaaS ISV’s website from Azure.
        /// Note: The URL decodes the token value from the browser before using it.
        /// This token is valid only for 1 hour
        /// </param>
        /// <param name="requestId"></param>
        /// <param name="correlationId"></param>
        /// <param name="bearerToken"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResolvedSubscription> ResolveSubscriptionAsync(string marketplaceToken, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken)
        {
            var requestUrl = FluentUriBuilder
                .Start(this.baseUri)
                .AddPath("subscriptions")
                .AddPath("resolve")
                .AddQuery(DefaultApiVersionParameterName, this.apiVersion)
                .Uri;

            requestId = requestId == default ? Guid.NewGuid() : requestId;
            correlationId = correlationId == default ? Guid.NewGuid() : correlationId;

            var response = await this.SendRequestAndReturnResult(HttpMethod.Post,
                requestUrl,
                requestId,
                correlationId,
                bearerToken,
                r =>
                {
                    r.Headers.Add("x-ms-marketplace-token", marketplaceToken);
                },
                "",
                cancellationToken);

            return await FullfilmentRequestResult.ParseAsync<ResolvedSubscription>(response);
        }

        public async Task<UpdateSubscriptionResult> UpdateSubscriptionAsync(string subscriptionId, ActivatedSubscription update, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken)
        {
            var requestUrl = FluentUriBuilder
                .Start(this.baseUri)
                .AddPath("subscriptions")
                .AddPath(subscriptionId)
                .AddQuery(DefaultApiVersionParameterName, this.apiVersion)
                .Uri;

            requestId = requestId == default ? Guid.NewGuid() : requestId;
            correlationId = correlationId == default ? Guid.NewGuid() : correlationId;
            var updateContent = JsonConvert.SerializeObject(update);

            if (update.PlanId != string.Empty && update.Quantity != string.Empty)
            {
                throw new ApplicationException("Plan Id and quantity cannot be patched at the same time.");
            }

            var response = await this.SendRequestAndReturnResult(
                new HttpMethod("PATCH"),
                requestUrl,
                requestId,
                correlationId,
                bearerToken,
                null,
                updateContent,
                cancellationToken);

            return await FullfilmentRequestResult.ParseAsync<UpdateSubscriptionResult>(response);
        }

        private static HttpRequestMessage BuildRequest(
            HttpMethod method,
            Uri requestUri,
            Guid requestId,
            Guid correlationId,
            string bearerToken,
            string content)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = requestUri,
                Method = method
            };

            request.Headers.Add("x-ms-requestid", requestId.ToString());
            request.Headers.Add("x-ms-correlationid", correlationId.ToString());
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            if (method == HttpMethod.Post ||
                method.ToString().ToUpper() == "PATCH")
            {
                request.Content = new StringContent(content);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return request;
        }

        private string BuildReceivedLogMessage(Guid requestId, Guid correlationId, HttpStatusCode responseStatusCode,
            string result, string caller)
        {
            return
                $"Received response {caller}: requestId: {requestId} correlationId: {correlationId}. Status: {responseStatusCode}. Response content: {result}";
        }

        private string BuildSendLogMessage(Guid requestId, Guid correlationId, string caller)
        {
            return $"Sending request {caller}: requestId: {requestId} correlationId: {correlationId}";
        }

        private HttpClient GetHttpClient()
        {
            if (this.httpMessageHandler == null) return new HttpClient();

            return new HttpClient(this.httpMessageHandler);
        }

        private async Task<HttpResponseMessage> SendRequestAndReturnResult(
            HttpMethod method,
            Uri requestUri,
            Guid requestId,
            Guid correlationId,
            string bearerToken,
            Action<HttpRequestMessage> customRequestBuilder = null,
            string content = "",
            CancellationToken cancellationToken = default,
            [CallerMemberName] string caller = "")
        {
            this.logger.LogInformation(this.BuildSendLogMessage(requestId, correlationId, caller));
            using (var httpClient = this.GetHttpClient())
            {
                var marketplaceApiRequest = BuildRequest(method, requestUri, requestId, correlationId, bearerToken, content);

                // Give option to modify the request for non-default settings
                customRequestBuilder?.Invoke(marketplaceApiRequest);

                var response = await httpClient.SendAsync(marketplaceApiRequest, cancellationToken);
                var result = await response.Content.ReadAsStringAsync();
                var responseLogMessage = this.BuildReceivedLogMessage(requestId, correlationId, response.StatusCode, result,
                        caller);

                if (response.IsSuccessStatusCode)
                {
                    this.logger.LogInformation(responseLogMessage);

                    return response;
                }

                this.logger.LogError(responseLogMessage);
                throw new ApplicationException(responseLogMessage);
            }
        }
    }
}
