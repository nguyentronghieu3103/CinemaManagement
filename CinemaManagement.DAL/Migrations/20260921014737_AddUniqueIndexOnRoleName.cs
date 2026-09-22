using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexOnRoleName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_TenVaiTro",
                table: "VaiTro",
                column: "TenVaiTro",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VaiTro_TenVaiTro",
                table: "VaiTro");
        }
    }
}
