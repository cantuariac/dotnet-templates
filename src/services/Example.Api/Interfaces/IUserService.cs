using Core.Api.Interfaces;
using Example.Api.Models;

namespace Example.Api.Interfaces
{
    public interface IUserService : IGenericService<User, int, UserDto>
    {
    }
}
