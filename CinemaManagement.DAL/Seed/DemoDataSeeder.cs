using CinemaApp.Common.Entities;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using CinemaManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.DAL.Seed
{
    public static class DemoDataSeeder
    {
        public static async Task SeedAsync(CinemaDbContext context, Func<string>? qrPayloadFactory = null)
        {
            await SeedSeatSurchargesAsync(context);   // bắt buộc, không phải data "demo" thật sự
            await SeedGenresAsync(context);
            await SeedMoviesAsync(context);
            await SeedRoomsAsync(context);
            await SeedCustomersAsync(context);
            await SeedShowtimesAsync(context);
            await SeedShowtimeSeatStatusesAsync(context);
            if (qrPayloadFactory is not null)
                await SeedSampleTicketsAsync(context, qrPayloadFactory);
        }
        private static async Task SeedSampleTicketsAsync(CinemaDbContext context, Func<string> qrPayloadFactory)
        {
            if (await context.Ves.AnyAsync()) return;

            var showtime = await context.SuatChieus.FirstOrDefaultAsync();
            var cashier = await context.NguoiDungs.FirstOrDefaultAsync(u => u.Email == "cashier@cinemamanagement.local");
            var customer = await context.KhachHangs.FirstOrDefaultAsync();
            if (showtime is null || cashier is null || customer is null) return;   // thiếu dữ liệu nền thì bỏ qua

            // Lấy 2 ghế đang ở trạng thái "Đã đặt" của suất mẫu để dữ liệu nhất quán với sơ đồ ghế
            var bookedSeatIds = await context.TrangThaiGheTheoSuats
                .Where(x => x.ShowtimeId == showtime.Id && x.TrangThai == SeatStatus.DaDat)
                .OrderBy(x => x.SeatId)
                .Select(x => x.SeatId)
                .Take(2)
                .ToListAsync();
            if (bookedSeatIds.Count < 2) return;

            var invoice = new Invoice
            {
                UserId = cashier.Id,
                CustomerId = customer.Id,
                NgayLap = DateTime.Now,
                TongTien = showtime.GiaVeCoSo * bookedSeatIds.Count,
                TrangThaiThanhToan = InvoiceStatus.DaThanhToan,
                PhuongThuc = PaymentMethod.TienMat
            };

            foreach (var seatId in bookedSeatIds)
                invoice.Tickets.Add(new Ticket
                {
                    ShowtimeId = showtime.Id,
                    SeatId = seatId,
                    GiaVe = showtime.GiaVeCoSo,
                    MaQR = qrPayloadFactory()
                });

            await context.HoaDons.AddAsync(invoice);
            await context.SaveChangesAsync();
        }
        private static async Task SeedSeatSurchargesAsync(CinemaDbContext context)
        {
            if (await context.LoaiGhePhuThus.AnyAsync()) return;

            await context.LoaiGhePhuThus.AddRangeAsync(
                new SeatTypeSurcharge { LoaiGhe = SeatType.Thuong, SoTienPhuThu = 0 },
                new SeatTypeSurcharge { LoaiGhe = SeatType.Vip, SoTienPhuThu = 20000 },
                new SeatTypeSurcharge { LoaiGhe = SeatType.Doi, SoTienPhuThu = 50000 }
            );
            await context.SaveChangesAsync();
        }

        private static async Task SeedGenresAsync(CinemaDbContext context)
        {
            if (await context.TheLoais.AnyAsync()) return;

            await context.TheLoais.AddRangeAsync(
                new Genre { TenTheLoai = "Hành động" },
                new Genre { TenTheLoai = "Hài" }
            );
            await context.SaveChangesAsync();
        }

        private static async Task SeedMoviesAsync(CinemaDbContext context)
        {
            if (await context.Phims.AnyAsync()) return;

            var hanhDong = await context.TheLoais.FirstAsync(g => g.TenTheLoai == "Hành động");

            var movie = new Movie
            {
                TenPhim = "Phim Test 01",
                ThoiLuong = 120,
                DoTuoi = AgeRating.T13,
                DaoDien = "Nguyễn Văn A",
                DienVien = "Trần Thị B",
                NgayKhoiChieu = DateTime.Today,
                TrangThai = MovieStatus.DangChieu
            };
            movie.MovieGenres.Add(new MovieGenre { Genre = hanhDong });

            await context.Phims.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        private static async Task SeedRoomsAsync(CinemaDbContext context)
        {
            if (await context.PhongChieus.AnyAsync()) return;

            var room = new CinemaRoom { TenPhong = "Phòng 1", SoHang = 6, SoCot = 8 };

            for (int hang = 1; hang <= 6; hang++)
            {
                SeatType loaiGhe = hang == 6 ? SeatType.Doi
                                  : hang >= 4 ? SeatType.Vip
                                  : SeatType.Thuong;

                for (int cot = 1; cot <= 8; cot++)
                    room.Seats.Add(new Seat { Hang = hang, Cot = cot, LoaiGhe = loaiGhe });
            }

            await context.PhongChieus.AddAsync(room);
            await context.SaveChangesAsync();
        }
        private static async Task SeedCustomersAsync(CinemaDbContext context)
        {
            if (await context.KhachHangs.AnyAsync())
                return;

            await context.KhachHangs.AddAsync(new Customer
            {
                HoTen = "Nguyễn Văn Khách",
                SDT = "0901234567",
                Email = "customer@test.local",
                DiemTichLuy = 0
            });

            await context.SaveChangesAsync();
        }
        private static async Task SeedShowtimesAsync(CinemaDbContext context)
        {
            if (await context.SuatChieus.AnyAsync())
                return;

            var movie = await context.Phims.FirstAsync();
            var room = await context.PhongChieus.FirstAsync();

            DateTime start = DateTime.Now.AddMinutes(10);

            var showtime = new Showtime
            {
                MovieId = movie.Id,
                CinemaRoomId = room.Id,
                NgayChieu = DateTime.Today,
                GioBatDau = start.TimeOfDay,
                GioKetThuc = start
                    .AddMinutes(movie.ThoiLuong + 15)
                    .TimeOfDay,
                GiaVeCoSo = 90000
            };

            await context.SuatChieus.AddAsync(showtime);
            await context.SaveChangesAsync();
        }
        private static async Task SeedShowtimeSeatStatusesAsync(CinemaDbContext context)
        {
            var showtime = await context.SuatChieus.FirstAsync();

            if (await context.TrangThaiGheTheoSuats
                .AnyAsync(x => x.ShowtimeId == showtime.Id))
                return;

            var seats = await context.Ghes
                .Where(x => x.CinemaRoomId == showtime.CinemaRoomId)
                .OrderBy(x => x.Id)
                .ToListAsync();

            for (int i = 0; i < seats.Count; i++)
            {
                context.TrangThaiGheTheoSuats.Add(
                    new SeatShowtimeStatus
                    {
                        ShowtimeId = showtime.Id,
                        SeatId = seats[i].Id,

                        // 2 ghế đầu làm vé mẫu
                        TrangThai = i < 2
                            ? SeatStatus.DaDat
                            : SeatStatus.Trong,

                        ThoiGianGiu = null
                    });
            }

            await context.SaveChangesAsync();
        }
    }
}