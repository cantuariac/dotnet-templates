using Core.Business.Interfaces;
using ExampleApi.Models;

namespace ExampleApi.Data
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
    }
}
