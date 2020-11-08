using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DnsTube.CloudflareClient.Models.Shared;
using DnsTube.CloudflareClient.Models.Zone;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DnsTube.CloudflareClient
{
    public class CloudflareClient
    {
        private const string BaseAddress = "https://api.cloudflare.com/client/v4/";
        private readonly HttpClient _client;
        private readonly string _token;
        private readonly string _apiKey;
        private readonly string _emailAddress;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudflareClient"/> class.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> with which to perform requests.</param>
        /// <param name="token">The Cloudflare token with appropriate permissions to perform actions.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="client"/> or <paramref name="token"/> are null.
        /// </exception>
        public CloudflareClient(HttpClient client, string token)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _token = token ?? throw new ArgumentNullException(nameof(token));

            _client.BaseAddress = new Uri(BaseAddress);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudflareClient"/> class.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> with which to perform requests.</param>
        /// <param name="apiKey">The global api key for the Cloudflare account</param>
        /// <param name="emailAddress">The email address associated with the Cloudflare account</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="client"/>, <paramref name="apiKey"/>, or <paramref name="emailAddress"/> are null.
        /// </exception>
        public CloudflareClient(HttpClient client, string apiKey, string emailAddress)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _emailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
        }

        /// <summary>
        /// Gets a list of zones available.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Zone}"/> of available zones.</returns>
        public async Task<IEnumerable<Zone>> GetZoneIdsAsync()
        {
            const string ZoneEndpoint = "zones?status=active&page=1&per_page=50&order=name&direction=asc&match=all";

            using (var request = GetRequestMessage(HttpMethod.Get, ZoneEndpoint))
            using (var response = await _client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ListSuccessResponse>(content);

                    return result.Result.Select(z => (z as JObject).ToObject<Zone>());
                }
                else
                {
                    // TODO: Parse error status code and throw appropriate extension
                    throw new Exception();
                }
            }
        }

        /// <summary>
        /// Creates an <see cref="HttpRequestMessage" /> for the specified method and uri.
        /// Sets headers based on presence of token or api key/email address
        /// </summary>
        /// <param name="httpMethod">The <see cref="HttpMethod"/> to use for the request.</param>
        /// <param name="requestUri">The uri to use for the request.</param>
        /// <returns>An <see cref="HttpRequestMessage"/> for the specified method and uri.</returns>
        private HttpRequestMessage GetRequestMessage(HttpMethod httpMethod, string requestUri)
        {
            if (httpMethod is null)
            {
                throw new ArgumentNullException(nameof(httpMethod));
            }

            if (requestUri is null)
            {
                throw new ArgumentNullException(nameof(requestUri));
            }

            if (string.IsNullOrWhiteSpace(requestUri))
            {
                throw new ArgumentException("Cannot be empty", nameof(requestUri));
            }

            var req = new HttpRequestMessage(httpMethod, requestUri);

            if (!string.IsNullOrWhiteSpace(_token))
            {
                req.Headers.Add("Authorization", $"Bearer {_token}");
            }
            else
            {
                req.Headers.Add("X-Auth-Key", _apiKey);
                req.Headers.Add("X-Auth-Email", _emailAddress);
            }

            return req;
        }
    }
}
