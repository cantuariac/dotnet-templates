using Core.Business.Interfaces;
using Example.Api.Models;

namespace Example.Api.Interfaces
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
    }
}
