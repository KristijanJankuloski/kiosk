using Microsoft.Extensions.DependencyInjection;
using Kiosk.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Kiosk.Services.UserService.Interfaces;
using Kiosk.Services.UserService.Implementaitons;
using Kiosk.DataAccess.Repositories.Interfaces;
using Kiosk.DataAccess.Repositories.Implementations;

namespace Kiosk.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITokenRepository, TokenRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
