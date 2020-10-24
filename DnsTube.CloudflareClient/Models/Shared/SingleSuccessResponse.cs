namespace DnsTube.CloudflareClient.Models.Shared
{
    /// <summary>
    /// Represents a successful response from the API with a single result.
    /// </summary>
    class SingleSuccessResponse : SuccessResponse
    {
        /// <summary>
        /// Gets or sets the result object.
        /// </summary>
        public object Result { get; set; }
    }
}
