using Example.Api.Data;
using Example.Api.Interfaces;
using Example.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IQuoteMongoRepository _quoteRepository;
        private readonly CustomRedisService _redisRepository;

        public TestController(IQuoteMongoRepository quoteRepository, CustomRedisService redisRepository)
        {
            _quoteRepository = quoteRepository;
            _redisRepository = redisRepository;
        }

        [HttpPost("mongo")]
        public async Task<ActionResult> TestMongoDB()
        {
            var quote = new Quote() { Author = "fulano", Text = "Deu bom!" };
            await _quoteRepository.Create(quote);
            return Ok();
        }

        [HttpPost("redis")]
        public async Task<ActionResult> TestRedis()
        {
            var obj = await _redisRepository.Get<Cache>("test");
            await _redisRepository.Set("test", new Cache
            {
                Timestamp = DateTime.UtcNow,
                Data = "Cached object"
            });
            return Ok(obj);
        }
        class Cache
        {
            public DateTime Timestamp { get; set; }
            public string Data { get; set; }
        }
    }
}
