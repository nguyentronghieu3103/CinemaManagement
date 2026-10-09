using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaymentToSeepay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaGiaoDichVNPay",
                table: "GiaoDichThanhToan",
                newName: "MaGiaoDichSeepay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaGiaoDichSeepay",
                table: "GiaoDichThanhToan",
                newName: "MaGiaoDichVNPay");
        }
    }
}
