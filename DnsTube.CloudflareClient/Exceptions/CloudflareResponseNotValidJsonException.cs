using System;

namespace DnsTube.CloudflareClient.Exceptions
{
    /// <summary>
    /// Represents the exception when the API returns
    /// status code 415 (Unsupported Media Type).
    /// </summary>
    public class CloudflareResponseNotValidJsonException : Exception
    {
        public CloudflareResponseNotValidJsonException()
        {
        }

        public CloudflareResponseNotValidJsonException(string message)
            : base(message)
        {
        }

        public CloudflareResponseNotValidJsonException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
