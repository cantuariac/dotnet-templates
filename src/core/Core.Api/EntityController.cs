
using Core.Business;
using Core.Business.Interfaces;
using Core.Data;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Core.Api
{
    public abstract class EntityController<TEntity, TKeyType, TEntityDTO> : ControllerBase, ICRUDController<TKeyType, TEntityDTO>
    {
        protected readonly INotificator _notificator;

        protected EntityController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected ActionResult ObjectOrNotFound(object obj)
        {
            return obj == null ? NotFound() : Ok(obj);
        }

        protected ObjectResult SimpleCreatedResult(object obj, object id)
        {
            var action = this.NameOf() + ".Read";
            return CreatedAtRoute(action, new { id }, obj);
            return new ObjectResult(obj) { StatusCode = StatusCodes.Status201Created };
        }

        protected BadRequestObjectResult NotificationResult(int? status = null)
        {
            foreach (var error in _notificator.GetNotifications()) ModelState.AddModelError(error.Label, error.Message);
            var result = BadRequest(ModelState);
            if (status != null) result.StatusCode = status;
            return result;
        }

        public abstract Task<ActionResult> Create([FromBody] TEntityDTO dto);
        public abstract Task<ActionResult> ReadAll();
        public abstract Task<ActionResult> Read(TKeyType id);
        public abstract Task<ActionResult> Update(TKeyType id, [FromBody] TEntityDTO dto);
        public abstract Task<ActionResult> Delete(TKeyType id);
    }

    public static class Extention
    {
        public static string NameOf(this ControllerBase controller)
        {
            return controller.GetType().Name;
        }
    }
}