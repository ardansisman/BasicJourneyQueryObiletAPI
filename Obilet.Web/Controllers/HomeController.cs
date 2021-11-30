using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Obilet.Web.Models;
using Obilet.Web.Models.Journey;
using Obilet.Web.Models.ObiletApiModels.Request.Common;
using Obilet.Web.Models.ObiletApiModels.Request.GetBusJourney;
using Obilet.Web.Models.ObiletApiModels.Request.GetBusLocation;
using Obilet.Web.Models.ObiletApiModels.Request.GetSession;
using Obilet.Web.Models.ObiletApiModels.Response.GetBusLocation;
using Obilet.Web.Models.Trip;
using Obilet.Web.Models.User;
using Obilet.Web.Services.Abstract;
using System;
using System.Linq;

namespace Obilet.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Dependency Injection
        private readonly ILogger<HomeController> _logger;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IObiletService _obiletService;

        public const string User = "User:{0}";
        public const string BusLocations = "BusLocations";

        public HomeController(ILogger<HomeController> logger, IRedisCacheService redisCacheService, IObiletService obiletService)
        {
            _logger = logger;
            _redisCacheService = redisCacheService;
            _obiletService = obiletService;
        }
        #endregion
        public IActionResult Index()
        {
            #region User IP, RedisCache Info and Response Model Instance
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            var cacheKeyUser = string.Format(User, ip);
            var userResult = _redisCacheService.Get<UserModel>(cacheKeyUser);

            GetBusLocationResponseModel busLocationResponse = new();
            #endregion

            #region In memory User 
            if (userResult != null)
            {
                #region GetBusLocation Request
                busLocationResponse = _obiletService.GetBusLocation(new GetBusLocationRequestModel { Language = "tr-TR", DeviceSession = new DeviceSession { DeviceId = userResult.DeviceId, SessionId = userResult.SessionId }, Date = DateTimeOffset.Now });

                if (busLocationResponse.Status.ToLower() == "success")
                {
                    var cacheKeyBusLocations = string.Format(BusLocations);
                    _redisCacheService.Set(cacheKeyBusLocations, busLocationResponse);
                    return View(new TripModel { BusLocations = busLocationResponse, LastSearchModel = new LastSearchModel { LastOriginId = userResult.LastSearchModel.LastOriginId, LastDestinationId = userResult.LastSearchModel.LastDestinationId, LastDepartureDate = userResult.LastSearchModel.LastDepartureDate } });
                }
                else
                {
                    TempData["message"] = busLocationResponse.UserMessage;
                    return View(new TripModel { BusLocations = new GetBusLocationResponseModel(), LastSearchModel = new LastSearchModel() });
                }
                #endregion
            }
            #endregion

            #region Not in memory User
            else
            {
                #region GetSession Request
                var response = _obiletService.GetSession(new GetSessionRequestModel { Connection = new Connection { IpAddress = ip, Port = 5117 }, Browser = new Browser { Name = "Chrome", Version = "47.0.0.12" }, Type = 1 });

                if (response.Status.ToLower() == "success")
                {
                    var cacheKeyBusLocations = string.Format(BusLocations);
                    _redisCacheService.Set(cacheKeyBusLocations, busLocationResponse);
                    var user = new UserModel { Ip = ip, SessionId = response.Data.SessionId, DeviceId = response.Data.DeviceId };
                    _redisCacheService.Set(cacheKeyUser, user);
                }
                else
                {
                    TempData["message"] = response.UserMessage;
                    return View(new TripModel { BusLocations = new GetBusLocationResponseModel(), LastSearchModel = new LastSearchModel() });
                }
                #endregion
                #region GetBusLocation Request
                busLocationResponse = _obiletService.GetBusLocation(new GetBusLocationRequestModel { Language = "tr-TR", DeviceSession = new DeviceSession { DeviceId = response.Data.DeviceId, SessionId = response.Data.SessionId }, Date = DateTimeOffset.Now });
                if (busLocationResponse.Status.ToLower() == "success")
                {
                    return View(new TripModel { BusLocations = busLocationResponse, LastSearchModel = new LastSearchModel() });

                }
                else
                {
                    TempData["message"] = busLocationResponse.UserMessage;
                    return View(new TripModel { BusLocations = new GetBusLocationResponseModel(), LastSearchModel = new LastSearchModel() });

                }
                #endregion
            }
            #endregion

        }

        [HttpPost]
        public IActionResult GetBusJourney(TripModel data)
        {
            #region Validation
            if (data.OriginId == data.DestinationId)
            {
                TempData["message"] = "Kalkış ve varış yerleri farklı olmalıdır.";
                return RedirectToAction("Index");
            }
            if (data.DepartureDate.DateTime < DateTimeOffset.Now.DateTime.Date)
            {
                TempData["message"] = "Tarih seçimi bugün veya bugünden sonra olmalıdır.";
                return RedirectToAction("Index");
            }
            #endregion

            #region Update UserInfo in Redis Cache
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            var cacheKeyUser = string.Format(User, ip);

            var userResult = _redisCacheService.Get<UserModel>(cacheKeyUser);
            _redisCacheService.Remove(cacheKeyUser);
            var user = new UserModel { Ip = userResult.Ip, SessionId = userResult.SessionId, DeviceId = userResult.DeviceId, LastSearchModel = new LastSearchModel { LastOriginId = data.OriginId, LastDestinationId = data.DestinationId, LastDepartureDate = data.DepartureDate } };
            _redisCacheService.Set(cacheKeyUser, user);
            #endregion

            #region Set BusLocation in Redis Cache
            var cacheKeyBusLocations = string.Format(BusLocations);
            var busLocations = _redisCacheService.Get<GetBusLocationResponseModel>(cacheKeyBusLocations);
            #endregion

            #region GetJourney Request
            var journeysResponse = _obiletService.GetJourney(new GetBusJourneyRequestModel { DeviceSession = new DeviceSession { DeviceId = userResult.DeviceId, SessionId = userResult.SessionId }, Data = new Data { OriginId = data.OriginId, DestinationId = data.DestinationId, DepartureDateStr = data.DepartureDate.DateTime.ToString("yyyy-MM-dd") }, Language = "tr-TR", Date = data.DepartureDate.ToString("yyyy-MM-dd") });
            journeysResponse.Data = journeysResponse.Data.OrderBy(x => x.Journey.Departure).ToArray();

            if (journeysResponse.Status.ToLower() == "success")
            {
                return View("Journeys", new JoruneyModel { JourneyResponseModel = journeysResponse, OriginName = busLocations.Data.Where(x => x.Id == data.OriginId).FirstOrDefault().Name, DestinationName = busLocations.Data.Where(x => x.Id == data.DestinationId).FirstOrDefault().Name, DeperatureDate = data.DepartureDate.ToString("dd MMMM dddd") });
            }
            else
            {
                TempData["message"] = journeysResponse.UserMessage;
                return RedirectToAction("Index");
            }
            #endregion

        }

    }
}
