using CinemaManagement.Common.Constants;
using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Helpers;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.Common.Results;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.BLL.Services.Sales
{
    public class CustomerService : ICustomerService
    {
        private const int MaxSearchResults = 20;
        private const int MaxKeywordLength = 100;

        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        // ================= TÌM KHÁCH HÀNG =================
        public async Task<Result<List<SaleCustomerDto>>> SearchAsync(string? keyword)
        {
            string kw = (keyword ?? string.Empty).Trim();
            if (kw.Length == 0)
                return Result<List<SaleCustomerDto>>.Fail("Vui lòng nhập số điện thoại hoặc tên khách hàng.");
            if (kw.Length > MaxKeywordLength)
                return Result<List<SaleCustomerDto>>.Fail("Từ khóa tìm kiếm quá dài.");

            IQueryable<Customer> query = _unitOfWork.Customers.Query().AsNoTracking();

            // Toàn chữ số (cho phép khoảng trắng . - +) → tìm theo SĐT; còn lại → tìm theo tên
            bool looksLikePhone = kw.All(c => char.IsDigit(c) || c is ' ' or '.' or '-' or '+');
            if (looksLikePhone)
            {
                string digits = new string(CustomerValidationHelper.NormalizePhone(kw).Where(char.IsDigit).ToArray());
                if (digits.Length == 0)
                    return Result<List<SaleCustomerDto>>.Fail("Số điện thoại tìm kiếm không hợp lệ.");
                query = query.Where(c => c.SDT.Contains(digits));
            }
            else
            {
                string lower = kw.ToLower();
                query = query.Where(c => c.HoTen.ToLower().Contains(lower));
            }

            List<SaleCustomerDto> list = await query
                .OrderBy(c => c.HoTen).ThenBy(c => c.SDT)
                .Take(MaxSearchResults)
                .Select(c => new SaleCustomerDto
                {
                    CustomerId = c.Id,
                    HoTen = c.HoTen,
                    SDT = c.SDT,
                    Email = c.Email,
                    DiemTichLuy = c.DiemTichLuy
                })
                .ToListAsync();

            return Result<List<SaleCustomerDto>>.Success(list);
        }

        // ================= TẠO KHÁCH HÀNG MỚI =================
        public async Task<Result<SaleCustomerDto>> CreateAsync(string? hoTen, string? sdt, string? email)
        {
            string name = CustomerValidationHelper.NormalizeName(hoTen);
            if (name.Length == 0)
                return Result<SaleCustomerDto>.Fail("Vui lòng nhập họ tên khách hàng.");
            if (name.Length > PaymentConstants.MaxCustomerNameLength)
                return Result<SaleCustomerDto>.Fail($"Họ tên tối đa {PaymentConstants.MaxCustomerNameLength} ký tự.");

            if (!CustomerValidationHelper.IsValidPhone(sdt))
                return Result<SaleCustomerDto>.Fail("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0.");
            string phone = CustomerValidationHelper.NormalizePhone(sdt);

            string? mail = string.IsNullOrWhiteSpace(email) ? null : email.Trim();
            if (!CustomerValidationHelper.IsValidOptionalEmail(mail))
                return Result<SaleCustomerDto>.Fail("Email không đúng định dạng.");

            // DOCX M8: không tạo trùng khách hàng theo SĐT (kiểm tra trước khi insert)
            Customer? existing = await _unitOfWork.Customers.Query().AsNoTracking()
                .FirstOrDefaultAsync(c => c.SDT == phone);
            if (existing != null)
                return Result<SaleCustomerDto>.Fail(DuplicateMessage(existing));

            var customer = new Customer { HoTen = name, SDT = phone, Email = mail, DiemTichLuy = 0 };
            await _unitOfWork.Customers.AddAsync(customer);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Có thể nhân viên khác vừa tạo cùng SĐT (chỉ mục duy nhất trên KhachHang.SDT) → báo như trường hợp trùng
                Customer? raced = await _unitOfWork.Customers.Query().AsNoTracking()
                    .FirstOrDefaultAsync(c => c.SDT == phone);
                if (raced != null)
                    return Result<SaleCustomerDto>.Fail(DuplicateMessage(raced));
                throw;
            }

            return Result<SaleCustomerDto>.Success(new SaleCustomerDto
            {
                CustomerId = customer.Id,
                HoTen = customer.HoTen,
                SDT = customer.SDT,
                Email = customer.Email,
                DiemTichLuy = customer.DiemTichLuy
            });
        }

        private static string DuplicateMessage(Customer existing)
            => $"Số điện thoại {existing.SDT} đã thuộc về khách hàng \"{existing.HoTen}\". Vui lòng tìm và chọn khách hàng này.";
    }
}
