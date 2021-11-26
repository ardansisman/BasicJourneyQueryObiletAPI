using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web.Models.Settings
{
    public class ObiletApiSettings:IObiletApiSettings
    {
        public string BaseUrl { get; set; }
        public string GetSessionUrl { get; set; }
        public string GetBusLocationUrl { get; set; }
        public string GetBusJourneyUrl { get; set; }
        public string ClientToken { get; set; }
    }
}
