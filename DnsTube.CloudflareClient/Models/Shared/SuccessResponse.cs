using System.Collections.Generic;

namespace DnsTube.CloudflareClient.Models.Shared
{
    public class SuccessResponse : Response
    {
        public IEnumerable<object> Result { get; set; }

        public IEnumerable<string> Messages { get; set; }

        public ResultInfo ResultInfo { get; set; }
    }
}
