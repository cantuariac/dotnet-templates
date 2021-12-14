using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace Core.Data
{
    public class RedisRepository
    {
        private readonly IDistributedCache _distributedCache;

        public RedisRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task Set(string key, object obj)
        {
            var data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(obj));
            await _distributedCache.SetAsync(key, data);
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
