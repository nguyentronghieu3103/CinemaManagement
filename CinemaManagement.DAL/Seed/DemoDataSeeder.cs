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
            qrPayloadFactory ??= () => $"{Guid.NewGuid():N}"[..16] + "." + $"{Guid.NewGuid():N}"[..8];

            await CleanAndResetDemoDataIfNeededAsync(context);
            await SeedSeatSurchargesAsync(context);
            await SeedGenresAsync(context);
            await SeedCombosAsync(context);
            await SeedRoomsAsync(context);
            await SeedMoviesAsync(context);
            await SeedCustomersAsync(context);
            await SeedShowtimesAsync(context);
            await SeedShowtimeSeatStatusesAsync(context);
            await SeedSampleTicketsAsync(context, qrPayloadFactory);
        }

        private static async Task CleanAndResetDemoDataIfNeededAsync(CinemaDbContext context)
        {
            var today = DateTime.Today;
            var nowTime = DateTime.Now.TimeOfDay;

            // 1. Dọn dẹp toàn bộ dữ liệu demo của các ngày cũ trước hôm nay
            await CleanPastDemoDataAsync(context);

            // 2. Kiểm tra tính toàn vẹn của dữ liệu demo hôm nay
            int todayShowtimesCount = await context.SuatChieus.CountAsync(s => s.NgayChieu.Date == today);
            int upcomingCount = await context.SuatChieus.CountAsync(s => s.NgayChieu.Date == today && s.GioBatDau >= nowTime);
            int todayTicketsCount = await context.Ves.CountAsync(v => v.Showtime.NgayChieu.Date == today);
            int todayCheckInCount = await context.Ves.CountAsync(v => v.Showtime.NgayChieu.Date == today && v.TrangThaiCheckIn == CheckInStatus.DaCheckIn);

            // Nếu dữ liệu hôm nay trên máy hiện tại không đúng chuẩn demo:
            // (khác 6 suất, ít hơn 3 suất sắp tới, vé khác 219, hoặc chưa có check-in)
            // -> Thực hiện dọn sạch hôm nay để nạp lại đúng 6 suất từ thời điểm hiện tại, 219 vé và 1 check-in
            bool isDemoClean = todayShowtimesCount == 6
                            && upcomingCount >= 3
                            && todayTicketsCount == 219
                            && todayCheckInCount == 1;

            if (!isDemoClean)
            {
                var todayShowtimes = await context.SuatChieus
                    .Where(s => s.NgayChieu.Date == today)
                    .ToListAsync();

                if (todayShowtimes.Count > 0)
                {
                    var todayShowtimeIds = todayShowtimes.Select(s => s.Id).ToList();

                    var todayTickets = await context.Ves
                        .Where(v => todayShowtimeIds.Contains(v.ShowtimeId))
                        .ToListAsync();

                    var invoiceIds = todayTickets.Select(v => v.InvoiceId).Distinct().ToList();

                    if (todayTickets.Count > 0)
                    {
                        context.Ves.RemoveRange(todayTickets);
                        await context.SaveChangesAsync();
                    }

                    if (invoiceIds.Count > 0)
                    {
                        var invoicesToDelete = await context.HoaDons
                            .Where(i => invoiceIds.Contains(i.Id))
                            .ToListAsync();

                        var delInvIds = invoicesToDelete.Select(i => i.Id).ToList();

                        var payments = await context.GiaoDichThanhToans.Where(p => delInvIds.Contains(p.InvoiceId)).ToListAsync();
                        if (payments.Count > 0) context.GiaoDichThanhToans.RemoveRange(payments);

                        var combos = await context.HoaDonCombos.Where(c => delInvIds.Contains(c.InvoiceId)).ToListAsync();
                        if (combos.Count > 0) context.HoaDonCombos.RemoveRange(combos);

                        var emailLogs = await context.LichSuGuiEmails.Where(e => delInvIds.Contains(e.InvoiceId)).ToListAsync();
                        if (emailLogs.Count > 0) context.LichSuGuiEmails.RemoveRange(emailLogs);

                        if (invoicesToDelete.Count > 0) context.HoaDons.RemoveRange(invoicesToDelete);

                        await context.SaveChangesAsync();
                    }

                    var seatStatuses = await context.TrangThaiGheTheoSuats
                        .Where(x => todayShowtimeIds.Contains(x.ShowtimeId))
                        .ToListAsync();
                    if (seatStatuses.Count > 0)
                    {
                        context.TrangThaiGheTheoSuats.RemoveRange(seatStatuses);
                        await context.SaveChangesAsync();
                    }

                    context.SuatChieus.RemoveRange(todayShowtimes);
                    await context.SaveChangesAsync();
                }

                // Dọn dẹp các hóa đơn rác không có vé còn sót lại của ngày hôm nay
                var orphanedInvoices = await context.HoaDons
                    .Where(i => i.NgayLap.Date == today && !context.Ves.Any(v => v.InvoiceId == i.Id))
                    .ToListAsync();
                if (orphanedInvoices.Count > 0)
                {
                    var orphanIds = orphanedInvoices.Select(i => i.Id).ToList();
                    var orphanPayments = await context.GiaoDichThanhToans.Where(p => orphanIds.Contains(p.InvoiceId)).ToListAsync();
                    if (orphanPayments.Count > 0) context.GiaoDichThanhToans.RemoveRange(orphanPayments);
                    var orphanCombos = await context.HoaDonCombos.Where(c => orphanIds.Contains(c.InvoiceId)).ToListAsync();
                    if (orphanCombos.Count > 0) context.HoaDonCombos.RemoveRange(orphanCombos);
                    context.HoaDons.RemoveRange(orphanedInvoices);
                    await context.SaveChangesAsync();
                }
            }
        }

        private static async Task CleanPastDemoDataAsync(CinemaDbContext context)
        {
            var today = DateTime.Today;

            // Dọn dẹp toàn bộ dữ liệu demo của các ngày cũ trước hôm nay
            var pastShowtimes = await context.SuatChieus
                .Where(s => s.NgayChieu.Date < today)
                .ToListAsync();

            if (pastShowtimes.Count > 0)
            {
                var pastShowtimeIds = pastShowtimes.Select(s => s.Id).ToList();

                var pastTickets = await context.Ves
                    .Where(v => pastShowtimeIds.Contains(v.ShowtimeId))
                    .ToListAsync();

                var invoiceIds = pastTickets.Select(v => v.InvoiceId).Distinct().ToList();

                if (pastTickets.Count > 0)
                {
                    context.Ves.RemoveRange(pastTickets);
                    await context.SaveChangesAsync();
                }

                if (invoiceIds.Count > 0)
                {
                    var invoicesToDelete = await context.HoaDons
                        .Where(i => invoiceIds.Contains(i.Id) && !context.Ves.Any(v => v.InvoiceId == i.Id && !pastShowtimeIds.Contains(v.ShowtimeId)))
                        .ToListAsync();

                    var delInvIds = invoicesToDelete.Select(i => i.Id).ToList();

                    var payments = await context.GiaoDichThanhToans.Where(p => delInvIds.Contains(p.InvoiceId)).ToListAsync();
                    if (payments.Count > 0) context.GiaoDichThanhToans.RemoveRange(payments);

                    var combos = await context.HoaDonCombos.Where(c => delInvIds.Contains(c.InvoiceId)).ToListAsync();
                    if (combos.Count > 0) context.HoaDonCombos.RemoveRange(combos);

                    var emailLogs = await context.LichSuGuiEmails.Where(e => delInvIds.Contains(e.InvoiceId)).ToListAsync();
                    if (emailLogs.Count > 0) context.LichSuGuiEmails.RemoveRange(emailLogs);

                    if (invoicesToDelete.Count > 0) context.HoaDons.RemoveRange(invoicesToDelete);

                    await context.SaveChangesAsync();
                }

                var pastSeatStatuses = await context.TrangThaiGheTheoSuats
                    .Where(x => pastShowtimeIds.Contains(x.ShowtimeId))
                    .ToListAsync();
                if (pastSeatStatuses.Count > 0)
                {
                    context.TrangThaiGheTheoSuats.RemoveRange(pastSeatStatuses);
                    await context.SaveChangesAsync();
                }

                context.SuatChieus.RemoveRange(pastShowtimes);
                await context.SaveChangesAsync();
            }
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
            var existing = await context.TheLoais.Select(g => g.TenTheLoai).ToListAsync();
            var genres = new[] { "Hành động", "Hài", "Khoa học viễn tưởng", "Kinh dị", "Hoạt hình", "Tình cảm", "Tâm lý", "Gia đình" };
            foreach (var g in genres)
            {
                if (!existing.Contains(g))
                    await context.TheLoais.AddAsync(new Genre { TenTheLoai = g });
            }
            await context.SaveChangesAsync();
        }

        private static async Task SeedCombosAsync(CinemaDbContext context)
        {
            var existing = await context.Combos.Select(c => c.TenCombo).ToListAsync();
            var combos = new[]
            {
                new Combo { TenCombo = "Combo Solo (1 Bắp + 1 Nước)", Gia = 79000, MoTa = "1 Bắp ngọt 60oz + 1 Coca-Cola 32oz" },
                new Combo { TenCombo = "Combo Couple (1 Bắp + 2 Nước)", Gia = 109000, MoTa = "1 Bắp phô mai 60oz + 2 Coca-Cola 32oz" },
                new Combo { TenCombo = "Combo Family (2 Bắp + 4 Nước)", Gia = 199000, MoTa = "2 Bắp phô mai lớn + 4 Nước ngọt 32oz" },
                new Combo { TenCombo = "Bắp Rang Bơ Phô Mai", Gia = 55000, MoTa = "Bắp rang bơ lắc bột phô mai giòn thơm" },
                new Combo { TenCombo = "Nước Ngọt Coca-Cola 32oz", Gia = 35000, MoTa = "Coca-Cola mát lạnh sảng khoái" }
            };
            foreach (var c in combos)
            {
                if (!existing.Contains(c.TenCombo))
                    await context.Combos.AddAsync(c);
            }
            await context.SaveChangesAsync();
        }

        private static async Task SeedRoomsAsync(CinemaDbContext context)
        {
            if (!await context.PhongChieus.AnyAsync(r => r.TenPhong.Contains("Phòng 1")))
            {
                var r1 = new CinemaRoom { TenPhong = "Phòng 1 (Standard)", SoHang = 6, SoCot = 8 };
                for (int h = 1; h <= 6; h++)
                {
                    SeatType loai = h == 6 ? SeatType.Doi : h >= 4 ? SeatType.Vip : SeatType.Thuong;
                    for (int c = 1; c <= 8; c++)
                        r1.Seats.Add(new Seat { Hang = h, Cot = c, LoaiGhe = loai });
                }
                await context.PhongChieus.AddAsync(r1);
            }

            if (!await context.PhongChieus.AnyAsync(r => r.TenPhong.Contains("Phòng 2")))
            {
                var r2 = new CinemaRoom { TenPhong = "Phòng 2 (IMAX)", SoHang = 8, SoCot = 10 };
                for (int h = 1; h <= 8; h++)
                {
                    SeatType loai = h == 8 ? SeatType.Doi : h >= 5 ? SeatType.Vip : SeatType.Thuong;
                    for (int c = 1; c <= 10; c++)
                        r2.Seats.Add(new Seat { Hang = h, Cot = c, LoaiGhe = loai });
                }
                await context.PhongChieus.AddAsync(r2);
            }

            if (!await context.PhongChieus.AnyAsync(r => r.TenPhong.Contains("Phòng 3")))
            {
                var r3 = new CinemaRoom { TenPhong = "Phòng 3 (VIP Laser)", SoHang = 4, SoCot = 6 };
                for (int h = 1; h <= 4; h++)
                {
                    SeatType loai = h == 4 ? SeatType.Doi : SeatType.Vip;
                    for (int c = 1; c <= 6; c++)
                        r3.Seats.Add(new Seat { Hang = h, Cot = c, LoaiGhe = loai });
                }
                await context.PhongChieus.AddAsync(r3);
            }
            await context.SaveChangesAsync();
        }

        private static async Task SeedMoviesAsync(CinemaDbContext context)
        {
            var existing = await context.Phims.Select(p => p.TenPhim).ToListAsync();
            var genres = await context.TheLoais.ToListAsync();
            var getGenre = (string name) => genres.FirstOrDefault(g => g.TenTheLoai == name) ?? genres.First();

            var moviesToSeed = new (string title, int duration, AgeRating rating, string director, string actors, MovieStatus status, string genreName)[]
            {
                ("Dune: Hành Tinh Cát - Phần 2", 166, AgeRating.T16, "Denis Villeneuve", "Timothée Chalamet, Zendaya", MovieStatus.DangChieu, "Khoa học viễn tưởng"),
                ("Mai", 131, AgeRating.T18, "Trấn Thành", "Phương Anh Đào, Tuấn Trần", MovieStatus.DangChieu, "Tâm lý"),
                ("Godzilla x Kong: Đế Chế Mới", 115, AgeRating.T13, "Adam Wingard", "Rebecca Hall, Dan Stevens", MovieStatus.DangChieu, "Hành động"),
                ("Kung Fu Panda 4", 94, AgeRating.p, "Mike Mitchell", "Jack Black, Awkwafina", MovieStatus.DangChieu, "Hoạt hình"),
                ("Exhuma: Quật Mộ Trùng Ma", 134, AgeRating.T16, "Jang Jae-hyun", "Choi Min-sik, Kim Go-eun", MovieStatus.DangChieu, "Kinh dị"),
                ("Lật Mặt 7: Một Điều Ước", 138, AgeRating.k, "Lý Hải", "Thanh Hiền, Trương Minh Cường", MovieStatus.DangChieu, "Gia đình"),
                ("Deadpool & Wolverine", 128, AgeRating.T18, "Shawn Levy", "Ryan Reynolds, Hugh Jackman", MovieStatus.SapChieu, "Hành động"),
                ("Thám Tử Lừng Danh Conan", 110, AgeRating.p, "Chika Nagaoka", "Minami Takayama", MovieStatus.DangChieu, "Hoạt hình")
            };

            foreach (var m in moviesToSeed)
            {
                if (!existing.Contains(m.title))
                {
                    var movie = new Movie
                    {
                        TenPhim = m.title,
                        ThoiLuong = m.duration,
                        DoTuoi = m.rating,
                        DaoDien = m.director,
                        DienVien = m.actors,
                        NgayKhoiChieu = DateTime.Today.AddDays(-7),
                        TrangThai = m.status
                    };
                    movie.MovieGenres.Add(new MovieGenre { Genre = getGenre(m.genreName) });
                    await context.Phims.AddAsync(movie);
                }
            }
            await context.SaveChangesAsync();
        }

        private static async Task SeedCustomersAsync(CinemaDbContext context)
        {
            var existingPhones = await context.KhachHangs.Select(c => c.SDT).ToListAsync();
            var customers = new[]
            {
                new Customer { HoTen = "Nguyễn Văn Khách", SDT = "0901234567", Email = "customer@test.local", DiemTichLuy = 150 },
                new Customer { HoTen = "Trần Thị Thu Trang", SDT = "0988888888", Email = "trang.tran@gmail.com", DiemTichLuy = 420 },
                new Customer { HoTen = "Lê Hoàng Nam", SDT = "0912345678", Email = "nam.le@yahoo.com", DiemTichLuy = 0 },
                new Customer { HoTen = "Phạm Quỳnh Anh", SDT = "0977112233", Email = "quynhanh@outlook.com", DiemTichLuy = 85 }
            };
            foreach (var c in customers)
            {
                if (!existingPhones.Contains(c.SDT))
                    await context.KhachHangs.AddAsync(c);
            }
            await context.SaveChangesAsync();
        }

        private static async Task SeedShowtimesAsync(CinemaDbContext context)
        {
            var movies = await context.Phims.ToListAsync();
            var rooms = await context.PhongChieus.ToListAsync();
            if (movies.Count == 0 || rooms.Count == 0) return;

            var r1 = rooms.FirstOrDefault(r => r.TenPhong.Contains("Phòng 1")) ?? rooms[0];
            var r2 = rooms.FirstOrDefault(r => r.TenPhong.Contains("Phòng 2")) ?? rooms[0];
            var r3 = rooms.FirstOrDefault(r => r.TenPhong.Contains("Phòng 3")) ?? rooms[0];

            var getMovie = (string title) => movies.FirstOrDefault(m => m.TenPhim.Contains(title)) ?? movies[0];

            var today = DateTime.Today;
            var nowTime = DateTime.Now.TimeOfDay;
            var now = DateTime.Now;

            // Kiểm tra xem hôm nay còn bao nhiêu suất chiếu sắp tới (chưa hết giờ)
            int upcomingCount = await context.SuatChieus.CountAsync(s => s.NgayChieu.Date == today && s.GioBatDau >= nowTime);

            var todayShowtimes = await context.SuatChieus
                .Where(s => s.NgayChieu.Date == today)
                .OrderBy(s => s.GioBatDau)
                .ToListAsync();

            // Nếu các suất chiếu hôm nay đã trôi qua trong quá khứ (ít hơn 3 suất sắp tới):
            // Tự động điều chỉnh giờ chiếu của các suất hôm nay từ thời điểm hiện tại trở đi để luôn sẵn sàng phục vụ
            if (upcomingCount < 3 && todayShowtimes.Count >= 6)
            {
                int[] minuteOffsets = { 15, 90, 160, 240, 320, 400 };
                for (int i = 0; i < Math.Min(todayShowtimes.Count, minuteOffsets.Length); i++)
                {
                    var st = todayShowtimes[i];
                    var startDt = now.AddMinutes(minuteOffsets[i]);
                    var startSpan = new TimeSpan(startDt.Hour, startDt.Minute, 0);
                    if (startDt.Date > today) startSpan = new TimeSpan(23, 45, 0);
                    var endSpan = startSpan.Add(TimeSpan.FromMinutes(120 + 15));
                    if (endSpan.Days > 0) endSpan = new TimeSpan(23, 59, 0);

                    st.GioBatDau = startSpan;
                    st.GioKetThuc = endSpan;
                }
                await context.SaveChangesAsync();
            }
            else if (todayShowtimes.Count < 6)
            {
                // Nếu hôm nay chưa có đủ suất chiếu: dọn các suất cũ chưa có vé và tạo mới bộ 6 suất
                var todayShowtimesWithoutTickets = await context.SuatChieus
                    .Where(s => s.NgayChieu.Date == today && !context.Ves.Any(v => v.ShowtimeId == s.Id))
                    .ToListAsync();

                if (todayShowtimesWithoutTickets.Count > 0)
                {
                    var stIds = todayShowtimesWithoutTickets.Select(s => s.Id).ToList();
                    var oldStatuses = await context.TrangThaiGheTheoSuats
                        .Where(x => stIds.Contains(x.ShowtimeId))
                        .ToListAsync();
                    context.TrangThaiGheTheoSuats.RemoveRange(oldStatuses);
                    context.SuatChieus.RemoveRange(todayShowtimesWithoutTickets);
                    await context.SaveChangesAsync();
                }

                var schedulesToday = new[]
                {
                    (getMovie("Kung Fu Panda"), r1, now.AddMinutes(15), 85000m),   // Trong khung 30p để test check-in ngay
                    (getMovie("Godzilla x Kong"), r1, now.AddMinutes(90), 95000m),
                    (getMovie("Dune"), r2, now.AddMinutes(160), 110000m),
                    (getMovie("Mai"), r2, now.AddMinutes(240), 100000m),
                    (getMovie("Exhuma"), r3, now.AddMinutes(320), 120000m),
                    (getMovie("Lật Mặt 7"), r1, now.AddMinutes(400), 90000m)
                };

                foreach (var (m, r, startDt, price) in schedulesToday)
                {
                    var startSpan = new TimeSpan(startDt.Hour, startDt.Minute, 0);
                    if (startDt.Date > today) startSpan = new TimeSpan(23, 45, 0);
                    var endSpan = startSpan.Add(TimeSpan.FromMinutes(m.ThoiLuong + 15));
                    if (endSpan.Days > 0) endSpan = new TimeSpan(23, 59, 0);

                    await context.SuatChieus.AddAsync(new Showtime
                    {
                        MovieId = m.Id,
                        CinemaRoomId = r.Id,
                        NgayChieu = today,
                        GioBatDau = startSpan,
                        GioKetThuc = endSpan,
                        GiaVeCoSo = price
                    });
                }
                await context.SaveChangesAsync();
            }

            // Tạo các suất chiếu ngày mai và ngày mốt để test bộ chọn ngày
            var tomorrow = today.AddDays(1);
            if (!await context.SuatChieus.AnyAsync(s => s.NgayChieu.Date == tomorrow))
            {
                var schedulesTomorrow = new[]
                {
                    (getMovie("Kung Fu Panda"), r1, new TimeSpan(9, 30, 0), 85000m),
                    (getMovie("Dune"), r2, new TimeSpan(13, 15, 0), 110000m),
                    (getMovie("Mai"), r2, new TimeSpan(18, 0, 0), 100000m),
                    (getMovie("Godzilla x Kong"), r1, new TimeSpan(21, 0, 0), 95000m)
                };
                foreach (var (m, r, start, price) in schedulesTomorrow)
                {
                    await context.SuatChieus.AddAsync(new Showtime
                    {
                        MovieId = m.Id,
                        CinemaRoomId = r.Id,
                        NgayChieu = tomorrow,
                        GioBatDau = start,
                        GioKetThuc = start.Add(TimeSpan.FromMinutes(m.ThoiLuong + 15)),
                        GiaVeCoSo = price
                    });
                }
                await context.SaveChangesAsync();
            }

            var dayAfter = today.AddDays(2);
            if (!await context.SuatChieus.AnyAsync(s => s.NgayChieu.Date == dayAfter))
            {
                var schedulesDayAfter = new[]
                {
                    (getMovie("Lật Mặt 7"), r1, new TimeSpan(10, 0, 0), 90000m),
                    (getMovie("Exhuma"), r3, new TimeSpan(15, 30, 0), 120000m),
                    (getMovie("Dune"), r2, new TimeSpan(19, 30, 0), 110000m)
                };
                foreach (var (m, r, start, price) in schedulesDayAfter)
                {
                    await context.SuatChieus.AddAsync(new Showtime
                    {
                        MovieId = m.Id,
                        CinemaRoomId = r.Id,
                        NgayChieu = dayAfter,
                        GioBatDau = start,
                        GioKetThuc = start.Add(TimeSpan.FromMinutes(m.ThoiLuong + 15)),
                        GiaVeCoSo = price
                    });
                }
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedShowtimeSeatStatusesAsync(CinemaDbContext context)
        {
            var today = DateTime.Today;

            // 1. Đối với suất chiếu hôm nay: Thiết lập tỷ lệ ghế đa dạng để test trạng thái Dashboard và Bán vé
            var todayShowtimes = await context.SuatChieus
                .Where(s => s.NgayChieu.Date == today)
                .Include(s => s.CinemaRoom).ThenInclude(r => r.Seats)
                .OrderBy(s => s.GioBatDau)
                .ToListAsync();

            int index = 0;
            foreach (var st in todayShowtimes)
            {
                bool hasSeats = await context.TrangThaiGheTheoSuats.AnyAsync(x => x.ShowtimeId == st.Id);
                if (hasSeats) { index++; continue; }

                var seats = st.CinemaRoom.Seats.OrderBy(s => s.Hang).ThenBy(s => s.Cot).ToList();
                int totalSeats = seats.Count;

                // Tỷ lệ ghế đặt trước:
                // Suất 0: 10 ghế (Đang bán - xanh)
                // Suất 1: ~88% (Gần đầy - cam)
                // Suất 2: 100% (Đã đầy - đỏ)
                // Suất 3: ~85% (Gần đầy - cam)
                // Suất 4: 12 ghế (Đang bán - xanh)
                // Suất 5: 0 ghế (Đang bán - mới mở)
                int bookedTarget = (index % 6) switch
                {
                    0 => Math.Min(10, totalSeats),
                    1 => (int)(totalSeats * 0.88),
                    2 => totalSeats,
                    3 => (int)(totalSeats * 0.85),
                    4 => Math.Min(12, totalSeats),
                    _ => 0
                };
                index++;

                for (int i = 0; i < totalSeats; i++)
                {
                    context.TrangThaiGheTheoSuats.Add(new SeatShowtimeStatus
                    {
                        ShowtimeId = st.Id,
                        SeatId = seats[i].Id,
                        TrangThai = i < bookedTarget ? SeatStatus.DaDat : SeatStatus.Trong,
                        ThoiGianGiu = null
                    });
                }
            }

            // 2. Đối với các suất chiếu tương lai (ngày mai, ngày mốt): Đảm bảo tất cả ghế là TRỐNG để nhân viên test bán vé trước
            var futureStatuses = await context.TrangThaiGheTheoSuats
                .Where(x => x.Showtime.NgayChieu.Date > today && x.TrangThai == SeatStatus.DaDat)
                .ToListAsync();
            foreach (var s in futureStatuses) s.TrangThai = SeatStatus.Trong;

            var futureShowtimes = await context.SuatChieus
                .Where(s => s.NgayChieu.Date > today)
                .Include(s => s.CinemaRoom).ThenInclude(r => r.Seats)
                .ToListAsync();

            foreach (var st in futureShowtimes)
            {
                bool hasSeats = await context.TrangThaiGheTheoSuats.AnyAsync(x => x.ShowtimeId == st.Id);
                if (hasSeats) continue;

                var seats = st.CinemaRoom.Seats.OrderBy(s => s.Hang).ThenBy(s => s.Cot).ToList();
                for (int i = 0; i < seats.Count; i++)
                {
                    context.TrangThaiGheTheoSuats.Add(new SeatShowtimeStatus
                    {
                        ShowtimeId = st.Id,
                        SeatId = seats[i].Id,
                        TrangThai = SeatStatus.Trong,
                        ThoiGianGiu = null
                    });
                }
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedSampleTicketsAsync(CinemaDbContext context, Func<string> qrPayloadFactory)
        {
            var today = DateTime.Today;

            // Đảm bảo có ít nhất 1 vé đã check-in cho ngày hôm nay để card Check-in trên Dashboard hiển thị đúng
            bool hasCheckedInToday = await context.Ves.AnyAsync(v => v.Showtime.NgayChieu.Date == today && v.TrangThaiCheckIn == CheckInStatus.DaCheckIn);
            if (!hasCheckedInToday)
            {
                var firstTicketToday = await context.Ves
                    .Where(v => v.Showtime.NgayChieu.Date == today)
                    .OrderBy(v => v.Id)
                    .FirstOrDefaultAsync();

                if (firstTicketToday != null)
                {
                    firstTicketToday.TrangThaiCheckIn = CheckInStatus.DaCheckIn;
                    firstTicketToday.ThoiGianCheckIn = DateTime.Now.AddMinutes(-5);
                    await context.SaveChangesAsync();
                }
            }

            // Nếu hôm nay đã có vé rồi thì không seed thêm để tránh trùng lặp
            if (await context.Ves.AnyAsync(v => v.Showtime.NgayChieu.Date == today)) return;

            var cashier = await context.NguoiDungs.FirstOrDefaultAsync(u => u.Email == "cashier@cinemamanagement.local")
                       ?? await context.NguoiDungs.FirstAsync();
            var customers = await context.KhachHangs.OrderBy(c => c.Id).ToListAsync();
            var showtimesToday = await context.SuatChieus
                .Where(s => s.NgayChieu.Date == today)
                .Include(s => s.CinemaRoom).ThenInclude(r => r.Seats)
                .OrderBy(s => s.GioBatDau)
                .ToListAsync();
            var combos = await context.Combos.ToListAsync();

            if (customers.Count == 0 || showtimesToday.Count == 0) return;

            var c1 = customers[0]; // Nguyễn Văn Khách
            var c2 = customers.Count > 1 ? customers[1] : c1; // Trần Thị Thu Trang
            var c3 = customers.Count > 2 ? customers[2] : c1; // Lê Hoàng Nam
            var c4 = customers.Count > 3 ? customers[3] : c1; // Phạm Quỳnh Anh

            var comboSolo = combos.FirstOrDefault(c => c.TenCombo.Contains("Solo"));
            var comboCouple = combos.FirstOrDefault(c => c.TenCombo.Contains("Couple"));
            var comboFamily = combos.FirstOrDefault(c => c.TenCombo.Contains("Family"));

            // HÓA ĐƠN 1: Tiền mặt - 2 vé - 1 vé ĐÃ CHECK-IN, 1 vé CHƯA CHECK-IN - Kèm 1 Combo Solo (Khách: 0901234567)
            var st1 = showtimesToday[0];
            var seats1 = await context.TrangThaiGheTheoSuats
                .Where(x => x.ShowtimeId == st1.Id && x.TrangThai == SeatStatus.DaDat)
                .OrderBy(x => x.SeatId)
                .Select(x => x.SeatId)
                .Take(2)
                .ToListAsync();

            if (seats1.Count > 0)
            {
                var inv1 = new Invoice
                {
                    UserId = cashier.Id,
                    CustomerId = c1.Id,
                    NgayLap = DateTime.Now,
                    TongTien = (st1.GiaVeCoSo * seats1.Count) + (comboSolo?.Gia ?? 0),
                    TrangThaiThanhToan = InvoiceStatus.DaThanhToan,
                    PhuongThuc = PaymentMethod.TienMat
                };

                int seatIdx = 0;
                foreach (var sId in seats1)
                {
                    bool alreadyCheckedIn = seatIdx == 0;
                    inv1.Tickets.Add(new Ticket
                    {
                        ShowtimeId = st1.Id,
                        SeatId = sId,
                        GiaVe = st1.GiaVeCoSo,
                        MaQR = qrPayloadFactory(),
                        TrangThaiCheckIn = alreadyCheckedIn ? CheckInStatus.DaCheckIn : CheckInStatus.ChuaCheckIn,
                        ThoiGianCheckIn = alreadyCheckedIn ? DateTime.Now.AddMinutes(-5) : null
                    });
                    seatIdx++;
                }
                if (comboSolo != null)
                {
                    inv1.InvoiceCombos.Add(new InvoiceCombo { ComboId = comboSolo.Id, SoLuong = 1, DonGiaLucMua = comboSolo.Gia });
                }
                await context.HoaDons.AddAsync(inv1);
                await context.SaveChangesAsync();
            }

            // HÓA ĐƠN 2: Chuyển khoản SePay - 2 vé VIP - CHƯA CHECK-IN - Kèm 1 Combo Couple (Khách: 0988888888)
            var st2 = showtimesToday.Count > 1 ? showtimesToday[1] : st1;
            var seats2 = await context.TrangThaiGheTheoSuats
                .Where(x => x.ShowtimeId == st2.Id && x.TrangThai == SeatStatus.DaDat)
                .OrderBy(x => x.SeatId)
                .Select(x => x.SeatId)
                .Take(2)
                .ToListAsync();

            var existing2 = await context.Ves.Where(v => v.ShowtimeId == st2.Id).Select(v => v.SeatId).ToListAsync();
            var validSeats2 = seats2.Except(existing2).ToList();

            if (validSeats2.Count > 0)
            {
                var inv2 = new Invoice
                {
                    UserId = cashier.Id,
                    CustomerId = c2.Id,
                    NgayLap = DateTime.Now,
                    TongTien = (st2.GiaVeCoSo * validSeats2.Count) + (comboCouple?.Gia ?? 0),
                    TrangThaiThanhToan = InvoiceStatus.DaThanhToan,
                    PhuongThuc = PaymentMethod.ChuyenKhoanOnline
                };

                foreach (var sId in validSeats2)
                {
                    inv2.Tickets.Add(new Ticket
                    {
                        ShowtimeId = st2.Id,
                        SeatId = sId,
                        GiaVe = st2.GiaVeCoSo,
                        MaQR = qrPayloadFactory(),
                        TrangThaiCheckIn = CheckInStatus.ChuaCheckIn,
                        ThoiGianCheckIn = null
                    });
                }
                if (comboCouple != null)
                {
                    inv2.InvoiceCombos.Add(new InvoiceCombo { ComboId = comboCouple.Id, SoLuong = 1, DonGiaLucMua = comboCouple.Gia });
                }
                await context.HoaDons.AddAsync(inv2);
                await context.SaveChangesAsync();
            }

            // HÓA ĐƠN 3: Tiền mặt - 1 vé - CHƯA CHECK-IN - KHÔNG KÈM COMBO (Khách: 0912345678)
            var st3 = showtimesToday.Count > 2 ? showtimesToday[2] : st1;
            var seats3 = await context.TrangThaiGheTheoSuats
                .Where(x => x.ShowtimeId == st3.Id && x.TrangThai == SeatStatus.DaDat)
                .OrderBy(x => x.SeatId)
                .Select(x => x.SeatId)
                .Take(1)
                .ToListAsync();

            var existing3 = await context.Ves.Where(v => v.ShowtimeId == st3.Id).Select(v => v.SeatId).ToListAsync();
            var validSeats3 = seats3.Except(existing3).ToList();

            if (validSeats3.Count > 0)
            {
                var inv3 = new Invoice
                {
                    UserId = cashier.Id,
                    CustomerId = c3.Id,
                    NgayLap = DateTime.Now,
                    TongTien = st3.GiaVeCoSo * validSeats3.Count,
                    TrangThaiThanhToan = InvoiceStatus.DaThanhToan,
                    PhuongThuc = PaymentMethod.TienMat
                };

                foreach (var sId in validSeats3)
                {
                    inv3.Tickets.Add(new Ticket
                    {
                        ShowtimeId = st3.Id,
                        SeatId = sId,
                        GiaVe = st3.GiaVeCoSo,
                        MaQR = qrPayloadFactory(),
                        TrangThaiCheckIn = CheckInStatus.ChuaCheckIn,
                        ThoiGianCheckIn = null
                    });
                }
                await context.HoaDons.AddAsync(inv3);
                await context.SaveChangesAsync();
            }

            // HÓA ĐƠN 4: Chuyển khoản SePay - 4 vé Gia đình - CHƯA CHECK-IN - Kèm Combo Family (Khách: 0977112233)
            var st4 = showtimesToday.Count > 3 ? showtimesToday[3] : st1;
            var seats4 = await context.TrangThaiGheTheoSuats
                .Where(x => x.ShowtimeId == st4.Id && x.TrangThai == SeatStatus.DaDat)
                .OrderBy(x => x.SeatId)
                .Select(x => x.SeatId)
                .Take(4)
                .ToListAsync();

            var existing4 = await context.Ves.Where(v => v.ShowtimeId == st4.Id).Select(v => v.SeatId).ToListAsync();
            var validSeats4 = seats4.Except(existing4).ToList();

            if (validSeats4.Count > 0)
            {
                var inv4 = new Invoice
                {
                    UserId = cashier.Id,
                    CustomerId = c4.Id,
                    NgayLap = DateTime.Now,
                    TongTien = (st4.GiaVeCoSo * validSeats4.Count) + (comboFamily?.Gia ?? 0),
                    TrangThaiThanhToan = InvoiceStatus.DaThanhToan,
                    PhuongThuc = PaymentMethod.ChuyenKhoanOnline
                };

                foreach (var sId in validSeats4)
                {
                    inv4.Tickets.Add(new Ticket
                    {
                        ShowtimeId = st4.Id,
                        SeatId = sId,
                        GiaVe = st4.GiaVeCoSo,
                        MaQR = qrPayloadFactory(),
                        TrangThaiCheckIn = CheckInStatus.ChuaCheckIn,
                        ThoiGianCheckIn = null
                    });
                }
                if (comboFamily != null)
                {
                    inv4.InvoiceCombos.Add(new InvoiceCombo { ComboId = comboFamily.Id, SoLuong = 1, DonGiaLucMua = comboFamily.Gia });
                }
                await context.HoaDons.AddAsync(inv4);
                await context.SaveChangesAsync();
            }

            // Cấp vé cho TẤT CẢ các ghế đã đặt còn lại của các suất hôm nay để số liệu dashboard và tiến độ thanh bar hiển thị đúng thực tế 100%
            foreach (var st in showtimesToday)
            {
                var bookedSeatIds = await context.TrangThaiGheTheoSuats
                    .Where(x => x.ShowtimeId == st.Id && x.TrangThai == SeatStatus.DaDat)
                    .Select(x => x.SeatId)
                    .ToListAsync();

                var existingTicketSeatIds = await context.Ves
                    .Where(v => v.ShowtimeId == st.Id)
                    .Select(v => v.SeatId)
                    .ToListAsync();

                var remainingSeats = bookedSeatIds
                    .Except(existingTicketSeatIds)
                    .Distinct()
                    .ToList();

                if (remainingSeats.Count > 0)
                {
                    var extraInvoice = new Invoice
                    {
                        UserId = cashier.Id,
                        CustomerId = c1.Id,
                        NgayLap = DateTime.Now,
                        TongTien = st.GiaVeCoSo * remainingSeats.Count,
                        TrangThaiThanhToan = InvoiceStatus.DaThanhToan,
                        PhuongThuc = PaymentMethod.TienMat
                    };

                    foreach (var sId in remainingSeats)
                    {
                        extraInvoice.Tickets.Add(new Ticket
                        {
                            ShowtimeId = st.Id,
                            SeatId = sId,
                            GiaVe = st.GiaVeCoSo,
                            MaQR = qrPayloadFactory(),
                            TrangThaiCheckIn = CheckInStatus.ChuaCheckIn
                        });
                    }
                    await context.HoaDons.AddAsync(extraInvoice);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}