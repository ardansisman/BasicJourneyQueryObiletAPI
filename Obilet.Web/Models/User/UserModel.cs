using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web.Models.User
{
    public class UserModel
    {
        public UserModel()
        {
            Ip = default;
            SessionId = default;
            DeviceId = default;
            
        }
        public string Ip { get; set; }
        public string SessionId { get; set; }
        public string DeviceId { get; set; }

    }
}
