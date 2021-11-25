
using Core.Business;
using Core.Business.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api
{
    public abstract class CoreController : ControllerBase
    {
        protected readonly INotificator _notificator;

        protected CoreController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected ActionResult ObjectOrNotFound(object obj)
        {
            return obj == null ? NotFound() : Ok(obj);
        }

        protected ObjectResult SimpleCreatedResult(object obj)
        {
            return new ObjectResult(obj) { StatusCode = StatusCodes.Status201Created };
        }

        protected BadRequestObjectResult NotificationResult(int? status = null)
        {
            foreach (var error in _notificator.GetNotifications()) ModelState.AddModelError(error.Label, error.Message);
            var result = BadRequest(ModelState);
            if (status != null) result.StatusCode = status;
            return result;
        }

        //protected bool Validate<TValidator, TEntity>(TValidator validator, TEntity entity) where TValidator : AbstractValidator<TEntity>
        //{
        //    var result = validator.Validate(entity);

        //    if (result.IsValid)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            Notify(error.ErrorMessage);
        //        }
        //        return false;
        //    }
        //}

        //protected void Notify(string message)
        //{
        //    _notificator.Notify(new Notification(message));
        //}

        //protected void Notify(string message, string label)
        //{
        //    _notificator.Notify(new Notification(message, label));
        //}
    }
}