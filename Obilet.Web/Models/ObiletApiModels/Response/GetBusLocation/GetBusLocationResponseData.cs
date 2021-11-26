using Newtonsoft.Json;

namespace Obilet.Web.Models.ObiletApiModels.Response.GetBusLocation
{
    public class GetBusLocationResponseData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("parent-id")]
        public long ParentId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("geo-location")]
        public GeoLocation GeoLocation { get; set; }

        [JsonProperty("tz-code")]
        public string TzCode { get; set; }

        [JsonProperty("weather-code")]
        public object WeatherCode { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("reference-code")]
        public object ReferenceCode { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }
    }
}
