using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectVet.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class randevuKisit_eklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandevuKisit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OgledenOnceMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuKisit", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandevuKisit");
        }
    }
}
