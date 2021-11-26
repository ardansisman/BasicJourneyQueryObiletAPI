using Newtonsoft.Json;
using Obilet.Web.Models.ObiletApiModels.Request.Common;

namespace Obilet.Web.Models.ObiletApiModels.Request.GetBusJourney
{
    public class GetBusJourneyRequestModel
    {
        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
