using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIY.Castle.Data.Migrations
{
    public partial class FixSeededImageSourcePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ImageSourcePath" },
                values: new object[] { new DateTime(2021, 8, 16, 16, 20, 54, 367, DateTimeKind.Utc).AddTicks(8533), "/images/stock/book1.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ImageSourcePath" },
                values: new object[] { new DateTime(2021, 8, 16, 16, 20, 54, 369, DateTimeKind.Utc).AddTicks(8601), "/images/stock/book2.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ImageSourcePath" },
                values: new object[] { new DateTime(2021, 8, 16, 16, 20, 54, 369, DateTimeKind.Utc).AddTicks(8894), "/images/stock/book3.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ImageSourcePath" },
                values: new object[] { new DateTime(2021, 8, 14, 15, 33, 9, 563, DateTimeKind.Utc).AddTicks(8458), "~/images/stock/book1.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ImageSourcePath" },
                values: new object[] { new DateTime(2021, 8, 14, 15, 33, 9, 565, DateTimeKind.Utc).AddTicks(5373), "~/images/stock/book2.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ImageSourcePath" },
                values: new object[] { new DateTime(2021, 8, 14, 15, 33, 9, 565, DateTimeKind.Utc).AddTicks(5575), "~/images/stock/book3.jpg" });
        }
    }
}
