using Core.Business.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class GenericMongoRepository<T> : IGenericMongoRepository<T>
    {
        protected IMongoCollection<T> Collection;


        public GenericMongoRepository(IMongoClient mongoClient, String dbName)
        {
            var database = mongoClient.GetDatabase(dbName);
            Collection = database.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public async Task Create(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task Delete(Expression<Func<T, bool>> function)
        {
            await Collection.DeleteOneAsync(function);
        }

        public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> function)
        {
            return await Task.Run(() => Collection.FindAsync(function).Result.ToEnumerable());
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> function)
        {
            return await Task.Run(() => FindBy(function).Result.Any());
        }

        public async Task Update(Expression<Func<T, bool>> function, T entity)
        {
            await Collection.ReplaceOneAsync(function, entity);
        }
    }
}
