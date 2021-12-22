using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Interfaces
{
    public interface IAuthService<TSignInDTO>
    {
        Task SignIn(TSignInDTO signInDTO);
    }
}
