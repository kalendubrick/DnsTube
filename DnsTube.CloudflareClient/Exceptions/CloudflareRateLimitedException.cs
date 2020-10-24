using System;

namespace DnsTube.CloudflareClient.Exceptions
{
    /// <summary>
    /// Represents the exception when the API returns
    /// status code 429 (Too Many Requests).
    /// </summary>
    public class CloudflareRateLimitedException : Exception
    {
        public CloudflareRateLimitedException()
        {
        }

        public CloudflareRateLimitedException(string message)
            : base(message)
        {
        }

        public CloudflareRateLimitedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
