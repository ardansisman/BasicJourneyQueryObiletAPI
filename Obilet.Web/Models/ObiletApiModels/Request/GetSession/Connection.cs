using Newtonsoft.Json;

namespace Obilet.Web.Models.ObiletApiModels.Request.GetSession
{
    public class Connection
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }

        [JsonProperty("port")]
        public long Port { get; set; }
    }
}
