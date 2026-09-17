using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaManagement.DAL.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CinemaDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, DAL.UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}