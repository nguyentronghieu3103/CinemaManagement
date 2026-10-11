using CinemaManagement.BLL.BusinessRules;
using CinemaManagement.Common.Constants;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;

namespace CinemaManagement.Tests.Unit
{
    public class TicketRulesTests
    {
        private static Ticket CreateValidTicket(DateTime showDate, TimeSpan startTime)
        {
            return new Ticket
            {
                Id = 1,
                TrangThaiCheckIn = CheckInStatus.ChuaCheckIn,
                Invoice = new Invoice
                {
                    TrangThaiThanhToan = InvoiceStatus.DaThanhToan
                },
                Showtime = new Showtime
                {
                    NgayChieu = showDate.Date,
                    GioBatDau = startTime,
                    GioKetThuc = startTime.Add(TimeSpan.FromHours(2))
                }
            };
        }

        [Fact]
        public void EvaluateCheckIn_WhenInvoiceNotPaid_ReturnsFalse()
        {
            var ticket = CreateValidTicket(DateTime.Today, new TimeSpan(19, 0, 0));
            ticket.Invoice.TrangThaiThanhToan = InvoiceStatus.ChoThanhToan;

            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, DateTime.Today.Add(new TimeSpan(18, 45, 0)));

            Assert.False(canCheckIn);
            Assert.Equal("Vé chưa thanh toán hoặc đã bị hủy.", reason);
        }

        [Fact]
        public void EvaluateCheckIn_WhenAlreadyCheckedIn_ReturnsFalse()
        {
            var ticket = CreateValidTicket(DateTime.Today, new TimeSpan(19, 0, 0));
            ticket.TrangThaiCheckIn = CheckInStatus.DaCheckIn;
            ticket.ThoiGianCheckIn = DateTime.Today.Add(new TimeSpan(18, 40, 0));

            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, DateTime.Today.Add(new TimeSpan(18, 45, 0)));

            Assert.False(canCheckIn);
            Assert.Contains("Vé đã check-in lúc", reason);
        }

        [Fact]
        public void EvaluateCheckIn_EarlierThan30MinutesBeforeShowtime_ReturnsFalse()
        {
            // Phim chiếu 19:00, check-in lúc 18:29 (31 phút trước)
            var showDate = DateTime.Today;
            var startTime = new TimeSpan(19, 0, 0);
            var ticket = CreateValidTicket(showDate, startTime);
            var checkInTime = showDate.Add(startTime).AddMinutes(-31);

            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, checkInTime);

            Assert.False(canCheckIn);
            Assert.Contains("Chưa tới giờ vào rạp. Mở check-in lúc 18:30", reason);
        }

        [Fact]
        public void EvaluateCheckIn_Exactly30MinutesBeforeShowtime_ReturnsTrue()
        {
            // Phim chiếu 19:00, check-in lúc 18:30 (đúng 30 phút trước)
            var showDate = DateTime.Today;
            var startTime = new TimeSpan(19, 0, 0);
            var ticket = CreateValidTicket(showDate, startTime);
            var checkInTime = showDate.Add(startTime).AddMinutes(-CheckInConstants.OpenMinutesBeforeStart);

            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, checkInTime);

            Assert.True(canCheckIn);
            Assert.Null(reason);
        }

        [Fact]
        public void EvaluateCheckIn_Between30MinBeforeAndStart_ReturnsTrue()
        {
            // Phim chiếu 19:00, check-in lúc 18:45 (15 phút trước)
            var showDate = DateTime.Today;
            var startTime = new TimeSpan(19, 0, 0);
            var ticket = CreateValidTicket(showDate, startTime);
            var checkInTime = showDate.Add(startTime).AddMinutes(-15);

            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, checkInTime);

            Assert.True(canCheckIn);
            Assert.Null(reason);
        }

        [Fact]
        public void EvaluateCheckIn_ExactlyAtShowtime_ReturnsTrue()
        {
            // Phim chiếu 19:00, check-in đúng 19:00
            var showDate = DateTime.Today;
            var startTime = new TimeSpan(19, 0, 0);
            var ticket = CreateValidTicket(showDate, startTime);
            var checkInTime = showDate.Add(startTime);

            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, checkInTime);

            Assert.True(canCheckIn);
            Assert.Null(reason);
        }

        [Fact]
        public void EvaluateCheckIn_BetweenStartAnd15MinAfter_ReturnsTrue()
        {
            // Phim chiếu 19:00, check-in lúc 19:10 (10 phút sau khi bắt đầu)
            var showDate = DateTime.Today;
            var startTime = new TimeSpan(19, 0, 0);
            var ticket = CreateValidTicket(showDate, startTime);
            var checkInTime = showDate.Add(startTime).AddMinutes(10);

            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, checkInTime);

            Assert.True(canCheckIn);
            Assert.Null(reason);
        }

        [Fact]
        public void EvaluateCheckIn_Exactly15MinutesAfterShowtime_ReturnsTrue()
        {
            // Phim chiếu 19:00, check-in lúc 19:15 (đúng 15 phút sau khi bắt đầu)
            var showDate = DateTime.Today;
            var startTime = new TimeSpan(19, 0, 0);
            var ticket = CreateValidTicket(showDate, startTime);
            var checkInTime = showDate.Add(startTime).AddMinutes(CheckInConstants.CloseMinutesAfterStart);

            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, checkInTime);

            Assert.True(canCheckIn);
            Assert.Null(reason);
        }

        [Fact]
        public void EvaluateCheckIn_LaterThan15MinutesAfterShowtime_ReturnsFalse()
        {
            // Phim chiếu 19:00, check-in lúc 19:16 (16 phút sau khi bắt đầu)
            var showDate = DateTime.Today;
            var startTime = new TimeSpan(19, 0, 0);
            var ticket = CreateValidTicket(showDate, startTime);
            var checkInTime = showDate.Add(startTime).AddMinutes(16);

            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, checkInTime);

            Assert.False(canCheckIn);
            Assert.Contains("Suất chiếu đã bắt đầu quá lâu", reason);
        }

        [Fact]
        public void EvaluateCheckIn_FutureDateShowtime_ShowsDateInReason()
        {
            // Phim chiếu ngày mai lúc 19:00, check-in hôm nay
            var showDate = DateTime.Today.AddDays(1);
            var startTime = new TimeSpan(19, 0, 0);
            var ticket = CreateValidTicket(showDate, startTime);
            var now = DateTime.Today.AddHours(10);

            var (canCheckIn, reason) = TicketRules.EvaluateCheckIn(ticket, now);

            Assert.False(canCheckIn);
            Assert.Contains(showDate.ToString("dd/MM/yyyy"), reason);
        }
    }
}
