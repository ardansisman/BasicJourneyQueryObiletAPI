using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web.Services.Abstract
{
    public interface IRedisCacheService
    {
        T Get<T>(string key);
        IList<T> GetAll<T>(string key);
        void Set(string key, object data);
        void Set(string key, object data, DateTime time);
        void SetAll<T>(IDictionary<string, T> values);
        bool IsSet(string key);
        void Remove(string key);
        void Clear();
        int Count(string key);
    }
}
