using CinemaManagement.DAL.Context;
using CinemaManagement.DAL.DependencyInjection;
using CinemaManagement.DAL.Seed;
using CinemaManagement.UI.ExceptionHandling;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CinemaManagement.UI
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; } = null!;
        public static IServiceProvider Services { get; private set; } = null!;
        [STAThread]
        static void Main()
        {
            // Đọc appsettings.json
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Cấu hình Serilog đọc section "Serilog" từ appsettings.json
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            GlobalExceptionHandler.Initialize();
            var services = new ServiceCollection();
            services.AddDalServices(Configuration);   
            Services = services.BuildServiceProvider();
            try
            {
                Log.Information("Ứng dụng khởi động");
                using (var scope = Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();
                    context.Database.Migrate();
                    DbSeeder.SeedAsync(context).GetAwaiter().GetResult();
                }
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());   
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ứng dụng bị crash ngay lúc khởi động");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}