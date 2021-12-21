using Core.Api.Models;

namespace Core.Api.Interfaces
{
    public interface IGenericService<TEntity, TKey, TEntityDto> where TEntity : Entity<TKey> where TKey : IComparable
    {
        Task<List<TEntity>> ReadAll();
        Task<TEntity?> Create(TEntityDto entityDto);
        Task<TEntity?> Read(TKey id);
        Task Update(TKey id, TEntityDto entityDto);
        Task Delete(TKey id);

    }
}
