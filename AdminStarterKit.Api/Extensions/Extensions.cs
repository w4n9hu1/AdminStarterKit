using AdminStarterKit.Domain.Aggregates;
using AdminStarterKit.Infrastructure.Repositories;

namespace AdminStarterKit.Api.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}
