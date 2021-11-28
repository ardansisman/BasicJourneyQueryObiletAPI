using Obilet.Web.Models.ObiletApiModels.Request.GetBusJourney;
using Obilet.Web.Models.ObiletApiModels.Request.GetBusLocation;
using Obilet.Web.Models.ObiletApiModels.Request.GetSession;
using Obilet.Web.Models.ObiletApiModels.Response;
using Obilet.Web.Models.ObiletApiModels.Response.GetBusJourney;
using Obilet.Web.Models.ObiletApiModels.Response.GetBusLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web.Services.Abstract
{
   public interface IObiletService
    {
        GetSessionResponseModel GetSession(GetSessionRequestModel model);
        GetBusLocationResponseModel GetBusLocation(GetBusLocationRequestModel model);
        GetBusJourneyResponseModel GetJourney(GetBusJourneyRequestModel model);
    }
}
