using ExampleApi.Data;
using ExampleApi.Models;
using ExampleApi.Services;
using Core.Api;
using Core.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CoreController, ICRUDController<int, UserDto>
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UsersController(INotificator notificator, IUserRepository userRepository, IUserService userService) : base(notificator)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> ReadAll()
        {
            return Ok(await _userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Read(int id)
        {
            return ObjectOrNotFound(await _userRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDto userDto)
        {
            var user = await _userService.Create(userDto);
            return CreatedAtAction(nameof(Read),user);
            return SimpleCreatedResult(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserDto userDto)
        {
            await _userService.Update(id, userDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
