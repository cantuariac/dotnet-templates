
using Core.Business.Interfaces;
using Core.Business.Models;

namespace Core.Business
{
    public abstract class GenericService<TEntity, TKey, TEntityDto> : IGenericService<TEntity, TKey, TEntityDto> where TEntity : Entity<TKey> where TKey : IComparable
    {
        protected readonly INotificator _notificator;
        protected readonly IGenericRepository<TEntity, TKey> _repository;

        protected GenericService(INotificator notificator, IGenericRepository<TEntity, TKey> repository)
        {
            _notificator = notificator;
            _repository = repository;
        }

        public async Task<TEntity> Create(TEntityDto entityDto)
        {
            var user = MapFrom(entityDto);
            if (!await _repository.Add(user))
            {
                _notificator.Notify($"Erro interno do servidor");
                _notificator.SetStatusCode(500);
            }
            return user;
        }

        public async Task Update(TKey id, TEntityDto entityDto)
        {
            if (await _repository.Get(id) == null)
            {
                _notificator.Notify($"Não existe um {nameof(TEntity)} com {nameof(id)} = {id}");
                _notificator.SetStatusCode(404);
            }
            else
            {
                var user = MapFrom(entityDto);
                user.Id = id;
                if(!await _repository.Update(user))
                {
                    _notificator.Notify($"Erro interno do servidor");
                    _notificator.SetStatusCode(500);
                }
            }
        }

        public async Task Delete(TKey id)
        {
            if (await _repository.Get(id) == null)
            {
                _notificator.Notify($"Não existe um {nameof(TEntity)} com {nameof(id)} = {id}");
                _notificator.SetStatusCode(404);
            }
            else if (!await _repository.Remove(id))
            {
                _notificator.Notify($"Erro interno do servidor");
                _notificator.SetStatusCode(500);
            }
        }

        public abstract TEntity MapFrom(TEntityDto entityDto);

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