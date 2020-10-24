using System.Collections.Generic;

namespace DnsTube.CloudflareClient.Models.Shared
{
    /// <summary>
    /// Represents a successful reponse from the API with a collection result.
    /// </summary>
    public class ListSuccessResponse : SuccessResponse
    {
        /// <summary>
        /// Gets or sets the result collection.
        /// </summary>
        public IEnumerable<object> Result { get; set; }

        /// <summary>
        /// Gets or sets the paging information associated with the response.
        /// </summary>
        public ResultInfo ResultInfo { get; set; }
    }
}
