using Core.Api.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace Example.Api.Data
{
    public class CustomRedisService : RedisService
    {
        public CustomRedisService(IDistributedCache distributedCache) : base(distributedCache)
        {
        }
    }
}
