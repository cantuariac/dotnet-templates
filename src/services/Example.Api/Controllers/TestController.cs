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
        private readonly CustomRedisRepositoty _redisRepository;

        public TestController(IQuoteMongoRepository quoteRepository, CustomRedisRepositoty redisRepository)
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
            var obj = await _redisRepository.Get<object>("test");
            await _redisRepository.Set("test", new
            {
                timestamp = DateTime.UtcNow,
                cache = "Cached object"
            });
            return Ok(obj);
        }

    }
}
