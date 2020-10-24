namespace DnsTube.CloudflareClient.Models.Dns
{
    /// <summary>
    /// Represents the meta field in the List DNS records response.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Gets or sets a bool indicating if the record was automatically added.
        /// </summary>
        public bool AutoAdded { get; set; }

        /// <summary>
        /// Gets or sets the source of the record.
        /// </summary>
        public string Source { get; set; }
    }
}
