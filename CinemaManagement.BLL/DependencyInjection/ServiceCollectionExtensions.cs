using CinemaManagement.BLL.Services.Auth;
using CinemaManagement.BLL.Services.Dashboard;
using CinemaManagement.BLL.Services.Tickets;
using CinemaManagement.BLL.Services.Sales;
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
            services.AddScoped<ISaleCatalogService, SaleCatalogService>();
            services.AddScoped<ISeatHoldService, SeatHoldService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITicketIssuingService, TicketIssuingService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            return services;
        }
    }
}