using Core.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business.Interfaces
{
    public interface IGenericService<TEntityDto, IdType, TEntity>
    {
        Task<TEntity> Create(TEntityDto entityDto);
        Task Update(IdType id, TEntityDto entityDto);
        Task Delete(IdType id);

    }
}
