using AdminStarterKit.Domain.Aggregates;
using AdminStarterKit.Infrastructure;
using AdminStarterKit.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdminStarterKit.Api.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;

            var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
            var connectionString = builder.Configuration.GetConnectionString("MysqlDB");
            services.AddDbContext<MdmContext>(dbContextOptions =>
                dbContextOptions
               .UseMySql(connectionString, serverVersion)
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}
