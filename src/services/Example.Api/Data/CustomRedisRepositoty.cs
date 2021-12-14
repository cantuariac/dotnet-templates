using Core.Data;
using Microsoft.Extensions.Caching.Distributed;

namespace Example.Api.Data
{
    public class CustomRedisRepositoty : RedisRepository
    {
        public CustomRedisRepositoty(IDistributedCache distributedCache) : base(distributedCache)
        {
        }
    }
}
