using AdminStarterKit.Api.Mapper;
using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Aggregates;
using AdminStarterKit.Domain.Shared;
using AdminStarterKit.Infrastructure;
using AdminStarterKit.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdminStarterKit.Api.Extensions
{
    public static class Extensions
    {

        public static IServiceCollection AddConfig(this IServiceCollection services
            , IConfiguration config)
        {
            services.Configure<JwtConfig>(config.GetSection(JwtConfig.Position));

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services
            , IConfiguration config)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
            var connectionString = config.GetConnectionString("MysqlDB");
            services.AddDbContext<MdmContext>(dbContextOptions =>
                dbContextOptions
               .UseMySql(connectionString, serverVersion)
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors());

            services.AddAutoMapper(typeof(UserProfile));

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}
