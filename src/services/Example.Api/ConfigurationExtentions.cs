using Core.Business;
using Core.Business.Interfaces;
using ExampleApi.Data;
using ExampleApi.Services;
using Microsoft.OpenApi.Models;

namespace ExampleApi
{
    public static class ConfigurationExtentions
    {
        public static IServiceCollection ResolveDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection ResolveSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiExemple", Version = "v1" });
            });
            return services;
        }
    }
}
