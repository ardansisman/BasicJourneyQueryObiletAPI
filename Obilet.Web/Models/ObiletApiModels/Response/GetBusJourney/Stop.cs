using Newtonsoft.Json;
using System;

namespace Obilet.Web.Models.ObiletApiModels.Response.GetBusJourney
{
    public class Stop
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("station")]
        public long Station { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonProperty("is-destination")]
        public bool IsDestination { get; set; }
    }
}
