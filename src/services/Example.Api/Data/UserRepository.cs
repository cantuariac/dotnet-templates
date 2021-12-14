using Core.Data;
using Example.Api.Interfaces;
using Example.Api.Models;

namespace Example.Api.Data
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(ExampleDbContext context) : base(context)
        {
        }
    }
}
