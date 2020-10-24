using System;

namespace DnsTube.CloudflareClient.Exceptions
{
    /// <summary>
    /// Represents the exception when the API returns
    /// status code 405 (Method Not Allowed).
    /// </summary>
    public class CloudflareInvalidRequestMethodException : Exception
    {
        public CloudflareInvalidRequestMethodException()
        {
        }

        public CloudflareInvalidRequestMethodException(string message)
            : base(message)
        {
        }

        public CloudflareInvalidRequestMethodException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
