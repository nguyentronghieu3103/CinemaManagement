using CinemaManagement.Common.Exceptions;
using Serilog;

namespace CinemaManagement.UI.ExceptionHandling
{
    internal static class GlobalExceptionHandler
    {
        // Gọi hàm này đúng 1 lần, ngay khi app khởi động, trước Application.Run
        public static void Initialize()
        {
            // Bắt buộc gọi dòng này TRƯỚC khi đăng ký ThreadException,
            // nếu không WinForms sẽ tự xử lý lỗi theo kiểu mặc định (crash) mà bỏ qua handler của mình
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
        }

        private static void OnThreadException(object? sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception, isFatal: false);
        }

        private static void OnUnhandledException(object? sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception ?? new Exception("Lỗi không xác định trên thread nền");
            HandleException(ex, isFatal: e.IsTerminating);
        }

        private static void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            HandleException(e.Exception, isFatal: false);
            e.SetObserved(); // đánh dấu đã xử lý, tránh app tự đóng vì lỗi Task bị "bỏ quên"
        }

        private static void HandleException(Exception ex, bool isFatal)
        {
            string userMessage = GetUserFriendlyMessage(ex);

            if (isFatal)
                Log.Fatal(ex, "Lỗi nghiêm trọng khiến ứng dụng phải đóng");
            else
                Log.Error(ex, "Lỗi không được xử lý trong ứng dụng");

            MessageBox.Show(
                userMessage,
                isFatal ? "Lỗi nghiêm trọng" : "Đã có lỗi xảy ra",
                MessageBoxButtons.OK,
                isFatal ? MessageBoxIcon.Stop : MessageBoxIcon.Error);

            if (isFatal)
            {
                Log.CloseAndFlush(); // đảm bảo log kịp ghi xuống file trước khi process bị kill
                Environment.Exit(1);
            }
        }

        // Đây là chỗ "dịch" lỗi kỹ thuật thành câu người dùng hiểu được
        private static string GetUserFriendlyMessage(Exception ex)
        {
            return ex switch
            {
                ValidationException => ex.Message,       // đã viết sẵn câu thân thiện lúc ném lỗi
                BusinessException => ex.Message,
                NotFoundException => ex.Message,
                AuthorizationException => ex.Message,
                IntegrationException => "Không thể kết nối đến dịch vụ bên ngoài. Vui lòng kiểm tra kết nối mạng và thử lại.",
                _ => "Đã có lỗi xảy ra. Vui lòng thử lại hoặc liên hệ quản trị viên nếu lỗi tiếp tục xuất hiện."
            };
        }
    }
}