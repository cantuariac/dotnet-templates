using ApiExemple.Data;
using ApiExemple.Models;
using ApiExemple.Services;
using Core.Api;
using Core.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiExemple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CoreController
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UsersController(INotificator notificator, IUserRepository userRepository, IUserService userService) : base(notificator)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return ObjectOrNotFound(await _userRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto userDto)
        {
            var user = await _userService.Create(userDto);
            return SimpleCreatedResult(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto userDto)
        {
            await _userService.Update(id, userDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
