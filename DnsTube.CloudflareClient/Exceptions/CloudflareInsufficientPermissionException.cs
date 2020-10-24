using System;

namespace DnsTube.CloudflareClient.Exceptions
{
    /// <summary>
    /// Represents the exception when the API returns
    /// status code 401 (Unauthorized).
    /// </summary>
    public class CloudflareInsufficientPermissionException : Exception
    {
        public CloudflareInsufficientPermissionException()
        {
        }

        public CloudflareInsufficientPermissionException(string message)
            : base(message)
        {
        }

        public CloudflareInsufficientPermissionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
