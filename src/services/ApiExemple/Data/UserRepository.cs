using ApiExemple.Models;
using Core.Data;

namespace ApiExemple.Data
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(ExempleDbContext context) : base(context)
        {
        }
    }
}
