using Core.Api.Interfaces;
using Core.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("[auth]")]
    public abstract class CoreAuthController<TSignInDTO, TSignUpDTO> : CoreApiController
    {
        private readonly AuthService _authService;

        public CoreAuthController(INotificator notificator, AuthService authService) : base(notificator)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("[action]")]
        public abstract Task<IActionResult> SignUp(TSignUpDTO signUpDTO);

        [HttpPost]
        [Route("[action]")]
        public abstract Task<IActionResult> SignIn(TSignInDTO signInDTO);
    }
}
