using Microsoft.EntityFrameworkCore.Migrations;

namespace DIY.Castle.Data.Migrations
{
    public partial class AddedSubcategoriesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "5b730d6c-89cd-4c46-ab9d-b4e85edfcacd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "47077687-f843-4ff5-a388-14015526a50b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000AFADMIN000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c40df306-b46b-4ae3-aff0-6649b1d5e459", "AQAAAAEAACcQAAAAEJ1z9vmoJwS4bJ3BoJ8mbcHxzE4UDUJe6nvgb4ACVBJIJbNLYDWnnAKgF4MhvRKVrg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "f648ad53-dbaf-43a8-8205-c22e63352246");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a360047c-cd04-403f-b10c-7a97e480368c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000AFADMIN000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9813e2b8-8da5-43e3-aa3c-9115219a5468", "AQAAAAEAACcQAAAAEAYP83xgJ+T8CL94NfGu209BIDlFqP9AAVkoiS11d0RvmIf6DVkepTLj18DVCTAuqw==" });
        }
    }
}
