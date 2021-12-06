using ExampleApi.Models;
using Core.Data.Interfaces;

namespace ExampleApi.Data
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
    }
}
