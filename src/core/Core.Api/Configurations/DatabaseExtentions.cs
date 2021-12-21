using Core.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Core.Api.Configurations
{
    public static class DatabaseExtentions
    {
        public static IServiceCollection ResolvePostgres<T>(this IServiceCollection services, String connectionString) where T : DbContext
        {
            services.AddDbContext<T>(options =>
            {
                options.UseNpgsql(connectionString);
            }
                );
            return services;
        }

        public static IServiceCollection ResolveMongoDB<TContext>(this IServiceCollection services, String connectionString) where TContext : CoreMongoContext, new()
        {
            //BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
            services.AddScoped<TContext>(_ =>
            {
                var context = new TContext();
                context.Configure(connectionString);
                return context;
            });

            return services;
        }

        public static IServiceCollection ResolveRedis(this IServiceCollection services, String connectionString)
        {
            services.AddStackExchangeRedisCache(options =>
                options.Configuration = connectionString);
            return services;
        }
    }
}
