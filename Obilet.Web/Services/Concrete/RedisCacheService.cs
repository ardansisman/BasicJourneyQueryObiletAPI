using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Obilet.Web.Models.Settings;
using Obilet.Web.Services.Abstract;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Web.Services.Concrete
{
    public class RedisCacheService: IRedisCacheService
    {
        private readonly RedisEndpoint conf = null;
        public readonly IOptions<RedisSettings> _redisConfiguration;


        public RedisCacheService(IOptions<RedisSettings> redisConfiguration)
        {
            _redisConfiguration = redisConfiguration;
            conf = new RedisEndpoint { Db = _redisConfiguration.Value.Database, Host = _redisConfiguration.Value.Host, Port = _redisConfiguration.Value.Port, RetryTimeout = 1000 };
        }
        public T Get<T>(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    return client.Get<T>(key);
                }
            }
            catch
            {
                //throw new RedisNotAvailableException();
                return default;
            }
        }

        public IList<T> GetAll<T>(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    var keys = client.SearchKeys(key);
                    if (keys.Any())
                    {
                        IEnumerable<T> dataList = client.GetAll<T>(keys).Values;
                        return dataList.ToList();
                    }
                    return new List<T>();
                }
            }
            catch
            {

                throw new System.Exception();
            }
        }

        public void Set(string key, object data)
        {
            Set(key, data, DateTime.Now.AddMinutes(_redisConfiguration.Value.Timeout));
        }

        public void Set(string key, object data, DateTime time)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    var dataSerialize = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    });
                    client.Set(key, Encoding.UTF8.GetBytes(dataSerialize), time);
                }
            }
            catch
            {
                //throw new RedisNotAvailableException();                
            }
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    client.SetAll(values);
                }
            }
            catch
            {

                throw new System.Exception();
            }

        }

        public int Count(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    return client.SearchKeys(key).Where(s => s.Contains(":") && s.Contains("Mobile-RefreshToken")).ToList().Count;
                }
            }
            catch
            {

                throw new System.Exception();
            }
        }

        public bool IsSet(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    return client.ContainsKey(key);
                }
            }
            catch
            {

                throw new System.Exception();
            }
        }

        public void Remove(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    client.Remove(key);
                }
            }
            catch
            {
                throw new System.Exception();
            }
        }
        
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
