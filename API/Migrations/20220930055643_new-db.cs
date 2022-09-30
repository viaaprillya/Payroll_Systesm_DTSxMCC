using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BulanTahun",
                table: "Gaji");

            migrationBuilder.AddColumn<int>(
                name: "Bulan",
                table: "Gaji",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tahun",
                table: "Gaji",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bulan",
                table: "Gaji");

            migrationBuilder.DropColumn(
                name: "Tahun",
                table: "Gaji");

            migrationBuilder.AddColumn<DateTime>(
                name: "BulanTahun",
                table: "Gaji",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
