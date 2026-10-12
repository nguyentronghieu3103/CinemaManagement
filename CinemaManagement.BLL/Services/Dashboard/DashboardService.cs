using CinemaManagement.Common.DTOs.Dashboard;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.BLL.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<StaffDashboardDto> GetStaffDashboardAsync()
        {
            var today = DateTime.Today;
            var now = DateTime.Now.TimeOfDay;

            int veDaBan = await _unitOfWork.Tickets.Query()
                .Include(t => t.Invoice)
                .Where(t => t.Invoice.NgayLap.Date == today
                         && t.Invoice.TrangThaiThanhToan == InvoiceStatus.DaThanhToan)
                .CountAsync();

            int soLuotCheckIn = await _unitOfWork.Tickets.Query()
                .Where(t => t.TrangThaiCheckIn == CheckInStatus.DaCheckIn
                         && t.ThoiGianCheckIn != null
                         && t.ThoiGianCheckIn.Value.Date == today)
                .CountAsync();

            int soSuatChieu = await _unitOfWork.Showtimes.Query()
                .Where(s => s.NgayChieu.Date == today)
                .CountAsync();

            decimal doanhThu = await _unitOfWork.Invoices.Query()
                .Where(i => i.NgayLap.Date == today && i.TrangThaiThanhToan == InvoiceStatus.DaThanhToan)
                .SumAsync(i => (decimal?)i.TongTien) ?? 0;

            var suatHomNay = await _unitOfWork.Showtimes.Query()
                .Include(s => s.Movie)
                .Include(s => s.CinemaRoom).ThenInclude(r => r.Seats)
                .Where(s => s.NgayChieu.Date == today)
                .OrderBy(s => s.GioBatDau)
                .ToListAsync();

            var danhSach = new List<UpcomingShowtimeDto>();
            var currentTime = DateTime.Now;
            foreach (var s in suatHomNay)
            {
                int daBan = await _unitOfWork.Tickets.Query().CountAsync(t => t.ShowtimeId == s.Id);
                int tongGhe = s.CinemaRoom.Seats.Count;

                var startDt = s.NgayChieu.Date + s.GioBatDau;
                var endDt = s.NgayChieu.Date + s.GioKetThuc;

                string trangThai = tongGhe == 0 ? "Chưa có ghế"
                    : currentTime > endDt ? "Đã chiếu"
                    : currentTime >= startDt ? "Đang chiếu"
                    : daBan >= tongGhe ? "Đã đầy"
                    : daBan >= tongGhe * 0.85 ? "Gần đầy"
                    : "Đang bán";

                danhSach.Add(new UpcomingShowtimeDto
                {
                    GioBatDau = s.GioBatDau,
                    TenPhim = s.Movie.TenPhim,
                    TenPhong = s.CinemaRoom.TenPhong,
                    DaBan = daBan,
                    TongGhe = tongGhe,
                    TrangThai = trangThai
                });
            }

            return new StaffDashboardDto
            {
                VeDaBanHomNay = veDaBan,
                SoSuatChieuHomNay = soSuatChieu,
                SoLuotCheckInHomNay = soLuotCheckIn,
                DoanhThuHomNay = doanhThu,
                SuatChieuSapDienRa = danhSach
            };
        }
    }
}