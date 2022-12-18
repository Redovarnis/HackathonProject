using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Corporates_CorporateId",
                        column: x => x.CorporateId,
                        principalTable: "Corporates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientName", "CorporateId", "OrderDate", "ProductId" },
                values: new object[] { 1, "Cihan Vural", 3, new DateTime(2022, 12, 18, 5, 19, 0, 492, DateTimeKind.Local).AddTicks(634), 3 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientName", "CorporateId", "OrderDate", "ProductId" },
                values: new object[] { 2, "Cihan Vural", 3, new DateTime(2022, 12, 18, 5, 19, 0, 492, DateTimeKind.Local).AddTicks(635), 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientName", "CorporateId", "OrderDate", "ProductId" },
                values: new object[] { 3, "Cihan Vural", 3, new DateTime(2022, 12, 18, 5, 19, 0, 492, DateTimeKind.Local).AddTicks(636), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CorporateId",
                table: "Orders",
                column: "CorporateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
