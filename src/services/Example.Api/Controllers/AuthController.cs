using Core.Api.Controllers;
using Core.Api.Interfaces;
using Core.Api.Services;
using Example.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : CoreAuthController<SignInDTO, SignUpDTO>
    {
        private readonly IUserService _userService;
        public AuthController(INotificator notificator, AuthService authService, IUserService userService) : base(notificator, authService)
        {
            _userService = userService;
        }

        public override async Task<IActionResult> SignIn(SignInDTO signInDTO)
        {
            return Ok();
        }

        public override Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {
            throw new NotImplementedException();
        }
    }
    public class SignInDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class SignUpDTO
    {
    }
}
