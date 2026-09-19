var builder = WebApplication.CreateBuilder(args);     

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/api/movies", () => new[] { "Phim mau 1", "Phim mau 2" });        
app.MapGet("/api/showtimes", () => new[] { "Suat 10:00", "Suat 14:00" });     
app.MapGet("/api/dashboard/revenue", () => new { TongDoanhThu = 0 });
var testValue = builder.Configuration["ApiOptions:BaseUrl"];
app.Run();                                              


