using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIY.Castle.Data.Migrations
{
    public partial class ChangeProductTypePropertyToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductType",
                table: "Products",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "257bf36c-25eb-4e76-8a7e-b0e2bfdf77d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b131d82a-925a-4dd4-97a7-d6959361eec7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ec85362-91e3-4731-a8a8-19a91317cb33", "AQAAAAEAACcQAAAAEOh5PxbU8SWPAecAq8iJ6MZifbD0xkQ6l5KPrhQW+J6W1XNMt1zJFtcPSkrSm1VjqA==", "3db11b57-c9e5-45c1-bbbb-77405095c342" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ProductType" },
                values: new object[] { new DateTime(2021, 10, 20, 13, 22, 1, 271, DateTimeKind.Utc).AddTicks(2778), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ProductType" },
                values: new object[] { new DateTime(2021, 10, 20, 13, 22, 1, 271, DateTimeKind.Utc).AddTicks(3323), 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ProductType" },
                values: new object[] { new DateTime(2021, 10, 20, 13, 22, 1, 271, DateTimeKind.Utc).AddTicks(3354), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductType",
                table: "Products",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "c1baaa4b-f2c6-4a6b-af6f-18a882dc1ea4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "649b2284-f33d-474e-b996-6d1afb934a65");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a52837f2-3230-4591-9493-78abd39bac82", "AQAAAAEAACcQAAAAEPDE2/iZiabSnCIo1JJRGTxBA5KQdh4fnpSvOUtGyQEPEiGF6ghNfzfglXDWMHDmVQ==", "4e73e3be-ae22-4af1-86a1-c9c9f932f229" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ProductType" },
                values: new object[] { new DateTime(2021, 10, 19, 21, 21, 44, 151, DateTimeKind.Utc).AddTicks(6797), "Icon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ProductType" },
                values: new object[] { new DateTime(2021, 10, 19, 21, 21, 44, 151, DateTimeKind.Utc).AddTicks(7318), "BookSeparator" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ProductType" },
                values: new object[] { new DateTime(2021, 10, 19, 21, 21, 44, 151, DateTimeKind.Utc).AddTicks(7347), "Candle" });
        }
    }
}
