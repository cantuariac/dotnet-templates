using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Interfaces
{

    public interface IGenericMongoRepository<T>
    {
        Task Create(T entity);

        Task Delete(Expression<Func<T, bool>> function);

        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> function);

        Task<bool> Exists(Expression<Func<T, bool>> function);

        Task Update(Expression<Func<T, bool>> function, T entity);
    }
}
