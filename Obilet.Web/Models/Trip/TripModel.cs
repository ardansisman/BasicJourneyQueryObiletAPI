using Obilet.Web.Models.ObiletApiModels.Response.GetBusLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web.Models.Trip
{
    public class TripModel
    {
        public GetBusLocationResponseModel BusLocations { get; set; }
        public long OriginId { get; set; }
        public long DestinationId { get; set; }
        public DateTimeOffset DepartureDate { get; set; }
    }
}
