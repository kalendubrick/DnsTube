namespace DnsTube.CloudflareClient.Models.Dns
{
    /// <summary>
    /// Represents the data to submit with a patch request on a DNS record.
    /// </summary>
    class UpdateInfo
    {
        /// <summary>
        /// Gets or sets the updated IPv4 or IPv6 address.
        /// </summary>
        public string UpdatedAddress { get; set; }
    }
}
