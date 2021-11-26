using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web.Models.ObiletApiModels.Request.GetSession
{
    public class Application
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }
    }
}
