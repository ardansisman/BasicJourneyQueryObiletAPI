using Obilet.Web.Models.ObiletApiModels.Response.GetBusJourney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web.Models.Journey
{
    public class JoruneyModel
    {
        public GetBusJourneyResponseModel JourneyResponseModel { get; set; }
        public string OriginName { get; set; }
        public string DestinationName { get; set; }
        public string DeperatureDate { get; set; }
    }
}
