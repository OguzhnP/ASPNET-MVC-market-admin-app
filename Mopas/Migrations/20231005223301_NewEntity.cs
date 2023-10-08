using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mopas.Migrations
{
    public partial class NewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesReportId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalesReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SalesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SalesReportId",
                table: "Products",
                column: "SalesReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SalesReports_SalesReportId",
                table: "Products",
                column: "SalesReportId",
                principalTable: "SalesReports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SalesReports_SalesReportId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "SalesReports");

            migrationBuilder.DropIndex(
                name: "IX_Products_SalesReportId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalesReportId",
                table: "Products");
        }
    }
}
