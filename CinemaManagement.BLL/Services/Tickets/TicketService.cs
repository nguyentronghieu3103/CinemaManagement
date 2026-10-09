using CinemaManagement.Common.DTOs.Tickets;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.Common.Results;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace CinemaManagement.BLL.Services.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITicketCodeService _codes;

        public TicketService(IUnitOfWork unitOfWork, ITicketCodeService codes)
        {
            _unitOfWork = unitOfWork;
            _codes = codes;
        }

        public async Task<Result<List<TicketDetailDto>>> SearchTicketsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Result<List<TicketDetailDto>>.Success(new List<TicketDetailDto>());

            query = query.Trim().ToLower();

            bool isTicketCode = _codes.TryParseDisplayCode(query.ToUpper(), out int ticketId);
            
            int invoiceIdSearch = 0;
            bool isInvoiceCode = false;
            if (query.StartsWith("hd"))
            {
                string numPart = new string(query.Where(char.IsDigit).ToArray());
                if (!string.IsNullOrEmpty(numPart))
                    isInvoiceCode = int.TryParse(numPart, out invoiceIdSearch);
            }

            var invoicesQuery = _unitOfWork.Invoices.Query()
                .Include(i => i.User)
                .Include(i => i.Customer)
                .Include(i => i.Tickets).ThenInclude(t => t.Seat)
                .Include(i => i.Tickets).ThenInclude(t => t.Showtime).ThenInclude(s => s.Movie)
                .Include(i => i.Tickets).ThenInclude(t => t.Showtime).ThenInclude(s => s.CinemaRoom)
                .Include(i => i.InvoiceCombos).ThenInclude(ic => ic.Combo)
                .AsNoTracking();

            List<CinemaManagement.Common.Entities.Invoice> invoices = new List<CinemaManagement.Common.Entities.Invoice>();

            if (isTicketCode)
            {
                var ticket = await _unitOfWork.Tickets.Query().AsNoTracking().FirstOrDefaultAsync(t => t.Id == ticketId);
                if (ticket != null)
                {
                    invoices = await invoicesQuery.Where(i => i.Id == ticket.InvoiceId).ToListAsync();
                }
            }
            else if (isInvoiceCode)
            {
                invoices = await invoicesQuery.Where(i => i.Id == invoiceIdSearch).ToListAsync();
            }
            else
            {
                invoices = await invoicesQuery.Where(i => 
                    (i.Customer != null && i.Customer.SDT.Contains(query)) ||
                    (i.Customer != null && i.Customer.HoTen.ToLower().Contains(query)) ||
                    i.Tickets.Any(t => t.Showtime.Movie.TenPhim.ToLower().Contains(query))
                ).ToListAsync();
            }

            var result = new List<TicketDetailDto>();
            foreach (var inv in invoices)
            {
                if (!inv.Tickets.Any()) continue;

                var firstTicket = inv.Tickets.First();
                var movie = firstTicket.Showtime.Movie;
                var room = firstTicket.Showtime.CinemaRoom;

                var seats = inv.Tickets.Select(t => SeatLabelHelper.Format(t.Seat.Hang, t.Seat.Cot)).ToList();
                string seatsStr = string.Join(" ", seats);
                string seatType = $"{seats.Count} ghế Standard"; // Defaulting for display
                
                string trangThaiCheckIn = inv.Tickets.All(t => t.TrangThaiCheckIn == CheckInStatus.DaCheckIn) ? "ĐÃ CHECK-IN" : "CHƯA CHECK-IN";
                var checkInTime = inv.Tickets.Where(t => t.ThoiGianCheckIn.HasValue).Select(t => t.ThoiGianCheckIn).DefaultIfEmpty(null).Max();
                string checkInTimeStr = checkInTime.HasValue ? $"{checkInTime.Value:HH:mm} • Cửa soát vé" : "";

                var combos = inv.InvoiceCombos.Select(ic => $"{ic.SoLuong}x {ic.Combo.TenCombo}").ToList();

                var dto = new TicketDetailDto
                {
                    InvoiceId = inv.Id,
                    InvoiceCode = $"#HD-{(inv.Id.ToString("D5"))}",
                    RepresentativeTicketCode = _codes.ToDisplayCode(firstTicket.Id),
                    MovieName = movie.TenPhim,
                    Genre = "Hành động", 
                    Format = "2D Lồng tiếng", // Hardcoded mock format since it doesn't seem to be in DB
                    RoomName = room.TenPhong,
                    NgayChieu = firstTicket.Showtime.NgayChieu,
                    GioBatDau = firstTicket.Showtime.GioBatDau,
                    Seats = seatsStr,
                    SeatType = seatType,
                    TongTien = inv.TongTien,
                    PhuongThucThanhToan = inv.PhuongThuc == PaymentMethod.TienMat ? "Tiền mặt (Tại quầy)" : "Online",
                    TrangThaiThanhToan = inv.TrangThaiThanhToan == InvoiceStatus.DaThanhToan ? "ĐÃ TT" : "CHƯA TT",
                    TrangThaiCheckIn = trangThaiCheckIn,
                    CheckInTimeStr = checkInTimeStr,
                    
                    KhachHangTen = inv.Customer?.HoTen ?? "Khách vãng lai",
                    KhachHangSdt = inv.Customer?.SDT ?? "",
                    DiemTichLuy = inv.Customer?.DiemTichLuy ?? 0,
                    HangThanhVien = "VIP MEMBER",
                    NvBanVe = inv.User?.Email ?? "Hệ thống",
                    
                    ThoiLuong = movie.ThoiLuong,
                    ManChieu = "Màn chiếu Laser Cinema",
                    
                    Combos = combos,
                    ComboTotal = inv.InvoiceCombos.Sum(ic => ic.DonGiaLucMua * ic.SoLuong),
                    TrangThaiFb = "Đã nhận tại quầy Canteen",
                    Barcode = firstTicket.MaQR ?? "N/A"
                };
                result.Add(dto);
            }

            return Result<List<TicketDetailDto>>.Success(result);
        }
    }
}
