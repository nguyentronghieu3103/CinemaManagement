using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Results;

namespace CinemaManagement.BLL.Services.Sales
{
    // Khách hàng trong luồng bán vé (Phase 5). Dùng lại bảng KhachHang có sẵn, KHÔNG phải module CRUD khách hàng.
    public interface ICustomerService
    {
        // Tìm theo SĐT (nếu keyword toàn số) hoặc theo tên. Tối đa 20 kết quả.
        Task<Result<List<SaleCustomerDto>>> SearchAsync(string? keyword);

        // Tạo nhanh khách mới ngay trong flow bán vé. Kiểm tra SĐT (10 số, đầu 0), không trùng SĐT.
        Task<Result<SaleCustomerDto>> CreateAsync(string? hoTen, string? sdt, string? email);
    }
}
