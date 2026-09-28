namespace CinemaManagement.BLL.Services.Tickets
{
    public interface ITicketCodeService
    {
        string GenerateQrPayload();                          // module Bán vé (C) gọi khi tạo vé
        bool TryVerifyQrPayload(string payload);
        string ToDisplayCode(int ticketId);                  // 325 -> "VE000325"
        bool TryParseDisplayCode(string input, out int ticketId);
    }
}