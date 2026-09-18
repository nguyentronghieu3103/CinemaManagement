namespace CinemaManagement.Common.Exceptions
{
    // Dùng khi vi phạm quy tắc nghiệp vụ, vd: "Không thể xóa phim đang có suất chiếu"
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}