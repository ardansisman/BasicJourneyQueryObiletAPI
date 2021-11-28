using Obilet.Web.Models.ObiletApiModels.Response.GetBusLocation;
using Obilet.Web.Models.User;
using System;

namespace Obilet.Web.Models.Trip
{
    public class TripModel
    {
        public GetBusLocationResponseModel BusLocations { get; set; }
        
        public long OriginId { get; set; }

        public long DestinationId { get; set; }

        public DateTimeOffset DepartureDate { get; set; }
        public LastSearchModel LastSearchModel { get; set; }
       
    }
}
