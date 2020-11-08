using System;
using System.Net.Http;

using DnsTube.CloudflareClient.Models;

namespace DnsTube.CloudflareClient
{
    public class CloudflareClient
    {
        private const string BaseAddress = "https://api.cloudflare.com/client/v4/";
        private readonly HttpClient _client;
        private readonly string _token;
        private readonly string _apiKey;
        private readonly string _emailAddress;

        public CloudflareClient(HttpClient client, string token)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _token = token ?? throw new ArgumentNullException(nameof(token));

            _client.BaseAddress = new Uri(BaseAddress);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

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

                    return result.Result as IEnumerable<Zone>;
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
