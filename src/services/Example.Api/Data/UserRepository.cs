using ExampleApi.Models;
using Core.Data;

namespace ExampleApi.Data
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(ExampleDbContext context) : base(context)
        {
        }
    }
}
