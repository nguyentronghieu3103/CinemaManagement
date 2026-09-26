using CinemaManagement.DAL.DependencyInjection;
using CinemaManagement.UI.ExceptionHandling;
using CinemaManagement.UI.Forms.Auth;
using CinemaManagement.DAL.Context;
using CinemaManagement.DAL.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using CinemaManagement.BLL.DependencyInjection;
using CinemaManagement.UI.Forms.Staff;

namespace CinemaManagement.UI
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; } = null!;
        public static IServiceProvider Services { get; private set; } = null!;
        [STAThread]
        static void Main()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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
            var services = new ServiceCollection();
            services.AddDalServices(Configuration);
            services.AddBllServices();
            Services = services.BuildServiceProvider();
            GlobalExceptionHandler.Initialize();
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
                Application.Run(new LoginForm());
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