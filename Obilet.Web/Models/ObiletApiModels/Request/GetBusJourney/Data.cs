using Newtonsoft.Json;
using System;

namespace Obilet.Web.Models.ObiletApiModels.Request.GetBusJourney
{
    public class Data
    {
        [JsonProperty("origin-id")]
        public long OriginId { get; set; }

        [JsonProperty("destination-id")]
        public long DestinationId { get; set; }

        [JsonProperty("departure-date")]
        public DateTimeOffset DepartureDate { get; set; }
    }
}
