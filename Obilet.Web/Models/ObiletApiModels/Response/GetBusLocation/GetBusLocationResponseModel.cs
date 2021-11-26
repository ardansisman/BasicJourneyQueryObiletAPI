using Newtonsoft.Json;

namespace Obilet.Web.Models.ObiletApiModels.Response.GetBusLocation
{
    public class GetBusLocationResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public GetBusLocationResponseData[] Data { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("user-message")]
        public object UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public object ApiRequestId { get; set; }

        [JsonProperty("controller")]
        public string Controller { get; set; }
    }
}
