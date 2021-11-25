using Core.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Data.Interfaces
{
    public interface IGenericRepository<TEntity, IdType> : IDisposable where TEntity : Entity<IdType> where IdType : IComparable
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(IdType id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task Remove(IdType id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }

}
