namespace DnsTube.CloudflareClient.Models.Shared
{
    /// <summary>
    /// Contains paging information about response from the Cloudflare API.
    /// </summary>
    class ResultMetadata
    {
        /// <summary>
        /// Gets or sets the result page number.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the number of results per page.
        /// </summary>
        public int ResultsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the current result count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the total result count.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
