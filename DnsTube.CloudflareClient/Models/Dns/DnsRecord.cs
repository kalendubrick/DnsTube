using System;

namespace DnsTube.CloudflareClient.Models.Dns
{
    /// <summary>
    /// Represents a single DNS record result from the Cloudflare API.
    /// </summary>
    public class DnsRecord
    {
        /// <summary>
        /// Gets or sets the DNS record identifier tag.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the zone identifier.
        /// </summary>
        public string ZoneId { get; set; }

        /// <summary>
        /// Gets or sets the zone name.
        /// </summary>
        public string ZoneName { get; set; }

        /// <summary>
        /// Gets or sets the DNS record name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the DNS record type.
        /// Value should be one of possible values in <see cref="RecordType"/>.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the IPv4 or IPv6 address associated with the record.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Cloudflare is able to proxy the record.
        /// </summary>
        public bool Proxiable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Cloudflare is proxying the record.
        /// </summary>
        public bool Proxied { get; set; }

        /// <summary>
        /// Gets or sets the time to live for the DNS record.
        /// A value of 1 indicates "automatic".
        /// </summary>
        public int TimeToLive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this record can 
        /// be modified/deleted (true means it's managed by Cloudflare).
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Gets or sets extra Cloudflare-specific information about the record.
        /// </summary>
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets when the record was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets when the record was last modified.
        /// </summary>
        public DateTimeOffset ModifiedOn { get; set; }
    }
}
