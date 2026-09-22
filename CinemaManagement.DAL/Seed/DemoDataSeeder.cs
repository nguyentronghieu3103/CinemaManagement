using CinemaApp.Common.Entities;
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;
using CinemaManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.DAL.Seed
{
    public static class DemoDataSeeder
    {
        public static async Task SeedAsync(CinemaDbContext context)
        {
            await SeedSeatSurchargesAsync(context);   // bắt buộc, không phải data "demo" thật sự
            await SeedGenresAsync(context);
            await SeedMoviesAsync(context);
            await SeedRoomsAsync(context);
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
    }
}