using Core.Business;
using Core.Business.Interfaces;
using Example.Api.Interfaces;
using Example.Api.Models;

namespace Example.Api.Services
{
    public class UserService : GenericService<User, int, UserDto>, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(INotificator notificator, IUserRepository userRepository) : base(notificator, userRepository)
        {
            this.userRepository = userRepository;
        }

        public override User MapFrom(UserDto entityDto)
        {
            return new User(entityDto.Username, User.HashPassword(entityDto.Password));
        }
    }
}
