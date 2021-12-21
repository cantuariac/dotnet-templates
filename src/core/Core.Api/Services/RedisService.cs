using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace Core.Api.Services
{
    public class RedisService
    {
        private readonly IDistributedCache _distributedCache;

        public RedisService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task Set(string key, object obj) => await Set(key, obj, DateTime.Now.AddDays(1));
        public async Task Set(string key, object obj, DateTime expiration)
        {
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(expiration);
            var data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(obj));
            await _distributedCache.SetAsync(key, data, options);
        }
        public async Task<T?> Get<T>(string key) where T : class
        {
            var data = await _distributedCache.GetAsync(key);
            if (data is not null)
            {
                return JsonConvert.DeserializeObject<T>(Encoding.ASCII.GetString(data));
            }
            else
            {
                return null;
            }
        }
    }
}
