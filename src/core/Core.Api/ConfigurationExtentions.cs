using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Core.Api
{
    public static class ConfigurationExtentions
    {
        public static IServiceCollection ResolvePostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql();
            }
                );
            return services;
        }

        //public static IServiceCollection ResolveDependencyInjection(this IServiceCollection services)
        //{
        //    //services.AddScoped<IMongoUserRepository, MongoUserRepository>();

        //    return services;
        //}

        //public static IServiceCollection ResolveSwagger(this IServiceCollection services) {

        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Core.Api", Version = "v1" });
        //    });
        //    return services;
        //}
    }
}
