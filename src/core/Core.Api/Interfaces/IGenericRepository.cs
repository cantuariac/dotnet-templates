using Core.Api.Models;
using System.Linq.Expressions;

namespace Core.Api.Interfaces
{
    public interface IGenericRepository<TEntity, TKey> : IDisposable where TEntity : Entity<TKey> where TKey : IComparable
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity?> Get(TKey id);
        bool Exists(TKey id);
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Remove(TEntity entity);
        Task<bool> Remove(TKey id);
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }

}
