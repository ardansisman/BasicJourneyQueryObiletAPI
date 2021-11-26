using Newtonsoft.Json;
using System;

namespace Obilet.Web.Models.ObiletApiModels.Response.GetBusJourney
{
    public class Journey
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("stops")]
        public Stop[] Stops { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("departure")]
        public DateTimeOffset Departure { get; set; }

        [JsonProperty("arrival")]
        public DateTimeOffset Arrival { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("duration")]
        public DateTimeOffset Duration { get; set; }

        [JsonProperty("original-price")]
        public long OriginalPrice { get; set; }

        [JsonProperty("internet-price")]
        public long InternetPrice { get; set; }

        [JsonProperty("booking")]
        public object Booking { get; set; }

        [JsonProperty("bus-name")]
        public string BusName { get; set; }

        [JsonProperty("policy")]
        public Policy Policy { get; set; }

        [JsonProperty("features")]
        public string[] Features { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("available")]
        public object Available { get; set; }
    }
}
