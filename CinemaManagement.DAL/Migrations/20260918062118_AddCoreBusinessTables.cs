using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CinemaManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCoreBusinessTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenCombo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Gia = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    MoTa = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HoTen = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SDT = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    DiemTichLuy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiGhePhuThu",
                columns: table => new
                {
                    LoaiGhe = table.Column<int>(type: "integer", nullable: false),
                    SoTienPhuThu = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiGhePhuThu", x => x.LoaiGhe);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyHeThong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    HanhDong = table.Column<int>(type: "integer", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChiTiet = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyHeThong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyHeThong_NguoiDung_UserId",
                        column: x => x.UserId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Phim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenPhim = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ThoiLuong = table.Column<int>(type: "integer", nullable: false),
                    DoTuoi = table.Column<int>(type: "integer", nullable: false),
                    DaoDien = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    DienVien = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NgayKhoiChieu = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    Poster = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongChieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenPhong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SoHang = table.Column<int>(type: "integer", nullable: false),
                    SoCot = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongChieu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenTheLoai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TongTien = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    TrangThaiThanhToan = table.Column<int>(type: "integer", nullable: false),
                    PhuongThuc = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_NguoiDung_UserId",
                        column: x => x.UserId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ghe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CinemaRoomId = table.Column<int>(type: "integer", nullable: false),
                    Hang = table.Column<int>(type: "integer", nullable: false),
                    Cot = table.Column<int>(type: "integer", nullable: false),
                    LoaiGhe = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ghe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ghe_PhongChieu_CinemaRoomId",
                        column: x => x.CinemaRoomId,
                        principalTable: "PhongChieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuatChieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    CinemaRoomId = table.Column<int>(type: "integer", nullable: false),
                    NgayChieu = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GioBatDau = table.Column<TimeSpan>(type: "interval", nullable: false),
                    GioKetThuc = table.Column<TimeSpan>(type: "interval", nullable: false),
                    GiaVeCoSo = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuatChieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuatChieu_Phim_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Phim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuatChieu_PhongChieu_CinemaRoomId",
                        column: x => x.CinemaRoomId,
                        principalTable: "PhongChieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phim_TheLoai",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phim_TheLoai", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_Phim_TheLoai_Phim_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Phim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phim_TheLoai_TheLoai_GenreId",
                        column: x => x.GenreId,
                        principalTable: "TheLoai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaoDichThanhToan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    MaGiaoDichVNPay = table.Column<string>(type: "text", nullable: true),
                    SoTien = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    MaPhanHoi = table.Column<string>(type: "text", nullable: true),
                    NoiDungIPN = table.Column<string>(type: "text", nullable: true),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoDichThanhToan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaoDichThanhToan_HoaDon_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonCombo",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    ComboId = table.Column<int>(type: "integer", nullable: false),
                    SoLuong = table.Column<int>(type: "integer", nullable: false),
                    DonGiaLucMua = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonCombo", x => new { x.InvoiceId, x.ComboId });
                    table.ForeignKey(
                        name: "FK_HoaDonCombo_Combo_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDonCombo_HoaDon_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichSuGuiEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    DiaChiNhan = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ThoiGianGui = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    LoiNeuCo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuGuiEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichSuGuiEmail_HoaDon_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiGheTheoSuat",
                columns: table => new
                {
                    ShowtimeId = table.Column<int>(type: "integer", nullable: false),
                    SeatId = table.Column<int>(type: "integer", nullable: false),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    ThoiGianGiu = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiGheTheoSuat", x => new { x.ShowtimeId, x.SeatId });
                    table.ForeignKey(
                        name: "FK_TrangThaiGheTheoSuat_Ghe_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Ghe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrangThaiGheTheoSuat_SuatChieu_ShowtimeId",
                        column: x => x.ShowtimeId,
                        principalTable: "SuatChieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    ShowtimeId = table.Column<int>(type: "integer", nullable: false),
                    SeatId = table.Column<int>(type: "integer", nullable: false),
                    GiaVe = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    MaQR = table.Column<string>(type: "text", nullable: false),
                    TrangThaiCheckIn = table.Column<int>(type: "integer", nullable: false),
                    ThoiGianCheckIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ve_Ghe_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Ghe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ve_HoaDon_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ve_SuatChieu_ShowtimeId",
                        column: x => x.ShowtimeId,
                        principalTable: "SuatChieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ghe_CinemaRoomId_Hang_Cot",
                table: "Ghe",
                columns: new[] { "CinemaRoomId", "Hang", "Cot" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiaoDichThanhToan_InvoiceId",
                table: "GiaoDichThanhToan",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_CustomerId",
                table: "HoaDon",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_UserId",
                table: "HoaDon",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCombo_ComboId",
                table: "HoaDonCombo",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_SDT",
                table: "KhachHang",
                column: "SDT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichSuGuiEmail_InvoiceId",
                table: "LichSuGuiEmail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyHeThong_UserId",
                table: "NhatKyHeThong",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Phim_TheLoai_GenreId",
                table: "Phim_TheLoai",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongChieu_TenPhong",
                table: "PhongChieu",
                column: "TenPhong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuatChieu_CinemaRoomId",
                table: "SuatChieu",
                column: "CinemaRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SuatChieu_MovieId",
                table: "SuatChieu",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_TheLoai_TenTheLoai",
                table: "TheLoai",
                column: "TenTheLoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiGheTheoSuat_SeatId",
                table: "TrangThaiGheTheoSuat",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_InvoiceId",
                table: "Ve",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_MaQR",
                table: "Ve",
                column: "MaQR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ve_SeatId",
                table: "Ve",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_ShowtimeId_SeatId",
                table: "Ve",
                columns: new[] { "ShowtimeId", "SeatId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaoDichThanhToan");

            migrationBuilder.DropTable(
                name: "HoaDonCombo");

            migrationBuilder.DropTable(
                name: "LichSuGuiEmail");

            migrationBuilder.DropTable(
                name: "LoaiGhePhuThu");

            migrationBuilder.DropTable(
                name: "NhatKyHeThong");

            migrationBuilder.DropTable(
                name: "Phim_TheLoai");

            migrationBuilder.DropTable(
                name: "TrangThaiGheTheoSuat");

            migrationBuilder.DropTable(
                name: "Ve");

            migrationBuilder.DropTable(
                name: "Combo");

            migrationBuilder.DropTable(
                name: "TheLoai");

            migrationBuilder.DropTable(
                name: "Ghe");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SuatChieu");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "Phim");

            migrationBuilder.DropTable(
                name: "PhongChieu");
        }
    }
}
