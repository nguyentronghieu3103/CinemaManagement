using Serilog;

// Khởi tạo Serilog tạm thời để bắt lỗi ngay từ giây đầu tiên khởi động app
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Đang khởi động hệ thống CinemaManagement API...");

    var builder = WebApplication.CreateBuilder(args);

    // Yêu cầu ứng dụng sử dụng Serilog và đọc cấu hình từ appsettings.json
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());

    // Thêm các dịch vụ cơ bản
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Cấu hình pipeline xử lý request
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    // Tự động ghi nhật ký (log) thông tin của mọi API request gửi tới
    app.UseSerilogRequestLogging();

    app.MapGet("/", () => "Hello World!");
    app.MapGet("/api/movies", () => new[] { "Phim mau 1", "Phim mau 2" });        
    app.MapGet("/api/showtimes", () => new[] { "Suat 10:00", "Suat 14:00" });     
    app.MapGet("/api/dashboard/revenue", () => new { TongDoanhThu = 0 });
    
    var testValue = builder.Configuration["ApiOptions:BaseUrl"];

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "API bị crash do lỗi nghiêm trọng!");
}
finally
{
    Log.CloseAndFlush();
}
