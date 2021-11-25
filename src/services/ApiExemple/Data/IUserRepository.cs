using ApiExemple.Models;
using Core.Data.Interfaces;

namespace ApiExemple.Data
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
    }
}
