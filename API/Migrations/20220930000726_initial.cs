using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jabatan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(nullable: true),
                    GajiPokok = table.Column<int>(nullable: false),
                    Tunjangan = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jabatan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Karyawan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaLengkap = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NomerRekening = table.Column<string>(nullable: true),
                    NomerTelepon = table.Column<string>(nullable: true),
                    JabatanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karyawan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Karyawan_Jabatan_JabatanID",
                        column: x => x.JabatanID,
                        principalTable: "Jabatan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bonus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KaryawanID = table.Column<int>(nullable: false),
                    Jumlah = table.Column<int>(nullable: false),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Keterangan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bonus_Karyawan_KaryawanID",
                        column: x => x.KaryawanID,
                        principalTable: "Karyawan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuti",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KaryawanID = table.Column<int>(nullable: false),
                    JumlahHari = table.Column<int>(nullable: false),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Keterangan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cuti_Karyawan_KaryawanID",
                        column: x => x.KaryawanID,
                        principalTable: "Karyawan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gaji",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BulanTahun = table.Column<DateTime>(nullable: false),
                    KaryawanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gaji", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gaji_Karyawan_KaryawanID",
                        column: x => x.KaryawanID,
                        principalTable: "Karyawan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lembur",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KaryawanID = table.Column<int>(nullable: false),
                    JumlahJam = table.Column<int>(nullable: false),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Keterangan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lembur", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lembur_Karyawan_KaryawanID",
                        column: x => x.KaryawanID,
                        principalTable: "Karyawan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Potongan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KaryawanID = table.Column<int>(nullable: false),
                    Jumlah = table.Column<int>(nullable: false),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Keterangan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potongan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Potongan_Karyawan_KaryawanID",
                        column: x => x.KaryawanID,
                        principalTable: "Karyawan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Karyawan_ID",
                        column: x => x.ID,
                        principalTable: "Karyawan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_KaryawanID",
                table: "Bonus",
                column: "KaryawanID");

            migrationBuilder.CreateIndex(
                name: "IX_Cuti_KaryawanID",
                table: "Cuti",
                column: "KaryawanID");

            migrationBuilder.CreateIndex(
                name: "IX_Gaji_KaryawanID",
                table: "Gaji",
                column: "KaryawanID");

            migrationBuilder.CreateIndex(
                name: "IX_Karyawan_JabatanID",
                table: "Karyawan",
                column: "JabatanID");

            migrationBuilder.CreateIndex(
                name: "IX_Lembur_KaryawanID",
                table: "Lembur",
                column: "KaryawanID");

            migrationBuilder.CreateIndex(
                name: "IX_Potongan_KaryawanID",
                table: "Potongan",
                column: "KaryawanID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonus");

            migrationBuilder.DropTable(
                name: "Cuti");

            migrationBuilder.DropTable(
                name: "Gaji");

            migrationBuilder.DropTable(
                name: "Lembur");

            migrationBuilder.DropTable(
                name: "Potongan");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Karyawan");

            migrationBuilder.DropTable(
                name: "Jabatan");
        }
    }
}
