using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web.Models.Settings
{
    public class RedisSettings: IRedisSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }
        public int Database { get; set; }
    }
}
