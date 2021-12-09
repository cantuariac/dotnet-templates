using Core.Business.Interfaces;
using ExampleApi.Models;

namespace ExampleApi.Services
{
    public interface IUserService : IGenericService<User, int, UserDto>
    {
    }
}
