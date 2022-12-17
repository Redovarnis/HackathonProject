using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corporates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderState = table.Column<bool>(type: "bit", nullable: false),
                    StartOrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOrderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Corporates",
                columns: new[] { "Id", "CorporateName", "EndOrderTime", "OrderState", "StartOrderTime" },
                values: new object[,]
                {
                    { 1, "Getir", new DateTime(2022, 12, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 12, 17, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "YemekSepeti", new DateTime(2022, 12, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 12, 17, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Trendyol", new DateTime(2022, 12, 17, 16, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 12, 17, 13, 30, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corporates");
        }
    }
}
