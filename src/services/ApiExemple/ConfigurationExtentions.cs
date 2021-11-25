using ApiExemple.Data;
using ApiExemple.Services;
using Core.Business;
using Core.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ApiExemple
{
    public static class ConfigurationExtentions
    {
        public static IServiceCollection ResolvePostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExempleDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql(connectionString);
            }
                );
            return services;
        }

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
