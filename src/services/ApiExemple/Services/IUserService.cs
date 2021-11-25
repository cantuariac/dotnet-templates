using ApiExemple.Models;
using Core.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExemple.Services
{
    public interface IUserService : IGenericService<UserDto, int, User>
    {
    }
}
