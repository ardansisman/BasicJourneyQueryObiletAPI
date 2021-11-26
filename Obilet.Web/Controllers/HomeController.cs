﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Obilet.Web.Models;
using Obilet.Web.Models.ObiletApiModels.Request.Common;
using Obilet.Web.Models.ObiletApiModels.Request.GetBusLocation;
using Obilet.Web.Models.ObiletApiModels.Request.GetSession;
using Obilet.Web.Models.ObiletApiModels.Response.GetBusLocation;
using Obilet.Web.Models.Trip;
using Obilet.Web.Models.User;
using Obilet.Web.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Obilet.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IObiletService _obiletService;

        public const string User = "User:{0}";

        public HomeController(ILogger<HomeController> logger, IRedisCacheService redisCacheService, IObiletService obiletService)
        {
            _logger = logger;
            _redisCacheService = redisCacheService;
            _obiletService = obiletService;
        }

        public IActionResult Index()
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            var cacheKeyUser = string.Format(User, ip);
            var userResult = _redisCacheService.Get<UserModel>(cacheKeyUser);

            GetBusLocationResponseModel busLocationResponse = new();
            if (userResult == null) // rediste user yoksa GetSession çalışıyor
            {
                var response = _obiletService.GetSession(new GetSessionRequestModel { Connection = new Connection { IpAddress = ip, Port = 5117 }, Browser = new Browser { Name = "Chrome", Version = "47.0.0.12" }, Type = 1 });
                if (response.Status.ToLower() == "success")
                {
                    var user = new UserModel { Ip = ip, SessionId = response.Data.SessionId, DeviceId = response.Data.DeviceId };
                    _redisCacheService.Set(cacheKeyUser, user);
                }
                else
                {
                    //Obilet Apiden Session alırken hata oluştu
                }

              busLocationResponse=  _obiletService.GetBusLocation(new GetBusLocationRequestModel { Language = "tr-TR", DeviceSession = new DeviceSession { DeviceId = response.Data.DeviceId, SessionId = response.Data.SessionId }, Date = DateTimeOffset.Now });
                if (busLocationResponse.Status.ToLower()=="success")
                {
                    //buslocation çekilirken hata oluştu
                }
            }
            else
            {
                busLocationResponse = _obiletService.GetBusLocation(new GetBusLocationRequestModel { Language = "tr-TR", DeviceSession = new DeviceSession { DeviceId = userResult.DeviceId, SessionId = userResult.SessionId }, Date = DateTimeOffset.Now });
                if (busLocationResponse.Status.ToLower() == "success")
                {
                    //buslocation çekilirken hata oluştu
                }
            }
           
            return View(new TripModel {BusLocations=busLocationResponse });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}