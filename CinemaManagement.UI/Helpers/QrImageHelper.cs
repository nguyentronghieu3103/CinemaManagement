using QRCoder;

namespace CinemaManagement.UI.Helpers
{
    // Vẽ ảnh QR từ chuỗi MaQR do TicketCodeService tạo. CHỈ để hiển thị: không đổi nội dung mã, không lưu ảnh vào database.
    // Nội dung QR = đúng Ve.MaQR ("TOKEN.CHỮKÝ"); máy quét/Check-in đọc lại đúng chuỗi này rồi TicketCodeService.TryVerifyQrPayload.
    public static class QrImageHelper
    {
        // Trả về null nếu không vẽ được (giao diện sẽ hiện mã vé dạng chữ để nhập tay)
        public static Bitmap? TryRender(string payload, int pixelsPerModule = 6)
        {
            try
            {
                using var generator = new QRCodeGenerator();
                using QRCodeData data = generator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.M);
                byte[] png = new PngByteQRCode(data).GetGraphic(pixelsPerModule);
                using var ms = new MemoryStream(png);
                using var img = Image.FromStream(ms);
                return new Bitmap(img);       // copy để không phụ thuộc stream
            }
            catch (Exception ex)
            {
                Serilog.Log.Warning(ex, "Không vẽ được ảnh QR");
                return null;
            }
        }
    }
}
