﻿using Core.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Api.Configurations
{
    public static class AuthExtentions
    {

        public static IServiceCollection ResolveJWT(this IServiceCollection services, string secret)
        {
            var secret_bytes = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secret_bytes),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddScoped(_=>new AuthService(secret));
            return services;
        }
    }
}
