using Core.Business;
using Core.Business.Interfaces;
using ExampleApi.Data;
using ExampleApi.Models;

namespace ExampleApi.Services
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
            return new User(entityDto.Username, "");
        }

        //public async Task<User> Create(UserDto entityDto)
        //{
        //    var user = new User(entityDto.Username, "");
        //    await userRepository.Add(user);
        //    return user;
        //}

        //public async Task Update(int id, UserDto entityDto)
        //{
        //    var user = new User(entityDto.Username, "");
        //    await userRepository.Update(user);
        //}

        //public async Task Delete(int id)
        //{
        //    await userRepository.Remove(id);
        //}
    }
}
