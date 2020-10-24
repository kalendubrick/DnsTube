using System.Collections.Generic;

namespace DnsTube.CloudflareClient.Models.Shared
{
    /// <summary>
    /// Represents a generic response from the API.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or sets a value indicating if the request was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets a collection of errors returned by the API.
        /// </summary>
        public IEnumerable<ResponseError> Errors { get; set; }
    }
}
