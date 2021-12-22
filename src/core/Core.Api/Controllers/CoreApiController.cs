using Core.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [ApiController]
    public abstract class CoreApiController : ControllerBase
    {
        protected readonly INotificator _notificator;

        public CoreApiController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected BadRequestObjectResult BadRequestNotificationResult()
        {
            foreach (var error in _notificator.GetNotifications())
            {
                ModelState.AddModelError(error.Label, error.Message);
            }
            var result = BadRequest(ModelState);
            result.StatusCode = _notificator.GetStatusCode();
            return result;
        }
    }
}