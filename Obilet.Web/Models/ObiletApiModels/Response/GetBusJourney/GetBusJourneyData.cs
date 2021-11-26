using Newtonsoft.Json;

namespace Obilet.Web.Models.ObiletApiModels.Response.GetBusJourney
{
    public class GetBusJourneyData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("partner-id")]
        public long PartnerId { get; set; }

        [JsonProperty("partner-name")]
        public string PartnerName { get; set; }

        [JsonProperty("route-id")]
        public long RouteId { get; set; }

        [JsonProperty("bus-type")]
        public string BusType { get; set; }

        [JsonProperty("total-seats")]
        public long TotalSeats { get; set; }

        [JsonProperty("available-seats")]
        public long AvailableSeats { get; set; }

        [JsonProperty("journey")]
        public Journey Journey { get; set; }

        [JsonProperty("features")]
        public Feature[] Features { get; set; }

        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }

        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }

        [JsonProperty("is-active")]
        public bool IsActive { get; set; }

        [JsonProperty("origin-location-id")]
        public long OriginLocationId { get; set; }

        [JsonProperty("destination-location-id")]
        public long DestinationLocationId { get; set; }

        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty("cancellation-offset")]
        public long CancellationOffset { get; set; }

        [JsonProperty("has-bus-shuttle")]
        public bool HasBusShuttle { get; set; }

        [JsonProperty("disable-sales-without-gov-id")]
        public bool DisableSalesWithoutGovId { get; set; }

        [JsonProperty("display-offset")]
        public object DisplayOffset { get; set; }

        [JsonProperty("partner-rating")]
        public double PartnerRating { get; set; }
    }
}
