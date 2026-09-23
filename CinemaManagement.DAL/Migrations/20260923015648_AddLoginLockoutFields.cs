using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginLockoutFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LanSaiCuoiCung",
                table: "NguoiDung",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLanBiKhoa",
                table: "NguoiDung",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanSaiCuoiCung",
                table: "NguoiDung");

            migrationBuilder.DropColumn(
                name: "SoLanBiKhoa",
                table: "NguoiDung");
        }
    }
}
