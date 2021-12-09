using Core.Business.Interfaces;
using Core.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api
{//, ICRUDController<TKey, TEntityDTO>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericEntityController<TEntity, TKey, TEntityDTO> : ControllerBase where TEntity : Entity<TKey> where TKey : IComparable
    {
        protected readonly INotificator _notificator;
        protected readonly IGenericRepository<TEntity, TKey> _repository;
        protected readonly IGenericService<TEntity, TKey, TEntityDTO> _service;

        protected GenericEntityController(INotificator notificator, IGenericRepository<TEntity, TKey> repository, IGenericService<TEntity, TKey, TEntityDTO> service)
        {
            _notificator = notificator;
            _repository = repository;
            _service = service;
        }

        protected ActionResult ObjectOrNotFound(TEntity obj)
        {
            return obj == null ? NotFound() : Ok(obj);
        }

        protected ObjectResult CreatedResult(TEntity obj)
        {
            var action = nameof(TEntity) + "Controller." + nameof(Read);
            return CreatedAtRoute(action, obj.Id, obj);
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
                var action = nameof(TEntity) + "Controller." + nameof(Read);
                return CreatedAtRoute(action, entity.Id, entity);
            }
        }

        [HttpGet]
        public virtual async Task<ActionResult> ReadAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}", Name = nameof(TEntity) + "Controller." + nameof(Read))]
        public virtual async Task<ActionResult> Read(TKey id)
        {
            return ObjectOrNotFound(await _repository.Get(id));
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