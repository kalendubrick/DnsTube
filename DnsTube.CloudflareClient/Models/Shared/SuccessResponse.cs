using System.Collections.Generic;

namespace DnsTube.CloudflareClient.Models.Shared
{
    /// <summary>
    /// Represents a successful response from the API.
    /// </summary>
    public class SuccessResponse : Response
    {
        /// <summary>
        /// Gets or sets a collection of messages returned from the API.
        /// </summary>
        public IEnumerable<string> Messages { get; set; }
    }
}
