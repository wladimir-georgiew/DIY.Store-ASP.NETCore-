using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIY.Castle.Data.Migrations
{
    public partial class SeedDefaultProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "ImageSourcePath", "IsDeleted", "Name", "Price" },
                values: new object[] { 1, new DateTime(2021, 8, 14, 15, 33, 9, 563, DateTimeKind.Utc).AddTicks(8458), null, "This is just a sample product with short description.", "~/images/stock/book1.jpg", false, "Book", 0.80m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "ImageSourcePath", "IsDeleted", "Name", "Price" },
                values: new object[] { 2, new DateTime(2021, 8, 14, 15, 33, 9, 565, DateTimeKind.Utc).AddTicks(5373), null, "This is just a sample product with a medium description length.Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "~/images/stock/book2.jpg", false, "Book2", 0.05m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "ImageSourcePath", "IsDeleted", "Name", "Price" },
                values: new object[] { 3, new DateTime(2021, 8, 14, 15, 33, 9, 565, DateTimeKind.Utc).AddTicks(5575), null, "This is just a sample product with long description for testing the front-end.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam", "~/images/stock/book3.jpg", false, "Book3", 150.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
