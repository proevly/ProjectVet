using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectVet.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:ProjectVet/Migrations/20240601163311_migration_eklendi.cs
    public partial class migrationeklendi : Migration
========
    public partial class first : Migration
>>>>>>>> master:ProjectVet/Migrations/20240601165648_first.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KullaniciName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cins = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciId");
                });

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HayvanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RandevuTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RandevuSaat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AsiMiMuayeneMi = table.Column<bool>(type: "bit", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OnaylandiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Randevu_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciId");
                    table.ForeignKey(
                        name: "FK_Randevu_Pet_HayvanId",
                        column: x => x.HayvanId,
                        principalTable: "Pet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_KullaniciId",
                table: "Pet",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_HayvanId",
                table: "Randevu",
                column: "HayvanId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_KullaniciId",
                table: "Randevu",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Randevu");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Kullanici");
        }
    }
}
