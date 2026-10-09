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
using CinemaManagement.BLL.Services.Tickets;

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
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();

            // Cấu hình Serilog đọc section "Serilog" từ appsettings.json
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            var services = new ServiceCollection();
            services.AddDalServices(Configuration);
            services.AddBllServices(Configuration["Security:QrSecret"]
                    ?? throw new InvalidOperationException("Thiếu Security:QrSecret trong appsettings.json")); 
            Services = services.BuildServiceProvider();
            GlobalExceptionHandler.Initialize();
            try
            {
                Log.Information("Ứng dụng khởi động");
                using (var scope = Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();
                    var codes = scope.ServiceProvider.GetRequiredService<ITicketCodeService>();
                    context.Database.Migrate();
                    DbSeeder.SeedAsync(context, codes.GenerateQrPayload).GetAwaiter().GetResult();
                }
                ApplicationConfiguration.Initialize();
                var pocForm = new Form
                {
                    Text = "POC LiveCharts2 & API Test - KAN-25",
                    Width = 800,
                    Height = 600,
                    StartPosition = FormStartPosition.CenterScreen
                };

                // Panel chứa các nút test API
                var panelTop = new Panel { Dock = DockStyle.Top, Height = 50 };
                var btnTestGemini = new Button { Text = "Test Gemini AI", Width = 150, Left = 10, Top = 10 };
                var btnTestSePay = new Button { Text = "Test SePay API", Width = 150, Left = 170, Top = 10 };
                
                btnTestGemini.Click += async (s, e) =>
                {
                    try
                    {
                        btnTestGemini.Text = "Đang xử lý...";
                        btnTestGemini.Enabled = false;
                        var geminiConfig = Configuration.GetSection("Gemini");
                        var service = new CinemaManagement.Integrations.AI.GeminiService(
                            geminiConfig["ApiKey"], geminiConfig["BaseUrl"], geminiConfig["Model"]);
                        
                        var result = await service.SendMessageAsync("Xin chào, bạn là ai? Trả lời ngắn gọn trong 1 câu.");
                        MessageBox.Show("Gemini trả lời:\n" + result, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi Gemini", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        btnTestGemini.Text = "Test Gemini AI";
                        btnTestGemini.Enabled = true;
                    }
                };

                btnTestSePay.Click += async (s, e) =>
                {
                    try
                    {
                        btnTestSePay.Text = "Đang xử lý...";
                        btnTestSePay.Enabled = false;
                        var sepayConfig = Configuration.GetSection("Seepay");
                        var service = new CinemaManagement.Integrations.Payment.SeepayService(
                            sepayConfig["Endpoint"], sepayConfig["PartnerCode"], sepayConfig["AccessKey"], sepayConfig["SecretKey"]);
                        
                        var result = await service.TestConnectionAsync();
                        MessageBox.Show("SePay kết nối thành công!\nDữ liệu trả về (cắt gọn):\n" + (result.Length > 200 ? result.Substring(0, 200) + "..." : result), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi SePay", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        btnTestSePay.Text = "Test SePay API";
                        btnTestSePay.Enabled = true;
                    }
                };

                panelTop.Controls.Add(btnTestGemini);
                panelTop.Controls.Add(btnTestSePay);

                var chart = new UserControls.Common.RevenueChartControl();
                chart.Dock = DockStyle.Fill;
                
                pocForm.Controls.Add(chart);
                pocForm.Controls.Add(panelTop);
                Application.Run(pocForm);

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Lỗi khởi động",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}