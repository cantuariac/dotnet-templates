using ExampleApi.Models;
using Core.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleApi.Services
{
    public interface IUserService : IGenericService<UserDto, int, User>
    {
    }
}
