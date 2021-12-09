using Core.Business.Interfaces;
using Core.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Data
{
    public abstract class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : Entity<TKey> where TKey : IComparable
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> Get(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                await SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
                await SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }

        public virtual async Task<bool> Remove(TEntity entity)
        {
            try
            {
                DbSet.Remove(entity);
                await SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public virtual async Task<bool> Remove(TKey id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null)
            {
                return await Remove(entity);
            }
            else
            {
                return false;
            }

        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
