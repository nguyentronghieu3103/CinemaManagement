using CinemaManagement.BLL.Services.Auth;
using CinemaManagement.BLL.Services.Dashboard;
using CinemaManagement.BLL.Services.Tickets;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaManagement.BLL.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services, string qrSecret)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddSingleton<ITicketCodeService>(new TicketCodeService(qrSecret));
            services.AddScoped<ICheckInService, CheckInService>();
            return services;
        }
    }
}