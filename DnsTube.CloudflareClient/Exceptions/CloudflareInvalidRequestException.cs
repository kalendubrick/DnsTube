using System;

namespace DnsTube.CloudflareClient.Exceptions
{
    /// <summary>
    /// Represents the exception when the API returns
    /// status code 400 (Bad Request).
    /// </summary>
    public class CloudflareInvalidRequestException : Exception
    {
        public CloudflareInvalidRequestException()
        {
        }

        public CloudflareInvalidRequestException(string message)
            : base(message)
        {
        }

        public CloudflareInvalidRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
