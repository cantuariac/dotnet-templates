using Core.Api.Interfaces;
using Core.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [ApiController]
    public abstract class GenericEntityController<TEntity, TKey, TEntityDTO> : CoreApiController
                                                    where TEntity : Entity<TKey>
                                                    where TKey : IComparable
    {
        protected readonly IGenericEntityService<TEntity, TKey, TEntityDTO> _service;

        protected GenericEntityController(INotificator notificator, IGenericEntityService<TEntity, TKey, TEntityDTO> service) : base(notificator)
        {
            _service = service;
        }

        protected ActionResult ObjectOrNotFound(TEntity? obj)
        {
            return obj == null ? NotFound() : Ok(obj);
        }

        protected ObjectResult CreatedResult(TEntity obj)
        {
            return new ObjectResult(obj) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet]
        public virtual async Task<ActionResult> ReadAll()
        {
            return Ok(await _service.ReadAll());
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create([FromBody] TEntityDTO dto)
        {
            var entity = await _service.Create(dto);
            if (_notificator.CheckNotifications())
            {
                return BadRequestNotificationResult();
            }
            else
            {
                var action = typeof(TEntity).Name + "." + nameof(Read);
                return CreatedResult(entity);
            }
        }

        [HttpGet("{id}")]
        //[ActionName($"{typeof(TEntity)}.{nameof(Read)}")]
        public virtual async Task<ActionResult> Read(TKey id)
        {
            //var name = typeof(TEntity).Name + "." + nameof(Read);
            //_ = new ActionNameAttribute(name);
            return ObjectOrNotFound(await _service.Read(id));
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update(TKey id, [FromBody] TEntityDTO userDto)
        {
            await _service.Update(id, userDto);
            if (_notificator.CheckNotifications())
            {
                return BadRequestNotificationResult();
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(TKey id)
        {
            await _service.Delete(id);
            if (_notificator.CheckNotifications())
            {
                return BadRequestNotificationResult();
            }
            else
            {
                return Ok();
            }
        }
    }
}