using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CinemaManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaQuyen = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenQuyen = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenVaiTro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MatKhauHash = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    TrangThaiTaiKhoan = table.Column<int>(type: "integer", nullable: false),
                    SoLanSaiMatKhau = table.Column<int>(type: "integer", nullable: false),
                    ThoiGianKhoaDenLuc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDung_VaiTro_RoleId",
                        column: x => x.RoleId,
                        principalTable: "VaiTro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro_Quyen",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    PermissionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro_Quyen", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_VaiTro_Quyen_Quyen_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Quyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaiTro_Quyen_VaiTro_RoleId",
                        column: x => x.RoleId,
                        principalTable: "VaiTro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_Email",
                table: "NguoiDung",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_RoleId",
                table: "NguoiDung",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Quyen_MaQuyen",
                table: "Quyen",
                column: "MaQuyen",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_Quyen_PermissionId",
                table: "VaiTro_Quyen",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "VaiTro_Quyen");

            migrationBuilder.DropTable(
                name: "Quyen");

            migrationBuilder.DropTable(
                name: "VaiTro");
        }
    }
}
