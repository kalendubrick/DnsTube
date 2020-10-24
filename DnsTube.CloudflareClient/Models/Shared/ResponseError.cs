namespace DnsTube.CloudflareClient.Models.Shared
{
    /// <summary>
    /// Represents an error from the response.
    /// </summary>
    public class ResponseError
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string Message { get; set; }
    }
}
