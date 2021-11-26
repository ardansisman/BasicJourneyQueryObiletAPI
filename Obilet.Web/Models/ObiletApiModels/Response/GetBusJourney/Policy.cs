using Newtonsoft.Json;

namespace Obilet.Web.Models.ObiletApiModels.Response.GetBusJourney
{
    public class Policy
    {
        [JsonProperty("max-seats")]
        public object MaxSeats { get; set; }

        [JsonProperty("max-single")]
        public object MaxSingle { get; set; }

        [JsonProperty("max-single-males")]
        public object MaxSingleMales { get; set; }

        [JsonProperty("max-single-females")]
        public object MaxSingleFemales { get; set; }

        [JsonProperty("mixed-genders")]
        public bool MixedGenders { get; set; }

        [JsonProperty("gov-id")]
        public bool GovId { get; set; }

        [JsonProperty("lht")]
        public bool Lht { get; set; }
    }
}
