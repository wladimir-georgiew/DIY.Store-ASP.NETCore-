using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIY.Castle.Data.Migrations
{
    public partial class AddedProductTypeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Products",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "d8322e8e-fcc4-4a77-98fe-720d8bc74c49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c855625b-f147-42f4-9953-0b19689391a5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1131f0f-26c4-4251-8cbc-f42065b12c3d", "AQAAAAEAACcQAAAAEIqQ+Ncn68euZUZaOkUpJeGPL+Z0BxpuKQq38fgdNqeRyIsh6xXedcyNGgf/wSuzXw==", "0ce0e54c-500d-4c78-b13b-71a04cc0f106" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 1, 12, 33, 56, 40, DateTimeKind.Utc).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 1, 12, 33, 56, 40, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 1, 12, 33, 56, 40, DateTimeKind.Utc).AddTicks(8851));
        }
    }
}
