using System;
using System.Collections.Generic;

namespace DnsTube.CloudflareClient.Models.Zone
{
    public class Zone
    {
        /// <summary>
        /// Gets or sets the zone identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the zone name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the interval (in seconds) from when development mode
        /// expires (positive integer) or last expired (negative integer) for
        /// the domain. If development mode has never been enabled, this value is 0.
        /// </summary>
        public int DevelopmentModeExpirationInterval { get; set; }

        /// <summary>
        /// Gets or sets the collection of nameservers used before transferring
        /// to Cloudflare.
        /// </summary>
        public IEnumerable<string> OriginalNameServers { get; set; }

        /// <summary>
        /// Gets or sets the name of the original registrar used before
        /// transferring to Cloudflare.
        /// </summary>
        public string OriginalRegistrar { get; set; }

        /// <summary>
        /// Gets or sets the name of the original DNS host used before
        /// transferring to Cloudflare.
        /// </summary>
        public string OriginalDnsHost { get; set; }

        /// <summary>
        /// Gets or sets when the zone was originally created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets when the zone was last modified.
        /// </summary>
        public DateTimeOffset ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets when the zone was activated.
        /// </summary>
        public DateTimeOffset ActivatedOn { get; set; }

        /// <summary>
        /// Gets or sets the owner (user or org) of the zone.
        /// </summary>
        public object Owner { get; set; }

        /// <summary>
        /// Gets or sets the account information for the zone owner.
        /// </summary>
        public object Account { get; set; }

        /// <summary>
        /// Gets or sets the permissions the user has for the zone.
        /// </summary>
        public IEnumerable<string> Permissions { get; set; }

        /// <summary>
        /// Gets or sets the zone plan.
        /// </summary>
        public object Plan { get; set; }

        /// <summary>
        /// Gets or sets the pending zone plan.
        /// </summary>
        public object PlanPending { get; set; }

        /// <summary>
        /// Gets or sets the status of the zone.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the zone is paused.
        /// </summary>
        public bool IsPaused { get; set; }

        /// <summary>
        /// Gets or sets the zone type; possible values are full or partial.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the collection of nameservers.
        /// </summary>
        public IEnumerable<string> NameServers { get; set; }
    }
}
