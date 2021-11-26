using Newtonsoft.Json;

namespace Obilet.Web.Models.ObiletApiModels.Response.GetBusJourney
{
    public class Feature
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("priority")]
        public long Priority { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty("back-color")]
        public object BackColor { get; set; }

        [JsonProperty("fore-color")]
        public object ForeColor { get; set; }
    }
}
