namespace CinemaManagement.Common.Exceptions
{
    // Dùng khi truy vấn 1 bản ghi không tồn tại, vd: "Không tìm thấy suất chiếu #45"
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}