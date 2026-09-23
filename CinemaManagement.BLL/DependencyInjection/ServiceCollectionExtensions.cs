using CinemaManagement.BLL.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaManagement.BLL.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}