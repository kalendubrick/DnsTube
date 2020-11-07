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

        private HttpRequestMessage GetRequestMessage(HttpMethod httpMethod, string requestUri)
        {
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
