using Core.Api;
using Core.Business.Interfaces;
using ExampleApi.Data;
using ExampleApi.Models;
using ExampleApi.Services;

namespace ExampleApi.Controllers
{
    public class UsersController : GenericEntityController<User, int, UserDto>
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UsersController(INotificator notificator, IUserRepository userRepository, IUserService userService) : base(notificator, userRepository, userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        //[HttpGet]
        //public override async Task<ActionResult> ReadAll()
        //{
        //    Console.WriteLine("overhide ReadAll UsersController");
        //    return Ok(await _userRepository.GetAll());
        //}

        //[HttpGet("{id}", Name = nameof(UsersController) + "." + nameof(Read))]
        //public override async Task<ActionResult> Read(int id)
        //{
        //    return ObjectOrNotFound(await _userRepository.Get(id));
        //}

        //[HttpPost]
        //public override async Task<ActionResult> Create([FromBody] UserDto userDto)
        //{
        //    var user = await _userService.Create(userDto);
        //    //var action = this.NameOf() + "." + nameof(Read);
        //    //return CreatedAtRoute(action, new { id = user.Id }, user);
        //    return SimpleCreatedResult(user, user.Id);
        //}

        //[HttpPut("{id}")]
        //public override async Task<ActionResult> Update(int id, [FromBody] UserDto userDto)
        //{
        //    await _userService.Update(id, userDto);
        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public override async Task<ActionResult> Delete(int id)
        //{
        //    Console.WriteLine("overridden Delete@UsersController");
        //    await _userService.Delete(id);
        //    return Ok();
        //}
    }
}
