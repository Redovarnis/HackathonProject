using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    CorporateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Corporates_CorporateId",
                        column: x => x.CorporateId,
                        principalTable: "Corporates",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Corporates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndOrderTime", "StartOrderTime" },
                values: new object[] { new DateTime(2022, 12, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 18, 8, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Corporates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndOrderTime", "StartOrderTime" },
                values: new object[] { new DateTime(2022, 12, 18, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 18, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Corporates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndOrderTime", "StartOrderTime" },
                values: new object[] { new DateTime(2022, 12, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 18, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CorporateId", "CorporateName", "ProductName", "Stock", "UnitPrice" },
                values: new object[,]
                {
                    { 1, null, "YemekSepeti", "Tantuni", 5, 45.0 },
                    { 2, null, "YemekSepeti", "Döner", 5, 40.0 },
                    { 3, null, "YemekSepeti", "Tavuklu Makarna", 5, 40.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CorporateId",
                table: "Products",
                column: "CorporateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "Corporates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndOrderTime", "StartOrderTime" },
                values: new object[] { new DateTime(2022, 12, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 17, 8, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Corporates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndOrderTime", "StartOrderTime" },
                values: new object[] { new DateTime(2022, 12, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 17, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Corporates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndOrderTime", "StartOrderTime" },
                values: new object[] { new DateTime(2022, 12, 17, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 17, 13, 30, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
