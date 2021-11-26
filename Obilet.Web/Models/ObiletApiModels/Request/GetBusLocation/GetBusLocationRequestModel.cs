using Newtonsoft.Json;
using Obilet.Web.Models.ObiletApiModels.Request.Common;
using System;

namespace Obilet.Web.Models.ObiletApiModels.Request.GetBusLocation
{
    public class GetBusLocationRequestModel
    {
        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
