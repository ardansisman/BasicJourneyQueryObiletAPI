using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web.Models.ObiletApiModels.Request.GetSession
{
    public class GetSessionRequestModel
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("connection")]
        public Connection Connection { get; set; }

        [JsonProperty("browser")]
        public Browser Browser { get; set; }
    }
}
