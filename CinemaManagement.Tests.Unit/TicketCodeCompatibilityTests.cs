using CinemaManagement.BLL.Services.Tickets;

namespace CinemaManagement.Tests.Unit;

// MaQR mà Bán vé lưu vào Ve.MaQR phải được Check-in verify được (cùng TicketCodeService, cùng secret).
public class TicketCodeCompatibilityTests
{
    private static TicketCodeService Create(string secret = "TrongHieu_NgocGiau_MaiDao_TienTien") => new(secret);

    [Fact]
    public void GeneratedPayload_IsVerifiedAndAlreadyUpperCase()
    {
        var codes = Create();
        string payload = codes.GenerateQrPayload();

        Assert.True(codes.TryVerifyQrPayload(payload));
        Assert.Equal(payload.ToUpperInvariant(), payload);   // Check-in tra cứu bằng input.ToUpperInvariant() == MaQR
        Assert.Contains('.', payload);                       // Check-in nhận dạng QR bằng dấu '.'
    }

    [Fact]
    public void GeneratedPayloads_AreUnique()
    {
        var codes = Create();
        var set = Enumerable.Range(0, 200).Select(_ => codes.GenerateQrPayload()).ToHashSet();
        Assert.Equal(200, set.Count);
    }

    [Fact]
    public void PayloadFromDifferentSecret_IsRejected()
    {
        string payload = Create().GenerateQrPayload();
        Assert.False(Create("MotChuoiBiMatKhacHoanToan_123").TryVerifyQrPayload(payload));
    }

    [Fact]
    public void DisplayCode_RoundTrips()
    {
        var codes = Create();
        string code = codes.ToDisplayCode(325);

        Assert.Equal("VE000325", code);
        Assert.True(codes.TryParseDisplayCode(code, out int id));
        Assert.Equal(325, id);
    }
}
