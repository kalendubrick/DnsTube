using System;

namespace DnsTube.CloudflareClient.Exceptions
{
    /// <summary>
    /// Represents the exception when the API returns
    /// status code 403 (Forbidden).
    /// </summary>
    public class CloudflareNotAuthenticatedException : Exception
    {
        public CloudflareNotAuthenticatedException()
        {
        }

        public CloudflareNotAuthenticatedException(string message)
            : base(message)
        {
        }

        public CloudflareNotAuthenticatedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
