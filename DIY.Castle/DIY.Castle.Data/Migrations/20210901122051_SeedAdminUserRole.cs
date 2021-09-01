using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIY.Castle.Data.Migrations
{
    public partial class SeedAdminUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "f16c2138-d14b-4953-a67c-ad767781f021", "User", "USER" },
                    { "0", "7ef2a79b-1082-4a82-adbe-6691deb2a6a1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-0000-0000-0000-000000000000", 0, "69d4064d-2db2-4f2c-ba1c-6360a847c263", "admin@abv.bg", false, false, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAECeisvy6DxNGNNyQf0S/URyfZjW7PpFhDxotv+eUt0qw6K7YSa0NDadvzNGxdLeDPA==", null, false, "01a5292a-c8fd-41b4-9aaf-7cd51959ed1a", false, "admin@abv.bg" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "00000000-0000-0000-0000-000000000000", "0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000000", "0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 16, 16, 20, 54, 367, DateTimeKind.Utc).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 16, 16, 20, 54, 369, DateTimeKind.Utc).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 16, 16, 20, 54, 369, DateTimeKind.Utc).AddTicks(8894));
        }
    }
}
