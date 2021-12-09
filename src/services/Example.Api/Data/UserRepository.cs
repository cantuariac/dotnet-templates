using Core.Data;
using ExampleApi.Models;

namespace ExampleApi.Data
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(ExampleDbContext context) : base(context)
        {
        }
    }
}
