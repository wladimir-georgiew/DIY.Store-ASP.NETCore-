using Microsoft.EntityFrameworkCore.Migrations;

namespace DIY.Castle.Data.Migrations
{
    public partial class AddedSubcategoriesUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Subcategory_SubcategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "SubcategoryId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "ac94d59a-b292-4363-b20f-455bf168c93c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "14bfadc7-8add-45d6-9628-9471745dc758");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000AFADMIN000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8fe48e68-9a08-4e21-b769-9b394dd35a60", "AQAAAAEAACcQAAAAEDCAp4T0TsIr3OEnaO2NCwp8Wq4HhXoLE69qhKxywzb62SPJ+IBJOgkPUn/zdyHkYw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Subcategory_SubcategoryId",
                table: "Products",
                column: "SubcategoryId",
                principalTable: "Subcategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Subcategory_SubcategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "SubcategoryId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Subcategory_SubcategoryId",
                table: "Products",
                column: "SubcategoryId",
                principalTable: "Subcategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
