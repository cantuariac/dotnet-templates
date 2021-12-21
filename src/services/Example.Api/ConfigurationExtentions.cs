using Core.Api.Services;
using Core.Api.Interfaces;
using Example.Api.Data;
using Example.Api.Interfaces;
using Example.Api.Services;
using Microsoft.OpenApi.Models;

namespace Example.Api
{
    public static class ConfigurationExtentions
    {
        public static IServiceCollection ResolveDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<INotificator, Notificator>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IQuoteMongoRepository, QuoteMongoRepository>();
            services.AddScoped<CustomRedisService>();

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
