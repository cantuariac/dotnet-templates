
using Core.Business.Interfaces;
using Core.Business.Models;
using FluentValidation;

namespace Core.Business
{
    public abstract class GenericService<TEntity, TKey, TEntityDto> : IGenericService<TEntity, TKey, TEntityDto>
                                                    where TEntity : Entity<TKey>
                                                    where TKey : IComparable
                                                    where TEntityDto : IValidatable
    {
        protected readonly INotificator _notificator;
        protected readonly IGenericRepository<TEntity, TKey> _repository;

        protected GenericService(INotificator notificator, IGenericRepository<TEntity, TKey> repository)
        {
            _notificator = notificator;
            _repository = repository;
        }

        public async Task<List<TEntity>> ReadAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity?> Create(TEntityDto entityDto)
        {
            if (!Validate(entityDto))
            {
                return null;
            }
            var user = MapFrom(entityDto);
            if (!await _repository.Add(user))
            {
                _notificator.Notify($"Erro interno do servidor");
                _notificator.SetStatusCode(500);
            }
            return user;
        }
        public async Task<TEntity?> Read(TKey id)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
            {
                _notificator.Notify($"Não existe um {typeof(TEntity).Name} com {nameof(id)} = {id}");
                _notificator.SetStatusCode(404);
                return null;
            }
            else
            {
                return entity;
            }
        }

        public async Task Update(TKey id, TEntityDto entityDto)
        {
            if (!_repository.Exists(id))
            {
                _notificator.Notify($"Não existe um {typeof(TEntity).Name} com {nameof(id)} = {id}");
                _notificator.SetStatusCode(404);
            }
            else
            {
                var user = MapFrom(entityDto);
                user.Id = id;
                if (!await _repository.Update(user))
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
                _notificator.Notify($"Não existe um {typeof(TEntity).Name} com {nameof(id)} = {id}");
                _notificator.SetStatusCode(404);
            }
            else if (!await _repository.Remove(id))
            {
                _notificator.Notify($"Erro interno do servidor");
                _notificator.SetStatusCode(500);
            }
        }

        public abstract TEntity MapFrom(TEntityDto entityDto);

        protected bool Validate(TEntityDto entityDto)
        {
            var result = entityDto.Validate();

            if (result.IsValid)
            {
                return true;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    _notificator.Notify(error.ErrorMessage);
                }
                return false;
            }
        }
    }
}