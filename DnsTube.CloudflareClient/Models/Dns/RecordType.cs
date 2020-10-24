namespace DnsTube.CloudflareClient.Models.Dns
{
    /// <summary>
    /// String enum with relevant DNS record types.
    /// </summary>
    public sealed class RecordType
    {
        /// <summary>
        /// Represents the IPv4 address record type.
        /// </summary>
        public static readonly string A = "A";

        /// <summary>
        /// Represents the IPv6 address record type.
        /// </summary>
        public static readonly string AAAA = "AAAA";
    }
}
