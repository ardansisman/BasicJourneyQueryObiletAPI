using Newtonsoft.Json;
using Obilet.Web.Models.ObiletApiModels.Request.GetBusLocation;
using Obilet.Web.Models.ObiletApiModels.Request.GetSession;
using Obilet.Web.Models.ObiletApiModels.Response;
using Obilet.Web.Models.ObiletApiModels.Response.GetBusLocation;
using Obilet.Web.Models.Settings;
using Obilet.Web.Services.Abstract;
using RestSharp;
using System;

namespace Obilet.Web.Services.Concrete
{
    public class ObiletService : IObiletService
    {
        private readonly IObiletApiSettings _obiletApiSettings;
        public ObiletService(IObiletApiSettings obiletApiSettings)
        {
            _obiletApiSettings = obiletApiSettings;
        }

        public GetSessionResponseModel GetSession(GetSessionRequestModel model)
        {
            var client = new RestClient($"{_obiletApiSettings.BaseUrl}{_obiletApiSettings.GetSessionUrl}");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Basic {_obiletApiSettings.ClientToken}");

            var body = JsonConvert.SerializeObject(model, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var myresponse = JsonConvert.DeserializeObject<GetSessionResponseModel>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

            return myresponse;
        }
        public GetBusLocationResponseModel GetBusLocation(GetBusLocationRequestModel model)
        {
            var client = new RestClient($"{_obiletApiSettings.BaseUrl}{_obiletApiSettings.GetBusLocationUrl}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Basic {_obiletApiSettings.ClientToken}");
            
            var body = JsonConvert.SerializeObject(model, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            //var body = @"{" + "\n" +
            //@"    ""data"":null," + "\n" +
            //@"    ""device-session"":{" + "\n" +
            //@"      ""session-id"": ""KrM6Qw6EVHf1EztU+OaAnrmhONGnr4sMrW4rjTEf140=""," + "\n" +
            //@"        ""device-id"": ""+kGLzG31LV2FuprOVnZdd585Ca83NpzDnW/kMlAJb7c=""" + "\n" +
            //@"  }," + "\n" +
            //@"    ""date"":""2016-03-11T11:33:00""," + "\n" +
            //@"    ""language"":""tr-TR""" + "\n" +
            //@"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var myresponse = JsonConvert.DeserializeObject<GetBusLocationResponseModel>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
            return myresponse;
        }
    }
}
