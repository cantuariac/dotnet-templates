using Core.Api.Controllers;
using Core.Api.Interfaces;
using Example.Api.Interfaces;
using Example.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    public class UsersController : GenericEntityController<User, int, UserDto>
    {

        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(INotificator notificator, IUserService userService, ILogger<UsersController> logger) : base(notificator, userService)
        {
            _userService = userService;
            _logger = logger;
        }

        [ActionName($"{nameof(Models.User)}.{nameof(Read)}")]
        public override Task<ActionResult> Read(int id)
        {
            var action = $"{nameof(Models.User)}.{nameof(Read)}";
            _logger.LogInformation(action);
            return base.Read(id);
        }
    }
}
