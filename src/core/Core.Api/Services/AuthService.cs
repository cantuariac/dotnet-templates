using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Services
{
    public class AuthService
    {
        private readonly byte[] _secret;

        public AuthService(string secret)
        {
            _secret = Encoding.ASCII.GetBytes(secret);
        }

        /*
         new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes., usuario.Email),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                })
         */
        private string GenerateToken(ClaimsIdentity identity, DateTime expiration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = expiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
