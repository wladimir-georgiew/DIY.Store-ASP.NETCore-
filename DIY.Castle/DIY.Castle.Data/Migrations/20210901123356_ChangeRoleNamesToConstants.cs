using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIY.Castle.Data.Migrations
{
    public partial class ChangeRoleNamesToConstants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "7ef2a79b-1082-4a82-adbe-6691deb2a6a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f16c2138-d14b-4953-a67c-ad767781f021");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69d4064d-2db2-4f2c-ba1c-6360a847c263", "AQAAAAEAACcQAAAAECeisvy6DxNGNNyQf0S/URyfZjW7PpFhDxotv+eUt0qw6K7YSa0NDadvzNGxdLeDPA==", "01a5292a-c8fd-41b4-9aaf-7cd51959ed1a" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 1, 12, 20, 50, 970, DateTimeKind.Utc).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 1, 12, 20, 50, 970, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 1, 12, 20, 50, 970, DateTimeKind.Utc).AddTicks(3431));
        }
    }
}
