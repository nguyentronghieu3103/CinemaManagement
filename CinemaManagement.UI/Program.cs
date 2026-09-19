using CinemaManagement.UI.ExceptionHandling;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CinemaManagement.UI
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; } = null!;

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
            try
            {
                Log.Information("Ứng dụng khởi động");

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