using ApiExemple.Data;
using ApiExemple.Models;
using Core.Business;
using Core.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExemple.Services
{
    public class UserService : CoreService, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository, INotificator notificator) : base(notificator)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> Create(UserDto entityDto)
        {
            var user = new User(entityDto.Username);
            await userRepository.Add(user);
            return user;
        }

        public async Task Update(int id, UserDto entityDto)
        {
            var user = new User(entityDto.Username);
            await userRepository.Update(user);
        }

        public async Task Delete(int id)
        {
            await userRepository.Remove(id);
        }
    }
}
