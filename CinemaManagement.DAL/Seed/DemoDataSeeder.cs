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
            int countToday = await context.SuatChieus.CountAsync(s => s.NgayChieu.Date == today);
            if (countToday < 5)
            {
                // Tạo các suất chiếu hôm nay: Trải dài từ thời điểm hiện tại trở đi để luôn lọt vào danh sách "Sắp diễn ra"
                var now = DateTime.Now;
                var schedulesToday = new[]
                {
                    (getMovie("Kung Fu Panda"), r1, now.AddMinutes(20), 85000m),
                    (getMovie("Godzilla x Kong"), r1, now.AddMinutes(85), 95000m),
                    (getMovie("Dune"), r2, now.AddMinutes(160), 110000m),
                    (getMovie("Mai"), r2, now.AddMinutes(250), 100000m),
                    (getMovie("Exhuma"), r3, now.AddMinutes(340), 120000m),
                    (getMovie("Lật Mặt 7"), r1, now.AddMinutes(440), 90000m)
                };

                foreach (var (m, r, startDt, price) in schedulesToday)
                {
                    var startSpan = new TimeSpan(startDt.Hour, startDt.Minute, 0);
                    if (startDt.Date > today) startSpan = new TimeSpan(23, 45, 0); // nếu vượt quá nửa đêm thì ghim cuối ngày
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
            var showtimes = await context.SuatChieus
                .Include(s => s.CinemaRoom).ThenInclude(r => r.Seats)
                .ToListAsync();

            int index = 0;
            foreach (var st in showtimes)
            {
                bool hasSeats = await context.TrangThaiGheTheoSuats.AnyAsync(x => x.ShowtimeId == st.Id);
                if (hasSeats) continue;

                var seats = st.CinemaRoom.Seats.OrderBy(s => s.Hang).ThenBy(s => s.Cot).ToList();
                int totalSeats = seats.Count;

                // Xác định tỷ lệ ghế đặt trước để test các trạng thái trên Dashboard:
                // Suất 0: ~20% (Đang bán - xanh)
                // Suất 1: ~88% (Gần đầy - cam)
                // Suất 2: 100% (Đã đầy - đỏ)
                // Suất 3: ~85% (Gần đầy - cam)
                // Suất 4: ~35% (Đang bán - xanh)
                // Suất 5: 0% (Đang bán - rạp mới mở)
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
            await context.SaveChangesAsync();
        }

        private static async Task SeedSampleTicketsAsync(CinemaDbContext context, Func<string> qrPayloadFactory)
        {
            if (await context.Ves.CountAsync() >= 6) return;

            var cashier = await context.NguoiDungs.FirstOrDefaultAsync(u => u.Email == "cashier@cinemamanagement.local")
                       ?? await context.NguoiDungs.FirstAsync();
            var customers = await context.KhachHangs.OrderBy(c => c.Id).ToListAsync();
            var showtimes = await context.SuatChieus
                .Include(s => s.CinemaRoom).ThenInclude(r => r.Seats)
                .OrderBy(s => s.Id)
                .ToListAsync();
            var combos = await context.Combos.ToListAsync();

            if (customers.Count == 0 || showtimes.Count == 0) return;

            var c1 = customers[0]; // Nguyễn Văn Khách
            var c2 = customers.Count > 1 ? customers[1] : c1; // Trần Thị Thu Trang
            var c3 = customers.Count > 2 ? customers[2] : c1; // Lê Hoàng Nam
            var c4 = customers.Count > 3 ? customers[3] : c1; // Phạm Quỳnh Anh

            var comboSolo = combos.FirstOrDefault(c => c.TenCombo.Contains("Solo"));
            var comboCouple = combos.FirstOrDefault(c => c.TenCombo.Contains("Couple"));
            var comboFamily = combos.FirstOrDefault(c => c.TenCombo.Contains("Family"));

            // HÓA ĐƠN 1: Tiền mặt - 2 vé - ĐÃ CHECK-IN - Kèm 1 Combo Solo (Khách: 0901234567)
            var st1 = showtimes[0];
            var seats1 = await context.TrangThaiGheTheoSuats
                .Where(x => x.ShowtimeId == st1.Id && x.TrangThai == SeatStatus.DaDat)
                .Select(x => x.SeatId)
                .Take(2)
                .ToListAsync();

            var existing1 = await context.Ves.Where(v => v.ShowtimeId == st1.Id).Select(v => v.SeatId).ToListAsync();
            var validSeats1 = seats1.Except(existing1).ToList();

            if (validSeats1.Count > 0)
            {
                var inv1 = new Invoice
                {
                    UserId = cashier.Id,
                    CustomerId = c1.Id,
                    NgayLap = DateTime.Now,
                    TongTien = (st1.GiaVeCoSo * validSeats1.Count) + (comboSolo?.Gia ?? 0),
                    TrangThaiThanhToan = InvoiceStatus.DaThanhToan,
                    PhuongThuc = PaymentMethod.TienMat
                };

                foreach (var sId in validSeats1)
                {
                    inv1.Tickets.Add(new Ticket
                    {
                        ShowtimeId = st1.Id,
                        SeatId = sId,
                        GiaVe = st1.GiaVeCoSo,
                        MaQR = qrPayloadFactory(),
                        TrangThaiCheckIn = CheckInStatus.DaCheckIn,
                        ThoiGianCheckIn = DateTime.Now.AddMinutes(-30)
                    });
                }
                if (comboSolo != null)
                {
                    inv1.InvoiceCombos.Add(new InvoiceCombo { ComboId = comboSolo.Id, SoLuong = 1, DonGiaLucMua = comboSolo.Gia });
                }
                await context.HoaDons.AddAsync(inv1);
                await context.SaveChangesAsync();
            }

            // HÓA ĐƠN 2: Chuyển khoản SePay - 2 vé VIP - CHƯA CHECK-IN - Kèm 1 Combo Couple (Khách: 0988888888)
            var st2 = showtimes.Count > 1 ? showtimes[1] : st1;
            var seats2 = await context.TrangThaiGheTheoSuats
                .Where(x => x.ShowtimeId == st2.Id && x.TrangThai == SeatStatus.DaDat)
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
            var st3 = showtimes.Count > 2 ? showtimes[2] : st1;
            var seats3 = await context.TrangThaiGheTheoSuats
                .Where(x => x.ShowtimeId == st3.Id && x.TrangThai == SeatStatus.DaDat)
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
            var st4 = showtimes.Count > 3 ? showtimes[3] : st1;
            var seats4 = await context.TrangThaiGheTheoSuats
                .Where(x => x.ShowtimeId == st4.Id && x.TrangThai == SeatStatus.DaDat)
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

            // Tạo thêm vé bán cho các ghế đã đặt của các suất hôm nay để số liệu dashboard và tiến độ thanh bar hiển thị đúng thực tế
            foreach (var st in showtimes.Where(s => s.NgayChieu.Date == DateTime.Today))
            {
                var bookedSeatIds = await context.TrangThaiGheTheoSuats
                    .Where(x => x.ShowtimeId == st.Id && x.TrangThai == SeatStatus.DaDat)
                    .Select(x => x.SeatId)
                    .ToListAsync();

                var existingTicketSeatIds = await context.Ves
                    .Where(v => v.ShowtimeId == st.Id)
                    .Select(v => v.SeatId)
                    .ToListAsync();

                var localTicketSeatIds = context.ChangeTracker.Entries<Ticket>()
                    .Where(e => e.Entity.ShowtimeId == st.Id)
                    .Select(e => e.Entity.SeatId)
                    .ToList();

                var remainingSeats = bookedSeatIds
                    .Except(existingTicketSeatIds)
                    .Except(localTicketSeatIds)
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